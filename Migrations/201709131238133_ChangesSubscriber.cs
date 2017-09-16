namespace webAPIAngular.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesSubscriber : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcessLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Duration = c.Int(nullable: false),
                        AcessDate = c.DateTime(nullable: false),
                        SubscriberId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subscriber", t => t.SubscriberId)
                .Index(t => t.SubscriberId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AcessLog", "SubscriberId", "dbo.Subscriber");
            DropIndex("dbo.AcessLog", new[] { "SubscriberId" });
            DropTable("dbo.AcessLog");
        }
    }
}
