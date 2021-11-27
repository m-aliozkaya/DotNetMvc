using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SkillManager : ISkillService
    {
        ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public void Add(Skill skill)
        {
            _skillDal.Insert(skill);
        }

        public void Delete(Skill skill)
        {
            _skillDal.Delete(skill);
        }

        public Skill GetSkillById(int id)
        {
            return _skillDal.Get(x => x.Id == id);
        }

        public List<Skill> GetSkills()
        {
            return _skillDal.List();
        }

        public void Update(Skill skill)
        {
            _skillDal.Update(skill);
        }
    }
}
