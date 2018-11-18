using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApiMvcApp.BLL;
using WeatherApiMvcApp.Models;
using WeatherApiMvcApp.Models.ApiModels;
using WeatherApiMvcApp.Models.ViewModels;
using WeatherApiMvcApp.Services;

namespace WeatherApiMvcApp.Controllers
{
    public class HomeController : Controller
    {

        IBusinessLogic businessLogic;
        ShowWeatherViewModel viewModel;
        public HomeController(IBusinessLogic businessLogic)
        {
            this.businessLogic = businessLogic;
            viewModel = new ShowWeatherViewModel();
        }

        public IActionResult Index() => View(viewModel);
        

        [HttpPost]
        public async Task<IActionResult> Index(ShowWeatherViewModel model)
        {

            if (ModelState.IsValid)
            {
               var result = await businessLogic.GetWeather(model);
               viewModel.RootObject = result;
               return View(viewModel);
            }

            return View();
        }

        
    }
}