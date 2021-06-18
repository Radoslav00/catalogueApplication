namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarID = c.Int(nullable: false, identity: true),
                        Make = c.String(),
                        Manufacturer = c.String(),
                        Color = c.String(),
                        Fuel = c.String(),
                    })
                .PrimaryKey(t => t.CarID);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        PartID = c.Int(nullable: false, identity: true),
                        PartName = c.String(),
                        Price = c.Double(nullable: false),
                        CatalogueNumber = c.String(),
                        ZoneID = c.Int(nullable: false),
                        CarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartID)
                .ForeignKey("dbo.Cars", t => t.CarID, cascadeDelete: true)
                .ForeignKey("dbo.Zones", t => t.ZoneID, cascadeDelete: true)
                .Index(t => t.ZoneID)
                .Index(t => t.CarID);
            
            CreateTable(
                "dbo.Zones",
                c => new
                    {
                        ZoneID = c.Int(nullable: false, identity: true),
                        ZoneName = c.String(),
                    })
                .PrimaryKey(t => t.ZoneID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        PositionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonID)
                .ForeignKey("dbo.Positions", t => t.PositionID, cascadeDelete: true)
                .Index(t => t.PositionID);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionID = c.Int(nullable: false, identity: true),
                        PositionTitle = c.String(),
                    })
                .PrimaryKey(t => t.PositionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "PositionID", "dbo.Positions");
            DropForeignKey("dbo.Parts", "ZoneID", "dbo.Zones");
            DropForeignKey("dbo.Parts", "CarID", "dbo.Cars");
            DropIndex("dbo.People", new[] { "PositionID" });
            DropIndex("dbo.Parts", new[] { "CarID" });
            DropIndex("dbo.Parts", new[] { "ZoneID" });
            DropTable("dbo.Positions");
            DropTable("dbo.People");
            DropTable("dbo.Zones");
            DropTable("dbo.Parts");
            DropTable("dbo.Cars");
        }
    }
}
