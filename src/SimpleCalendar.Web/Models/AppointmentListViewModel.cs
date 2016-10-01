using System.Collections.Generic;
using System.Linq;
using SimpleCalendar.Domain;

namespace SimpleCalendar.Web.Models
{
    public class AppointmentListViewModel
    {
        public IEnumerable<AppointmentViewModel> Appointments { get; set; }

        public AppointmentListViewModel(IEnumerable<Appointment> appointments)
        {
            Appointments = appointments.Select(a => new AppointmentViewModel(a));
        }
    }
}