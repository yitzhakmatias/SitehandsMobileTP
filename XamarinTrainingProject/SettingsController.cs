using Foundation;
using System;
using BL.Core.Services.Model;
using UIKit;

namespace XamarinTrainingProject
{
    public partial class SettingsController : UIViewController
    {
        public User User { get; set; }
        public SettingsController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            DatabindUI();

            this.NavigationItem.Title = "User Settings";

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

                var plist = NSUserDefaults.StandardUserDefaults;

                plist.SetBool(false, "isAuthenticated");

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