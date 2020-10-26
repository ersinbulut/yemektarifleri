namespace YemekTarifleri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deneme1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Yorums", "ProfileImageName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Yorums", "ProfileImageName");
        }
    }
}
