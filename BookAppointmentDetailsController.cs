﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiagnosticMedicalCenter.Models;

namespace DiagnosticMedicalCenter.Controllers
{
    public class BookAppointmentDetailsController : Controller
    {
        // GET: BookAppointmentDetails
        public ActionResult bookAppointmentDetails()
        {
            DBContext contextObject = new DBContext();
            List<BookAppointment> bookAppointmentsList = (from bookAppointments in contextObject.BookAppointments select bookAppointments).ToList();
            return View(bookAppointmentsList);
        }


        public ActionResult AcceptBookAppointment(string Text)
        {
            DBContext contextObject = new DBContext();
            var acceptStatus = contextObject.BookAppointments.Find(Text);
            acceptStatus.Status = "Approved";
            contextObject.SaveChanges();
            return RedirectToAction("bookAppointmentDetails");
        }


        public ActionResult RejectBookAppointment(string Text)
        {
            DBContext contextObject = new DBContext();
            var rejectStatus = contextObject.BookAppointments.Find(Text);
            rejectStatus.Status = "Rejected";
            contextObject.SaveChanges();
            return RedirectToAction("bookAppointmentDetails");
        }
    }
}