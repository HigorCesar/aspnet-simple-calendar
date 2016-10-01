using System;
using NUnit.Framework;
using SimpleCalendar.Domain;
using SimpleCalendar.Web.Models;

namespace SimpleCalendar.Tests.Unit.Web.Models
{
    public class AppointmentViewModelTests
    {
        [Test]
        public void Map()
        {
            var bdayParty = new Appointment(Month.May, new DateTime(2016, 05, 10, 22, 0, 0), "Emanuelle`s bday", "Higor") { Subject = "Bday party" };

            var actual = new AppointmentViewModel(bdayParty);

            Assert.AreEqual(bdayParty.Id, actual.Id);
            Assert.AreEqual(bdayParty.When.ToString("MM/dd/yyyy hh:mm tt"), actual.When);
            Assert.AreEqual(bdayParty.Description, actual.Description);
        }
    }
}
