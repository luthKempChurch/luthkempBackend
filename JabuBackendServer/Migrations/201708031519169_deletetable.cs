namespace JabuBackendServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletetable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.MobileNotificationTokens");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MobileNotificationTokens",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Token = c.String(nullable: false, maxLength: 128),
                        DeviceId = c.String(),
                    })
                .PrimaryKey(t => new { t.Id, t.Token });
            
        }
    }
}
