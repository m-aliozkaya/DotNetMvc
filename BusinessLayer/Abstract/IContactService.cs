using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();

        void Add(Contact contact);

        void Update(Contact contact);

        void Delete(Contact contact);
        Contact GetContactById(int id);
    }
}
