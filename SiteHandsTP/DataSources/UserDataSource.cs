using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BL.Core.Services.Model;
using Foundation;
using UIKit;

namespace SiteHandsTP.DataSources
{
    public class UserDataSource : UITableViewSource
    {

        private readonly List<User> _users;
        readonly NSString _cellIdentifier = new NSString("UserCell");

        public UserDataSource(List<User> users, UserController callingController)
        {
            _users = users;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(_cellIdentifier) ?? new UITableViewCell(UITableViewCellStyle.Default, _cellIdentifier);

            var employee = _users[indexPath.Row];
            cell.TextLabel.Text = employee.Name;
            //cell.ImageView.Image = UIImage.FromFile("Images/data" + employee.Id + ".jpg");

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _users.Count;
        }
        public User GetItem(int id)
        {
            return _users[id];
        }
    }
}