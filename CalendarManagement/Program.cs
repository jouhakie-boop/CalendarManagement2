using System;
using System.Collections.Generic;
using static CalendarManagement.CalendarManagementAppService;
using static CalendarManagement.CalendarManagementModels;

namespace CalendarManagement
{
    internal class Program

    {
         static Dictionary<string, List<string>> reminders = new Dictionary<string, List<string>>();
        static Dictionary<string, List<string>> events = new Dictionary<string, List<string>>();


        

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

            Console.WriteLine();
            DisplayMenu();
            Console.WriteLine();
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

            Console.WriteLine();
            DisplayMenu();
            Console.WriteLine();
        }

        static void ViewReminders()
        {
            Console.Write("Enter Reminder Name to view: ");
            string reminderToView = Console.ReadLine();

           if (reminders.ContainsKey(reminderToView))
               {           
                    foreach (var detail in events[reminderToView])
                    {
                        Console.WriteLine();
                        string reminderNameUpper = reminderToView.ToUpper();
                        Console.WriteLine(reminderToView);
                        string reminderUpper = detail.ToUpper();
                        Console.WriteLine(detail);
                        Console.WriteLine();
                    }

                }
            else
            {
                Console.WriteLine("Reminder not found.");
            }
            Console.WriteLine();
            DisplayMenu();
            Console.WriteLine();
        }

        static void ViewEvents()
        {
            Console.Write("Enter Event Name to view: ");
            string eventToView = Console.ReadLine();
            if (events.ContainsKey(eventToView))
            {
                foreach (var detail in events[eventToView])
                {
                    Console.WriteLine();
                    string eventNameUpper = eventToView.ToUpper();
                    Console.WriteLine(eventToView);                  
                    string eventUpper = detail.ToUpper();
                    Console.WriteLine(detail);
                    Console.WriteLine();
                }
               
            }
            else
            {
                Console.WriteLine("Event not found");
            }

            Console.WriteLine();
            DisplayMenu();
            Console.WriteLine();
        }

            static void UpdateReminder()
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
                    //  Console.WriteLine("Would you like to try again?");
                }
            Console.WriteLine();
            DisplayMenu();
            Console.WriteLine();
        }

            static void UpdateEvent()
            {
                Console.Write("Would you like to update a reminder? (yes/no)");
                string updateChoice = Console.ReadLine();
                string choice = updateChoice.ToLower();

                if (choice == "yes")
                {
                Console.WriteLine("Enter the name of the Reminder you want to update: ");
                string reminderUpdateChoice = Console.ReadLine();
                Console.WriteLine();
                    if (reminders.ContainsKey(reminderUpdateChoice))
                    {
                    foreach (var detail in reminders[reminderUpdateChoice])
                    {
                        Console.WriteLine();
                        string reminderNameUpper = reminderUpdateChoice.ToUpper();
                        Console.WriteLine(reminderUpdateChoice);
                        string reminderUpper = detail.ToUpper();
                        Console.WriteLine(detail);
                        Console.WriteLine();
                    }

                    Console.WriteLine();
                        Console.Write("Enter the new Date (February 10, 2026): ");
                        string newReminderDate = Console.ReadLine();
                        Console.Write("Enter the new Day (Tuesday): ");
                        string newReminderDay = Console.ReadLine();
                        Console.Write("Enter the new Time (9 PM/9 AM): ");
                        string newReminderTime = Console.ReadLine();
    
                        reminders[reminderUpdateChoice] = new List<string> { newReminderDate, newReminderDay, newReminderTime };
                        Console.WriteLine("Reminder '" + reminderUpdateChoice + "' updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Name " + reminderUpdateChoice + " Reminder not found.");
                }
            }
                else if (choice == "no")
                {
                Console.WriteLine("No updates made to the reminder.");
                Console.WriteLine();
                DisplayMenu();
                Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                Console.WriteLine();
                DisplayMenu();
                Console.WriteLine();
            }
               
            }


        static void DeleteReminder()
        {
            Console.WriteLine("Enter the name of the reminder you want to delete: ");
            string reminderDeleteChoice = Console.ReadLine();

            if (reminders.ContainsKey(reminderDeleteChoice))
            {
                reminders.Remove(reminderDeleteChoice);
                Console.WriteLine("Reminder '" + reminderDeleteChoice + "' deleted.");               
            }
            else
            {
                Console.WriteLine("Name " + reminderDeleteChoice + " Reminder not found.");
            }

            Console.WriteLine();
            DisplayMenu();
            Console.WriteLine();

        }

        static void DeleteEvent()
        {
            Console.WriteLine("Enter the name of the event you want to delete: ");
            string eventDeleteChoice = Console.ReadLine();

            if (events.ContainsKey(eventDeleteChoice))
            {
                events.Remove(eventDeleteChoice);
                Console.WriteLine("Event '" + eventDeleteChoice + "' deleted.");
            }
            else
            {
                Console.WriteLine("Name " + eventDeleteChoice + " Event not found.");
            }
            Console.WriteLine();
            DisplayMenu();
            Console.WriteLine();
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
                Console.WriteLine("Current Date and Time: " + now.ToString("MMMM dd/n yyyy, HH:mm:ss"));

                DisplayMenu();


            }
        }
    }
