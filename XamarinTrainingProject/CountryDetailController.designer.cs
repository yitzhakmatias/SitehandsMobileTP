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
    [Register ("CountryDetailController")]
    partial class CountryDetailController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Area { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView CountryFlag { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel MainCurrency { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel MainLanguage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel NameLbl { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Population { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Region { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Subregion { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Area != null) {
                Area.Dispose ();
                Area = null;
            }

            if (CountryFlag != null) {
                CountryFlag.Dispose ();
                CountryFlag = null;
            }

            if (MainCurrency != null) {
                MainCurrency.Dispose ();
                MainCurrency = null;
            }

            if (MainLanguage != null) {
                MainLanguage.Dispose ();
                MainLanguage = null;
            }

            if (NameLbl != null) {
                NameLbl.Dispose ();
                NameLbl = null;
            }

            if (Population != null) {
                Population.Dispose ();
                Population = null;
            }

            if (Region != null) {
                Region.Dispose ();
                Region = null;
            }

            if (Subregion != null) {
                Subregion.Dispose ();
                Subregion = null;
            }
        }
    }
}