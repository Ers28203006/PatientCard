using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientCardWebClient.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Iin { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public int House { get; set; }
        public int Flat { get; set; }
        public ICollection<VisitLog> VisitLogs { get; set; }
        public Patient()
        {
            VisitLogs = new List<VisitLog>();
        }
    }
}