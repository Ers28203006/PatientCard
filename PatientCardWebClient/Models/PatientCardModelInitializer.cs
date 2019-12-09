using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PatientCardWebClient.Models
{
    public class PatientCardModelInitializer : DropCreateDatabaseAlways<PatientCardModel>
    {
        protected override void Seed(PatientCardModel db)
        {
            db.Spetialists.Add(new Spetialist() { Title = "лор" });
            db.Spetialists.Add(new Spetialist() { Title = "хирург" });
            db.Spetialists.Add(new Spetialist() { Title = "терапевт" });
            db.Spetialists.Add(new Spetialist() { Title = "стоматолог" });
            db.SaveChanges();
        }
    }
}