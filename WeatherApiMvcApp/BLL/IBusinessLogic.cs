using System;
using System.Threading.Tasks;
using WeatherApiMvcApp.Models;
using WeatherApiMvcApp.Models.ApiModels;
using WeatherApiMvcApp.Models.ViewModels;

namespace WeatherApiMvcApp.BLL
{
    public interface IBusinessLogic
    {
        Task<RootObject> GetWeather(ShowWeatherViewModel model);
        DateTime ConvertNumberToAccuretTime(double timeAsDouble);
        ShowWeatherViewModel CreateViewModel(RootObject result);
    }
}
