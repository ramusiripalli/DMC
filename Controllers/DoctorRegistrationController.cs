using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiagnosticMedicalCenter.Models;

namespace DiagnosticMedicalCenter.Controllers
{
    public class DoctorRegistrationController : Controller
    {
        // GET: DoctorRegistration
        public ActionResult DoctorRegistrationForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoctorRegistrationForm(Doctor doctor, FormCollection formData)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ValidationMessage = "Please update the highlighted mandatory field(s). Also highlight the missed out field in red";
                return View();
            }
            else
            {
                DataBaseContext doctorContext = new DataBaseContext();
                foreach (var item in doctorContext.Doctors)
                {
                    if (item.DoctorId == Int32.Parse(formData["DoctorId"]))
                    {
                        ViewBag.ValidationMessage = "Doctor Id already exists.";
                    }
                }
                doctorContext.Doctors.Add(doctor);
                doctorContext.SaveChanges();
                ViewBag.ValidationMessage = "Your details are submitted succesfully.";
                return View();
            }
        }
    }
}