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
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<VisitLog> VisitLogs { get; set; }
        public virtual DbSet<Spetialist> Spetialists { get; set; }
    }
}