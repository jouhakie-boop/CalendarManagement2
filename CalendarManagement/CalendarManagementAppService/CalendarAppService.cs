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
            CalendarJsonData());

        public bool CreateReminder(Reminder newReminder)
        {
            if (calendarDataService.ReminderExists(newReminder.Name))
            {
                Console.WriteLine("A reminder with the same name already exists. Please choose a different name.");
                return false;
            }

             calendarDataService.Add(newReminder);
            return true;

        }
        public Reminder ViewReminder(Guid ReminderId)
        {
            return calendarDataService.GetReminderById(ReminderId);
          // return calendarDataService.GetReminder(name);
        }

        public void DeleteReminder(string name) => calendarDataService.DeleteReminder(name);


        public bool CreateEvent(Event newEvent)
        {
            if (calendarDataService.EventExists(newEvent.Name))
            {
                Console.WriteLine("A event with the same name already exists. Please choose a different name.");
                return false;
            }
           
            calendarDataService.Add(newEvent);
            return true;
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