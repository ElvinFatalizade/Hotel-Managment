namespace HotelBookingData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StayId = c.Int(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stays", t => t.StayId, cascadeDelete: true)
                .Index(t => t.StayId);
            
            CreateTable(
                "dbo.Stays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Desc = c.String(),
                        StayTypePackageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StayTypePackages", t => t.StayTypePackageId, cascadeDelete: true)
                .Index(t => t.StayTypePackageId);
            
            CreateTable(
                "dbo.StayTypePackages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StayTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StayTypes", t => t.StayTypeId, cascadeDelete: true)
                .Index(t => t.StayTypeId);
            
            CreateTable(
                "dbo.StayTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "StayId", "dbo.Stays");
            DropForeignKey("dbo.Stays", "StayTypePackageId", "dbo.StayTypePackages");
            DropForeignKey("dbo.StayTypePackages", "StayTypeId", "dbo.StayTypes");
            DropIndex("dbo.StayTypePackages", new[] { "StayTypeId" });
            DropIndex("dbo.Stays", new[] { "StayTypePackageId" });
            DropIndex("dbo.Bookings", new[] { "StayId" });
            DropTable("dbo.StayTypes");
            DropTable("dbo.StayTypePackages");
            DropTable("dbo.Stays");
            DropTable("dbo.Bookings");
        }
    }
}
