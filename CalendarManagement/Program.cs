using System;
using System.Collections.Generic;

namespace CalendarManagement
{
    internal class Program
    {

        static void DisplayMenu()
        {
            int choice = 0;
            Console.Write("-------------------------------\n");
            Console.Write("Welcome to Calendar Management System!");
            Console.Write("-------------------------------\n");


            Console.WriteLine("1. Create Reminder");
            Console.WriteLine("2. Create Event");
            Console.WriteLine("3. View Reminders");
            Console.WriteLine("4. View Events");
            Console.WriteLine("5. Exit");

            if (choice == 1)
            {
                Console.WriteLine(CreateReminder);
            }
            else if (choice == 2)  {
                Console.WriteLine(CreateEvent);
            }
        }


        static void CreateReminder()
        {
            Console.Write("Enter the Name or Title of the Reminder: ");
            string RemindersName = Console.ReadLine();
            Console.Write("Enter Date (February 10, 2026): ");
            string Reminderdate = Console.ReadLine();
            Console.Write("Enter Day (Tuesday): ");
            string Reminderday = Console.ReadLine();
            Console.Write("Enter Time (9 PM/9 AM): ");
            string Remindertime = Console.ReadLine();
            var reminders = new List<string>();
            reminders.Add(RemindersName);
            reminders.Add(Reminderdate);
            reminders.Add(Reminderday);
            reminders.Add(Remindertime);
            Console.WriteLine("Reminder Created Successfully!");
        }

        static void CreateEvent()
        {
            Console.Write("Enter the Name or Title of the Event: ");
            string eventsName = Console.ReadLine();
            Console.Write("Enter Date (February 10, 2026): ");
            string Eventdate = Console.ReadLine();
            Console.Write("Enter Day (Tuesday): ");
            string Eventday = Console.ReadLine();
            Console.Write("Enter Time (9:00PM): ");
            string Eventtime = Console.ReadLine();
            var events = new List<string>();
            events.Add(eventsName);
            events.Add(Eventdate);
            events.Add(Eventday);
            events.Add(Eventtime);
            Console.WriteLine("Event Created Successfully!");
            }

        static void ViewReminders()
        {
            var reminders = new List<string>();
            foreach (var reminder in reminders)
            {
                Console.WriteLine(reminder);
            }
        }

        static void ViewEvents()
        {
            var events = new List<string>();
            foreach (var item in events)
            {
                Console.WriteLine(events);
            }
        }


            static void Main(string[] args)
        {
            string eventsName;
            string Eventdate, Reminderdate;
            string Eventday, Reminderday;
            string Eventtime, Remindertime;
            string RemindersName;
            string typesOfEvents ;
            string continueReminder1, continueReminder2, continueEvent1, continueEvent2;
            string viewReminder, viewEvent;

            //Create Repeat Update Delete

            DateTime now = DateTime.Now;
            Console.WriteLine("Current Date and Time: " + now.ToString("MMMM dd, yyyy HH:mm:ss"));
            Console.WriteLine(DisplayMenu);


            }
        }
    }

