using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;
using CalendarManagementModels;

namespace CalendarManagmentDataService
{
    public class CalendarDataService
    {
        ICalendarDataService _dataService;
        private Dictionary<string, Event> events = new Dictionary<string, Event>();
        private Dictionary<string, Reminder> reminders = new Dictionary<string, Reminder>();

        public CalendarDataService(ICalendarDataService calendarDataService)
        {

            _dataService = calendarDataService;
        }


        public void Add(Reminder reminder)
        {
            _dataService.Add(reminder);
          //  _dataService.Add(newReminder);
        }
        public Reminder? GetReminderById(Guid id)
        {
            return _dataService.GetReminderById(id);
        }
        public Reminder GetReminder(string name)
        {
            return _dataService.GetReminderByName(name);
        }
        public bool ReminderExists(string name)
        {
            return _dataService.ReminderExists(name);
        }

        public void DeleteReminder(string name) => _dataService.Remove(name);



        public void Add(Event ev) => _dataService.Add(ev);
        public Event? GetEventById(Guid id) => _dataService.GetEventById(id);
        public Event GetEvent(string name) => _dataService.GetEventByName(name);
        public bool EventExists(string name) => _dataService.EventExists(name);
        public void DeleteEvent(string name) => _dataService.Remove(name);
        public void UpdateReminder(string name, Reminder reminder) => _dataService.UpdateReminder(reminder);

        public void UpdateEvent(string name, Event updatedEvent) => _dataService.UpdateEvent(updatedEvent);


    }
}
