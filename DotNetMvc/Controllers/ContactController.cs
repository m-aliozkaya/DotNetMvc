﻿using BusinessLayer.Concrete;
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
    }
}