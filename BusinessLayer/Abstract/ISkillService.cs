using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISkillService
    {
        List<Skill> GetSkills();

        void Add(Skill skill);

        void Update(Skill skill);

        void Delete(int id);
        Skill GetSkillById(int id);
    }
}
