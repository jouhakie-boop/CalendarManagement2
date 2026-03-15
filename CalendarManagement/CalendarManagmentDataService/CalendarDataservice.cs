using CalendarManagementModels;

namespace CalendarManagmentDataService
{
    public class CalendarDataService
    {
        private Dictionary<string, Reminder> reminders = new();
        private Dictionary<string, Reminder> reminders = new();

        public void AddReminder(Reminder reminder) => reminders[reminder.ReminderName] = reminder;
        public Reminder GetReminder(string name) => reminders.ContainsKey(name) ? reminders[name] : null;
        public void DeleteReminder(string name) => reminders.Remove(name);

        public void AddEvent(Event ev) => events[ev.EventName] = ev;
        public event GetEvent(string name) => events.ContainsKey(name) ? events[name] : null;
        public void DeleteEvent(string name) => events.Remove(name);


    }
}
