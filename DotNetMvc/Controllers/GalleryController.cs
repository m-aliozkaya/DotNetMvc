using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetMvc.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager fm = new ImageFileManager(new EfImageFileDal());
        // GET: Gallery
        public ActionResult Index()
        {
            var images = fm.GetList();
            return View(images);
        }
    }
}