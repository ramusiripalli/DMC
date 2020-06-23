using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiagnosticMedicalCenter.Models;

namespace DiagnosticMedicalCenter.Controllers
{
    public class AgentLoginController : Controller
    {
        // GET: AgentLogin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection formData)
        {
            if ((formData["UserId"] == null) || (formData["UserId"] == "") || (formData["UserId"] == " "))
            {
                ViewBag.ValidationMessage = "User Id cannot be blank.";
            }
            else if ((formData["Password"] == null) || (formData["Password"] == "") || (formData["Password"] == " "))
            {
                ViewBag.ValidationMessage = "Password cannot be blank.";
            }
            else
            {
                int userId = Convert.ToInt32(formData["UserId"]);
                string password = formData["Password"];
                DataBaseContext AgentLogin = new DataBaseContext();
                foreach (var item in AgentLogin.Agents)
                {
                    if ((item.AgentId == userId) && (item.Password == password) && (item.Status == "Accepted"))
                    {
                        Session["UserId"] = item.AgentId;
                        Session["Password"] = item.Password;

                        return RedirectToAction("AgentHomePage");
                    }
                    else
                    {
                        ViewBag.ValidationMessage = "Invalid User Id (or) Incorrect Password(or) The Request is Pending with Admin.";

                    }
                }
            }
            return View("Login");
        }
        public ActionResult AgentHomePage()
        {
            if ((Session["UserId"] != null) || (Session["Password"] != null))
            {
                ViewBag.ValidationMessage = "Login Success";
                return View("AgentHomePage");
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
    }
}