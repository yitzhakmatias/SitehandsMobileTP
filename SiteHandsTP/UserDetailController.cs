using Foundation;
using System;
using BL.Core.Services.Model;
using UIKit;

namespace SiteHandsTP
{
    public partial class UserDetailController : UIViewController
    {
        public UserDetailController (IntPtr handle) : base (handle)
        {
        }
        public User User
        {
            get; set;
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            DatabindUI();
        }

        private void DatabindUI()
        {
          //  User.Image = img;
            UsrNameLbl.Text = User.Name;
          //  PhoneLbl.Text = Employee.Phone;
           // AddressLbl.Text = Employee.Address;
        }
    }
}