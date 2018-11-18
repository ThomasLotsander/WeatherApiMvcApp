using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApiMvcApp.Services
{
    public class GetHttpClient
    {
        private static GetHttpClient _instace;

        protected GetHttpClient(){}

        public HttpClient client { get; private set; } = new HttpClient();

        public static GetHttpClient Instance()
        {
            if (_instace == null)
            {
                _instace = new GetHttpClient();
            }

            return _instace;
        }



        

    }
}
