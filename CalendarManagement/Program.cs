using System;
using System.Collections.Generic;

namespace CalendarManagement
{
    internal class Program

    {
        static List<string> reminders = new List<string>();
        static List<string> events = new List<string>();


        static void DisplayMenu()
        {

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Welcome to Calendar Management System!");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("1. Create Reminder");
            Console.WriteLine("2. Create Event");
            Console.WriteLine("3. View Reminders");
            Console.WriteLine("4. View Events");
            Console.WriteLine("5. Exit");

            Console.WriteLine("Please select an option:");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                CreateReminder();
            }
            else if (choice == 2)
            {
                CreateEvent();
            }
            else if (choice == 3)
            {
                ViewReminders();
            }
            else if (choice == 4)
            {
                ViewEvents();
            }
            else if (choice == 5)
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
                Console.Write("Enter the Name or Title of the Reminder: ");
                string RemindersName = Console.ReadLine();
                Console.Write("Enter Date (February 10, 2026): ");
                string Reminderdate = Console.ReadLine();
                Console.Write("Enter Day (Tuesday): ");
                string Reminderday = Console.ReadLine();
                Console.Write("Enter Time (9 PM/9 AM): ");
                string Remindertime = Console.ReadLine();
                
                reminders.AddRange(new List<string> { RemindersName, Reminderdate, Reminderday, Remindertime });
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
             
                events.AddRange(new List<string> { eventsName, Eventdate, Eventday, Eventtime });
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
                foreach (var ev in events)
                {
                    Console.WriteLine(ev);
                }
            }

        static void UpdateReminder()
        {
            Console.Write("Would you like to update a reminder? (yes/no)");
            string updateChoice = Console.ReadLine();
            string choice = updateChoice.ToLower();

            if (choice == "yes")
            {

            }
        }

            static void Main(string[] args)
            {

                //Create Repeat Update Delete

                DateTime now = DateTime.Now;
                Console.WriteLine("Current Date and Time: " + now.ToString("MMMM dd/n yyyy HH:mm:ss"));

                DisplayMenu();


            }
        }
    }

   

