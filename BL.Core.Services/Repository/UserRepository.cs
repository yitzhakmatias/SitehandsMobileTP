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
               
                Pass = "123123 Av Str",
                Name = "John",
                Email = "123123-212"
            },
            new User()
            {
                //Id = 2,
                Pass = "33333 Av Str",
                Name = "Peter",
                Email = "666666-2222"
            },
            new User()
            {
               // Id = 1,
                Pass = "9999 Av Str",
                Name = "Sarah",
                Email = "2233-2222"
            }
        };
    }
}
