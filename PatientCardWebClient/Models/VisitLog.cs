using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientCardWebClient.Models
{
    public class VisitLog
    {
        public int Id { get; set; }
        public int? DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public int? PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public string Diagnosis { get; set; }
        public string Plaint { get; set; }
        public DateTime Date { get; set; }
    }
}