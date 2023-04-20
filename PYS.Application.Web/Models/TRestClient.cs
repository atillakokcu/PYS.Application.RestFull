using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PYS.Application.Data;
using RestSharp;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;

namespace PYS.Application.Web.Models
{
    public class TRestClient
    {
        private RestClient client;
        

        public TRestClient()
        {
            //client = new RestClient();  
        }

        public string Test()
        {
            client = new RestClient(TSiteSettings.ApiUrl+"//Token12");
            var request = new RestRequest();
            var response = client.Get(request);
            return response.Content;
            
        }

        public TResult Register(TKullaniciKisiIletisim KisiBilgileri)
        {
            TResult result= new TResult();
            string JsonKİsiBilgileri = // burada kaldım
            client = new RestClient(TSiteSettings.ApiUrl + "//User");
            client.
        }

    }
}