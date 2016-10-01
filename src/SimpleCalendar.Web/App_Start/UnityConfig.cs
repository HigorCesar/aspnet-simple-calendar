using System;
using Microsoft.Practices.Unity;
using SimpleCalendar.Domain;
using SimpleCalendar.Infrastructure;

namespace SimpleCalendar.Web
{
    public class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            var appointmentsRepository = new AppointmentsInMemoryRepository();

            var bday = new Appointment(Month.August, new DateTime(2016, 08, 2, 10, 00, 00), "Higor`s birthday", "Higor");
            bday.AddAttendee("Emanuelle");
            bday.AddAttendee("Hudson");

            var assessment = new Appointment(Month.October, new DateTime(2016, 10, 1, 16, 00, 00), "Assessment: build a simple calendar", "Higor");

            var strangerThings = new Appointment(Month.October, new DateTime(2016, 10, 1, 20, 00, 00), "watch stranger things", "Higor");
            strangerThings.AddAttendee("Emanuelle");

            appointmentsRepository.Save(bday);
            appointmentsRepository.Save(assessment);
            appointmentsRepository.Save(strangerThings);
            container.RegisterType<IAppointmentsRepository, AppointmentsInMemoryRepository>();
            container.RegisterInstance(typeof(IAppointmentsRepository), appointmentsRepository, new ExternallyControlledLifetimeManager());
        }
    }
}
