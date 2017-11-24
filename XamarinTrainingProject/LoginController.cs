using System;
using BL.Core.Services.AppServices;
using Firebase.Auth;
using Foundation;
using UIKit;

namespace XamarinTrainingProject
{
    public partial class LoginController : UIViewController
    {
        Auth auth;
        public LoginController(IntPtr handle) : base(handle)
        {
        }

        public event EventHandler OnLoginSuccess;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            auth = Auth.DefaultInstance;
        }

        partial void LoginButton_TouchUpInside(UIButton sender)
        {
            var email = UserNameTextView.Text.Trim();
            var password = PasswordTextView.Text.Trim();
            

           /* Auth.DefaultInstance.SignIn(email, password, (user, error) => {
                if (error != null)
                {
                    AuthErrorCode errorCode;
                    if (IntPtr.Size == 8) // 64 bits devices
                        errorCode = (AuthErrorCode)((long)error.Code);
                    else // 32 bits devices
                        errorCode = (AuthErrorCode)((int)error.Code);

                    // Posible error codes that SignIn method with email and password could throw
                    // Visit https://firebase.google.com/docs/auth/ios/errors for more information
                    switch (errorCode)
                    {
                        case AuthErrorCode.OperationNotAllowed:
                        case AuthErrorCode.InvalidEmail:
                        case AuthErrorCode.UserDisabled:
                        case AuthErrorCode.WrongPassword:
                        default:
                            // Print error
                            break;
                    }
                }
                else
                {
                    // Do your magic to handle authentication result
                }
            });*/


            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                AppDelegate.ShowMessage("Hey!", "Seems that some information is missing...", this);
                return;
            }
            auth.SignIn(email, password, SignInOnCompletion);


            //var login = new LoginService(UserNameTextView.Text.Trim(), PasswordTextView.Text.Trim());
            //Validate our Username & Password.
            //This is usually a web service call.
            /* var user = login.ValidateUserPass();
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
             }*/

            if (OnLoginSuccess != null)
            {
                // Get Shared User Defaults
                var plist = NSUserDefaults.StandardUserDefaults;

                plist.SetString(email, "email");
               
                OnLoginSuccess(sender, new EventArgs());
            }
        }

        private void SignInOnCompletion(User user, NSError error)
        {
            if (error != null)
            {
                AuthErrorCode errorCode;
                if (IntPtr.Size == 8) // 64 bits devices
                    errorCode = (AuthErrorCode)((long)error.Code);
                else // 32 bits devices
                    errorCode = (AuthErrorCode)((int)error.Code);

                // Posible error codes that SignIn method with email and password could throw
                // Visit https://firebase.google.com/docs/auth/ios/errors for more information
                switch (errorCode)
                {
                    case AuthErrorCode.OperationNotAllowed:
                    case AuthErrorCode.InvalidEmail:
                    case AuthErrorCode.UserDisabled:
                    case AuthErrorCode.WrongPassword:
                    default:
                        if (errorCode == AuthErrorCode.KeychainError)
                        {
                            break;
                        }
                        new UIAlertView("Login Error", "Bad user name or password", null, "OK", null).Show();
                        //AppDelegate.ShowMessage("Could not login!", error.LocalizedDescription, NavigationController);
                        break;
                }

                return;
            }
        }
    }
}