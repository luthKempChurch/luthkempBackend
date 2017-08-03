namespace JabuBackendServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingdeviceid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MobileNotificationTokens", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.MobileNotificationTokens", new[] { "User_Id" });
            AddColumn("dbo.MobileNotificationTokens", "DeviceId", c => c.String());
            DropColumn("dbo.MobileNotificationTokens", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MobileNotificationTokens", "User_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.MobileNotificationTokens", "DeviceId");
            CreateIndex("dbo.MobileNotificationTokens", "User_Id");
            AddForeignKey("dbo.MobileNotificationTokens", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
