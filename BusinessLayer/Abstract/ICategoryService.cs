using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();

        void Add(Category category);

        void Update(Category category);

        void Delete(Category category);

        Category GetCategoryById(int id);
    }
}
