using CalendarManagementModels;

namespace CalendarManagmentDataService
{
    public interface ICalendarDataService
    {
        void AddEvent(Event ev);
        void AddReminder(Reminder reminder);
        void DeleteEvent(string name);
        void DeleteReminder(string name);
        List<Event> GetAllEvents();
        List<Reminder> GetAllReminders();
        Event GetEvent(string name);
        Reminder GetReminder(string name);
        void UpdateEvent(string name, Event updatedEvent);
        void UpdateReminder(string name, Reminder updatedReminder);
    }
}