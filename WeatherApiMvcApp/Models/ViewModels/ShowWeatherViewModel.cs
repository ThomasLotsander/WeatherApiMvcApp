using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using WeatherApiMvcApp.Models.ApiModels;

namespace WeatherApiMvcApp.Models.ViewModels
{
    public class ShowWeatherViewModel
    {
        // Hold all information about the apicall
        public RootObject RootObject { get; set; }

        // Search parameters
        [DataMember]
        [Required(ErrorMessage = "A city name is requierd")]
        public string City { get; set; }

        [DataMember]
        public string Units { get; set; }

        [DataMember]
        public string CountryCode { get; set; } = "";

        // Additional displaydata parsed from RootObject result
        public bool RequestIsSuccessful { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public string WeatherIcon { get; set; }

    }
}
