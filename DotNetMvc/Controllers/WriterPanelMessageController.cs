using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Web.Mvc;

namespace DotNetMvc.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator validator = new MessageValidator();
        // GET: WriterPanelMessage

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inbox()
        {
            var messageList = mm.GetListInbox();

            return View(messageList);
        }

        public ActionResult Sendbox()
        {
            var messageList = mm.GetListSendbox();

            return View(messageList);
        }

        public ActionResult GetMessageDetails(int id)
        {
            var message = mm.GetById(id);
            message.IsReaded = true;
            mm.Update(message);
            return View(message);
        }

        public ActionResult Draft()
        {
            var messageList = mm.GetListDraft();

            return View(messageList);
        }

        public PartialViewResult MessageListMenu() => PartialView();

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Message message)
        {
            message.Date = DateTime.Now;
            message.Status = true;

            var result = validator.Validate(message);

            if (result.IsValid)
            {
                mm.Add(message);
                return RedirectToAction("Sendbox");
            }


            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View(message);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Draft(Message message)
        {
            message.Date = DateTime.Now;
            message.Status = false;

            var result = validator.Validate(message);

            if (result.IsValid)
            {
                mm.Add(message);
                return RedirectToAction("Sendbox");
            }


            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View(message);
        }
    }
}