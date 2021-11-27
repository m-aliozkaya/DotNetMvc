using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
        AdminManager manager = new AdminManager(new EfAdminDal());

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var user = manager.GetUser(admin);
       

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