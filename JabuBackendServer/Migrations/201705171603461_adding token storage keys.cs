namespace JabuBackendServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingtokenstoragekeys : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.MobileNotificationTokens");
            AlterColumn("dbo.MobileNotificationTokens", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.MobileNotificationTokens", "Token", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.MobileNotificationTokens", new[] { "Id", "Token" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.MobileNotificationTokens");
            AlterColumn("dbo.MobileNotificationTokens", "Token", c => c.String());
            AlterColumn("dbo.MobileNotificationTokens", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.MobileNotificationTokens", "Id");
        }
    }
}
