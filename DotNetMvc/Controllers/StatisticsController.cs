using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetMvc.Controllers
{
    public class StatisticsController : Controller
    {
        Context context = new Context();
        // GET: Statistics
        public ActionResult Index()
        {
            var categoryCount = context.Categories.Count();
            ViewBag.categoryCount = categoryCount;

            var softwareCategoryCount = context.Headings.Count(h => h.Category.Name == "yazılım");
            ViewBag.categoryYazilimCount = softwareCategoryCount;

            var writersCount = context.Writers.Count(w => w.Name.Contains("a"));
            ViewBag.writersCount = writersCount;

            var maxTitlesCategoryId = context.Headings.Max(x => x.Category.Id);
            var categoryName = context.Categories.Find(maxTitlesCategoryId).Name;
            ViewBag.maxTitlesCategory = categoryName;

            var activeCategories = context.Categories.Count(c => c.Status == true);
            var closeCategories = context.Categories.Count(c => c.Status == false);

            ViewBag.gapActiveDeactiveCategories = Math.Abs(activeCategories - closeCategories);

            return View();
        }
    }
}