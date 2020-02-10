using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MVC
{
     public static class GlobalVariables
    {
        public static HttpClient webApiClient { get; set; }
      
        static GlobalVariables()
        {
            webApiClient = new HttpClient();
            webApiClient.BaseAddress = new Uri("https://localhost:44345/");
            webApiClient.DefaultRequestHeaders.Clear();
            webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }      
    }
}