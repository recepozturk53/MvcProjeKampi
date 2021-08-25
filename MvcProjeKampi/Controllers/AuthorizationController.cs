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
    public class AuthorizationController : Controller
    {
        // GET: Authorization


        AdminManager adminManager = new AdminManager(new EFAdminDal());
        RegisterValidator rv = new RegisterValidator();
        public ActionResult Index()
        {
            var adminValues = adminManager.GetAll();
            return View(adminValues);
        }

        [HttpGet]
        public ActionResult AdminAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminAdd(Admin admin)
        {
            ValidationResult results = rv.Validate(admin);
            if (results.IsValid)
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                string password = admin.AdminPassword;
                string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
                admin.AdminPassword = result;
                admin.AdminRole = "B";
                adminManager.Add(admin);
                return RedirectToAction("Index");
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
        public ActionResult AdminUpdate(int id)
        {
            #region ViewBag
            List<SelectListItem> mySkills = new List<SelectListItem>() {
        new SelectListItem {
            Text = "A", Value = "A"
        },
        new SelectListItem {
            Text = "B", Value = "B"
        },
        new SelectListItem {
            Text = "C", Value = "C"
        },
        
    };
            ViewBag.MySkills = mySkills;
            #endregion
            var adminValue = adminManager.GetById(id);
            return View(adminValue);
        }

        [HttpPost]
        public ActionResult AdminUpdate(Admin admin)
        {
            
            adminManager.Update(admin);
            return RedirectToAction("Index");
        }

        public ActionResult AdminDelete(int id)
        {
            var adminValue = adminManager.GetById(id);
            adminManager.Delete(adminValue);
            return RedirectToAction("Index");
        }

        public PartialViewResult AdminPartial()
        {
            return PartialView();
        }
    }
}