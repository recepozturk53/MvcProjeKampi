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
   public class PersonalManager : IPersonalService
    {
        IPersonalDal _personalDal;

        public PersonalManager(IPersonalDal personalDal)
        {
            _personalDal = personalDal;
        }

        public void Add(Personal p)
        {
            _personalDal.Insert(p);

        }
        public void Delete(Personal p)
        {
            _personalDal.Delete(p);
        }

        public Personal GetByID(int id)
        {

            return _personalDal.Get(x => x.PersonalID == id);
        }

        public List<Personal> GetList()
        {
            return _personalDal.List();
        }

        public void Update(Personal p)
        {
            _personalDal.Update(p);
        }
    }
}
