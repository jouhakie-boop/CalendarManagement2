using System;
using System.Collections.Generic;

namespace CalendarManagement
{
    internal class Program
    {
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
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Welcome to Calendar Management System");
            Console.WriteLine("---------------------------------------------------------------------");

            Console.WriteLine("Enter 'R' to Create an Reminder and 'E' for an Event: ");
            typesOfEvents = Console.ReadLine();

            if (typesOfEvents == "R")
            {
                Console.Write("Enter the Name or Title of the Reminder: ");
                RemindersName = Console.ReadLine();
                Console.Write("Enter Date (February 10, 2026): ");
                Reminderdate = Console.ReadLine();
                Console.Write("Enter Day (Tuesday): ");
                Reminderday = Console.ReadLine();
                Console.Write("Enter Time (9 PM/9 AM): ");
                Remindertime = Console.ReadLine();

                var reminders = new List<string>();

                reminders.Add(RemindersName);
                reminders.Add(Reminderdate);
                reminders.Add(Reminderday);
                reminders.Add(Remindertime);

                Console.WriteLine("Reminder Created Successfully!");

                Console.WriteLine("Would you like to View the Created Reminder? (Y/N):");
                viewReminder = Console.ReadLine();
                if (viewReminder == "Y")
                {
                    foreach (var reminder in reminders)
                    {
                        Console.WriteLine(reminder);
                    }

                }
                else if (viewReminder == "N")
                {
                    Console.WriteLine("Thank you for using Calendar Management System!");
                }

                Console.WriteLine("Would you like to continue? (Y/N):");
                continueReminder1 = Console.ReadLine();
                if (continueReminder1 == "Y")
                {
                    Console.WriteLine("Would you like to Create another Reminder? (Y/N): ");
                    continueReminder2 = Console.ReadLine();
                    if (continueReminder2 == "Y")
                    {
                        Console.Write("Enter the Name or Title of the Reminder: ");
                        RemindersName = Console.ReadLine();
                        Console.Write("Enter Date (February 10, 2026): ");
                        Reminderdate = Console.ReadLine();
                        Console.Write("Enter Day (Tuesday): ");
                        Reminderday = Console.ReadLine();
                        Console.Write("Enter Time (9 PM/9 AM): ");
                        Remindertime = Console.ReadLine();

                        reminders.Add(RemindersName);
                        reminders.Add(Reminderdate);
                        reminders.Add(Reminderday);
                        reminders.Add(Remindertime);

                        Console.WriteLine("Reminder Created Successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Thank you for using Calendar Management System!");

                    }
                }
                Console.WriteLine("Would you like to Create another Reminder? (Y/N): ");
                string createAnotherEvent = Console.ReadLine();
            }

            else if (typesOfEvents == "E")
            {
                Console.Write("Enter the Name or Title of the Event: ");
                eventsName = Console.ReadLine();
                Console.Write("Enter Date (February 10, 2026): ");
                Eventdate = Console.ReadLine();
                Console.Write("Enter Day (Tuesday): ");
                Eventday = Console.ReadLine();
                Console.Write("Enter Time (9:00PM): ");
                Eventtime = Console.ReadLine();

                var events = new List<string>();

                events.Add(eventsName);
                events.Add(Eventdate);
                events.Add(Eventday);
                events.Add(Eventtime);

                Console.WriteLine("Event Created Successfully!");

                Console.WriteLine("Would you like to View the Created Event? (Y/N):");
                viewEvent = Console.ReadLine();
                if (viewEvent == "Y")
                {
                    foreach (var ev in events)
                    {
                        Console.WriteLine(ev);
                    }
                }
                else if (viewEvent == "N")
                {
                    Console.WriteLine("Thank you for using Calendar Management System!");
                }

                Console.WriteLine("Would you like to continue? (Y/N):");
                continueEvent1 = Console.ReadLine();
                if (continueEvent1 == "Y")
                {
                    Console.WriteLine("Would you like to Create another Event? (Y/N): ");
                    continueEvent2 = Console.ReadLine();
                    if (continueEvent2 == "Y")
                    {
                        Console.Write("Enter the Name or Title of the Event: ");
                        eventsName = Console.ReadLine();
                        Console.Write("Enter Date (February 10, 2026): ");
                        Eventdate = Console.ReadLine();
                        Console.Write("Enter Day (Tuesday): ");
                        Eventday = Console.ReadLine();
                        Console.Write("Enter Time (9:00PM): ");
                        Eventtime = Console.ReadLine();

                        events.Add(eventsName);
                        events.Add(Eventdate);
                        events.Add(Eventday);
                        events.Add(Eventtime);
                    }
                    else
                    {
                        Console.WriteLine("Thank you for using Calendar Management System!");
                    }
                }

            }
        }
    }
}
