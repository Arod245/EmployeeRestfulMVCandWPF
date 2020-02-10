using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ApiHelper
{
    
    public class ApiClient
    {
        public  HttpClient webApiClient { get; set; }
        
        public  void Api() 
        {
            webApiClient = new HttpClient();
            webApiClient.BaseAddress = new Uri("https://localhost:44345/");
            webApiClient.DefaultRequestHeaders.Clear();
            webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
