namespace CarCleanerClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderNumber = c.String(unicode: false),
                        StartDate = c.DateTime(precision: 0),
                        EndDate = c.DateTime(precision: 0),
                        OrderTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.OrderTypes", t => t.OrderTypeId)
                .Index(t => t.OrderTypeId);
            
            CreateTable(
                "dbo.OrderTypes",
                c => new
                    {
                        OrderTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Price = c.Double(nullable: false,defaultValue:0),
                        Times = c.Int(nullable: false, defaultValue:0),
                        Remarks = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.OrderTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "OrderTypeId", "dbo.OrderTypes");
            DropIndex("dbo.Orders", new[] { "OrderTypeId" });
            DropTable("dbo.OrderTypes");
            DropTable("dbo.Orders");
        }
    }
}
