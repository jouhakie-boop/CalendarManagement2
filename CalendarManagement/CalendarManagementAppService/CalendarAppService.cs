using CalendarManagmentDataService;
using CalendarManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Sources;

namespace CalendarManagementAppService
{
    public class CalendarAppService
    {
        CalendarDataService calendarDataService = new CalendarDataService(new
            CalendarDBData());
        public void CreateReminder(Reminder newReminder)
        {
            Reminder reminder = new Reminder();
            reminder = newReminder;
            calendarDataService.Add(newReminder);
        }
        public void CreateEvent(Event newEvent)
        {
            Event ev = new Event();
            ev = newEvent;
            calendarDataService.Add(newEvent);
        }

        public Reminder ViewReminder(string reminder)
        {
          //  return calendarDataService.GetReminderById(ReminderId);
           return calendarDataService.GetReminder(reminder);
        }

        public void DeleteReminder(string name) => calendarDataService.DeleteReminder(name);


        public Event ViewEvent(string name) => calendarDataService.GetEvent(name);

        public void DeleteEvent(string name) => calendarDataService.DeleteEvent(name);

        public void UpdateReminder(string name, string date, string day, string time)
        {
            var updatedReminder = new Reminder { Name = name, Date = date, Day = day, Time = time };
            calendarDataService.UpdateReminder(name, updatedReminder);

        }
        public void UpdateEvent(string name, string date, string day, string time)
        {
            var updatedEvent = new Event { Name = name, Date = date, Day = day, Time = time };
            calendarDataService.UpdateEvent(name, updatedEvent);
            
        }
    }
    }