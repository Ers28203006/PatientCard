using PatientCardWebClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientCardWebClient.Controllers
{
    public class VisitLogController : Controller
    {
        PatientCardModel db = new PatientCardModel();
        List<VisitLog> logs = new List<VisitLog>();
        List<Doctor> doctors = new List<Doctor>();
        List<Patient> patients = new List<Patient>();

        public ActionResult Create()
        {
            List<Doctor> doctors = new List<Doctor>();
            foreach (var doctor in db.Doctors)
                doctors.Add(doctor);
            ViewBag.Patient = PatientController.Patient;
            ViewBag.Doctors = doctors;
            return View();
        }

        [HttpPost]
        public ActionResult Create(VisitLog visitLog, string doctor, string patient)
        {
            if (visitLog!=null && doctor != null && patient != null)
            {
                Doctor doc = new Doctor();
                Patient pat = new Patient();
                doc = db.Doctors.Where(d => d.Fullname == doctor).FirstOrDefault();
                pat = db.Patients.Where(p => p.Fullname == patient).FirstOrDefault();
                visitLog.Doctor = doc;
                visitLog.Patient = pat;
                db.VisitLogs.Add(visitLog);
                db.SaveChanges();
            }
            doctors = db.Doctors.ToList();
            patients = db.Patients.ToList();
            foreach (var l in db.VisitLogs)
                logs.Add(l);
            ViewBag.Logs = logs;
            ViewBag.Doctors = doctors;
            ViewBag.Patients = patients;
            return View("List");
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult FullList()
        {
            logs.Clear();
            doctors.Clear();
            patients.Clear();
            var visitLogs = db.VisitLogs.ToList();
            foreach (var d in visitLogs)
            {
                    doctors.Add(d.Doctor);
                    patients.Add(d.Patient);
                    logs.Add(d);
            }
            ViewBag.Doctors = doctors;
            ViewBag.Patients = patients;
            ViewBag.Logs = logs;
            return View("List");
        }
        public ActionResult Filter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Filter(DateTime startDate, DateTime endDate)
        {
            logs.Clear();
            doctors.Clear();
            patients.Clear();

            var visitLogs = db.VisitLogs.ToList();
            foreach (var d in visitLogs)
            {
                if (startDate <= d.Date && endDate >= d.Date)
                {
                    doctors.Add(d.Doctor);
                    patients.Add(d.Patient);
                    logs.Add(d);
                }
            }
            ViewBag.Doctors = doctors;
            ViewBag.Patients = patients;
            ViewBag.Logs = logs;
            return View("List");
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string fullname)
        {
            logs.Clear();
            doctors.Clear();
            patients.Clear();
            var visitLogs = db.VisitLogs.ToList();
            foreach (var d in visitLogs)
            {
                if (fullname == d.Patient.Fullname)
                {
                    doctors.Add(d.Doctor);
                    patients.Add(d.Patient);
                    logs.Add(d);
                }
            }
            ViewBag.Doctors = doctors;
            ViewBag.Patients = patients;
            ViewBag.Logs = logs;
            return View("List");
        }
    }
}