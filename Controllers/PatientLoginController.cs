using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiagnosticMedicalCenter.Models;

namespace DiagnosticMedicalCenter.Controllers
{
    public class PatientLoginController : Controller
    {
        // GET: PatientLogin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection formData)
        {
           
            if ((formData["UserId"] == null) || (formData["UserId"] == ""))
            {
                ViewBag.ValidationMessage = "User Id cannot be blank.";
            }
            else if ((formData["Password"] == null) || (formData["Password"] == ""))
            {
                ViewBag.ValidationMessage = "Password cannot be blank.";
            }
            else
            {
                int userId = Convert.ToInt32(formData["UserId"]);
                string password = formData["Password"];
                DataBaseContext patientLogin = new DataBaseContext();
                foreach (var item in patientLogin.Patients)
                {
                    if ((item.PatientId == userId) && (item.Password == password) && (item.Status == "Accepted"))
                    {
                        Session["UserId"] = item.PatientId;
                        Session["Password"] = item.Password;

                        return RedirectToAction("PatientHome");
                    }
                    else
                    {
                        ViewBag.ValidationMessage = "Invalid User Id (or) Incorrect Password.";
                        return View("Login");
                    }

                }
            }
            
            return View();
        }
        public ActionResult PatientHome(Patient patient)
        {
            if ((Session["UserId"] != null) || (Session["Password"] != null))
            {
                ViewBag.ValidationMessage = "Login Success";
                return View("PatientHome");
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
    }
}