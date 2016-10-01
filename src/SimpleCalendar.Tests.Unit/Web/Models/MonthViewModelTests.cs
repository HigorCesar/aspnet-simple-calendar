using NUnit.Framework;
using SimpleCalendar.Domain;
using SimpleCalendar.Web.Models;

namespace SimpleCalendar.Tests.Unit.Web.Models
{
    public class MonthViewModelTests
    {
        public void Map()
        {
            var actual = new MonthViewModel(Month.August);

            Assert.AreEqual((int)Month.August, actual.Id);
            Assert.AreEqual(Month.August.ToString(), actual.Text);
        }
    }
}
