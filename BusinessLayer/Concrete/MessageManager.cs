﻿using BusinessLayer.Abstract;
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

        public List<Message> GetListInbox()
        {
            return _messageDal.List(m => m.ReceiverMail == "admin@gmail.com" && m.Status == true);
        }

        public List<Message> GetListSendbox()
        {
            return _messageDal.List(m => m.SenderMail == "admin@gmail.com" && m.Status == true);
        }

        public List<Message> GetListDraft()
        {
            return _messageDal.List(m => m.SenderMail == "admin@gmail.com" && m.Status == false);
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
