using CalendarManagementModels;
using CalendarManagmentDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Sources;
using System.Reflection.Metadata.Ecma335;

namespace CalendarManagementAppService
{
    public class CalendarAppService
    {
        CalendarDataService calendarDataService = new CalendarDataService(new
            CalendarDBData());

        EmailService emailService = new EmailService();



        public bool CreateReminder(Reminder newReminder)
        {
            try
            {
                calendarDataService.Add(newReminder);

                try
                {
                    emailService.SendEmail(newReminder.Name, "Reminder", newReminder.Date, newReminder.Day, newReminder.Time);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Reminder saved, but email notification failed: {ex.Message}");
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public void CreateEvent(Event newEvent)
        {
            Event ev = new Event();
            ev = newEvent;
            calendarDataService.Add(newEvent);

            try
            {
                emailService.SendEmail(newEvent.Name, "Event", newEvent.Date, newEvent.Day, newEvent.Time);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Event saved, but email notification failed: {ex.Message}");
            }
        }

        public Reminder ViewReminder(string reminder)
        {
            //  return calendarDataService.GetReminderById(ReminderId);
            return calendarDataService.GetReminder(reminder);
        }
        public List<Reminder> ViewAllReminders()
        {
            return calendarDataService.GetReminderses();
        }



        public void DeleteReminder(string name) => calendarDataService.DeleteReminder(name);


        public Event ViewEvent(string name) => calendarDataService.GetEvent(name);

        public void DeleteEvent(string name) => calendarDataService.DeleteEvent(name);

        public void UpdateReminder(string name, Reminder reminder)
        {
            calendarDataService.UpdateReminder(name, reminder);
        }
        public void UpdateEvent(string name, string date, string day, string time)
        {
            var updatedEvent = new Event { Name = name, Date = date, Day = day, Time = time };
            calendarDataService.UpdateEvent(name, updatedEvent);

        }





    }

}