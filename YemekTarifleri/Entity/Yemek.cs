using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekTarifleri.Entity
{
    public class Yemek
    {
        public int Id { get; set; }
        public string YemekAd { get; set; }
        public string YemekMalzeme { get; set; }
        public string YemekTarif { get; set; }
        public string YemekResim { get; set; }
        public DateTime YemekTarih { get; set; }
        public float YemekPuan { get; set; }
        public int Kategoriid { get; set; }
        public virtual Kategori Kategori { get; set; }
        public bool Durum { get; set; }

        public virtual ICollection<Yorum> Yorumlar { get; set; }

        
    }
}