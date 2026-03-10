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
