using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiagnosticMedicalCenter.Models;

namespace DiagnosticMedicalCenter.Controllers
{
    public class AgentRegistrationController : Controller
    {
        // GET: DoctorRegistration
        public ActionResult AgentRegistrationForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgentRegistrationForm(Agent agent, FormCollection formData)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ValidationMessage = "Please update the highlighted mandatory field(s). Also highlight the missed out field in red";
                return View();
            }
            else
            {
                DataBaseContext agentContext = new DataBaseContext();
                foreach (var item in agentContext.Agents)
                {
                    if (item.AgentId == Int32.Parse(formData["AgentId"]))
                    {
                        ViewBag.ValidationMessage = "Agent Id already exists.";
                    }
                }
                agentContext.Agents.Add(agent);
                agentContext.SaveChanges();
                ViewBag.ValidationMessage = "Your details are submitted succesfully.";
                return View();
            }
        }
    }
}