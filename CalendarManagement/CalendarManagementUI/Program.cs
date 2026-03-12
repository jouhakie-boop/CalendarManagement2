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
            //  manager.CreateReminder("Meeting", "Feb 10, 2026", "Tuesday", "9 AM");
            //  var reminder = manager.ViewReminder("Meeting");
            //  Console.WriteLine($"Reminder: {reminder.Name} on {reminder.Date} at {reminder.Time}");


        }
        static void DisplayMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Welcome to Calendar Management System!");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine("1. Create Reminder");
            Console.WriteLine("2. Create Event");
            Console.WriteLine("3. View Reminder");
            Console.WriteLine("4. View Event");
            Console.WriteLine("5. Delete Reminder");
            Console.WriteLine("6. Delete Event");
            Console.WriteLine("7. Exit");

            Console.WriteLine("Enter your choice:");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateReminder();
                    break;
                case "2":
                    CreateEvent();
                    break;
                case "3":
                    ViewReminder();
                    break;
                case "4":
                    ViewEvent();
                    break;
                case "5":
                    DeleteReminder();
                    break;
                case "6":
                    DeleteEvent();
                    break;
                case "7":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
        static void CreateReminder()
        {
            Console.WriteLine("Enter Reminder Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Date (e.g., Feb 10, 2026):");
            string date = Console.ReadLine();
            Console.WriteLine("Enter Day (e.g., Tuesday):");
            string day = Console.ReadLine();
            Console.WriteLine("Enter Time (e.g., 9 AM):");
            string time = Console.ReadLine();
            var manager = new CalendarAppService();
            manager.CreateReminder(name, date, day, time);
            Console.WriteLine("Reminder created successfully!");

        }
        static void CreateEvent()
        {
            Console.WriteLine("Enter Event Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Date (e.g., Feb 10, 2026):");
            string date = Console.ReadLine();
            Console.WriteLine("Enter Day (e.g., Tuesday):");
            string day = Console.ReadLine();
            Console.WriteLine("Enter Time (e.g., 9 AM):");
            string time = Console.ReadLine();
            var manager = new CalendarAppService();
            manager.CreateEvent(name, date, day, time);
            Console.WriteLine("Event created successfully!");
        }
        static void ViewReminder()
        {
            Console.WriteLine("Enter Reminder Name to View:");
            string name = Console.ReadLine();
            var manager = new CalendarAppService();
            var reminder = manager.ViewReminder(name);
            if (reminder != null)
                Console.WriteLine($"Reminder: {reminder.Name} on {reminder.Date} at {reminder.Time}");
            else
                Console.WriteLine("Reminder not found.");
        }
        static void ViewEvent()
        {
            Console.WriteLine("Enter Event Name to View:");
            string name = Console.ReadLine();
            var manager = new CalendarAppService();
            var ev = manager.ViewEvent(name);
            if (ev != null)
                Console.WriteLine($"Event: {ev.Name} on {ev.Date} at {ev.Time}");
            else
                Console.WriteLine("Event not found.");
        }
        static void DeleteReminder()
        {
            Console.WriteLine("Enter Reminder Name to Delete:");
            string name = Console.ReadLine();
            var manager = new CalendarAppService();
            manager.DeleteReminder(name);
            Console.WriteLine("Reminder deleted successfully!");
        }
        static void DeleteEvent()
        {
            Console.WriteLine("Enter Event Name to Delete:");
            string name = Console.ReadLine();
            var manager = new CalendarAppService();
            manager.DeleteEvent(name);
            Console.WriteLine("Event deleted successfully!");
        }

        }
}
