using System;
using BL.Core.Services.AppServices;
using Foundation;
using UIKit;

namespace XamarinTrainingProject
{
    public partial class LoginController : UIViewController
    {
        public LoginController(IntPtr handle) : base(handle)
        {
        }

        public event EventHandler OnLoginSuccess;

        partial void LoginButton_TouchUpInside(UIButton sender)
        {
            var login = new LoginService(UserNameTextView.Text.Trim(), PasswordTextView.Text.Trim());
            //Validate our Username & Password.
            //This is usually a web service call.
            var user = login.ValidateUserPass();
            if (user != null)
            {
                //We have successfully authenticated a the user,
                //Now fire our OnLoginSuccess Event.
                if (OnLoginSuccess != null)
                {
                    // Get Shared User Defaults
                    var plist = NSUserDefaults.StandardUserDefaults;

                    plist.SetString(user.Email, "email");

                    // Get value
                    var useHeader = plist.StringForKey("email");

                    OnLoginSuccess(sender, new EventArgs());
                }
            }
            else
            {
                new UIAlertView("Login Error", "Bad user name or password", null, "OK", null).Show();
            }
        }
    }
}