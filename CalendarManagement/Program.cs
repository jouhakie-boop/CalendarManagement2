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

            //Create Repeat Update Delete
            Console.WriteLine("Welcome to Calendar Management System");

            Console.WriteLine("Enter 'R' to Create an Reminder and 'E' for an Event: ");
            typesOfEvents = Console.ReadLine();



            if (typesOfEvents == "R")
            {
                Console.Write("Enter the Name or Title of the Reminder: ");
                RemindersName = Console.ReadLine();
                Console.Write("Enter Date(February 10, 2026: ");
                Reminderday = Console.ReadLine();
                Console.Write("Enter Day(Tuesday): ");
                Reminderday = Console.ReadLine();
                Console.Write("Enter Time Thrusday(9 PM/9 AM): ");
                Remindertime = Console.ReadLine();


                List<string> reminders = new List<string>();

                reminders.Add(RemindersName);
                reminders.Add(Reminderday);
                reminders.Add(Reminderday);
                reminders.Add(Remindertime);

                Console.WriteLine("Reminder Created Successfully!");

                  Console.WriteLine("Would you like to continue? (Y/N):")
                if (continueReminder1 == "Y")
                {
                    Console.WriteLine("Would you like to View the Reminder? (Y/N): ");
                    if (continueReminder2)
                    {
                        Console.Write("Enter the Name or Title of the Reminder: ");
                        RemindersName = Console.ReadLine();
                        Console.Write("Enter Date(February 10, 2026: ");
                        Reminderday = Console.ReadLine();
                        Console.Write("Enter Day(Tuesday): ");
                        Reminderday = Console.ReadLine();
                        Console.Write("Enter Time Thrusday(9 PM/9 AM): ");
                        Remindertime = Console.ReadLine();

                        reminders.Add(RemindersName);
                        reminders.Add(Reminderday);
                        reminders.Add(Reminderday);
                        reminders.Add(Remindertime);
                    }
                    else if (continueReminder2 == "N")
                    {
                        Console.WriteLine("Thank you for using Calendar Management System!");
                    }


                }
                Console.WriteLine("Would you like to Create an another Reminder? (Y/N): ");
                string createAnotherEvent = Console.ReadLine();
            }
            else if (typesOfEvents == "E")
            {
                Console.Write("Enter the Name or Title of the Event: ");
                eventsName = Console.ReadLine();
                Console.Write("Enter Date(February 10, 2026: ");
                Eventdate = Console.ReadLine();
                Console.Write("Enter Day(Tuesday): ");
                Eventday = Console.ReadLine();
                Console.Write("Enter Time Thrusday(9:00PM): ");
                Eventtime = Console.ReadLine();

                List<string> events = new List<string>();

                events.Add(eventsName);
                events.Add(Eventdate);
                events.Add(Eventday);
                events.Add(Eventtime);

                Console.WriteLine("Would you like to continue? (Y/N):")
                if (continueEvent1 == "Y")
                {
                    Console.WriteLine("Would you like to View the Event? (Y/N): ");
                    if (continueEvent2)
                    {
                        Console.Write("Enter the Name or Title of the Event: ");
                        eventsName = Console.ReadLine();
                        Console.Write("Enter Date(February 10, 2026: ");
                        Eventdate = Console.ReadLine();
                        Console.Write("Enter Day(Tuesday): ");
                        Eventday = Console.ReadLine();
                        Console.Write("Enter Time Thrusday(9:00PM): ");
                        Eventtime = Console.ReadLine();

                        events.Add(eventsName);
                        events.Add(Eventdate);
                        events.Add(Eventday);
                        events.Add(Eventtime);
                    }
                    else if (continueReminder2 == "N")
                    {
                        Console.WriteLine("Thank you for using Calendar Management System!");
                    }
                }


        }
    }
}
