using System;
using System.Collections.Generic;
using BL.Core.Services.Model;
using Foundation;
using UIKit;

namespace XamarinTrainingProject.DataSources
{
    public class CountryDataSource : UITableViewSource
    {

        private readonly List<Country> _getCountries;

        readonly NSString _cellIdentifier = new NSString("CountryCell");

        public CountryDataSource(List<Country> getCountries, UITableViewController controllers)
        {
            _getCountries = getCountries;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(_cellIdentifier) ?? new UITableViewCell(UITableViewCellStyle.Subtitle, _cellIdentifier);

            var country = _getCountries[indexPath.Row];

            cell.TextLabel.Text = country.Name ;
            cell.DetailTextLabel.Text = country.Region;
            // cell.ImageView.Image = UIImage.FromBundle(country.Flag);
            // TranscoderInput input_svg_image = new TranscoderInput(svg_URI_input);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _getCountries.Count;
        }

        public Country GetItem(int id)
        {
            return _getCountries[id];
        }
       
    }
  
}