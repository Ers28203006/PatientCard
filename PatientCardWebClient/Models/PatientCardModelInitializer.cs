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

            Spetialist spetialist1 = new Spetialist { Title = "лор"};
            Spetialist spetialist2 = new Spetialist { Title = "хирург" };
            Spetialist spetialist3 = new Spetialist { Title = "терапевт" };
            Spetialist spetialist4 = new Spetialist { Title = "стоматолог" };

            db.Doctors.Add(new Doctor() { Fullname="Султанбаев Аслан Каирович", Spetialist= spetialist1 });
            db.Doctors.Add(new Doctor() { Fullname="Скилан Асхат Аирович", Spetialist= spetialist2 });
            db.Doctors.Add(new Doctor() { Fullname="Омарханов Гафур Леонидович", Spetialist= spetialist3 });
            db.Doctors.Add(new Doctor() { Fullname="Утяпов Шокан Омарович", Spetialist= spetialist4 });

            db.SaveChanges();
        }
    }
}