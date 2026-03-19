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
        private readonly CalendarDataService repo = new();

        public void CreateReminder(string name, string date, string day, string time)
        {
            var reminder = new Reminder { Name = name, Date = date, Day = day, Time = time };
            repo.AddReminder(reminder);
        }
        public void CreateReminder2(string name, DateTime start, TimeSpan duration, int priority = 0)
        {
            var reminder2 = new Reminder
            {
                Name = name,
                Start = start,
                Duration = duration,
                Priority = priority,
                Date = start.ToString("MMM d, yyyy"),
                Time = start.ToString("h:mm tt"),
                Day = start.DayOfWeek.ToString()
            };
            repo.AddReminder(reminder2);
        }

     //  private Reminder Reminders2 = new Reminder();
        public Reminder ViewReminder(string name) => repo.GetReminder(name);

        public void DeleteReminder(string name) => repo.DeleteReminder(name);


        public void CreateEvent(string name, string date, string day, string time)
        { 
            var ev = new Event { Name = name, Date = date, Day = day, Time = time };
            repo.AddEvent(ev);
        }

        public void CreateEvent(string name, DateTime start, TimeSpan duration, int priority = 0)
        {
            var ev = new Event
            {
                Name = name,
                Start = start,
                Duration = duration,
                Priority = priority,
                Date = start.ToString("MMM d, yyyy"),
                Time = start.ToString("h:mm tt"),
                Day = start.DayOfWeek.ToString()
            };
            repo.AddEvent(ev);
        }

        public Event ViewEvent(string name) => repo.GetEvent(name);

        public void DeleteEvent(string name) => repo.DeleteEvent(name);

        public void UpdateReminder(string name, string date, string day, string time)
        {
            var updatedReminder = new Reminder { Name = name, Date = date, Day = day, Time = time };
            repo.UpdateReminder(name, updatedReminder);
        }
        //public void UpdateReminder(string name, DateTime start, TimeSpan duration, int priority = 0)
        //{
        //    var updatedReminder = new Reminder
        //    {
        //        Name = name,
        //        Start = start,
        //        Duration = duration,
        //        Priority = priority,
        //        Date = start.ToString("MMM d, yyyy"),
        //        Time = start.ToString("h:mm tt"),
        //        Day = start.DayOfWeek.ToString()
        //    };
        //    repo.UpdateReminder(name, updatedReminder);
        //}
        public void UpdateEvent(string name, string date, string day, string time)
        {
            var updatedEvent = new Event { Name = name, Date = date, Day = day, Time = time };
            repo.UpdateEvent(name, updatedEvent);
        }
        //public void UpdateEvent(string name, DateTime start, TimeSpan duration, int priority = 0)
        //{
        //    var updatedEvent = new Event
        //    {
        //        Name = name,
        //        Start = start,
        //        Duration = duration,
        //        Priority = priority,
        //        Date = start.ToString("MMM d, yyyy"),
        //        Time = start.ToString("h:mm tt"),
        //        Day = start.DayOfWeek.ToString()
        //    };
        //    repo.UpdateEvent(name, updatedEvent);
        //}

        public List<Event> GetAllEvents() => repo.GetAllEvents();
        public List<Reminder> GetAllReminders() => repo.GetAllReminders();

        public List<(Event a, Event b)> FindConflicts()
        {
            var detector = new ConflictDetector(repo);
            return detector.FindConflicts();
        }

        public RescheduleResult TryRescheduleEvent(string eventName, TimeSpan increment, int maxAttempts = 48)
        {
            var ev = repo.GetEvent(eventName);
            if (ev == null)
                return new RescheduleResult { Success = false, Message = "Event not found." };

            var detector = new ConflictDetector(repo);
            return detector.TryReschedule(ev, increment, maxAttempts);
        }


    }
}
