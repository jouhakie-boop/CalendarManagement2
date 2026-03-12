using CalendarManagementAppService;

namespace CalendarManagementUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            Console.WriteLine("Current Date and Time: " + now.ToString("MMMM dd yyyy, HH:mm:ss"));

            //  DisplayMenu();

            var manager = new CalendarAppService();
            manager.CreateReminder("Meeting", "Feb 10, 2026", "Tuesday", "9 AM");
            var reminder = manager.ViewReminder("Meeting");
            Console.WriteLine($"Reminder: {reminder.Name} on {reminder.Date} at {reminder.Time}");


        }
    }
}
