namespace PatientCardWebClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(),
                        SpetiolistId = c.Int(),
                        Spetialist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Spetialists", t => t.Spetialist_Id)
                .Index(t => t.Spetialist_Id);
            
            CreateTable(
                "dbo.Spetialists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VisitLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(),
                        Diagnosis = c.String(),
                        Plaint = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(),
                        Iin = c.String(),
                        Phone = c.String(),
                        City = c.String(),
                        House = c.Int(nullable: false),
                        Flat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VisitLogs", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "Spetialist_Id", "dbo.Spetialists");
            DropIndex("dbo.VisitLogs", new[] { "DoctorId" });
            DropIndex("dbo.Doctors", new[] { "Spetialist_Id" });
            DropTable("dbo.Patients");
            DropTable("dbo.VisitLogs");
            DropTable("dbo.Spetialists");
            DropTable("dbo.Doctors");
        }
    }
}
