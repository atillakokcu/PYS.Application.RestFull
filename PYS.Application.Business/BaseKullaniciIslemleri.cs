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
            Message = "";

            try
            {
                var KisiKaydi = (from data in Db.VwKisiKullaniciIletisim where data.Iletisim == KullaniciBilgisi || data.KullaniciAdi == KullaniciBilgisi select data).FirstOrDefault();

                if (KisiKaydi == null)
                {
                    Message = "Kullanıcı bilgileri hatalı";
                }
                else
                {
                    if (KisiKaydi.Sifre != PysSecurity.StrToMd5(Sifre))
                    {
                        Message = "kullanıcı bilgileri hatalı";
                    }
                    else
                    {
                        KullaniciKisi = KisiKaydi; // giriş başarılıysa bilgileri out ile fırlatıyoruz ve result true yapıyoruz
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }

            return result;
        }

        internal TResult DoRegister(TKullaniciKisiIletisim KisiBilgileri)
        {

            TResult result = new TResult();

            try
            {
                if (!ExistUser(KisiBilgileri))// kullanıcı varmı yokmu kontrol ediyor, yoksa kullanıcı kaydetme işlemine devam ediyor
                {

                    TblKisi Kisi = KisiBilgileri.Kisi;
                    TblKullanicilar Kullanicilar = KisiBilgileri.Kullanici;
                    TblKisiFirma KisiFirma = KisiBilgileri.KisiFirma;
                    List<TblKisiIletisim> KisiIletisimler = KisiBilgileri.KisiIletisimler;

                    Db.TblKisi.Add(Kisi);
                    Db.SaveChanges();
                    Kullanicilar.KisiId = Kisi.KisiId;
                    Kullanicilar.Sifre = PysSecurity.StrToMd5(Kullanicilar.Sifre);
                    Db.TblKullanicilar.Add(Kullanicilar);
                    KisiFirma.KisiId = Kisi.KisiId;
                    Db.TblKisiFirma.Add(KisiFirma);

                    foreach (var Iletisim in KisiIletisimler)
                    {
                        Iletisim.KisiId = Kisi.KisiId;
                        Db.TblKisiIletisim.Add(Iletisim);
                        Db.SaveChanges();
                    }

                    Db.SaveChanges();

                    Kullanicilar.Sifre = "";
                    result.StatusCode = 200;
                    result.Success = true;
                    result.Data.Add(Kisi);
                    result.Data.Add(KisiFirma);
                    result.Data.Add(KisiIletisimler);
                    result.Data.Add(Kullanicilar);


                }
            }
            catch (Exception)
            {

                result.Message = "Hata Meydana geldi";
                result.Success = false;
                result.StatusCode = -1001;
            }

            return result;
        }


        private bool ExistUser(TKullaniciKisiIletisim KisiBilgileri)
        {
            bool result = false;
            var KisiKaydi = (from data in Db.TblKisi where data.Tc == KisiBilgileri.Kisi.Tc select data).FirstOrDefault();
            if (KisiKaydi != null)
            {
                result = true;
            }

            return result;
        }



    }
}
