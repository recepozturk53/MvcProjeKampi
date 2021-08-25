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
        ImageFileManager ımageFileManager = new ImageFileManager(new EFImageFileDal());
        AboutManager aboutManager = new AboutManager(new EFAboutDal());
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Image()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(categoryManager.GetList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult AboutChart()
        {
            return Json(aboutManager.GetList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult HeadingChart()
        {
            return Json(ımageFileManager.GetList(), JsonRequestBehavior.AllowGet);
        }


    }
}