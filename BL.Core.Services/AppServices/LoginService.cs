using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Core.Services.Model;
using BL.Core.Services.Repository;

namespace BL.Core.Services.AppServices
{
    public class LoginService
    {
        private readonly string _email;
        private readonly string _pass;
        readonly UserRepository _userRepository = new UserRepository();

        public LoginService(string user, string pass)
        {
            _email = user;
            _pass = pass;
        }
        public User ValidateUserPass()
        {
            if (String.IsNullOrEmpty(_email)) return null;
            var userRepo = _userRepository.GetWebUsers().FirstOrDefault(p => p.Email.Contains(_email));
            if (userRepo == null) return null;
            {
                if (String.IsNullOrEmpty(_pass)) return null;
                var passRepo = _userRepository.GetWebUsers().FirstOrDefault(p => p.Pass.Contains(_pass));
                if(passRepo != null) return userRepo;
            }
            return null;
        }

    }
}
