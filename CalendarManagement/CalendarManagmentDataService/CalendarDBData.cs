using CalendarManagementModels;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarManagmentDataService
{
    public class CalendarDBData  : ICalendarDataService
    {
        private string? connectionString 
          =  "Data Source: localhost\\SQLEXPRESS; Initial Catalog = CalendarManagement; Integrated Security = True; TrustServerCertificate=True";
    
        private SqlConnection SqlConnection;


        public CalendarDBData()
        {
            SqlConnection = new SqlConnection(connectionString);

            SqlConnection.Open();
        }


        private void AddSeeds()
        {
            var existingReminder = GetReminder();


            
            if (existingReminder.Count)
            {
                Reminder TestReminder = new Reminder { Name = "Test Reminder", Date = "Oct 7, 2026", Day = "Wednesday", Time = "12 PM" };
                Reminder TestRemider2 = new Reminder { Name = "Test Reminder 2", Date = "Oct 8, 2026", Day = "Thursday", Time = "1 PM" };
                Reminder TestReminder3 = new Reminder { Name = "Test Reminder 3", Date = "Oct 9, 2026", Day = "Friday", Time = "2 PM" };

                
                Add(TestReminder);
                Add(TestRemider2);
                Add(TestReminder3);
                
            }

            var existingEvents = GetEvent();

            if(existingEvents.Count == 0)
            {
                Event TestEvent = new Event { Name = "Test Event", Date = "Oct 10, 2026", Day = "Saturday", Time = "3 PM" };
                Event TestEvent2 = new Event { Name = "Test Event 2", Date = "Oct 11, 2026", Day = "Sunday", Time = "4 PM" };
                Event TestEvent3 = new Event { Name = "Test Event 3", Date = "Oct 12, 2026", Day = "Monday", Time = "5 PM" };

                Add(TestEvent);
                Add(TestEvent2);
                Add(TestEvent3);
            }
        }




        public void Add(Reminder reminder)
        {
            var insertStatement = "INSERT INTO Reminder VALUES (@ReminderID, @Name, @Date, @Day, @Time)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, SqlConnection);

            insertCommand.Parameters.AddWithValue("@ReminderID", reminder.ReminderId);
            insertCommand.Parameters.AddWithValue("@Name", reminder.Name);
            insertCommand.Parameters.AddWithValue("@Date", reminder.Date);
            insertCommand.Parameters.AddWithValue("@Day", reminder.Day);
            insertCommand.Parameters.AddWithValue("@Time", reminder.Time);
            SqlConnection.Open();

            insertCommand.ExecuteNonQuery();

            SqlConnection.Close();
        }

        public void Add(Event ev)
        {
            var insertStatement = "INSERT INTO Event VALUES (@ReminderID, @Name, @Date, @Day, @Time)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, SqlConnection);

            insertCommand.Parameters.AddWithValue("@EventID", ev.EventId);
            insertCommand.Parameters.AddWithValue("@Name", ev.Name);
            insertCommand.Parameters.AddWithValue("@Date", ev.Date);
            insertCommand.Parameters.AddWithValue("@Day", ev.Day);
            insertCommand.Parameters.AddWithValue("@Time", ev.Time);
            SqlConnection.Open();

            insertCommand.ExecuteNonQuery();

            SqlConnection.Close();
        }

        public Event? GetEvent()
        {
            string selecStatement = "SELECT EventID, Name, Date, Day, Time FROM Event";

            SqlCommand selectCommand = new SqlCommand(selecStatement, SqlConnection);

            SqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var events = new Event();

            while (reader.Read())
            {
                events.EventId = Guid.Parse(reader["EventID"].ToString());
                events.Name = reader["Name"].ToString();
                events.Date = reader["Date"].ToString();
                events.Day = reader["Day"].ToString();
                events.Time = reader["Time"].ToString();

            }

            SqlConnection.Close();
            return events;
        }

        public Event? GetEventByName(string name)
        {
            throw new NotImplementedException();
        }

        public Reminder? GetReminder()
        {
            string selecStatement = "SELECT ReminderID, Name, Date, Day, Time FROM Reminder";

            SqlCommand selectCommand = new SqlCommand(selecStatement, SqlConnection);

            SqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var  reminder = new Reminder();

            while (reader.Read())
            {
                
                reminder.ReminderId = Guid.Parse(reader["EventID"].ToString());
                reminder.Name = reader["Name"].ToString();
                reminder.Date = reader["Date"].ToString();
                reminder.Day = reader["Day"].ToString();
                reminder.Time = reader["Time"].ToString();

            }

            SqlConnection.Close();
            return reminder;
        }

        public Reminder? GetReminderByName(string name)
        {
            throw new NotImplementedException();
        }
        public void RemoveReminder(string name)
        {
            throw new NotImplementedException();
        }

        public void RemoveEvent(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateEvent(Event ev)
        {
            SqlConnection.Open();

            var updateStatement = $"UPDATE Event SET Name = @Name, Date = @Date, Day = @Day, Time = @Time WHERE EventID = @EventID";


            SqlCommand updateCommand = new SqlCommand(updateStatement, SqlConnection);

            updateCommand.Parameters.AddWithValue("@EventID", ev.EventId);
            updateCommand.Parameters.AddWithValue("@Name", ev.Name);
            updateCommand.Parameters.AddWithValue("@Date", ev.Date);
            updateCommand.Parameters.AddWithValue("@Day", ev.Day);
            updateCommand.Parameters.AddWithValue("@Time", ev.Time);
            updateCommand.ExecuteNonQuery();

            SqlConnection.Close();
        }

        public void UpdateReminder(Reminder reminder)
        {
            SqlConnection.Open();

            var updateStatement = $"UPDATE Reminder SET Name = @Name, Date = @Date, Day = @Day, Time = @Time WHERE ReminderID = @ReminderID";


            SqlCommand updateCommand = new SqlCommand(updateStatement, SqlConnection);

            updateCommand.Parameters.AddWithValue("@ReminderID", reminder.ReminderId);
            updateCommand.Parameters.AddWithValue("@Name", reminder.Name);
            updateCommand.Parameters.AddWithValue("@Date", reminder.Date);
            updateCommand.Parameters.AddWithValue("@Day", reminder.Day);
            updateCommand.Parameters.AddWithValue("@Time", reminder.Time);
            updateCommand.ExecuteNonQuery();

            SqlConnection.Close();
        }

        public void DeleteReminder(Reminder reminder)
        {
            throw new NotImplementedException();
        }

        public void DeleteEvents(Event ev)
        {
            throw new NotImplementedException();
        }

        public void Remove(string name)
        {
            throw new NotImplementedException();
        }

        public Reminder? GetReminderById(Guid id)
        {
            var selectStatement = "SELECT ReminderID, Name, Date, Day, Time FROM Reminder WHERE ReminderID = @ReminderID";
            SqlCommand selectCommand = new SqlCommand(selectStatement, SqlConnection);
            selectCommand.Parameters.AddWithValue("@ReminderID", id.ToString());
            SqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var reminders = new Reminder();

            while (reader.Read())
            {
                reminders.ReminderId = Guid.Parse(reader["ReminderID"].ToString());
                reminders.Name = reader["Name"].ToString();
                reminders.Date = reader["Date"].ToString();
                reminders.Day = reader["Day"].ToString();
                reminders.Time = reader["Time"].ToString();
            }

            SqlConnection.Close();
            return reminders;
        }

        public Event? GetEventById(Guid id)
        {
            var selectStatement = "SELECT EventID, Name, Date, Day, Time FROM Event WHERE EventID = @EventID";
            SqlCommand selectCommand = new SqlCommand(selectStatement, SqlConnection);
            selectCommand.Parameters.AddWithValue("@EventID", id.ToString());
            SqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var events = new Event();

            while (reader.Read())
            {
                events.EventId = Guid.Parse(reader["EventID"].ToString());
                events.Name = reader["Name"].ToString();
                events.Date = reader["Date"].ToString();
                events.Day = reader["Day"].ToString();
                events.Time = reader["Time"].ToString();
            }

            SqlConnection.Close();
            return events;
        }

        public bool ReminderExists(string name)
        {
            throw new NotImplementedException();
        }

        public bool EventExists(string name)
        {
            throw new NotImplementedException();
        }

        public Event? GetEvent(string name)
        {
            throw new NotImplementedException();
        }
    }
}
