namespace JabuBackendServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingtokenstorage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MobileNotificationTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Token = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MobileNotificationTokens", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.MobileNotificationTokens", new[] { "User_Id" });
            DropTable("dbo.MobileNotificationTokens");
        }
    }
}
