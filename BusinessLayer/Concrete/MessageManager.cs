using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {

        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message message)
        {
            _messageDal.Insert(message);
        }

        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(m => m.Id == id);
        }

        public List<Message> GetListInbox(string mail)
        {
            return _messageDal.List(m => m.ReceiverMail == mail && m.Status == true);
        }

        public List<Message> GetListSendbox(string mail)
        {
            return _messageDal.List(m => m.SenderMail == mail && m.Status == true);
        }

        public List<Message> GetListDraft(string mail)
        {
            return _messageDal.List(m => m.SenderMail == mail && m.Status == false);
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
