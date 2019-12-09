namespace PatientCardWebClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fieldVisitsPatients : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VisitLogs", "PatientId", c => c.Int());
            CreateIndex("dbo.VisitLogs", "PatientId");
            AddForeignKey("dbo.VisitLogs", "PatientId", "dbo.Patients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VisitLogs", "PatientId", "dbo.Patients");
            DropIndex("dbo.VisitLogs", new[] { "PatientId" });
            DropColumn("dbo.VisitLogs", "PatientId");
        }
    }
}
