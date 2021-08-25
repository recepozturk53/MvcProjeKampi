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
        List<Skill> GetAll();
        Skill GetById(int id);
        void Add(Skill talentCardSkill);
        void Update(Skill talentCardSkill);
        void Delete(Skill talentCardSkill);
    }
}
