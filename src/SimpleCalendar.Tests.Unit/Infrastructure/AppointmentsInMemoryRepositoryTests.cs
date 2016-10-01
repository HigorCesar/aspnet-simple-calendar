using System;
using System.Linq;
using NUnit.Framework;
using SimpleCalendar.Domain;
using SimpleCalendar.Infrastructure;

namespace SimpleCalendar.Tests.Unit.Infrastructure
{
    public class AppointmentsInMemoryRepositoryTests
    {
        Appointment fsharpTalk;
        Appointment oktoberfest;
        Appointment bdayParty;

        [SetUp]
        public void Setup()
        {
            fsharpTalk = new Appointment(Month.October, DateTime.UtcNow, "F# talk", "Higor") { Subject = "How to build a simple app in F#" };
            oktoberfest = new Appointment(Month.October, DateTime.UtcNow, "Oktoberfest", "Higor") { Subject = "Oktoberfest" };
            bdayParty = new Appointment(Month.May, new DateTime(2016, 05, 10, 22, 0, 0), "Emanuelle`s bday", "Higor") { Subject = "Bday party" };
        }

        [Test]
        public void Save_adds_new_item()
        {
            var target = new AppointmentsInMemoryRepository();

            Assert.AreEqual(0, target.Get(Month.October).Count());

            target.Save(fsharpTalk);
            Assert.AreEqual(1, target.Get(Month.October).Count());

            target.Save(oktoberfest);
            Assert.AreEqual(2, target.Get(Month.October).Count());
        }

        [Test]
        public void GetByMonth_with_values()
        {
            var target = new AppointmentsInMemoryRepository();
            target.Save(fsharpTalk);
            target.Save(oktoberfest);

            var appointments = target.Get(Month.October).ToList();
            Assert.AreEqual(2, appointments.Count());
            Assert.Contains(fsharpTalk, appointments);
            Assert.Contains(oktoberfest, appointments);
        }

        [Test]
        public void GetByMonth_empty()
        {
            var target = new AppointmentsInMemoryRepository();

            var oktoberAppointments = target.Get(Month.October).ToList();
            Assert.IsEmpty(oktoberAppointments);
        }

        [Test]
        public void GetById_with_value()
        {
            var target = new AppointmentsInMemoryRepository();
            target.Save(fsharpTalk);

            var actual = target.Get(fsharpTalk.Id);
            Assert.AreEqual(fsharpTalk, actual);
        }
        [Test]
        public void GetById_no_value()
        {
            var target = new AppointmentsInMemoryRepository();

            var actual = target.Get(fsharpTalk.Id);
            Assert.IsNull(actual);
        }

    }
}
