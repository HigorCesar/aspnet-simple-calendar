using SimpleCalendar.Domain;

namespace SimpleCalendar.Web.Models
{
    public class MonthViewModel
    {
        public string Text { get; }
        public int Id { get; }

        public MonthViewModel(Month month)
        {
            Text = month.ToString();
            Id = (int)month;
        }
    }
}