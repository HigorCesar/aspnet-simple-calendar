using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using SimpleCalendar.Domain;
using SimpleCalendar.Web.Controllers;
using SimpleCalendar.Web.Models;

namespace SimpleCalendar.Tests.Unit.Web
{
    public class CalendarControllerTests
    {
        [Test]
        public void Index()
        {
            var repository = new Mock<IAppointmentsRepository>();
            var target = new CalendarController(repository.Object);
            var actual = (ViewResult)target.Index();

            Assert.IsNotNull(actual.Model);
        }

        [Test]
        public void GetAppointments()
        {
            var oktoberfest = new Appointment(Month.October, DateTime.UtcNow, "Oktoberfest", "Higor") { Subject = "Oktoberfest" };
            var repository = new Mock<IAppointmentsRepository>();
            repository.Setup(x => x.Get(Month.August)).Returns(new List<Appointment> { oktoberfest });

            var target = new CalendarController(repository.Object);
            var actual = (PartialViewResult)target.GetAppointments((int)Month.August);

            repository.Verify(r => r.Get(Month.August), Times.Once);

            Assert.IsNotNull(actual.Model);

            var model = (AppointmentListViewModel)actual.Model;

            Assert.AreEqual(1, model.Appointments.Count());
        }

        [Test]
        public void GetAppointment()
        {
            var oktoberfest = new Appointment(Month.October, DateTime.UtcNow, "Oktoberfest", "Higor") { Subject = "Oktoberfest" };
            var repository = new Mock<IAppointmentsRepository>();
            repository.Setup(x => x.Get(oktoberfest.Id)).Returns(oktoberfest);

            var target = new CalendarController(repository.Object);
            var actual = (PartialViewResult)target.GetAppointment(oktoberfest.Id);

            repository.Verify(r => r.Get(oktoberfest.Id), Times.Once);

            Assert.IsNotNull(actual.Model);

            var model = (AppointmentDetailsViewModel)actual.Model;

            Assert.AreEqual(oktoberfest.Id, model.Id);
        }

    }
}
