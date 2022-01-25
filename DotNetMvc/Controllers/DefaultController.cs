using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetMvc.Controllers
{
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());

        public ActionResult Headings()
        {
            var headingList = hm.GetList();
            return View(headingList);
        }

        // GET: Default
        public PartialViewResult Index(int id = 0)
        {
            var contentList = cm.GetListByHeading(id);
            return PartialView(contentList);
        }
    }
}