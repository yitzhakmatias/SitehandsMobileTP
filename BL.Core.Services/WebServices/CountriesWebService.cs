using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BL.Core.Services.Model;
using Newtonsoft.Json;

namespace BL.Core.Services.WebServices
{
    public  class CountryWebService
    {
        private readonly string url = "https://restcountries.eu/rest/v2/all";

        public  List<Country> Countries = new List<Country>();
        public CountryWebService()
        {
            Task.Run(() => this.LoadDataAsync(url)).Wait();
        }
        private async Task LoadDataAsync(string uri)
        {
            if (Countries != null)
            {
                string responseJsonString = null;

                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        Task<HttpResponseMessage> getResponse = httpClient.GetAsync(uri);

                        HttpResponseMessage response = await getResponse;

                        responseJsonString = await response.Content.ReadAsStringAsync();
                    }
                    catch (Exception ex)
                    {
                        //handle any errors here, not part of the sample app
                        string message = ex.Message;
                    }
                }

                var webCountries = JsonConvert.DeserializeObject<List<Country>>(responseJsonString);
                Countries = webCountries;
            }
        }
    }
}
