using System;
using NUnit.Framework;
using SimpleCalendar.Domain;
using SimpleCalendar.Web.Models;

namespace SimpleCalendar.Tests.Unit.Web.Models
{
    public class AppointmentDetailsViewModelTests
    {
        public void Map()
        {
            var appointment = new Appointment(Month.October, DateTime.Now, "F# talk", "Higor") { Subject = "How to build a simple app in F#" };
            var target = new AppointmentDetailsViewModel(appointment);

            Assert.AreEqual(appointment.Id, target.Id);
            Assert.AreEqual(appointment.When, target.When);
            Assert.AreEqual(appointment.Organizer, target.Organizer);
            Assert.AreEqual(appointment.Description, target.Description);
            Assert.AreEqual(appointment.Subject, target.Subject);
            Assert.AreEqual(appointment.GetAttendees(), target.Attendees);

        }
    }
}
