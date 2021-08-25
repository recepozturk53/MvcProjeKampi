using BusinessLayer.Concrete;
using DataAccess.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager ifm = new ImageFileManager(new EFImageFileDal());
        public ActionResult Index()
        {
            var files = ifm.GetList();
            return View(files);
        }
        [HttpGet]
        public ActionResult AddImage()
        {
            return View();
        }
      
        [HttpPost]
        public ActionResult AddImage(ImageFile ımageFile)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                //string expansion = Path.GetExtension(Request.Files[0].FileName);
                string path = "/AdminLTE-3.0.4/Images/" + fileName;
                Request.Files[0].SaveAs(Server.MapPath(path));
                ımageFile.ImagePath = path;
                ifm.Add(ımageFile);
                Thread.Sleep(1500);
                return RedirectToAction("Index");

            }
            return View();
        }
    }

}