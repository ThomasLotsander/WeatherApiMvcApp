using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApiMvcApp.Models
{
    public class WeatherSearch
    {
        public string City { get; set; }

        public string CountryCode { get; set; }

        public string Units { get; set; }
    }
}
