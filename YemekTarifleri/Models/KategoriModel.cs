using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekTarifleri.Models
{
    public class KategoriModel
    {
        public int Id { get; set; }
        public string KategoriAd { get; set; }
        public int KategoriAdet { get; set; }
        public string KategoriResim { get; set; }
        public int ParentId { get; set; }
    }
}