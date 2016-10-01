using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SimpleCalendar.Domain;
using SimpleCalendar.Web.Models;

namespace SimpleCalendar.Tests.Unit.Web.Models
{
    public class AppointmentListViewModelTests
    {
        [Test]
        public void Map_empty()
        {
            var target = new AppointmentListViewModel(Enumerable.Empty<Appointment>());
            Assert.IsEmpty(target.Appointments);
        }

        [Test]
        public void Map_with_values()
        {
            var oktoberfest = new Appointment(Month.October, DateTime.UtcNow, "Oktoberfest", "Higor") { Subject = "Oktoberfest" };
            var bdayParty = new Appointment(Month.May, new DateTime(2016, 05, 10, 22, 0, 0), "Emanuelle`s bday", "Higor") { Subject = "Bday party" };

            var target = new AppointmentListViewModel(new List<Appointment> { oktoberfest, bdayParty });

            var appointments = target.Appointments.ToList();

            Assert.AreEqual(2, appointments.Count());
        }
    }
}
