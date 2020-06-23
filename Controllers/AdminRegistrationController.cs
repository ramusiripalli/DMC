using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiagnosticMedicalCenter.Models;
using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;

namespace DiagnosticMedicalCenter.Controllers
{
    public class AdminRegistrationController : Controller
    {
        // GET: PatientRegistration
        public ActionResult AdminRegistrationForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminRegistrationForm(Admin admin, FormCollection formData)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ValidationMessage = "Please update the highlighted mandatory field(s).Also highlight the missed out field in red";
                return View();
            }
            else
            {
                DataBaseContext adminRegistration = new DataBaseContext();
                foreach (var item in adminRegistration.Admins)
                {
                    if (item.VendorId == Int32.Parse(formData["VendorId"]))
                    {
                        ViewBag.ValidationMessage = "Vendor Id already exists.";
                    }
                }
                adminRegistration.Admins.Add(admin);
                adminRegistration.SaveChanges();
                ViewBag.ValidationMessage = "Your details are submitted succesfully.";
                return View();
            }
        }
    }
}