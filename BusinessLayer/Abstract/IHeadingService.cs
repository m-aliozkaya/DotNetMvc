using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetListByWriter(string mail);

        void Add(Heading heading);

        void Update(Heading heading);

        void Delete(Heading heading);

        Heading GetHeadingById(int id);
    }
}
