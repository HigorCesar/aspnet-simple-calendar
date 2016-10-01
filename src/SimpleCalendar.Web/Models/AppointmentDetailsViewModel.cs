using SimpleCalendar.Domain;

namespace SimpleCalendar.Web.Models
{
    public class AppointmentDetailsViewModel
    {
        public string Id { get; set; }
        public string When { get; set; }
        public string Description { get; set; }
        public string Organizer { get; set; }
        public string Subject { get; set; }
        public string[] Attendees { get; set; }
        public AppointmentDetailsViewModel(Appointment appointment)
        {
            Id = appointment.Id;
            When = appointment.When.ToString("MM/dd/yyyy hh:mm tt");
            Organizer = appointment.Organizer;
            Description = appointment.Description;
            Subject = appointment.Subject;
            Attendees = appointment.GetAttendees();
        }
    }
}