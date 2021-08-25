using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccess.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator messagevalidator = new MessageValidator();

        public ActionResult Inbox(string p = "")
        {
            string parameter = (string)Session["AdminUserName"];
            var messagelist = mm.GetListInbox(parameter, p);
            if (string.IsNullOrEmpty(p))
            {
                messagelist = mm.GetListInbox(parameter);
            }


            return View(messagelist);
        }


        public ActionResult Sendbox()
        {
            string parameter = (string)Session["AdminUserName"];
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
            string adminValue = (string)Session["AdminUserName"];
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
        public ActionResult Draft()
        {
            string parameter = (string)Session["AdminUserName"];
            var result = mm.GetAllDraft(parameter).Where(x => x.Draft == true).ToList();
            return View(result);
        }

        public ActionResult Delete()
        {
            string parameter = (string)Session["AdminUserName"];
            var result = mm.GetAllDeleted(parameter);
            return View(result);
        }


        public ActionResult IsDeleted(int id)
        {
            var result = mm.GetByID(id);
            if (result.Status == false)
            {
                result.Status = true;
            }
            mm.MessageUpdate(result);
            return RedirectToAction("Delete");
        }

        public ActionResult IsRead(int id)
        {
            var result = mm.GetByID(id);
            result.IsRead = !result.IsRead;
            mm.MessageUpdate(result);
            if (result.IsRead)
            {
                return RedirectToAction("ReadMessage");
            }
            else
            {
                return RedirectToAction("UnReadMessage");
            }
        }

        public ActionResult ReadMessage()
        {
            string parameter = (string)Session["AdminUserName"];
            var readMessage = mm.GetAllRead(parameter).Where(x => x.IsRead == true).ToList();
            return View(readMessage);
        }

        public ActionResult UnReadMessage()
        {
            string parameter = (string)Session["AdminUserName"];
            var unReadMessage = mm.GetAllUnRead(parameter);
            return View(unReadMessage);
        }
    }
}