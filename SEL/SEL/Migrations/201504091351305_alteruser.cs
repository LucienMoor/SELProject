namespace SEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteruser : DbMigration
    {
        public override void Up()
        {

            AlterColumn("dbo.User", "firstname", c => c.String(nullable: false));
            AlterColumn("dbo.User", "lastname", c => c.String(nullable: false));
            AlterColumn("dbo.User", "pseudo", c => c.String(nullable: false));
            AlterColumn("dbo.User","birthDate",c=> c.DateTime(nullable: true));
            AlterColumn("dbo.User","longitude", c => c.Double(nullable: true));
            AlterColumn("dbo.User","latitude", c => c.Double(nullable: true));
            AlterColumn("dbo.User", "phone", c => c.String(nullable: true));
            AlterColumn("dbo.User", "email", c => c.String(nullable: false));
            AlterColumn("dbo.User", "password", c => c.String(nullable: false));
            AlterColumn("dbo.User", "city", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "firstname", c => c.String());
            AlterColumn("dbo.User", "lastname", c => c.String());
            AlterColumn("dbo.User", "pseudo", c => c.String());
            AlterColumn("dbo.User", "birthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.User", "longitude", c => c.Double(nullable: false));
            AlterColumn("dbo.User", "latitude", c => c.Double(nullable: false));
            AlterColumn("dbo.User", "email", c => c.String());
            AlterColumn("dbo.User", "password", c => c.String());
        }
    }
}
