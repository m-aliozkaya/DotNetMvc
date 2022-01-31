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

            return View(values);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactDetail = cm.GetContactById(id);

            return View(contactDetail);
        }

        public PartialViewResult MessageListMenu()
        {
            var mail = (string)Session["WriterMail"];
            ViewBag.sendboxCount = mm.GetListSendbox(mail).Count;
            ViewBag.inboxCount = mm.GetListInbox(mail).Where(x => x.IsReaded == false).ToList().Count;
            ViewBag.contactCount = cm.GetList().Count;
            ViewBag.draftCount = mm.GetListDraft(mail).Count;

            return PartialView();
        }
    }
}