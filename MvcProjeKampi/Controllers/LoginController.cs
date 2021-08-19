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
using System.Net;
using Newtonsoft.Json;
using MvcProjeKampi.Models;
using System.Security.Cryptography;
using System.Text;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

       
        LoginManager loginManager = new LoginManager(new EFLoginDal(),new EFWriterDal());

        RegisterValidator rv = new RegisterValidator();

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            ValidationResult results = rv.Validate(p);
            var adminuserinfo = loginManager.Auth(p.AdminUserName, p.AdminPassword);
            if (results.IsValid)
            {
                if (adminuserinfo != null)
                {
                    FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                    Session["AdminUsername"] = adminuserinfo.AdminUserName;
                    return RedirectToAction("Sendbox", "Message");

                }
                else
                {
                    ModelState.AddModelError(nameof(Admin.AdminUserName), "Eposta bulunamadı veya eşleşmiyor");
                    ModelState.AddModelError(nameof(Admin.AdminPassword), "Parola bulunamadı veya eşleşmiyor");
                    return View(adminuserinfo);

                }
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
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
            var response = Request["g-recaptcha-response"];
            const string secret = "6LeIxAcTAAAAAGG-vFI1TnRWxMZNFuojJ4WifJWe";
            var client = new WebClient();

            var reply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

            if (!captchaResponse.Success)
            {
                TempData["Message"] = "Lütfen güvenliği doğrulayınız.";
                return View();
            }
            if (writeruserinfo !=null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                ViewBag.ErrorMessage = "Kullanıcı Adı veya Şifreniz Yanlış!";
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