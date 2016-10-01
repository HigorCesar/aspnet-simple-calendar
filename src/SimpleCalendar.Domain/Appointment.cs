using System;
using System.Collections.Generic;

namespace SimpleCalendar.Domain
{
    public enum Month
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }

    public class Appointment
    {
        public string Id { get; }
        public Month Month { get; }
        public DateTime When { get; }
        public string Description { get; }
        public string Organizer { get; }
        public string Subject { get; set; }
        private readonly List<string> attendees;

        public Appointment(Month month, DateTime when, string description, string organizer)
        {
            Id = Guid.NewGuid().ToString("N");
            Month = month;
            When = when;
            Description = description;
            Organizer = organizer;
            attendees = new List<string>() { Organizer };
        }

        public void AddAttendee(string name)
        {
            attendees.Add(name);
        }

        public string[] GetAttendees()
        {
            return attendees.ToArray();
        }
    }
}
