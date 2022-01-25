using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetMvc.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());

        // GET: WriterPanelContent
        public ActionResult MyContent()
        {
            var writerMail = (string) Session["WriterMail"];
            var contents = cm.GetListByWriter(writerMail);
            return View(contents);
        }
    }
}