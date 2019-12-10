using PatientCardWebClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientCardWebClient.Controllers
{
    public class PatientController : Controller
    {
        public static Patient Patient { get; set;} = new Patient();
        PatientCardModel db = new PatientCardModel();
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( Patient patient)
        {
            db.Patients.Add(patient);
            db.SaveChanges();
            Patient = patient;
            return RedirectToAction("Create", "VisitLog");
        }
    }
}