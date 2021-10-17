using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> repository = new GenericRepository<Category>();

        public List<Category> GetAllBL()
        {
            return repository.List();
        }

        public void AddCategoryBL(Category category)
        {
            if (category.Name == "" || category.Name.Length <= 3)
            {
                // Hata mesajı
            } else
            {
                repository.Insert(category);
            }
        }
    }
}
