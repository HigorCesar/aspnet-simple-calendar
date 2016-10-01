using System;
using System.Collections.Generic;
using System.Linq;
using SimpleCalendar.Domain;

namespace SimpleCalendar.Web.Models
{
    public class CalendarViewModel
    {
        public IEnumerable<MonthViewModel> Months { get; }
        public CalendarViewModel()
        {
            Months = Enum.GetValues(typeof(Month))
                     .Cast<Month>()
                     .ToList()
                     .Select(a => new MonthViewModel(a));

            Appointments = new AppointmentListViewModel(Enumerable.Empty<Appointment>());
        }

        public AppointmentListViewModel Appointments { get; set; }
        public AppointmentDetailsViewModel SelectedAppointment { get; set; }

    }
}