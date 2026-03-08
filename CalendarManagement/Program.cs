using System;
using System.Collections.Generic;

namespace CalendarManagement
{
    internal class Program

    {
        static Dictionary<string, List<string>> reminders = new Dictionary<string, List<string>>();
        static Dictionary<string, List<string>> events = new Dictionary<string, List<string>>();



        static void DisplayMenu()
        {

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Welcome to Calendar Management System!");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("1. Create Reminder");
            Console.WriteLine("2. Create Event");
            Console.WriteLine("3. View Reminders");
            Console.WriteLine("4. View Events");
            Console.WriteLine("5. Update Reminder");
            Console.WriteLine("6. Update Event");
            Console.WriteLine("7. Exit");

            Console.WriteLine("Please select an option:");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)      {  CreateReminder();    }

            else if (choice == 2) { CreateEvent();        }
          
            else if (choice == 3) { ViewReminders();      }
           
            else if (choice == 4) { ViewEvents();         }

            else if (choice == 5) { UpdateReminder();     }
           
            else if (choice == 6) { UpdateEvent();        }
          
            else if (choice == 7)
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

            //   reminders.AddRange(new List<string> { RemindersName, Reminderdate, Reminderday, Remindertime });
            reminders[RemindersName] = new List<string> { Reminderdate, Reminderday, Remindertime };
            Console.WriteLine("Reminder Created Successfully!");

            DisplayMenu();
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

            //   events.AddRange(new List<string> { eventsName, Eventdate, Eventday, Eventtime });
            events[eventsName] = new List<string> { Eventdate, Eventday, Eventtime };
            Console.WriteLine("Event Created Successfully!");

            DisplayMenu();
        }

        static void ViewReminders()
        {
            Console.Write("Enter Reminder Name to view: ");
            string reminderToView = Console.ReadLine();

            if (reminders.ContainsKey(reminderToView))
            {
                Console.WriteLine($"{reminderToView}:");
                foreach (var reminderdetail in reminders[reminderToView])
                {
                    Console.WriteLine(reminderdetail);
                }
            }
            else
            {
                Console.WriteLine("Reminder not found.");
            }
            DisplayMenu();
        }

        static void ViewEvents()
        {
            Console.Write("Enter Event Name to view: ");
            string eventToView = Console.ReadLine();

            if (reminders.ContainsKey(eventToView))
            {
                Console.WriteLine($"{eventToView}:");
                foreach (var eventdetail in reminders[eventToView])
                {
                    string eventdetails = eventdetail.ToUpper();
                    Console.WriteLine(eventdetail);
                }
            }
            else
            {
                Console.WriteLine("Reminder not found");
            }
            DisplayMenu();
        }

            static void UpdateReminder()
            {
                Console.Write("Would you like to update a reminder? (yes/no)");
                string updateChoice = Console.ReadLine();
                string choice = updateChoice.ToLower();

                if (choice == "yes")
                {
                    Console.Write("Enter the Name of the Reminder you want to update: ");
                    string reminderNametoUpdate = Console.ReadLine();



                }
                else if (choice == "no")
                {
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    //  Console.WriteLine("Would you like to try again?");
                }
            DisplayMenu();
        }

            static void UpdateEvent()
            {
                Console.Write("Would you like to update a reminder? (yes/no)");
                string updateChoice = Console.ReadLine();
                string choice = updateChoice.ToLower();

                if (choice == "yes")
                {

                }
                else if (choice == "no")
                {
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
                DisplayMenu();
            }

            /*  FIX CONFLICTS IN CALENDAR MANAGEMENT
             Identify: Actively scan for overlapping, color-coded, or alerted events.
             
              Assess: Determine which event has higher stakes or impact.

              Communicate: Inform all parties immediately, taking responsibility for the error.

              Reschedule: Offer alternative dates rather than just canceling.

              Audit: Regularly review your calendar to prevent future issues.   
             */



            static void Main(string[] args)
            {

                //Create Repeat Update Delete

                DateTime now = DateTime.Now;
                Console.WriteLine("Current Date and Time: " + now.ToString("MMMM dd/n yyyy HH:mm:ss"));

                DisplayMenu();


            }
        }
    }


   

