using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientCardWebClient.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public int? SpetiolistId { get; set; }
        public Spetialist Spetialist { get; set; }
        public ICollection<VisitLog> VisitLogs { get; set; }
        public Doctor()
        {
            VisitLogs = new List<VisitLog>();
        }
    }
}