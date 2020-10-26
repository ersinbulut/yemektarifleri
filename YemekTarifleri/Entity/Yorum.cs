using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekTarifleri.Entity
{
    public class Yorum
    {
        public int Id { get; set; }
        public string YorumAdSoyad { get; set; }//username
        public System.DateTime YorumTarih { get; set; }//AddedDate
        public bool YorumOnay { get; set; }//IsApproved
        public string Yorumicerik { get; set; }
        public int Yemekid { get; set; }
        public string YemekAd { get; set; }//Name
        public virtual Yemek Yemek { get; set; }

        public string ProfileImageName { get; set; }



    }
}