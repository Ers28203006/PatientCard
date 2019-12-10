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
        // GET: VisitLog
        public ActionResult Index()
        {
            return View();
        }

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
            var logs = new List<VisitLog>();
            var doctors = db.Doctors.ToList();
            var patients = db.Patients.ToList();
            foreach (var l in db.VisitLogs)
                logs.Add(l);
            ViewBag.Logs = logs;
            ViewBag.Doctors = doctors;
            ViewBag.Patients = patients;
            return View("List");
        }


        public ActionResult List()
        {
            var logs = new List<VisitLog>();
            foreach (var log in db.VisitLogs)
                logs.Add(log);
            ViewBag.Logs = logs;
            return View();
        }
        [HttpPost]
        public ActionResult List(DateTime startDate, DateTime endDate)
        {
            var logs = new List<VisitLog>();
            foreach (var d in db.VisitLogs)
            {
                if (startDate<=d.Date && endDate>=d.Date)
                {
                    logs.Add(d);
                    ViewBag.Logs = logs;
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult List(string fullname)
        {

            return View();
        }
        public ActionResult Filter()
        {

            return View();
        }

        public ActionResult Search()
        {
            return View();
        }
    }
}