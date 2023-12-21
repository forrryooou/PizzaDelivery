using lab8.Entities;
using lab8.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8.Services
{
    public class UserService
    {
        private IDBRepos context;
        public UserService(IDBRepos repos)
        {
            context = repos;
        }

        public bool Authenticate(string username, string password)
        {
            var user = context.Users.GetList().Where(u => u.Password == password && u.UserName == username).FirstOrDefault();
            if (user != null) return true;
            return false;
        }

        public void Registration (Client client)
        {

        }
    }
}
