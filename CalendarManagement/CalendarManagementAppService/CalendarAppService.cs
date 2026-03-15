using CalendarManagementModels;
using CalendarManagmentDataService;


namespace CalendarManagementAppService
{
    public class CalendarAppService
    {
        private readonly CalendarDataService repo = new();

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

        public void UpdateReminder(string name, string date, string day, string time)
        {
            var updatedReminder = new Reminder { Name = name, Date = date, Day = day, Time = time };
            repo.UpdateReminder(name, updatedReminder);
        }
        public void UpdateEvent(string name, string date, string day, string time)
        {
            var updatedEvent = new Event { Name = name, Date = date, Day = day, Time = time };
            repo.UpdateEvent(name, updatedEvent);
        }


    }
}
