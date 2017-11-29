using System;
using System.Drawing;
using Autofac;
using CoreFoundation;
using UIKit;
using Foundation;

namespace XamarinTrainingProject
{
    [Register("AutoFacUIController")]
    public class AutoFacUIController : UIViewController
    {

        private readonly IContainer _container;

        public AutoFacUIController(IntPtr ptr) : base(ptr)
        {
            _container = AppDelegate.AutoFacContainer;
        }
        public AutoFacUIController()
        {
        }
        public override void LoadView()
        {
            // resolve all properties
            _container.InjectProperties(this);

            base.LoadView();
        }
        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
          //  View = new UniversalView();

            base.ViewDidLoad();

            // Perform any additional setup after loading the view
        }
    }
}