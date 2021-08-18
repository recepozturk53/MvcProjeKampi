using BusinessLayer.Concrete;
using DataAccess.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EFAboutDal());
        // GET: About
        public ActionResult Index()
        {
            var aboutvalues = abm.GetList();
            return View(aboutvalues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            abm.AboutAddBL(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        public ActionResult DeleteAbout(int id)
        {
            var headingValue = abm.GetByID(id);
            if (headingValue.AboutStatus == true)
            {
                headingValue.AboutStatus = false;
            }

            else
            {
                headingValue.AboutStatus = true;
            }
            abm.AboutDelete(headingValue);
            return RedirectToAction("Index");
        }
    }
}