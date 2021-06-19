namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Restraintsadded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Make", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Cars", "Manufacturer", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Cars", "Fuel", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Parts", "PartName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Parts", "CatalogueNumber", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Zones", "ZoneName", c => c.String(nullable: false, maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Zones", "ZoneName", c => c.String());
            AlterColumn("dbo.Parts", "CatalogueNumber", c => c.String());
            AlterColumn("dbo.Parts", "PartName", c => c.String());
            AlterColumn("dbo.Cars", "Fuel", c => c.String());
            AlterColumn("dbo.Cars", "Manufacturer", c => c.String());
            AlterColumn("dbo.Cars", "Make", c => c.String());
        }
    }
}
