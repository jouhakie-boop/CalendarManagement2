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

        public void CreateReminder(string name, string date, string day, string time)
        {
            var reminder = new Reminder { Name = name, Date = date, Day = day, Time = time };
            calendarDataService.AddReminder(reminder);

        }
        public Reminder ViewReminder(string name) => calendarDataService.GetReminder(name);

        public void DeleteReminder(string name) => calendarDataService.DeleteReminder(name);


        public void CreateEvent(string name, string date, string day, string time)
        {
            var ev = new Event { Name = name, Date = date, Day = day, Time = time };
            calendarDataService.AddEvent(ev);
        }
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