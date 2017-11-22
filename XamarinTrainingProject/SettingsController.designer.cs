// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace XamarinTrainingProject
{
    [Register ("SettingsController")]
    partial class SettingsController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField EmailTxt { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Logout { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (EmailTxt != null) {
                EmailTxt.Dispose ();
                EmailTxt = null;
            }

            if (Logout != null) {
                Logout.Dispose ();
                Logout = null;
            }
        }
    }
}