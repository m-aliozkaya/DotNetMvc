using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DotNetMvc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            Context context = new Context();
            var user = context.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(admin.UserName, false);
                Session["userName"] = admin.UserName;
                return Redirect(Request.Form["ReturnUrl"]);
            } else
            {
                return Redirect(Request.UrlReferrer.AbsoluteUri);
            }
        }
    }
}