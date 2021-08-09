using BusinessLayer.Concrete;
using DataAccess.EntityFramework;
using EntityLayer.Concrete;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik

        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        WriterManager wm = new WriterManager(new EFWriterDal());

        public ActionResult Index()
        {
            IstatistikModel model = new IstatistikModel();
            model.CategoryCount = cm.GetList().Count;

            List<Heading> filteredHeadings = new List<Heading>();
            filteredHeadings = hm.GetList();
            filteredHeadings = hm.GetFilteredList(filteredHeadings);
            model.SwareHeadCount=filteredHeadings.Count;

            List<Writer> filteredWriters = new List<Writer>();
            filteredWriters = wm.GetList();
            filteredWriters = wm.GetFilteredList(filteredWriters);
            model.WriterCount = filteredWriters.Count;


            List<Heading> filteredHeadings2 = new List<Heading>();
            filteredHeadings2 = hm.GetList();
            int mostrepated = filteredHeadings2.GroupBy(i => i.CategoryID).OrderByDescending(g => g.Count()).Select(h=>h.Key).FirstOrDefault();
            model.MostHeadingCat = cm.GetByID(mostrepated).CategoryName;
            




            List<Category> filteredCategories = new List<Category>();
            filteredCategories = cm.GetList();
            int sum = filteredCategories.Count;
            filteredCategories = cm.GetFilteredList(filteredCategories);
            model.DifBtwnTF = Math.Abs(filteredCategories.Count - (sum - filteredCategories.Count));




            return View(model);
        }

       
        







    }
}