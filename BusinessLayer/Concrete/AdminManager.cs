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
    public class AdminManager : IAdminService
    {
        private IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        
        public List<Admin> GetAll()
        {
            return _adminDal.List();
        }

        public Admin GetById(int id)
        {
            return _adminDal.Get(x => x.AdminID == id);
        }

        public void Add(Admin admin)
        {
            CheckIfAdminExists(admin);
            _adminDal.Insert(admin);
        }

        public void Update(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public void Delete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public Admin GetAdmin(string mail, string password)
        {
            return _adminDal.Get(x => x.AdminUserName == mail && x.AdminPassword == password);
        }

        private void CheckIfAdminExists(Admin admin)
        {
            if (_adminDal.Get(x => x.AdminUserName == admin.AdminUserName) != null)
            {
                throw new Exception("Bu kullanıcı daha önce kayıt olmuştur.");
            }
        }
    }
}
