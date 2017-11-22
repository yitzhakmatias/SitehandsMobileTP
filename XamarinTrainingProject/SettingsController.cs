using Foundation;
using System;
using BL.Core.Services.Model;
using BL.Core.Services.Repository;
using UIKit;

namespace XamarinTrainingProject
{
    public partial class SettingsController : UIViewController
    {
        UserRepository userRepository = new UserRepository();

        public User User { get; set; }
        public SettingsController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            DatabindUI();

            /* AddToCartButton.TouchUpInside += (object sender, EventArgs e) =>
             {
                 AddToCart(SelectedHotDog, Int32.Parse(AmountText.Text));

                 UIAlertView message = new UIAlertView("warning", "warning", null, "OK", null);
                 message.Show();

                 this.DismissModalViewController(true);
             };

            */
            Logout.TouchUpInside += (object sender, EventArgs e) =>
            {

                //Create an instance of our AppDelegate
                var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;

                //Get an instance of our MainStoryboard.storyboard
                var mainStoryboard = appDelegate.MainStoryboard;

                //Get an instance of our Login Page View Controller

                var loginPageViewController = appDelegate.GetViewController(mainStoryboard, "Login") as LoginController;

                //Wire our event handler to show the MainTabBarController after we successfully logged in.
                loginPageViewController.OnLoginSuccess += (s, ev) =>
                {
                    var tabBarController = appDelegate.GetViewController(mainStoryboard, "MainNavigationBar");
                    appDelegate.SetRootViewController(tabBarController, true);
                };

                //Set the Login Page as our RootViewController
                appDelegate.SetRootViewController(loginPageViewController, true);

                this.DismissModalViewController(true);

            };
        }

        private void DatabindUI()
        {
            var plist = NSUserDefaults.StandardUserDefaults;
            // Get value
            EmailTxt.Text = plist.StringForKey("email");
        }
    }
}