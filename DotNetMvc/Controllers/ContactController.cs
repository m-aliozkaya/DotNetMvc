using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetMvc.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();
        // GET: Contact
        public ActionResult Index()
        {
            var values = cm.GetList();

            ViewBag.sendboxCount = mm.GetListSendbox().Count();
            ViewBag.inboxCount = mm.GetListInbox().Count();
            ViewBag.contactCount = cm.GetList().Count();

            return View(values);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactDetail = cm.GetContactById(id);

            ViewBag.sendboxCount = mm.GetListSendbox().Count();
            ViewBag.inboxCount = mm.GetListInbox().Count();
            ViewBag.contactCount = cm.GetList().Count();

            return View(contactDetail);
        }
    }
}