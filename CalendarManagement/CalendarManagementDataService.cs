using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CalendarManagement.CalendarManagementModels;

namespace CalendarManagement
{
    // Data Layer for Storage
    // handles storage/retrieval
    internal class CalendarManagementDataService
    {
        public class CalendarRepository
        {
            public Dictionary<string, Reminder> Reminders { get; } = new();
            public Dictionary<string, Event> Events { get; } = new();

            public void AddReminder(Reminder reminder) => Reminders[reminder.Title] = reminder;
            public void AddEvent(Event ev) => Events[ev.Title] = ev;

            public Reminder GetReminder(string title) => Reminders.ContainsKey(title) ? Reminders[title] : null;
            public Event GetEvent(string title) => Events.ContainsKey(title) ? Events[title] : null;

            public void DeleteReminder(string title) => Reminders.Remove(title);
            public void DeleteEvent(string title) => Events.Remove(title);
        }

    }
}
