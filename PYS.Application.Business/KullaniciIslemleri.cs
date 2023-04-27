using PYS.Application.Data;
using PYS.Application.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYS.Application.Business
{
    public class KullaniciIslemleri : BaseKullaniciIslemleri
    {
         static int ExpriedMinute = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["TokenExpiredMinute"].ToString());
        public TResult GetToken(string KullaniciBilgisi, string Sifre, string SecretKey)
        {
            VwKisiKullaniciIletisim KullaniciKisi;
            TResult result = new TResult();
            string Mesaj;
            string Token="";

            bool Success = base.DoLogin(KullaniciBilgisi, Sifre, out KullaniciKisi, out Mesaj, SecretKey);

            if (Success) // eğer giriş başarılıysa bilgileri şifreliyoruz token oluşturuyoruz
            {
                if (KullaniciKisi != null)
                {
                    Token= DoCreateToken(KullaniciKisi,SecretKey, ExpriedMinute);

                }
                result.Success = Success;
                result.StatusCode= 200;
                result.Data.Add(Token);

            }

            return result;
        }

        public TResult ValidToken(string Token, string SecretKey)
        {
            VwKisiKullaniciIletisim KullaniciKisi;
            TResult result = new TResult();
            string Mesaj;
            

           
                
                  bool  IsValid = DoValidToken(Token,SecretKey);

                
                result.Success = IsValid;
                result.StatusCode = 200;
                result.Data.Add(Token);

           

            return result;
        }


        public TResult Register(TKullaniciKisiIletisim kullaniciKisiIletisim)
        {
            return DoRegister(kullaniciKisiIletisim);
        }

        private string DoCreateToken(VwKisiKullaniciIletisim KullaniciKisi, string SecretKey, int ExpireDate)
        {
           string result = KullaniciKisi.Guid.Value.ToString() + "|" + //dişarı fırlatılan kullanıcı bilgilerini tuzluyoruz
                                           KullaniciKisi.FirmaKodu + "|" +
                                           KullaniciKisi.KisiId.ToString() + "|" +
                                           KullaniciKisi.Tc.ToString() + "|" +
                                           KullaniciKisi.KullaniciAdi + "|" +
                                           KullaniciKisi.KullaniciId + "|" +
                                          DateTime.Now.AddMinutes(ExpireDate) + "|" +
                                           Guid.NewGuid().ToString();


            result = PysSecurity.Encrypt(result, SecretKey);

            return result;

        }

        private bool DoValidToken(string Token, string SecretKey)
        {
            bool result = false;    

            //string result = KullaniciKisi.Guid.Value.ToString() + "|" + //dişarı fırlatılan kullanıcı bilgilerini tuzluyoruz
            //                                KullaniciKisi.FirmaKodu + "|" +
            //                                KullaniciKisi.KisiId.ToString() + "|" +
            //                                KullaniciKisi.Tc.ToString() + "|" +
            //                                KullaniciKisi.KullaniciAdi + "|" +
            //                                KullaniciKisi.KullaniciId + "|" +
            //                               DateTime.Now.AddMinutes(ExpireDate) + "|" +
            //                                Guid.NewGuid().ToString();


             var DecryptText= PysSecurity.Decrypt(Token, SecretKey);

            return result;

        }


    }
}
