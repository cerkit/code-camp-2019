using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JWTExample.MVC.Controllers
{
    public class HomeController : PrincipalController
    {
        public ActionResult Index()
        {
            var jwtToken = new JwtSecurityToken(Session["Token"].ToString());
            ViewBag.Claims = jwtToken.Claims.Select(c => $"{c.Type} = {c.Value?.ToString()}");
            ViewBag.UserClaims = User.Claims;
            ViewBag.User = User;
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