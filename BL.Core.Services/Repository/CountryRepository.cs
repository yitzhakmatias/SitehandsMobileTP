using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Core.Services.Model;
using BL.Core.Services.WebServices;

namespace BL.Core.Services.Repository
{
    public class CountryRepository
    {
        public List<Country> GetCountries()
        {
            return Countries;
        }

        public List<Country> GetWebCountries()
        {
            var service = new CountryWebService();
            return service.Countries;
          //  return null;
        }

        private static readonly List<Country> Countries = new List<Country>()
        { };

    }
}
