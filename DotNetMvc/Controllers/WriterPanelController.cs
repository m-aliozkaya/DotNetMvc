using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
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
            var writerMail = (string)Session["WriterMail"];
            var writer = wm.GetWriterByMail(writerMail);
            return View(writer);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult result = validationRules.Validate(writer);

            if (result.IsValid)
            {
                wm.UpdateWriter(writer);
                return RedirectToAction("AllHeadings");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View(writer);
        }

        public ActionResult MyHeading()
        {
            var writerMail = (string)Session["WriterMail"];
            var headings = hm.GetListByWriter(writerMail);
            return View(headings);
        }


        public ActionResult AllHeadings(int p = 1)
        {
            var headings = hm.GetList().ToPagedList(p, 2);
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