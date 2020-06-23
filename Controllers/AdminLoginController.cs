using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiagnosticMedicalCenter.Models;

namespace DiagnosticMedicalCenter.Controllers
{
    public class AdminLoginController : Controller
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
                DataBaseContext adminLogin = new DataBaseContext();
                foreach (var item in adminLogin.Admins)
                {
                    if ((item.VendorId == userId) && (item.Password == password))
                    {
                        Session["UserId"] = item.VendorId;
                        Session["Password"] = item.Password;

                        return RedirectToAction("AdminHomePage");
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
        public ActionResult AdminHomePage(Admin admin)
        {
            if ((Session["UserId"] != null) || (Session["Password"] != null))
            {
                ViewBag.ValidationMessage = "Login Success";
                return View("AdminHomePage");
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
    }
}