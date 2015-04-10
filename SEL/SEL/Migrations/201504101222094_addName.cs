namespace SEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offer", "name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Offer", "name");
        }
    }
}
