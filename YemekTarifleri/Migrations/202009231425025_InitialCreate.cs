namespace YemekTarifleri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GununYemegis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GununYemegiAd = c.String(),
                        GununYemegiMalzeme = c.String(),
                        GununYemegiTarif = c.String(),
                        GununYemegiResim = c.String(),
                        GununYemegiPuan = c.Single(nullable: false),
                        GununYemegiTarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hakkimizdas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Metin = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KategoriAd = c.String(),
                        KategoriAdet = c.Int(nullable: false),
                        KategoriResim = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Yemeks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YemekAd = c.String(),
                        YemekMalzeme = c.String(),
                        YemekTarif = c.String(),
                        YemekResim = c.String(),
                        YemekTarih = c.DateTime(nullable: false),
                        YemekPuan = c.Single(nullable: false),
                        Kategoriid = c.Int(nullable: false),
                        Durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kategoris", t => t.Kategoriid, cascadeDelete: true)
                .Index(t => t.Kategoriid);
            
            CreateTable(
                "dbo.Yorums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YorumAdSoyad = c.String(),
                        YorumTarih = c.DateTime(nullable: false),
                        YorumOnay = c.Boolean(nullable: false),
                        Yorumicerik = c.String(),
                        Yemekid = c.Int(nullable: false),
                        YemekAd = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Yemeks", t => t.Yemekid, cascadeDelete: true)
                .Index(t => t.Yemekid);
            
            CreateTable(
                "dbo.Mesajs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdSoyad = c.String(),
                        Email = c.String(),
                        İcerik = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tarifs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TarifAd = c.String(),
                        TarifMalzeme = c.String(),
                        TarifYapilis = c.String(),
                        TarifResim = c.String(),
                        TarifSahip = c.String(),
                        TarifSahipMail = c.String(),
                        TarifDurum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Yoneticis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YoneticiAd = c.String(),
                        YoneticiSifre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yorums", "Yemekid", "dbo.Yemeks");
            DropForeignKey("dbo.Yemeks", "Kategoriid", "dbo.Kategoris");
            DropIndex("dbo.Yorums", new[] { "Yemekid" });
            DropIndex("dbo.Yemeks", new[] { "Kategoriid" });
            DropTable("dbo.Yoneticis");
            DropTable("dbo.Tarifs");
            DropTable("dbo.Mesajs");
            DropTable("dbo.Yorums");
            DropTable("dbo.Yemeks");
            DropTable("dbo.Kategoris");
            DropTable("dbo.Hakkimizdas");
            DropTable("dbo.GununYemegis");
        }
    }
}
