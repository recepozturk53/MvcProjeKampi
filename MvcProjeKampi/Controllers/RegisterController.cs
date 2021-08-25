using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccess.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        AdminManager adm = new AdminManager(new EFAdminDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        RegisterValidator rv = new RegisterValidator();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            ValidationResult results = rv.Validate(admin);
            if (results.IsValid)
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                string password = admin.AdminPassword;
                string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
                admin.AdminPassword = result;
                admin.AdminRole = "B";
                adm.Add(admin);
                return RedirectToAction("Index", "Login");
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
        public ActionResult WriterRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterRegister(Writer writer)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string password = writer.WriterPassword;
            string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            writer.WriterPassword = result;
            writer.WriterStatus = true;
            writer.WriterRole = "B";
            wm.WriterAddBL(writer);
            return RedirectToAction("WriterLogin", "Login");
        }

        public ActionResult Hash(string data = null)
        {
            if (data != null)
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(data)));
                ViewBag.SHA1 = result;
                ViewBag.MD5 = result;
                ViewBag.Hash = true;
            }
            return View();
        }

    }
}