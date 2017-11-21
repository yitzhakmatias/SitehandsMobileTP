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

namespace SiteHandsTP
{
    [Register ("UserDetailController")]
    partial class UserDetailController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView UserDetail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UsrNameLbl { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (UserDetail != null) {
                UserDetail.Dispose ();
                UserDetail = null;
            }

            if (UsrNameLbl != null) {
                UsrNameLbl.Dispose ();
                UsrNameLbl = null;
            }
        }
    }
}