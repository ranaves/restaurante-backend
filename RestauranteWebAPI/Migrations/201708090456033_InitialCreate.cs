namespace RestauranteWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pratos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100),
                        Preco = c.Single(nullable: false),
                        RestauranteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurantes", t => t.RestauranteId, cascadeDelete: true)
                .Index(t => t.RestauranteId);
            
            CreateTable(
                "dbo.Restaurantes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pratos", "RestauranteId", "dbo.Restaurantes");
            DropIndex("dbo.Pratos", new[] { "RestauranteId" });
            DropTable("dbo.Restaurantes");
            DropTable("dbo.Pratos");
        }
    }
}
