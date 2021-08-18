using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccess.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager mm = new MessageManager(new EFMessageDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        MessageValidator messagevalidator = new MessageValidator();

        public ActionResult Inbox()
        {
            string parameter = (string)Session["WriterMail"];
            var messagelist = mm.GetListInbox(parameter);
            return View(messagelist);
        }

        public ActionResult Sendbox()
        {
            string parameter = (string)Session["WriterMail"];
            var messagelist = mm.GetListSendbox(parameter);
            return View(messagelist);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var messagevalues = mm.GetByID(id);
            return View(messagevalues);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var messagevalues = mm.GetByID(id);
            return View(messagevalues);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {

            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p, string parameter)
        {


            ValidationResult results = messagevalidator.Validate(p);
            string adminValue = (string)Session["WriterMail"];
            if (parameter == "send")
            {
                if (results.IsValid)
                {
                    p.SenderMail = adminValue;
                    p.Draft = false;
                    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mm.MessageAddBL(p);
                    Thread.Sleep(1500);
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (parameter == "draft")
            {
                if (results.IsValid)
                {
                    p.SenderMail = adminValue;
                    p.Draft = true;
                    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mm.MessageAddBL(p);
                    Thread.Sleep(1500);
                    return RedirectToAction("Draft");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }

            return View();
        }


        public PartialViewResult MessageListMenu()
        {
            string parameter = (string)Session["WriterMail"];
            var contactValues = cm.GetList();
            var messageInValues = mm.GetListInbox(parameter);
            var messageSendValues = mm.GetListSendbox(parameter);
            ContactPartialModel contactPartialModel = new ContactPartialModel
            {
                InBoxAmount = messageInValues.Count(),
                SendBoxAmount = messageSendValues.Count(),
                ContactAmount = contactValues.Count(),
                ReadAmount = mm.GetAllRead(parameter).Count(),
                UnReadAmount = mm.GetAllUnRead(parameter).Count(),
                DraftAmount = mm.GetAllDraft(parameter).Where(x => x.Draft == true).Count(),
                DeletedAmount = mm.GetAllDeleted(parameter).Count(),

            };

            return PartialView(contactPartialModel);

            
        }
    }
}