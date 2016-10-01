using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using SimpleCalendar.Domain;

namespace SimpleCalendar.Infrastructure
{
    public class AppointmentsInMemoryRepository : IAppointmentsRepository
    {
        private readonly ConcurrentBag<Appointment> appointments;

        public AppointmentsInMemoryRepository()
        {
            appointments = new ConcurrentBag<Appointment>();
        }

        public void Save(Appointment appointment)
        {
            appointments.Add(appointment);
        }

        public IEnumerable<Appointment> Get(Month month)
        {
            return appointments.Where(a => a.Month == month);
        }

        public Appointment Get(string id)
        {
            return appointments.FirstOrDefault(a => a.Id == id);
        }
    }
}
