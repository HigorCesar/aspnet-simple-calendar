using SimpleCalendar.Domain;

namespace SimpleCalendar.Web.Models
{
    public class AppointmentViewModel
    {
        public string Id { get; set; }
        public string When { get; set; }
        public string Description { get; set; }

        public AppointmentViewModel(Appointment appointment)
        {
            Id = appointment.Id;
            When = appointment.When.ToString("MM/dd/yyyy hh:mm tt");
            Description = appointment.Description;
        }
    }
}