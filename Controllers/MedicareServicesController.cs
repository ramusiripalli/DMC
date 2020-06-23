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
    public class MedicareServicesController : Controller
    {
        // GET: MedicareServices
        public ActionResult MedicareServicesForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MedicareServicesForm(MedicareServices medicare, FormCollection formData)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ValidationMessage = "Please update the highlighted mandatory field(s)";
                return View();
            }
            else
            {
                DataBaseContext medicareServices = new DataBaseContext();
                foreach (var item in medicareServices.MedicareServices)
                {
                    if (item.MedicareId == Int32.Parse(formData["MedicareId"]))
                    {
                        ViewBag.ValidationMessage = "Medicare Id already exists.";
                    }
                }
                medicareServices.MedicareServices.Add(medicare);
                medicareServices.SaveChanges();
                ViewBag.ValidationMessage = "Your details are submitted succesfully.";
                return View();
            }
        }



    }
}