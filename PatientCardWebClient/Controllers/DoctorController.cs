using PatientCardWebClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientCardWebClient.Controllers
{
    public class DoctorController : Controller
    {
        PatientCardModel db = new PatientCardModel();
        List<Spetialist> specialist = new List<Spetialist>();
        // GET: Doctor/Create
        public ActionResult Create()
        {
            foreach (var s in db.Spetialists)
                specialist.Add(s);

            ViewBag.Specialists = specialist;
            return View();
        }

        // POST: Doctor/Create
        [HttpPost]
        public ActionResult Create(Doctor doctorName, string spetialistTitle)
        {
            Doctor doctor = new Doctor();
            ViewBag.Specialists = new List<Spetialist>();

            if (doctorName != null && spetialistTitle!=null)
            {
                doctor.Fullname = doctorName.Fullname;
                doctor.Spetialist = db.Spetialists.Where(s=>s.Title==spetialistTitle).FirstOrDefault();
                db.Doctors.Add(doctor);
                db.SaveChanges();
            }
            return View();
        }
    }
}
