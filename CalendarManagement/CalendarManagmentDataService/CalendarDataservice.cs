using System.Collections.Generic;
using CalendarManagementModels;

namespace CalendarManagmentDataService
{
    public class CalendarDataService
    {
        private Dictionary<string, Reminder> reminders = new();
        private Dictionary<string, Event> events = new();

        public void AddReminder(Reminder reminder) => reminders[reminder.Name] = reminder;
        public Reminder GetReminder(string name) => reminders.ContainsKey(name) ? reminders[name] : null;
        public void DeleteReminder(string name) => reminders.Remove(name);

        public void AddEvent(Event ev) => events[ev.Name] = ev;
        public Event GetEvent(string name) => events.ContainsKey(name) ? events[name] : null;
        public void DeleteEvent(string name) => events.Remove(name);
        public void UpdateReminder(string name, Reminder updatedReminder)
        {
            if (reminders.ContainsKey(name))
            {
                reminders[name] = updatedReminder;
            }
        }
        public void UpdateEvent(string name, Event updatedEvent)
        {
            if (events.ContainsKey(name))
            {
                events[name] = updatedEvent;
            }
        }
    }
}
