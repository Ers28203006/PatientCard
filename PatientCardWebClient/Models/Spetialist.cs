using System.Collections;
using System.Collections.Generic;

namespace PatientCardWebClient.Models
{
    public class Spetialist
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public Spetialist()
        {
            Doctors = new List<Doctor>();
        }
    }
}