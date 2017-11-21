using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BL.Core.Services.Model
{
    public class Country
    {
        public int Id { get; set; }
        public string Flag { get; set; }
        public string RegionContinent { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string SubRegion { get; set; }
        public JArray Currencies { get; set; }
        public JArray Languages { get; set; }
        public string Population { get; set; }
        public string Area { get; set; }
    }
}
