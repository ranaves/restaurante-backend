namespace RestauranteWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prato",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Preco = c.Single(nullable: false),
                        RestauranteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurante", t => t.RestauranteId, cascadeDelete: true)
                .Index(t => t.RestauranteId);
            
            CreateTable(
                "dbo.Restaurante",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prato", "RestauranteId", "dbo.Restaurante");
            DropIndex("dbo.Prato", new[] { "RestauranteId" });
            DropTable("dbo.Restaurante");
            DropTable("dbo.Prato");
        }
    }
}
