using Foundation;
using System;
using BL.Core.Services.Model;
using BL.Core.Services.Repository;
using SiteHandsTP.DataSources;
using UIKit;

namespace SiteHandsTP
{
    public partial class UserController : UITableViewController
    {
        private readonly UserRepository _userRepository   = new UserRepository();
        public UserController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var users = _userRepository.GetWebUsers();
            TableView.Source = new UserDataSource(users, this);
            this.ParentViewController.NavigationItem.Title = "UserList List";
        }
        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if (segue.Identifier == "UserSegue")
            {
                var companyController = segue.DestinationViewController as UserDetailController;
                if (companyController != null)
                {
                    var companyDataSource = TableView.Source as UserDataSource;
                    var rowPath = TableView.IndexPathForSelectedRow;
                    var item = companyDataSource.GetItem(rowPath.Row);
                    companyController.User = item;
                }


            }
        }
        
    }
}