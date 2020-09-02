namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class title : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "Title");
        }
    }
}
