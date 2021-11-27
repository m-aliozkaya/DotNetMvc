using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            string hashedUserName = ComputeSha256Hash(userName);
            return _adminDal.Get(x => x.UserName == hashedUserName).Role;
        }

        public Admin GetUser(Admin admin)
        {
            string userName = ComputeSha256Hash(admin.UserName);
            string password = ComputeSha256Hash(admin.Password);

            return _adminDal.Get(x => x.UserName == userName && x.Password == password);
        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
