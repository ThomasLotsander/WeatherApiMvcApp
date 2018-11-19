using System;
using System.Collections.Generic;
using System.Globalization;
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
         
        public HomeController(IBusinessLogic businessLogic)
        {
            this.businessLogic = businessLogic;            
        }

        public IActionResult Index() => View(new ShowWeatherViewModel());


        [HttpPost]
        public async Task<IActionResult> Index(ShowWeatherViewModel model)
        {

            if (ModelState.IsValid)
            {
                var result = await businessLogic.GetWeather(model);
                var viewModel = businessLogic.CreateViewModel(result);

                if (viewModel == null)
                {
                    TempData["message"] = result.message;
                }
                else
                {
                    return View(viewModel);
                }               
                
            }

            return View(model);
        }

       


    }
}