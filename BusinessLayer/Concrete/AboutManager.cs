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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutdal;

        public AboutManager(IAboutDal aboutdal)
        {
            _aboutdal = aboutdal;
        }

        public void AboutAddBL(About about)
        {
            _aboutdal.Insert(about);
        }

        public void AboutDelete(About about)
        {
            _aboutdal.Update(about);
        }

        public void AboutUpdate(About about)
        {
            _aboutdal.Update(about);
        }

        public About GetByID(int id)
        {
            return _aboutdal.Get(x => x.AboutId == id);
        }

        public List<About> GetList()
        {
           return _aboutdal.List();
        }
    }
}
