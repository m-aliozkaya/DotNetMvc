using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IImageFileService
    {
        List<ImageFile> GetList();

        void Add(ImageFile imageFile);

        void Update(ImageFile imageFile);

        void Delete(ImageFile imageFile);

        ImageFile GetAboutById(int id);
    }
}
