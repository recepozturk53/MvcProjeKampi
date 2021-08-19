using BusinessLayer.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(categoryManager.GetList(), JsonRequestBehavior.AllowGet);
        }
    }
}