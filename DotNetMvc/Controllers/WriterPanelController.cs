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
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading()
        {
            var writerMail = (string)Session["WriterMail"];
            var headings = hm.GetListByWriter(writerMail);
            return View(headings);
        }


        public ActionResult AllHeadings()
        {
            var headings = hm.GetList();
            return View(headings);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            ViewBag.CategoryId = new SelectList(cm.GetList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var writerMail = (string)Session["WriterMail"];
            var writerId = wm.GetWriterByMail(writerMail).Id;
            heading.WriterId = writerId;
            heading.Status = true;
            hm.Add(heading);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            ViewBag.CategoryId = new SelectList(cm.GetList(), "Id", "Name");
            var heading = hm.GetHeadingById(id);
            return View(heading);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            hm.Update(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var heading = hm.GetHeadingById(id);
            heading.Status = false;
            hm.Update(heading);
            return RedirectToAction("MyHeading");
        }
    }
}