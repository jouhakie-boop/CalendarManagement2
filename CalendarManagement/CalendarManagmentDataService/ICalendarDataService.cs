using CalendarManagementModels;


namespace CalendarManagmentDataService
{
    public interface ICalendarDataService
    {
        void Add(Reminder reminder);
        Reminder? GetReminder();
        Reminder? GetReminderByName(string name);
        void UpdateReminder(Reminder reminder);
        void DeleteReminder(Reminder reminder);
        Reminder? GetReminderById(Guid id);
        bool ReminderExists(string name);

        void Add(Event ev);
        Event? GetEvent(string name);
        Event? GetEventByName(string name);
        void UpdateEvent(Event ev); 
        void DeleteEvents(Event ev);
        void Remove(string name);
        Event? GetEventById(Guid id);
        bool EventExists(string name);
    }
}