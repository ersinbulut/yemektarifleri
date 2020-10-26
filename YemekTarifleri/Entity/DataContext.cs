using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace YemekTarifleri.Entity
{
    public class DataContext : DbContext
    {
        public DataContext() : base("yemektarifleri")
        {

        }

        public DbSet<Yemek> Yemekler { get; set; }

        public DbSet<Tarif> Tarifler { get; set; }

        public DbSet<GununYemegi> GununYemekleri { get; set; }

        public DbSet<Hakkimizda> Hakkimizda { get; set; }

        public DbSet<Kategori> Kategoriler { get; set; }

        public DbSet<Mesaj> Mesajlar { get; set; }

        public DbSet<Yonetici> Yoneticiler { get; set; }

        public DbSet<Yorum> Yorumlar { get; set; }
    }
}