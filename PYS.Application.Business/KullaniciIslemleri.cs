using PYS.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYS.Application.Business
{
    public class KullaniciIslemleri : BaseKullaniciIslemleri
    {
        public bool Login(string KullaniciBilgisi, string Sifre, out VwKisiKullaniciIletisim KullaniciKisi, out string Message)
        {
            return base.DoLogin(KullaniciBilgisi, Sifre,out KullaniciKisi, out Message);
        }

    }
}
