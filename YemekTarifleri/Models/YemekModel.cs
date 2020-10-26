using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekTarifleri.Models
{
    public class YemekModel
    {
        public int Id { get; set; }
        public string YemekAd { get; set; }
        public string YemekMalzeme { get; set; }
        public string YemekTarif { get; set; }
        public string YemekResim { get; set; }
        public DateTime YemekTarih { get; set; }
        public float YemekPuan { get; set; }
        public int Kategoriid { get; set; }
    }
}