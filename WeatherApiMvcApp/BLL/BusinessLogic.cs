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
        // Gets access to dataAccesLayer
        IDataAccess dataAccess;
        public BusinessLogic(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public async Task<RootObject> GetWeather(ShowWeatherViewModel model)
        {
            // Getting the correct api call and returns a rootobject model
            WeatherSearch weatherSearch = CreateSearchModel(model);
            string uri = SetupUri(weatherSearch);
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
            // Determans if countrycode should be a parameter or not
            if (String.IsNullOrWhiteSpace(model.CountryCode))
            {
                return $"/data/2.5/weather?q={model.City}&type=like&units={model.Units}";
            }
            else
            {
                return $"/data/2.5/weather?q={model.City},{model.CountryCode}&type=like&units={model.Units}";
            }

            
        }

        // Takes a time in seconds and converts it to correct date 
        public DateTime ConvertNumberToAccuretTime(double timeAsDouble)
        {
            // TODO: Check if timeAsDouble is valid to become datetime
            try
            {
                return new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(timeAsDouble);
            }
            catch (Exception)
            {
                throw new InvalidCastException();
            }
            

        }

        public ShowWeatherViewModel CreateViewModel(RootObject result)
        {
            // Api-call is successful
            if (result.cod == 200)
            {
                ShowWeatherViewModel viewModel = new ShowWeatherViewModel();
                viewModel.RootObject = result;
                viewModel.RequestIsSuccessful = true;
                viewModel.City = result.name;

                // Country code ska stå med två bokstäver i sökningen men med hela staden i tabellen
                viewModel.CountryCode = result.sys.country;
                viewModel.Sunrise = ConvertNumberToAccuretTime(result.sys.sunrise);
                viewModel.Sunset = ConvertNumberToAccuretTime(result.sys.sunset);
                viewModel.WeatherIcon = $"http://openweathermap.org/img/w/{result.weather[0].icon}.png";

                return viewModel;
                
            }
            else
            {
                return null;                
            }            
        }
    }
}
