//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PYS.Application.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblKisiFirma
    {
        public int Id { get; set; }
        public int KisiId { get; set; }
        public Nullable<int> FirmaId { get; set; }
        public Nullable<System.DateTime> Kayittarihi { get; set; }
        public string Cinsiyet { get; set; }
        public Nullable<bool> Aktif { get; set; }
        public Nullable<bool> Silik { get; set; }
        public byte[] KayitVersiyonu { get; set; }
    }
}