namespace JabuBackendServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinguniqukeyss : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MobileNotificationTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Token = c.String(maxLength: 65),
                        DeviceId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Token, unique: true, name: "ix_Token");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.MobileNotificationTokens", "ix_Token");
            DropTable("dbo.MobileNotificationTokens");
        }
    }
}
