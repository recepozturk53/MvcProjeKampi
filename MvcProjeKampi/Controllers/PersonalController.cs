using BusinessLayer.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}