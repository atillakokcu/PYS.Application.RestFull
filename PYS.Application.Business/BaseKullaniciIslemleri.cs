using PYS.Application.Data;
using PYS.Application.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYS.Application.Business
{
    public class BaseKullaniciIslemleri
    {

        public DbPYSEntities Db;

        internal BaseKullaniciIslemleri()
        {
            DbPYSEntities Db = new DbPYSEntities();
        }

        internal bool DoLogin(string KullaniciBilgisi, string Sifre, out VwKisiKullaniciIletisim KullaniciKisi, out string Message)
        {
            bool result = false;
            KullaniciKisi = null;
            Message= "";

            try
            {
                var KisiKaydi = (from data in Db.VwKisiKullaniciIletisim where data.Iletisim == KullaniciBilgisi || data.KullaniciAdi == KullaniciBilgisi select data).FirstOrDefault();

                if (KisiKaydi==null)
                {
                    Message = "Kullanıcı bilgileri hatalı";
                }
                else
                {
                    if (KisiKaydi.Sifre!=PysSecurity.StrToMd5(Sifre))
                    {
                        Message = "kullanıcı bilgileri hatalı";
                    }
                    else
                    {
                        KullaniciKisi = KisiKaydi; // giriş başarılıysa bilgileri out ile fırlatıyoruz ve result true yapıyoruz
                        result= true;
                    }
                }
            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }

            return result;
        }


    }
}
