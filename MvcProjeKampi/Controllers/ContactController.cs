using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccess.EntityFramework;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [Authorize(Roles ="B")]
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EFContactcDal());
        MessageManager mm = new MessageManager(new EFMessageDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetByID(id);
          return View(contactvalues);
        }

        public PartialViewResult GetSideList()
        {
            string parameter = (string)Session["AdminUserName"];
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