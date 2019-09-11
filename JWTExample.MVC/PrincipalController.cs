using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace JWTExample.MVC
{
    public class PrincipalController : Controller
    {
        public new ApplicationUser User => Session["User"] as ApplicationUser;
    }
}