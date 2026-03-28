using CalendarManagementAppService;
using CalendarManagementModels;
using CalendarManagmentDataService;
using System.Dynamic;

namespace CalendarManagementUI;

internal class Program
{
    public static ICalendarDataService myDataService = new CalendarJsonData();
    public void DataService(ICalendarDataService dataService)
    {
        myDataService = dataService;
    }
    static void Main(string[] args)
    {
        DateTime now = DateTime.Now;
        Console.WriteLine("Current Date and Time: " + now.ToString("MMMM dd yyyy, HH:mm:ss"));

        DisplayMenu();

        ICalendarDataService myDataService = new CalendarInMemory();
        var appService = new CalendarAppService(myDataService);

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
        Console.WriteLine("5. Update Reminder");
        Console.WriteLine("6. Update Event");
        Console.WriteLine("7. Delete Reminder");
        Console.WriteLine("8. Delete Event");
        Console.WriteLine("9. Exit");

        Console.Write("Enter your choice:");
        string input = Console.ReadLine();
        if (!int.TryParse(input, out int choice))
        {
            Console.WriteLine("Invalid choice. Please enter a number.");
            Console.WriteLine();
            DisplayMenu();
            return;
        }

        switch (choice)
        {
            case 1:
                CreateReminder();
                break;
            case 2:
                CreateEvent();
                break;
            case 3:
                ViewReminder();
                break;
            case 4:
                ViewEvent();
                break;
            case 5:
                UpdateReminder();
                break;
            case 6:
                UpdateEvent();
                break;
            case 7:
                DeleteReminder();
                break;
            case 8:
                DeleteEvent();
                break;
            case 9:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }

    private static void UpdateReminder()
    {
        throw new NotImplementedException();
    }

    private static void UpdateEvent()
    {
        throw new NotImplementedException();
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
        var appService = new CalendarAppService(myDataService); 
        appService.CreateReminder(name, date, day, time);
        Console.WriteLine("Reminder created successfully!");

        Console.WriteLine();
        DisplayMenu();
        Console.WriteLine();
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
        var appService = new CalendarAppService(myDataService);
        appService.CreateEvent(name, date, day, time);
        Console.WriteLine("Event created successfully!");

        Console.WriteLine();
        DisplayMenu();
        Console.WriteLine();
    }
    static void ViewReminder()
    {
        Console.WriteLine("Enter Reminder Name to View:");
        string name = Console.ReadLine();
        var appService = new CalendarAppService(myDataService);
        var reminder = appService.ViewReminder(name);
        if (reminder != null)
            Console.WriteLine($"Reminder: {reminder.Name} on {reminder.Date} at {reminder.Time}");
        else
            Console.WriteLine("Reminder not found.");

        Console.WriteLine();
        DisplayMenu();
        Console.WriteLine();
    }
    static void ViewEvent()
    {
        Console.WriteLine("Enter Event Name to View:");
        string name = Console.ReadLine();
        var appService = new CalendarAppService(myDataService);
        var ev = appService.ViewEvent(name);
        if (ev != null)
            Console.WriteLine($"Event: {ev.Name} on {ev.Date} at {ev.Time}");
        else
            Console.WriteLine("Event not found.");

        Console.WriteLine();
        DisplayMenu();
        Console.WriteLine();
    }
    static void DeleteReminder()
    {
        Console.WriteLine("Enter Reminder Name to Delete:");
        string name = Console.ReadLine();
        var appService = new CalendarAppService(myDataService);
        appService.DeleteReminder(name);
        Console.WriteLine("Reminder deleted successfully!");

        Console.WriteLine();
        DisplayMenu();
        Console.WriteLine();
    }
    static void DeleteEvent()
    {
        Console.WriteLine("Enter Event Name to Delete:");
        string name = Console.ReadLine();
        var appService = new CalendarAppService(myDataService);
        appService.DeleteEvent(name);
        Console.WriteLine("Event deleted successfully!");

        Console.WriteLine();
        DisplayMenu();
        Console.WriteLine();
    }
    static void UpdateReminder(Reminder reminder)
    {
        Console.WriteLine("Enter Reminder Name to Upgrade:");
        string name = Console.ReadLine();
        var manager = new CalendarAppService(myDataService);
        Console.WriteLine("Enter new Date (e.g., Feb 10, 2026):");
        string date = Console.ReadLine();
        Console.WriteLine("Enter new Day (e.g., Tuesday):");
        string day = Console.ReadLine();
        Console.WriteLine("Enter new Time (e.g., 9 AM):");
        string time = Console.ReadLine();

        var appService = new CalendarAppService(myDataService);
        appService.UpdateReminder(name, date, day, time);

        Console.WriteLine();
        DisplayMenu();
        Console.WriteLine();
    }
    static void UpdateEvent(Event ev)
    {
        Console.WriteLine("Enter Event Name to Upgrade:");
        string name = Console.ReadLine();
        ICalendarDataService myDataService = new CalendarInMemory();
        var appService = new CalendarAppService(myDataService); ;
        Console.WriteLine("Enter new Date (e.g., Feb 10, 2026):");
        string date = Console.ReadLine();
        Console.WriteLine("Enter new Day (e.g., Tuesday):");
        string day = Console.ReadLine();
        Console.WriteLine("Enter new Time (e.g., 9 AM):");
        string time = Console.ReadLine();
       
        appService.UpdateEvent(name, date, day, time);

        Console.WriteLine();
        DisplayMenu();
        Console.WriteLine();
    }

}


