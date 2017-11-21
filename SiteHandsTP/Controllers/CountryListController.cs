using System;
using BL.Core.Services.Repository;
using Foundation;
using SiteHandsTP.DataSources;
using UIKit;

namespace SiteHandsTP.Controllers
{
    public partial class CountryListController : UITableViewController
    {
        readonly CountryRepository _countryRepository = new CountryRepository();
        public CountryListController(IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var employees = _countryRepository.GetWebCountries();
            var companyDataSource = new CountryDataSource(employees, this);
            TableView.Source = companyDataSource;
            this.NavigationItem.Title = "Country List";
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if (segue.Identifier == "CountrySegue")
            {
                var companyController = segue.DestinationViewController as CountryDetailController;
                if (companyController != null)
                {
                    var companyDataSource = TableView.Source as CountryDataSource;
                    var rowPath = TableView.IndexPathForSelectedRow;
                    var item = companyDataSource.GetItem(rowPath.Row);
                    companyController.Country = item;
                }


            }
        }
    }
}