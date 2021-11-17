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
        List<Message> GetList();

        void Add(Message message);

        void Update(Message message);

        void Delete(Message message);

        Message GetCategoryById(int id);
    }
}
