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
        public string GetToken(string KullaniciBilgisi, string Sifre, out string Mesaj)
        {
            VwKisiKullaniciIletisim KullaniciKisi;
            string result = "";

            bool Success = base.DoLogin(KullaniciBilgisi, Sifre, out KullaniciKisi, out Mesaj);

            if (Success) // eğer giriş başarılıysa bilgileri şifreliyoruz token oluşturuyoruz
            {
                if (KullaniciKisi != null)
                {
                   result= DoCreateToken(KullaniciKisi);
                }

            }

            return result;
        }

        public TResult Register(TKullaniciKisiIletisim kullaniciKisiIletisim)
        {
            return DoRegister(kullaniciKisiIletisim);
        }

        private string DoCreateToken(VwKisiKullaniciIletisim KullaniciKisi)
        {
           string result = KullaniciKisi.Guid.Value.ToString() + "|" + //dişarı fırlatılan kullanıcı bilgilerini tuzluyoruz
                                           KullaniciKisi.FirmaKodu + "|" +
                                           KullaniciKisi.KisiId.ToString() + "|" +
                                           KullaniciKisi.Tc.ToString() + "|" +
                                           KullaniciKisi.KullaniciAdi + "|" +
                                           KullaniciKisi.KullaniciId + "|" +
                                           Guid.NewGuid().ToString();
            result = PysSecurity.Encrypt(result, KullaniciKisi.Guid.Value.ToString());

            return result;

        }


    }
}
