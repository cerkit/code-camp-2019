using System.Web.Mvc;

namespace JWTExample.MVC
{
    public class PrincipalController : Controller
    {
        public new ApplicationUser User => Session["User"] as ApplicationUser;
    }
}