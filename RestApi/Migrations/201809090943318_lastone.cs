namespace RestApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastone : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "PaysProvenance");
            DropColumn("dbo.AspNetUsers", "PaysDistination");
            DropColumn("dbo.AspNetUsers", "Volume");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Volume", c => c.String());
            AddColumn("dbo.AspNetUsers", "PaysDistination", c => c.String());
            AddColumn("dbo.AspNetUsers", "PaysProvenance", c => c.String());
        }
    }
}
