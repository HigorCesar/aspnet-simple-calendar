
using System.Linq;
using NUnit.Framework;
using SimpleCalendar.Web.Models;

namespace SimpleCalendar.Tests.Unit.Web.Models
{
    public class CalendarViewModelTests
    {
        [Test]
        public void Ctor()
        {
            var actual = new CalendarViewModel();

            Assert.AreEqual(12, actual.Months.ToList().Count);
            Assert.IsNotNull(actual.Appointments);
            Assert.IsNull(actual.SelectedAppointment);
        }
    }
}
