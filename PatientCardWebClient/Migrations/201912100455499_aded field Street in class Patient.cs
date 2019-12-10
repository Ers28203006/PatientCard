namespace PatientCardWebClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adedfieldStreetinclassPatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Street", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Street");
        }
    }
}
