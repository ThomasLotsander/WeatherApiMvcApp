using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiMvcApp.Models.ApiModels;

namespace WeatherApiMvcApp.DAL
{
    public interface IDataAccess
    {
      Task<RootObject> GetWeather(string searchUri);
    }
}
