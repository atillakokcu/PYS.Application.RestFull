using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYS.Application.Data
{
    public class TKullaniciKisiIletisim
    {
        public TblKisi Kisi { get; set; }
        public TblKullanicilar Kullanici { get; set; }
        public TblKisiFirma KisiFirma { get; set; } 
        public List<TblKisiIletisim> KisiIletisimler { get;set; } // bir kişinin birden fazla iletişim modeli olacağı için liste şeklinde yaptık
        public TKullaniciKisiIletisim()
        {
            KisiIletisimler = new List<TblKisiIletisim>();// liste şeklinde yaptığımız bu yüzden kurucu metodunda create ediyoruz
        }

    }
}
