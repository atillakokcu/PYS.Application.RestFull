using PYS.Application.Business;
using PYS.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PYS.Application.RestFull.Controllers
{
    public class TokenController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(string Token,string SecretKey)
        {
            KullaniciIslemleri kullanici = new KullaniciIslemleri();
            TResult result = kullanici.ValidToken(Token, SecretKey);
            return "";
        }

        // POST api/<controller>
        public HttpResponseMessage Post(TUser User, string SecretKey)
        {
            HttpResponseMessage Response = new HttpResponseMessage();

            KullaniciIslemleri kullanici = new KullaniciIslemleri();
            TResult result = kullanici.GetToken(User.Username, User.Password, SecretKey);
            if (!result.Success)
            {
                Response= Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                Response= Request.CreateResponse<TResult>(HttpStatusCode.OK, result);
            }

            return Response;

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}