using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
        WriterManager wm = new WriterManager(new EfWriterDal());

        // GET: WriterPanelContent
        public ActionResult MyContent()
        {
            var writerMail = (string) Session["WriterMail"];
            var contents = cm.GetListByWriter(writerMail);
            return View(contents);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.HeadingId = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            var mail = (string) Session["WriterMail"];
            var writerId = wm.GetWriterByMail(mail).Id;
            content.ContentDate =  DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterId = writerId;
            cm.Add(content);
            return RedirectToAction("MyContent");
        }

    }
}