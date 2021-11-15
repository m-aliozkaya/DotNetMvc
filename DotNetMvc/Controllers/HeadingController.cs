using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetMvc.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        // GET: Heading
        public ActionResult Index()
        {
            var headings = hm.GetList();
            return View(headings);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            ViewBag.CategoryId = new SelectList(cm.GetList(), "Id", "Name");
            ViewBag.WriterId = new SelectList(wm.GetList(), "Id", "Name");
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            ViewBag.CategoryId = new SelectList(cm.GetList(), "Id", "Name");
            ViewBag.WriterId = new SelectList(wm.GetList(), "Id", "Name");

            HeadingValidator validator = new HeadingValidator();
            ValidationResult result = validator.Validate(heading);

            if (result.IsValid)
            {

                hm.Add(heading);
                return RedirectToAction("Index");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View(heading);
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            ViewBag.CategoryId = new SelectList(cm.GetList(), "Id", "Name");
            ViewBag.WriterId = new SelectList(wm.GetList(), "Id", "Name");

            var heading = hm.GetHeadingById(id);
            return View(heading);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            ViewBag.CategoryId = new SelectList(cm.GetList(), "Id", "Name");
            ViewBag.WriterId = new SelectList(wm.GetList(), "Id", "Name");

            HeadingValidator validator = new HeadingValidator();
            ValidationResult result = validator.Validate(heading);

            if (result.IsValid)
            {

                hm.Update(heading);
                return RedirectToAction("Index");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View(heading);
        }

        public ActionResult DeleteHeading(int id)
        {
            var heading = hm.GetHeadingById(id);
            hm.Delete(heading);
            return RedirectToAction("Index");
        }
    }
}