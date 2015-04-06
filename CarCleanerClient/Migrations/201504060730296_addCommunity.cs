namespace CarCleanerClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addCommunity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommunityAdministrators",
                c => new
                    {
                        CommunityAdministratorId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Phone = c.String(unicode: false),
                        IdCard = c.String(unicode: false),
                        PicPath = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.CommunityAdministratorId);

            CreateTable(
                "dbo.Communities",
                c => new
                    {
                        CommunityId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Address = c.String(unicode: false),
                        ImgPath = c.String(unicode: false),
                        QRCodePath = c.String(unicode: false),
                        UserCount = c.Int(nullable: false, defaultValue: 0),
                        CommunityAdministratorId = c.Int(),
                    })
                .PrimaryKey(t => t.CommunityId)
                .ForeignKey("dbo.CommunityAdministrators", t => t.CommunityAdministratorId)
                .Index(t => t.CommunityAdministratorId);

            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        WechatUserId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.WechatUsers", t => t.WechatUserId)
                .Index(t => t.WechatUserId);

            CreateTable(
                "dbo.WechatUsers",
                c => new
                    {
                        WechatUserId = c.Int(nullable: false, identity: true),
                        OpenId = c.String(unicode: false),
                        CardId = c.Int(),
                        NickName = c.String(unicode: false),
                        IsSubscribe = c.Boolean(nullable: false, defaultValue: false),
                        Sex = c.Int(nullable: false, defaultValue: 0),
                        City = c.String(unicode: false),
                        Country = c.String(unicode: false),
                        Province = c.String(unicode: false),
                        Language = c.String(unicode: false),
                        SubscribeTime = c.DateTime(precision: 0),
                        HeadImgUrl = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.WechatUserId);

            AddColumn("dbo.Orders", "UserId", c => c.Int());
            CreateIndex("dbo.Orders", "UserId");
            AddForeignKey("dbo.Orders", "UserId", "dbo.Users", "UserId");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "WechatUserId", "dbo.WechatUsers");
            DropForeignKey("dbo.Communities", "CommunityAdministratorId", "dbo.CommunityAdministrators");
            DropIndex("dbo.Users", new[] { "WechatUserId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Communities", new[] { "CommunityAdministratorId" });
            DropColumn("dbo.Orders", "UserId");
            DropTable("dbo.WechatUsers");
            DropTable("dbo.Users");
            DropTable("dbo.Communities");
            DropTable("dbo.CommunityAdministrators");
        }
    }
}
