using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IMessageService
    {
        List<Message> GetListInbox(string parameter);
        List<Message> GetListSendbox(string parameter);
        List<Message> GetAllUnRead(string parameter);
        List<Message> GetAllDraft(string parameter);
        List<Message> GetAllDeleted(string parameter);
        List<Message> GetAllRead(string parameter);
        List<Message> IsDraft();
        void MessageAddBL(Message message);
        Message GetByID(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
    }
}
