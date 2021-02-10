namespace RfidServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingrequestcounter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "RequestNo", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "RequestNo");
        }
    }
}
