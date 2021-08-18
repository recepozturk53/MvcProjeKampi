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
    public class LoginManager : ILoginService
    {
        ILoginDal _loginDal;
        IWriterDal _writerDal;

        public LoginManager(ILoginDal loginDal, IWriterDal writerDal)
        {
            _loginDal = loginDal;
            _writerDal = writerDal;
        }

        public Admin Auth(string username, string password)
        {
            return _loginDal.Get(x => x.AdminUserName == username && x.AdminPassword == password);
        }

        public Writer GetWriter(string username, string password)
        {
            return _writerDal.Get(x => x.WriterMail == username && x.WriterPassword == password);
        }
    }
}
