using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApiMvcApp.Models.ApiModels;

namespace WeatherApiMvcApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.openweathermap.org");
                HttpResponseMessage responseMessage = await client.GetAsync("/data/2.5/weather?q=Stockholm,swe&units=metric&appid=aa97b493f1c079f2d2db4538efb4d75c");

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(RootObject));
                Stream stream = await responseMessage.Content.ReadAsStreamAsync();
                RootObject model = (RootObject)serializer.ReadObject(stream);


            }

            return View();
        }
    }
}