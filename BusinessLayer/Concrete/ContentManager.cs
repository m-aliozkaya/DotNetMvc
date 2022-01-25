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
    public class ContentManager : IContentService
    {
        public IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void Add(Content content)
        {
            _contentDal.Insert(content);
        }

        public void Delete(Content content)
        {
            _contentDal.Delete(content);
        }

        public Content GetContentById(int id)
        {
            return _contentDal.Get(c => c.Id == id);
        }

        public List<Content> GetList()
        {
            return _contentDal.List();
        }

        public List<Content> GetListByHeading(int id)
        {
            return _contentDal.List(c => c.HeadingId == id);
        }

        public List<Content> GetListByWriter(string email)
        {
            return _contentDal.List(c => c.Writer.Email == email);
        }

        public void Update(Content content)
        {
            _contentDal.Update(content);
        }
    }
}
