using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiagnosticMedicalCenter.Models;

namespace DiagnosticMedicalCenter.Controllers
{
    public class ViewDoctorDetailsController : Controller
    {
        // GET: ViewDoctorDetails
        public ActionResult viewDoctorDetails()
        {
            DataBaseContext contextObject = new DataBaseContext();
            List<Doctor> viewDoctorList = (from doctors in contextObject.Doctors select doctors).ToList();
            return View(viewDoctorList);
        }
    }
}