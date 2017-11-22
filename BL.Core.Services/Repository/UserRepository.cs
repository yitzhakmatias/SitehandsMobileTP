using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Core.Services.Model;

namespace BL.Core.Services.Repository
{
    public class UserRepository
    {
        public List<User> GetWebUsers()
        {
           // var service = new EmployeeWebService();
            return Users;
        }
        private static readonly List<User> Users = new List<User>()
        {
            new User
            {
               
                Pass = "admin",
                Name = "john",
                Email = "john@abc.com"
            },
            new User()
            {
                //Id = 2,
                Pass = "admin",
                Name = "peter",
                Email = "peter@abc.com"
            },
            new User()
            {
               // Id = 1,
                Pass = "admin",
                Name = "sarah",
                Email = "sarah@abc.com"
            },
            new User()
            {
                //Id = 2,
                Pass = "admin",
                Name = "admin",
                Email = "admin@abc.com"
            },
        };
    }
}
