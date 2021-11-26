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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        // Dependecy Injection
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public string GetRoleForUser(string userName)
        {
            return _adminDal.Get(x => x.UserName == userName).Role;
        }

        public Admin GetUser(Admin admin)
        {
            return _adminDal.Get(x => x.UserName == admin.UserName && x.Password == admin.Password);   
        }
    }
}
