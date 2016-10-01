using System;
using NUnit.Framework;
using SimpleCalendar.Domain;

namespace SimpleCalendar.Tests.Unit.Domain
{
    public class AppointmentTests
    {
        [Test]
        public void Ctor()
        {
            var someDate = new DateTime(2016, 10, 01, 20, 00, 00);
            var target = new Appointment(Month.October, someDate, "F# talk", "Higor") { Subject = "How to build a simple app in F#" };

            Assert.AreEqual(Month.October, target.Month);
            Assert.AreEqual(someDate, target.When);
            Assert.AreEqual("F# talk", target.Description);
            Assert.AreEqual("Higor", target.Organizer);
            Assert.AreEqual("How to build a simple app in F#", target.Subject);
            Assert.Contains("Higor", target.GetAttendees());
        }

        public void AddAttendee()
        {
            var target = new Appointment(Month.October, DateTime.Now, "F# talk", "Higor") { Subject = "How to build a simple app in F#" };
            target.AddAttendee("Emanuelle");
            target.AddAttendee("Marcelo");

            var attemdees = target.GetAttendees();

            Assert.AreEqual(3, attemdees.Length);
            Assert.Contains("Higor", attemdees);
            Assert.Contains("Emanuelle", attemdees);
            Assert.Contains("Marcelo", attemdees);
        }
    }
}
