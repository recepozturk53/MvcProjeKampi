﻿using BusinessLayer.Concrete;
using DataAccess.EntityFramework;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CalendarController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EFHeadingDal());
        // GET: Calendar
        public ActionResult Index()
        {

            return View(new Calendar());
        }
        //https://dotnetfiddle.net/1ganYd
        public JsonResult GetEvents(DateTime start, DateTime end)
        {
            var viewModel = new Calendar();
            var events = new List<Calendar>();
            start = DateTime.Today.AddDays(-14);
            end = DateTime.Today.AddDays(-14);

            foreach (var item in headingManager.GetList())
            {
                events.Add(new Calendar()
                {
                    title = item.HeadingName,
                    start = item.HeadingDate,
                    end = item.HeadingDate.AddDays(-14),
                    allDay = false
                });

                start = start.AddDays(7);
                end = end.AddDays(7);
            }

            return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}