using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiMvcApp.Models.ApiModels;

namespace WeatherApiMvcApp.Models.ViewModels
{
    public class ShowWeatherViewModel
    {
        public RootObject RootObject { get; set; }

        [Required(ErrorMessage = "A city name is requierd")]
        public string City  { get; set; }

        public string Units { get; set; }

        public string CountryCode { get; set; } = "";

        public DateTime Sunrise { get; set; }

        public DateTime Sunset { get; set; }


    }
}
