using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web.Mvc;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JWTExample.Common.Models;
using System.Net.Http.Headers;

namespace JWTExample.MVC.Controllers
{
    public class HomeController : PrincipalController
    {
        public async Task<ActionResult> Index()
        {
            var jwtToken = new JwtSecurityToken(Session["Token"].ToString());
            ViewBag.Claims = jwtToken.Claims.Select(c => $"{c.Type} = {c.Value?.ToString()}");
            ViewBag.UserClaims = User.Claims;
            ViewBag.User = User;

            // Get a customer record from the WebApi
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49823/");
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["Token"].ToString());
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Session["Token"].ToString());
            var result = await client.GetAsync("api/Customer/5432");
            var customerJson = await result.Content.ReadAsStringAsync();
            var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

            ViewBag.Customer = customer;


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}