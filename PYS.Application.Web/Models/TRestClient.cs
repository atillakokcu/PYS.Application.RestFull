using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using static System.Net.WebRequestMethods;

namespace PYS.Application.Web.Models
{
    public class TRestClient
    {
        private RestClient client;
        private string Url = "https://localhost:44346/Api/";

        public TRestClient()
        {
            //client = new RestClient();  
        }

        public void Test()
        {
            client = new RestClient(Url+"//Token12");
            var request = new RestRequest();
            var response = client.Get(request);
            

        }

    }
}