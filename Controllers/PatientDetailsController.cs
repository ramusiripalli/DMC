using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiagnosticMedicalCenter.Models;

namespace DiagnosticMedicalCenter.Controllers
{
    public class PatientDetailsController : Controller
    {
        // GET: PatientDetails
        public ActionResult PatientDetails()
        {
            DataBaseContext contextObject = new DataBaseContext();
            List<Patient> patientsList = (from patients in contextObject.Patients select patients).ToList();
            return View(patientsList);
        }


        public ActionResult AcceptPatient(int id)
        {
            DataBaseContext contextObject = new DataBaseContext();
            var acceptStatus = contextObject.Patients.Find(id);
            acceptStatus.Status = "Accepted";
            contextObject.SaveChanges();
            return RedirectToAction("PatientDetails");
        }


        public ActionResult RejectPatient(int id)
        {
            DataBaseContext contextObject = new DataBaseContext();
            var rejectStatus = contextObject.Patients.Find(id);
            rejectStatus.Status = "Rejected";

            contextObject.SaveChanges();
            return RedirectToAction("PatientDetails");
        }



    }
}