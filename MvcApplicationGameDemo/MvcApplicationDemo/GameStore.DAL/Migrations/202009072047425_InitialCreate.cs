namespace GameStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Year = c.Int(nullable: false),
                        Description = c.String(),
                        Image = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        Developer_Id = c.Int(),
                        Genre_Id = c.Int(),
                        Genre_Id1 = c.Int(),
                        Developer_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Developers", t => t.Developer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id1, cascadeDelete: true)
                .ForeignKey("dbo.Developers", t => t.Developer_Id1)
                .Index(t => t.Developer_Id)
                .Index(t => t.Genre_Id)
                .Index(t => t.Genre_Id1)
                .Index(t => t.Developer_Id1);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "Developer_Id1", "dbo.Developers");
            DropForeignKey("dbo.Games", "Genre_Id1", "dbo.Genres");
            DropForeignKey("dbo.Games", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Games", "Developer_Id", "dbo.Developers");
            DropIndex("dbo.Games", new[] { "Developer_Id1" });
            DropIndex("dbo.Games", new[] { "Genre_Id1" });
            DropIndex("dbo.Games", new[] { "Genre_Id" });
            DropIndex("dbo.Games", new[] { "Developer_Id" });
            DropTable("dbo.Genres");
            DropTable("dbo.Games");
            DropTable("dbo.Developers");
        }
    }
}
