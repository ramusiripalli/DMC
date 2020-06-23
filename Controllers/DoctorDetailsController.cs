using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiagnosticMedicalCenter.Models;

namespace DiagnosticMedicalCenter.Controllers
{
    public class DoctorDetailsController : Controller
    {
        // GET: PatientDetails
        public ActionResult DoctorDetails()
        {
            DataBaseContext contextObject = new DataBaseContext();
            List<Doctor> doctorList = (from doctors in contextObject.Doctors select doctors).ToList();
            return View(doctorList);
        }


        public ActionResult AcceptDoctor(int id)
        {
            DataBaseContext contextObject = new DataBaseContext();
            var acceptStatus = contextObject.Doctors.Find(id);
            acceptStatus.Status = "Accepted";
            contextObject.SaveChanges();
            return RedirectToAction("DoctorDetails");
        }


        public ActionResult RejectDoctor(int id)
        {
            DataBaseContext contextObject = new DataBaseContext();
            var rejectStatus = contextObject.Doctors.Find(id);
            rejectStatus.Status = "Rejected";
            contextObject.SaveChanges();
            return RedirectToAction("DoctorDetails");
        }



    }
}