using Foundation;
using System;
using System.Linq;
using BL.Core.Services.Repository;
using UIKit;

namespace XamarinTrainingProject
{
    public partial class LoginController : UIViewController
    {
        readonly UserRepository _userRepository = new UserRepository();

        public LoginController(IntPtr handle) : base(handle)
        {
        }

        public event EventHandler OnLoginSuccess;

        partial void LoginButton_TouchUpInside(UIButton sender)
        {
            //Validate our Username & Password.
            //This is usually a web service call.
            if (IsUserNameValid() && IsPasswordValid())
            {
                //We have successfully authenticated a the user,
                //Now fire our OnLoginSuccess Event.
                if (OnLoginSuccess != null)
                {
                    OnLoginSuccess(sender, new EventArgs());
                }
            }
            else
            {
                new UIAlertView("Login Error", "Bad user name or password", null, "OK", null).Show();
            }
        }
        private bool IsUserNameValid()
        {
            if (String.IsNullOrEmpty(UserNameTextView.Text.Trim())) return false;
            var user = _userRepository.GetWebUsers().FirstOrDefault(p => p.Name.Contains(UserNameTextView.Text.Trim()));
            return user!=null;
        }

        private bool IsPasswordValid()
        {
            if (String.IsNullOrEmpty(PasswordTextView.Text.Trim())) return false;
            var pass = _userRepository.GetWebUsers().FirstOrDefault(p => p.Pass.Contains(PasswordTextView.Text.Trim()));
            return pass != null;
            
        }
    }
}