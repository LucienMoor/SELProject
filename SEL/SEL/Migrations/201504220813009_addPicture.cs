namespace SEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPicture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offer", "picture", c => c.String(nullable: true));
        }

        public override void Down()
        {
            DropColumn("dbo.Offer", "picture");
        }
    }
}
