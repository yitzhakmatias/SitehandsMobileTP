using System.Collections.Generic;
using BL.Core.Services.Model;

namespace BL.Core.Services.Repository
{
    public interface ICountryRepository
    {
        List<Country> GetWebCountries();
    }
}