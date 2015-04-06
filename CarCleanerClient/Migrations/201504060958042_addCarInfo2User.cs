namespace CarCleanerClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCarInfo2User : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "CarInfo", c => c.String(unicode: false));
            AddColumn("dbo.Users", "CarLocation", c => c.String(unicode: false));
            AddColumn("dbo.Users", "CarNumber", c => c.String(unicode: false));
            AddColumn("dbo.Users", "CommunityId", c => c.Int());
            CreateIndex("dbo.Users", "CommunityId");
            AddForeignKey("dbo.Users", "CommunityId", "dbo.Communities", "CommunityId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "CommunityId", "dbo.Communities");
            DropIndex("dbo.Users", new[] { "CommunityId" });
            DropColumn("dbo.Users", "CommunityId");
            DropColumn("dbo.Users", "CarNumber");
            DropColumn("dbo.Users", "CarLocation");
            DropColumn("dbo.Users", "CarInfo");
        }
    }
}
