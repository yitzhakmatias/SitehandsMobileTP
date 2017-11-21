using Foundation;
using System;
using System.Linq;
using BL.Core.Services.Model;
using Newtonsoft.Json.Linq;
using UIKit;

namespace SiteHandsTP
{
    public partial class CountryDetailController : UIViewController
    {
        public CountryDetailController(IntPtr handle) : base(handle)
        {
        }

        public Country Country { get; set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            DatabindUI();
        }

        private void DatabindUI()
        {
            
            NameLbl.Text = Country.Name;
            Region.Text = Country.Region;
            Subregion.Text = Country.SubRegion;
            Population.Text = Country.Population;
            Area.Text = Country.Area;
          

            foreach (var parsedObject in Country.Currencies.Children<JObject>())
            {
                foreach (var parsedProperty in parsedObject.Properties())
                {
                    var propertyName = parsedProperty.Name;
                    if (!propertyName.Equals("name")) continue;
                    var propertyValue = (string)parsedProperty.Value;
                    MainCurrency.Text = propertyValue;
                    break;
                }
            }
            foreach (var parsedObject in Country.Languages.Children<JObject>())
            {
                foreach (var parsedProperty in parsedObject.Properties())
                {
                    var propertyName = parsedProperty.Name;
                    if (!propertyName.Equals("name")) continue;
                    var propertyValue = (string)parsedProperty.Value;
                    MainLanguage.Text = propertyValue;
                    break;
                }
            }
           

        }
    }
}