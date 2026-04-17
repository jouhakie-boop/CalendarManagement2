using CalendarManagementModels;


namespace CalendarManagmentDataService
{
    public interface ICalendarDataService
    {
        void Add(Reminder reminder);
        Reminder? GetReminder();
        Reminder? GetReminderByName(string name);
        void UpdateReminder(Reminder reminder);
        void DeleteReminder(string reminderName);
        void RemoveReminder(string reminderName);
        Reminder? GetReminderById(Guid id);
        bool ReminderExists(string name);

        void Add(Event ev);
        Event? GetEvent();
        Event? GetEventByName(string name);
        void UpdateEvent(Event ev);
        void DeleteEvents(string reminerName);
        void RemoveEvent(string eventName);
        Event? GetEventById(Guid id);
        bool EventExists(string name);
        void Add(object newReminder);
        Event? GetEvent(string name);
    }
}
