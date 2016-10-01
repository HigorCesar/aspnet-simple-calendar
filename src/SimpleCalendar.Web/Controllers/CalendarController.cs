using System.Web.Mvc;
using SimpleCalendar.Domain;
using SimpleCalendar.Web.Models;

namespace SimpleCalendar.Web.Controllers
{
    public class CalendarController : Controller
    {
        private readonly IAppointmentsRepository repository;

        public CalendarController(IAppointmentsRepository repository)
        {
            this.repository = repository;
        }
        public ActionResult Index()
        {
            var model = new CalendarViewModel();
            return View(model);
        }

        public ActionResult GetAppointments(int month)
        {
            var model = new AppointmentListViewModel(repository.Get((Month)month));
            return PartialView("Appointments", model);
        }
        public ActionResult GetAppointment(string id)
        {
            var model = new AppointmentDetailsViewModel(repository.Get(id));
            return PartialView("AppointmentDetails", model);
        }
    }
}