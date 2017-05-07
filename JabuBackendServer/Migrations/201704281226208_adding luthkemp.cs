namespace JabuBackendServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingluthkemp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Title = c.String(),
                        Address = c.String(),
                        ContactPerson = c.String(),
                        Description = c.String(),
                        Email = c.String(),
                        Show = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Prayers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Prayers");
            DropTable("dbo.Notifications");
            DropTable("dbo.Events");
        }
    }
}
