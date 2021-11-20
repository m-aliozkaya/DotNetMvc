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
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactManager cm = new ContactManager(new EfContactDal());
        // GET: Message
        public ActionResult Inbox()
        {
            var messageList = mm.GetListInbox();

            ViewBag.sendboxCount = mm.GetListSendbox().Count();
            ViewBag.inboxCount = mm.GetListInbox().Count();
            ViewBag.contactCount = cm.GetList().Count();

            return View(messageList);
        }

        public ActionResult Sendbox()
        {
            var messageList = mm.GetListSendbox();

            ViewBag.sendboxCount = mm.GetListSendbox().Count();
            ViewBag.inboxCount = mm.GetListInbox().Count();
            ViewBag.contactCount = cm.GetList().Count();

            return View(messageList);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            ViewBag.sendboxCount = mm.GetListSendbox().Count();
            ViewBag.inboxCount = mm.GetListInbox().Count();
            ViewBag.contactCount = cm.GetList().Count();

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            return View();
        }
    }
}