﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using WeatherApiMvcApp.Models.ApiModels;

namespace WeatherApiMvcApp.DAL
{
    public class DataAccess : IDataAccess
    {
        private const string _baseAddress = "http://api.openweathermap.org";
        private const string _apiKey = "aa97b493f1c079f2d2db4538efb4d75c";


        // Makes a request to webApi and serialize the JSON-respons into a proper model
        public async Task<RootObject> GetWeather(string searchUri)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                HttpResponseMessage responseMessage = await client.GetAsync($"{searchUri}&appid={_apiKey}");

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(RootObject));
                Stream stream = await responseMessage.Content.ReadAsStreamAsync();
                RootObject model = (RootObject)serializer.ReadObject(stream);
                return model;
            }

        }

    }
}
