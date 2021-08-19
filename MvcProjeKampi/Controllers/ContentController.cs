using BusinessLayer.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {

        // GET: Content 

        ContentManager cm = new ContentManager(new EFContentDal());
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult GetAllContent(string p)
        {

            var values = cm.GetList(p);
            if (string.IsNullOrEmpty(p))
            {
                values = cm.GetList();
            }
            //var values = c.Contents.ToList();
            return View(values.ToList());
        }


        public ActionResult ContentByHeading(int id)
        {   
            var contentvalues = cm.GetListByHeadingID(id);
            return View(contentvalues);
        }
    }
}