using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekTarifleri.Entity
{
    public class Tarif
    {
        public int Id { get; set; }
        public string TarifAd { get; set; }
        public string TarifMalzeme { get; set; }
        public string TarifYapilis { get; set; }
        public string TarifResim { get; set; }
        public string TarifSahip { get; set; }
        public string TarifSahipMail { get; set; }
        public bool TarifDurum { get; set; }
    }
}