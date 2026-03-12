
using CalendarManagementDataService;
using CalendarManagementModels;


namespace CalendarManagementAppService
{
    public class CalendarAppService
    {
        private readonly CalendarDataService repo = new CalendarDataService();

        public void CreateReminder(string name, string date, string day, string time)
        {
            var reminder = new Reminder { Name = name, Date = date, Day = day, Time = time };
            repo.AddReminder(reminder);
        }

        public Reminder ViewReminder(string name) => repo.GetReminder(name);

        public void DeleteReminder(string name) => repo.DeleteReminder(name);


        public void CreateEvent(string name, string date, string day, string time)
        {
            var ev = new Event { Name = name, Date = date, Day = day, Time = time };
            repo.AddEvent(ev);
        }

        public Event ViewEvent(string name) => repo.GetEvent(name);

        public void DeleteEvent(string name) => repo.DeleteEvent(name);


    }
}
