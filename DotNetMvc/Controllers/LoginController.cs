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
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AdminManager manager = new AdminManager(new EfAdminDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

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

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            var user = writerManager.GetWriter(writer);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(writer.Email, false);
                Session["WriterMail"] = writer.Email;

                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return Redirect(Request.UrlReferrer.AbsoluteUri);
            }
        }

    }
}