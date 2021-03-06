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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void AddWriter(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void DeleteWriter(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        public Writer GetWriter(Writer writer) => _writerDal.Get(x => x.Email == writer.Email && x.Password == writer.Password);

        public Writer GetWriterById(int id) => _writerDal.Get(w => w.Id == id);
        public Writer GetWriterByMail(string mail) => _writerDal.Get(w => w.Email == mail);

        public void UpdateWriter(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
