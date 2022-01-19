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
    public class SkillController : Controller
    {
        SkillManager sm = new SkillManager(new EfSkillDal());
        // GET: Skill
        public ActionResult Index()
        {
            var skills = sm.GetSkills();
            return View(skills);
        }

        public ActionResult Edit()
        {
            var skills = sm.GetSkills();
            return View(skills);
        }

        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddSkill(Skill skill)
        {
            sm.Add(skill);
            return RedirectToAction("Edit");
        }

        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var skill = sm.GetSkillById(id);
            return View(skill);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UpdateSkill(Skill skill)
        {
            sm.Update(skill);
            return RedirectToAction("Edit");
        }

        public ActionResult DeleteSkill(int id)
        {
            sm.Delete(id);
            return RedirectToAction("Edit");
        }
    }
}