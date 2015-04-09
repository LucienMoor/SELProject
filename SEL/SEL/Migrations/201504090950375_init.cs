namespace SEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        message = c.String(),
                        senderID = c.Int(nullable: false),
                        destID = c.Int(nullable: false),
                        title = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.destID, cascadeDelete: false)
                .ForeignKey("dbo.User", t => t.senderID, cascadeDelete: false)
                .Index(t => t.senderID)
                .Index(t => t.destID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        firstname = c.String(),
                        lastname = c.String(),
                        pseudo = c.String(),
                        birthDate = c.DateTime(nullable: false),
                        longitude = c.Double(nullable: false),
                        latitude = c.Double(nullable: false),
                        phone = c.String(),
                        email = c.String(),
                        password = c.String(),
                        city = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Offer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        description = c.String(),
                        beginDate = c.DateTime(nullable: false),
                        endDate = c.DateTime(nullable: false),
                        longitude = c.Double(nullable: false),
                        latitude = c.Double(nullable: false),
                        ownerID = c.Int(nullable: false),
                        city = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.ownerID, cascadeDelete: false)
                .Index(t => t.ownerID);
            
            CreateTable(
                "dbo.OfferTag",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        tagID = c.Int(nullable: false),
                        offerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Offer", t => t.offerID, cascadeDelete: false)
                .ForeignKey("dbo.Tag", t => t.tagID, cascadeDelete: false)
                .Index(t => t.tagID)
                .Index(t => t.offerID);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        tag = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OfferTag", "tagID", "dbo.Tag");
            DropForeignKey("dbo.OfferTag", "offerID", "dbo.Offer");
            DropForeignKey("dbo.Offer", "ownerID", "dbo.User");
            DropForeignKey("dbo.Message", "senderID", "dbo.User");
            DropForeignKey("dbo.Message", "destID", "dbo.User");
            DropIndex("dbo.OfferTag", new[] { "offerID" });
            DropIndex("dbo.OfferTag", new[] { "tagID" });
            DropIndex("dbo.Offer", new[] { "ownerID" });
            DropIndex("dbo.Message", new[] { "destID" });
            DropIndex("dbo.Message", new[] { "senderID" });
            DropTable("dbo.Tag");
            DropTable("dbo.OfferTag");
            DropTable("dbo.Offer");
            DropTable("dbo.User");
            DropTable("dbo.Message");
        }
    }
}
