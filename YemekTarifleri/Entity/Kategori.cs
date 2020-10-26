using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekTarifleri.Entity
{
    public class Kategori
    {
        public int Id { get; set; }
        public string KategoriAd { get; set; }
        public int KategoriAdet { get; set; }
        public string KategoriResim { get; set; }
        public int ParentId { get; set; }

        public virtual List<Yemek> Yemekler { get; set; }
      
    }
}