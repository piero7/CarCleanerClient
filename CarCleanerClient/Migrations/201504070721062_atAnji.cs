namespace CarCleanerClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atAnji : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Remarks", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Remarks");
        }
    }
}
