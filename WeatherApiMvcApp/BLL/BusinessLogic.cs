using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApiMvcApp.DAL;
using WeatherApiMvcApp.Models;
using WeatherApiMvcApp.Models.ApiModels;
using WeatherApiMvcApp.Models.ViewModels;

namespace WeatherApiMvcApp.BLL
{
    public class BusinessLogic : IBusinessLogic
    {
        IDataAccess dataAccess;
        public BusinessLogic(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public async Task<RootObject> GetWeather(ShowWeatherViewModel model)
        {

            string uri = SetupUri(CreateSearchModel(model));
            return await dataAccess.GetWeather(uri);

        }

        private WeatherSearch CreateSearchModel(ShowWeatherViewModel model)
        {
            return new WeatherSearch()
            {
                City = model.City?.Trim(),
                CountryCode = model.CountryCode,
                Units = model.Units?.Trim()
            };

        }

        private string SetupUri(WeatherSearch model)
        {

            string uri = "";

            if (String.IsNullOrWhiteSpace(model.CountryCode))
            {
                uri = $"/data/2.5/weather?q={model.City}&units={model.Units}";
            }
            else
            {
                uri = $"/data/2.5/weather?q={model.City},{model.CountryCode}&units={model.Units}";
            }

            return uri;
        }


    }
}
