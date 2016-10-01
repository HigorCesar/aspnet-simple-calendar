using System.Collections.Generic;

namespace SimpleCalendar.Domain
{
    public interface IAppointmentsRepository
    {
        void Save(Appointment appointment);
        IEnumerable<Appointment> Get(Month month);
        Appointment Get(string id);
    }
}
