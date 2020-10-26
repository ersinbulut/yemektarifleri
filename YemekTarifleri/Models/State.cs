using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YemekTarifleri.Entity;

namespace YemekTarifleri.Models
{
    public class State
    {
        DataContext db = new DataContext();
        public StateModelStyle GetModelStyle()
        {
            StateModelStyle models = new StateModelStyle();
            models.YemekSayisi = db.Yemekler.Count();
            models.MesajSayisi = db.Mesajlar.Count();
            models.YorumSayisi = db.Yorumlar.Count();
            models.TarifSayisi = db.Tarifler.Count();
            return models;
        }
    }
    public class StateModelStyle
    {
        public int YemekSayisi { get; set; }
        public int MesajSayisi { get; set; }
        public int YorumSayisi { get; set; }
        public int TarifSayisi { get; set; }
    }
}