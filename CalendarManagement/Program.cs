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
                Console.WriteLine("Would you like to Create an another Event? (Y/N): ");
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
            }


        }
    }
}
