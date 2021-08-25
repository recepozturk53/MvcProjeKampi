using BusinessLayer.Concrete;
using DataAccess.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class PersonalController : Controller
    {
        PersonalManager pm = new PersonalManager(new EFPersonalDal());
        // GET: Personal
        public ActionResult Index()
        {
            var personalValues = pm.GetList();
            return View(personalValues);
        }

        [HttpGet]
        public ActionResult AddCard()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCard(Personal personal)
        {
            pm.Add(personal);
            Thread.Sleep(1500);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCard(int id)
        {
            var cardValues = pm.GetByID(id);
            return View(cardValues);
        }

        [HttpPost]
        public ActionResult UpdateCard(Personal personal)
        {
            pm.Update(personal);
            return RedirectToAction("Index");
        }
    }
}