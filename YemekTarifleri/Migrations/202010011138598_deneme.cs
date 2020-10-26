namespace YemekTarifleri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deneme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kategoris", "ParentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kategoris", "ParentId");
        }
    }
}
