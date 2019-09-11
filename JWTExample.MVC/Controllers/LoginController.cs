using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JWTExample.MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(LoginModel loginModel)
        {
            var loginJson = JsonConvert.SerializeObject(loginModel);
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63274/");
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var result = await client.PostAsync("api/Token", new StringContent(loginJson, Encoding.UTF8, "application/json"));
                var tokenJson = await result.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<TokenModel>(tokenJson);
                Session["Token"] = token.Token;
                var jwtToken = new JwtSecurityToken(token.Token);
                var user = new ApplicationUser(jwtToken.Claims);
                Session["User"] = user;
            }
            return RedirectToAction("Index", "Home");

        }

        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class TokenModel
        {
            [JsonProperty(PropertyName = "token")]
            public string Token { get; set; }
        }
    }
}