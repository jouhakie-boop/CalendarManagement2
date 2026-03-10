using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CalendarManagement.CalendarManagementModels;
using static CalendarManagement.CalendarManagementDataService;



namespace CalendarManagement
{
    // behavior lang (logic) UI
    // your Program.cs and menu logic
    internal class CalendarManagementAppService
    {
        static void Main(string[] args)
        {
            DisplayMenu();
        }
        static void DisplayMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Welcome to Calendar Management System!");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine("1. Create Reminder");
            Console.WriteLine("2. Create Event");
            Console.WriteLine("3. View Reminders");
            Console.WriteLine("4. View Events");
            Console.WriteLine("5. Update Reminder");
            Console.WriteLine("6. Update Event");
            Console.WriteLine("7. Delete Reminder");
            Console.WriteLine("8. Delete Event");
            Console.WriteLine("9. Exit");
            Console.WriteLine();

            Console.Write("Please select an option: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1) { CreateReminder(); }

         //   else if (choice == 2) { CreateEvent(); }

         //   else if (choice == 3) { ViewReminders(); }

         //   else if (choice == 4) { ViewEvents(); }

         //   else if (choice == 5) { UpdateReminder(); }

         //  else if (choice == 6) { UpdateEvent(); }

         //   else if (choice == 7) { DeleteReminder(); }

         //   else if (choice == 8) { DeleteEvent(); }

            else if (choice == 9)
            {
                Console.WriteLine("Exiting the Calendar Management System. Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select a valid option.");
            }
        }

        static void CreateReminder()
        {
            Console.Write("Enter Reminder Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Date: ");
            string date = Console.ReadLine();
            Console.Write("Enter Day: ");
            string day = Console.ReadLine();
            Console.Write("Enter Time: ");
            string time = Console.ReadLine();

         

            Console.WriteLine("Reminder Created Successfully!");
        }


    }
}
