using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IAdminService
    {
        List<Admin> GetAll();
        Admin GetById(int id);
        Admin GetAdmin(string mail, string password);
        void Add(Admin admin);
        void Update(Admin admin);
        void Delete(Admin admin);
    }
}
