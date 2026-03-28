using CalendarManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarManagmentDataService 
{
    public class CalendarInMemory : ICalendarDataService
    {
        Dictionary<string, Reminder> Dummyreminders = new Dictionary<string, Reminder>();
        Dictionary<string, Event> DummyEvents = new Dictionary<string, Event>();

        public CalendarInMemory()
        {
           Reminder TestReminder = new Reminder { ReminderId = Guid.NewGuid(), Name = "Test Reminder", Date = "Oct 7, 2026", Day = "Wednesday", Time = "12 PM" };
           Reminder TestRemider2 = new Reminder { ReminderId = Guid.NewGuid(), Name = "Test Reminder 2", Date = "Oct 8, 2026", Day = "Thursday", Time = "1 PM" };
           Reminder TestReminder3 = new Reminder { ReminderId = Guid.NewGuid(), Name = "Test Reminder 3", Date = "Oct 9, 2026", Day = "Friday", Time = "2 PM" };

            Event TestEvent = new Event { EventId = Guid.NewGuid(), Name = "Test Event", Date = "Oct 10, 2026", Day = "Saturday", Time = "3 PM" };
            Event TestEvent2 = new Event { EventId = Guid.NewGuid(), Name = "Test Event 2", Date = "Oct 11, 2026", Day = "Sunday", Time = "4 PM" };
            Event TestEvent3 = new Event { EventId = Guid.NewGuid(), Name = "Test Event 3", Date = "Oct 12, 2026", Day = "Monday", Time = "5 PM" };

            Dummyreminders.Add(TestReminder.Name, TestReminder);
            Dummyreminders.Add(TestRemider2.Name, TestRemider2);
            Dummyreminders.Add(TestReminder3.Name, TestReminder3);

            DummyEvents.Add(TestEvent.Name, TestEvent);
            DummyEvents.Add(TestEvent2.Name, TestEvent2);
            DummyEvents.Add(TestEvent3.Name, TestEvent3);
        }

        public void Add(Reminder reminder)
        {
            Dummyreminders.Add(reminder.Name, reminder);
        }
        public Reminder? GetReminderById(Guid id)
        {
            return Dummyreminders.Values.FirstOrDefault(r => r.ReminderId == id);
        }
        public Reminder? GetReminderByName(string name)
        {
          //  return Dummyreminders.ContainsKey(name) ? Dummyreminders[name] : null;
              return Dummyreminders.FirstOrDefault(r => r.Key == name).Value;
        }

        public Reminder? GetReminder()
        {
            return Dummyreminders.Values.FirstOrDefault();
        }

        public bool ReminderExists(string reminderName)
        {
          return Dummyreminders.Any(r => r.Key == reminderName);
        }

        public void UpdateReminder(Reminder reminder)
        {
            var existing = GetReminderById(reminder.ReminderId);
            if (existing != null)
            {
                existing.Name = reminder.Name;
                existing.Date = reminder.Date;
                existing.Day = reminder.Day;
                existing.Time = reminder.Time;
            }
        }

        public Dictionary<string, Reminder> GetAllReminders()
        {
            return Dummyreminders;
        }

        public void Add(Event ev)
        {
            DummyEvents.Add(ev.Name, ev);
        }
        public Event? GetEventById(Guid id)
        {
            return DummyEvents.Values.FirstOrDefault(e => e.EventId == id);
        }   

        public Event? GetEvent(string name)
        {
            return DummyEvents.ContainsKey(name) ? DummyEvents[name] : null;
        }


        public Event? GetEventByName(string name)
        {
           return DummyEvents.FirstOrDefault(e => e.Key == name).Value;
        }

        public bool EventExists(string eventName)
        {
           return DummyEvents.Any(e => e.Key == eventName);
        }

        public void UpdateEvent(Event ev)
        {
            var existing = GetEventById(ev.EventId);
            if (existing != null)
            {
               existing.Name = ev.Name;
               existing.Date = ev.Date;
               existing.Day = ev.Day;
               existing.Time = ev.Time;
            }
        }

        public Dictionary<string, Event> GetAllEvents()
        {
            return DummyEvents;
        }

        public void Remove(string name)
        {
            throw new NotImplementedException();
        }

        public void DeleteReminder(Reminder reminder)
        {
            throw new NotImplementedException();
        }

        public void DeleteEvents(Event ev)
        {
            throw new NotImplementedException();
        }

        void ICalendarDataService.Add(Reminder reminder)
        {
            throw new NotImplementedException();
        }

        Reminder? ICalendarDataService.GetReminder()
        {
            throw new NotImplementedException();
        }

        Reminder? ICalendarDataService.GetReminderByName(string name)
        {
            throw new NotImplementedException();
        }

        void ICalendarDataService.UpdateReminder(Reminder reminder)
        {
            throw new NotImplementedException();
        }

        void ICalendarDataService.DeleteReminder(Reminder reminder)
        {
            throw new NotImplementedException();
        }

        Reminder? ICalendarDataService.GetReminderById(Guid id)
        {
            return Dummyreminders.FirstOrDefault(r => r.Value.ReminderId == id).Value;
        }

        bool ICalendarDataService.ReminderExists(string name)
        {
            return Dummyreminders.Any(r => r.Key == name);
        }

        void ICalendarDataService.Add(Event ev)
        {
            DummyEvents.Add(ev.Name, ev);
        }

        Event? ICalendarDataService.GetEvent(string name)
        {
            throw new NotImplementedException();
        }

        Event? ICalendarDataService.GetEventByName(string name)
        {
            throw new NotImplementedException();
        }

        void ICalendarDataService.UpdateEvent(Event ev)
        {
            throw new NotImplementedException();
        }

        void ICalendarDataService.DeleteEvents(Event ev)
        {
            throw new NotImplementedException();
        }

        void ICalendarDataService.Remove(string name)
        {
            throw new NotImplementedException();
        }

        Event? ICalendarDataService.GetEventById(Guid id)
        {
            return DummyEvents.FirstOrDefault(r => r.Value.EventId == id).Value;
        }

        bool ICalendarDataService.EventExists(string name)
        {
            return DummyEvents.Any(e => e.Key == name);
        }
    }
}
