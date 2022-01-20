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

        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading(int id = 4)
        {
            var headings = hm.GetListByWriter(id);
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
            heading.WriterId = 4;
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