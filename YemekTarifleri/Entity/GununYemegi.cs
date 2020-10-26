using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekTarifleri.Entity
{
    public class GununYemegi
    {
        public int Id { get; set; }
        public string GununYemegiAd { get; set; }
        public string GununYemegiMalzeme { get; set; }
        public string GununYemegiTarif { get; set; }
        public string GununYemegiResim { get; set; }
        public float GununYemegiPuan { get; set; }
        public DateTime GununYemegiTarih { get; set; }
        //public int Kategoriid { get; set; }
        //public virtual Kategori Kategori { get; set; }
        //public bool Durum { get; set; }
    }
}