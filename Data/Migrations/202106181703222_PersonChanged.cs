namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "PositionID", "dbo.Positions");
            DropIndex("dbo.People", new[] { "PositionID" });
            AlterColumn("dbo.People", "PositionID", c => c.Int());
            CreateIndex("dbo.People", "PositionID");
            AddForeignKey("dbo.People", "PositionID", "dbo.Positions", "PositionID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "PositionID", "dbo.Positions");
            DropIndex("dbo.People", new[] { "PositionID" });
            AlterColumn("dbo.People", "PositionID", c => c.Int(nullable: false));
            CreateIndex("dbo.People", "PositionID");
            AddForeignKey("dbo.People", "PositionID", "dbo.Positions", "PositionID", cascadeDelete: true);
        }
    }
}
