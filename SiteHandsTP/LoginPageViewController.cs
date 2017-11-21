using Foundation;
using System;
using UIKit;

namespace SiteHandsTP
{
    public partial class LoginPageViewController : UIViewController
    {
        public LoginPageViewController() : base ("LoginPageViewController", null)
        {
        }
        public LoginPageViewController(IntPtr handle) : base (handle)
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
            return !String.IsNullOrEmpty(UserNameTextView.Text.Trim());
        }

        private bool IsPasswordValid()
        {
            return !String.IsNullOrEmpty(PasswordTextView.Text.Trim());
        }
    }
}