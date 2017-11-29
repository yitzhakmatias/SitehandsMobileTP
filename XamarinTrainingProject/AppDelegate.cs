using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Autofac;
using BL.Core.Services.Repository;
using Firebase.Core;
using Foundation;
using UIKit;

namespace XamarinTrainingProject
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        private bool isAuthenticated = false;
        public static IContainer AutoFacContainer { get; set; }

        public override UIWindow Window
        {
            get;
            set;
        }
        public UIStoryboard MainStoryboard
        {
            get { return UIStoryboard.FromName("Main", NSBundle.MainBundle); }
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {

            RegisterIoC();

            //Firebase init
            Firebase.Core.App.Configure();
            // Get Shared User Defaults
            var plist = NSUserDefaults.StandardUserDefaults;
            var isUserAuthenticated = plist.BoolForKey("isAuthenticated");

            if (isUserAuthenticated)
            {
                //We are already authenticated, so go to the main tab bar controller;
                var tabBarController = GetViewController(MainStoryboard, "MainNavigationBar");
                SetRootViewController(tabBarController, false);
            }
            else
            {
                var loginViewController = GetViewController(MainStoryboard, "Login") as LoginController;
                loginViewController.OnLoginSuccess += LoginViewController_OnLoginSuccess;
                SetRootViewController(loginViewController, false);

            }
            return true;
        }
        void LoginViewController_OnLoginSuccess(object sender, EventArgs e)
        {
            //We have successfully Logged In
            var tabBarController = GetViewController(MainStoryboard, "MainNavigationBar");
            SetRootViewController(tabBarController, true);
        }
        public void SetRootViewController(UIViewController rootViewController, bool animate)
        {
            if (animate)
            {
                var transitionType = UIViewAnimationOptions.TransitionFlipFromRight;

                Window.RootViewController = rootViewController;
                UIView.Transition(Window, 0.5, transitionType,
                    () => Window.RootViewController = rootViewController,
                    null);
            }
            else
            {
                Window.RootViewController = rootViewController;
            }
        }
        public UIViewController GetViewController(UIStoryboard storyboard, string viewControllerName)
        {
            return storyboard.InstantiateViewController(viewControllerName);
        }
        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }

        public static void ShowMessage(string title, string message, UIViewController fromViewController, Action okAction = null)
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var alert = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, (obj) => okAction?.Invoke()));
                fromViewController.PresentViewController(alert, true, null);
            }
            else
            {
                var alert = new UIAlertView(title, message, null, "Ok", null);
                alert.Canceled += (sender, e) => okAction?.Invoke();
                alert.Show();
            }
        }

        public override bool WillFinishLaunching(UIApplication application, NSDictionary launchOptions)
        {


            return true;
        }

        private void RegisterIoC()
        {
            var builder = new ContainerBuilder();

            // access the assembly and register ALL classes which implement our custom base class
            var types = GetType().Assembly.DefinedTypes;
            foreach (var theType in types)
            {
                if (theType.BaseType == typeof(AutoFacUIController))
                    builder.RegisterType(theType).PropertiesAutowired();
            }

            // ask the user to register their dependencies
            RegisterDependencies(builder);

            // establish our static container
            AutoFacContainer = builder.Build();
        }
        protected void RegisterDependencies(Autofac.ContainerBuilder builder)
        {
            builder.RegisterType<CountryRepository>().As<ICountryRepository>();
        }
    }
}