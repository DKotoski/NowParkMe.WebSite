namespace WebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscribers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ID, t.Email });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subscribers");
        }
    }
}
