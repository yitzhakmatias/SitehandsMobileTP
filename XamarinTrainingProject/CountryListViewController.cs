using Foundation;
using System;
using BL.Core.Services.Repository;
using UIKit;
using XamarinTrainingProject.DataSources;

namespace XamarinTrainingProject
{
    public partial class CountryListViewController : UITableViewController
    {
        readonly CountryRepository _countryRepository = new CountryRepository();
        public UIStoryboard MainStoryboard
        {
            get { return UIStoryboard.FromName("Main", NSBundle.MainBundle); }
        }
     
        public CountryListViewController (IntPtr handle) : base (handle)
        {
            
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //*********************************************/
            this.NavigationItem.SetRightBarButtonItem(new UIBarButtonItem(UIImage.FromFile("Images/settings.png")
                , UIBarButtonItemStyle.Plain
                , (sender, args) => {
                   // var settingsController = GetViewController(MainStoryboard, "Settings") as SettingsController;
                    var settingsController = GetViewController(MainStoryboard, "SettingsNav");
                    this.SettingsSelected(settingsController);
                }),true);

            //*********************************************/

            var countries = _countryRepository.GetWebCountries();
            var companyDataSource = new CountryDataSource(countries, this);
            TableView.Source = companyDataSource;
            this.NavigationItem.Title = "Country List";
            
        }

        public UIViewController GetViewController(UIStoryboard storyboard, string viewControllerName)
        {
            return storyboard.InstantiateViewController(viewControllerName);
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

        public async void SettingsSelected(UIViewController controller)
        {
        
            if (controller != null)
            {
                controller.ModalTransitionStyle = UIModalTransitionStyle.PartialCurl;

                await PresentViewControllerAsync(controller, true);
            }
        }
    }
}