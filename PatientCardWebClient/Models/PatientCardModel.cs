namespace PatientCardWebClient.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PatientCardModel : DbContext
    {
        public PatientCardModel()
            : base("name=PatientCardModel")
        {
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<VisitLog> VisitLogs { get; set; }
        public DbSet<Spetialist> Spetialists { get; set; }
    }
}