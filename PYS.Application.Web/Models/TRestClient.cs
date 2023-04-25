using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PYS.Application.Data;
using RestSharp;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;
using System.Web.Helpers;

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
           
            client = new RestClient(TSiteSettings.ApiUrl + "//User"); // restfull api ye gidiyor
            var request = new RestRequest();
            request.AddJsonBody(KisiBilgileri);
            client.Post(request);

            var response = client.Post(request);// restfullden dönüş 
            result = JsonConvert.DeserializeObject<TResult>(response.Content); // wepapi ye jsonu verilen tresult tipine dönüştürüyors 

            return result;



        }

    }
}