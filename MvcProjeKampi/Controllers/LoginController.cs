using BusinessLayer.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PagedList;
using PagedList.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

       
        LoginManager loginManager = new LoginManager(new EFLoginDal(),new EFWriterDal());


        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {

            var adminuserinfo = loginManager.Auth(p.AdminUserName, p.AdminPassword);
            if (adminuserinfo!=null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                Session["AdminUsername"] = adminuserinfo.AdminUserName;
                return RedirectToAction("Sendbox","Message");

            }
            else
            {
                ModelState.AddModelError(nameof(Admin.AdminUserName), "Eposta bulunamadı veya eşleşmiyor");
                ModelState.AddModelError(nameof(Admin.AdminPassword), "Parola bulunamadı veya eşleşmiyor");
                return View(adminuserinfo);
                
            }
            return View();
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            
            var writeruserinfo = loginManager.GetWriter(p.WriterMail,p.WriterPassword);
            if (writeruserinfo !=null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }

    }
}