using BusinessLayer.Abstract;
using DataAccess.Abstract;
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

        public void Add(Skill talentCardSkill)
        {
            _skillDal.Insert(talentCardSkill);
        }

        public void Delete(Skill talentCardSkill)
        {
            _skillDal.Delete(talentCardSkill);
        }

        public List<Skill> GetAll()
        {
            return _skillDal.List();
        }

        public Skill GetById(int id)
        {
            return _skillDal.Get(x => x.SkillId == id);
        }

        public void Update(Skill talentCardSkill)
        {
             _skillDal.Update(talentCardSkill);
        }
    }
}
