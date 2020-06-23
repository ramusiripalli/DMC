using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiagnosticMedicalCenter.Models;

namespace DiagnosticMedicalCenter.Controllers
{
    public class AgentDetailsController : Controller
    {
        // GET: PatientDetails
        public ActionResult AgentDetails()
        {
            DataBaseContext contextObject = new DataBaseContext();
            List<Agent> agentsList = (from agents in contextObject.Agents select agents).ToList();
            return View(agentsList);
        }


        public ActionResult AcceptAgent(int id)
        {
            DataBaseContext contextObject = new DataBaseContext();
            var acceptStatus = contextObject.Agents.Find(id);
            acceptStatus.Status = "Accepted";
            contextObject.SaveChanges();
            return RedirectToAction("AgentDetails");
        }


        public ActionResult RejectPatient(int id)
        {
            DataBaseContext contextObject = new DataBaseContext();
            var rejectStatus = contextObject.Agents.Find(id);
            rejectStatus.Status = "Rejected";
            contextObject.SaveChanges();
            return RedirectToAction("AgentDetails");
        }



    }
}