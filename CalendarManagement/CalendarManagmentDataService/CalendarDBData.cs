using CalendarManagementModels;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CalendarManagmentDataService
{
    public class CalendarDBData : ICalendarDataService
    {
        private string? connectionString
     =   "Data Source=localhost\\SQLEXPRESS;Initial Catalog=CalendarManagement;Integrated Security=True;TrustServerCertificate=True";
        private SqlConnection SqlConnection;

        public CalendarDBData()
        {
            SqlConnection = new SqlConnection(connectionString);

            SqlConnection.Open();
        }

        public bool TestConnection()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    return true; // ✅ Connected
                }
                catch (Exception ex)
                {
                
                    Console.WriteLine("❌ Connection failed: " + ex.Message);
                    return false;
                }
            }
        }

        private void AddSeeds()
        {
            var existingReminder = GetReminder();



            if (existingReminder.Counts == 0)
            {
                Reminder TestReminder = new Reminder { Name = "Test Reminder", Date = "Oct 7, 2026", Day = "Wednesday", Time = "12 PM" };
                Reminder TestRemider2 = new Reminder { Name = "Test Reminder 2", Date = "Oct 8, 2026", Day = "Thursday", Time = "1 PM" };
                Reminder TestReminder3 = new Reminder { Name = "Test Reminder 3", Date = "Oct 9, 2026", Day = "Friday", Time = "2 PM" };


                Add(TestReminder);
                Add(TestRemider2);
                Add(TestReminder3);

            }

            var existingEvents = GetEvent();

            if (existingEvents.Counts == 0)
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
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();

                    // run your command here
                    // conn is closed/disposed automatically here
                    var insertStatement = "INSERT INTO Reminder VALUES (@ReminderID, @Name, @Date, @Day, @Time)";

                    SqlCommand insertCommand = new SqlCommand(insertStatement, conn);

                    insertCommand.Parameters.AddWithValue("@ReminderID", reminder.ReminderId);
                    insertCommand.Parameters.AddWithValue("@Name", reminder.Name);
                    insertCommand.Parameters.AddWithValue("@Date", reminder.Date);
                    insertCommand.Parameters.AddWithValue("@Day", reminder.Day);
                    insertCommand.Parameters.AddWithValue("@Time", reminder.Time);

                    insertCommand.ExecuteNonQuery();

                }
            }
        }

        public void Add(Event ev)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    var insertStatement = "INSERT INTO Event VALUES (@EventID, @Name, @Date, @Day, @Time)";

                    SqlCommand insertCommand = new SqlCommand(insertStatement, conn);

                    insertCommand.Parameters.AddWithValue("@EventID", ev.EventId);
                    insertCommand.Parameters.AddWithValue("@Name", ev.Name);
                    insertCommand.Parameters.AddWithValue("@Date", ev.Date);
                    insertCommand.Parameters.AddWithValue("@Day", ev.Day);
                    insertCommand.Parameters.AddWithValue("@Time", ev.Time);

                    insertCommand.ExecuteNonQuery();
                }
                }
        }

        //public Event? GetEvent()
        //{

        //}

        public Event? GetEventByName(string name)
        {
            string selectStatement = "SELECT EventID, Name, Date, Day, Time FROM Event WHERE Name = @Name";

            SqlCommand selectCommand = new SqlCommand(selectStatement, SqlConnection);
            selectCommand.Parameters.AddWithValue("@Name", name);

            if (SqlConnection.State != ConnectionState.Open)
            {
                SqlConnection.Open();
            }

            SqlDataReader reader = selectCommand.ExecuteReader();

            if (!reader.HasRows)
            {
                Console.WriteLine("Event does not exist.");
                reader.Close();
                SqlConnection.Close();
                return null;
            }

            var ev = new Event();

            while (reader.Read())
            {
                ev.EventId = Guid.Parse(reader["EventID"].ToString());
                ev.Name = reader["Name"].ToString();
                ev.Date = reader["Date"].ToString();
                ev.Day = reader["Day"].ToString();
                ev.Time = reader["Time"].ToString();
            }

            reader.Close();
            SqlConnection.Close();

            return ev;
        }
        public Reminder? GetReminder()
        {
            string selecStatement = "SELECT ReminderID, Name, Date, Day, Time FROM Reminder";

            SqlCommand selectCommand = new SqlCommand(selecStatement, SqlConnection);

            SqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var reminder = new Reminder();

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
            string selectStatement = "SELECT ReminderID, Name, Date, Day, Time FROM Reminder WHERE Name = @Name";

            SqlCommand selectCommand = new SqlCommand(selectStatement, SqlConnection);
            selectCommand.Parameters.AddWithValue("@Name", name);

            if (SqlConnection.State != ConnectionState.Open)
            {
                SqlConnection.Open();
            }

            SqlDataReader reader = selectCommand.ExecuteReader();

  
            if (!reader.HasRows)
            {
                Console.WriteLine("Reminder does not exist.");
                reader.Close();
                SqlConnection.Close();
                return null; 
            }

            var reminder = new Reminder();

            while (reader.Read())
            {
                reminder.ReminderId = Guid.Parse(reader["ReminderID"].ToString());
                reminder.Name = reader["Name"].ToString();
                reminder.Date = reader["Date"].ToString();
                reminder.Day = reader["Day"].ToString();
                reminder.Time = reader["Time"].ToString();
            }

            reader.Close();
            SqlConnection.Close();

            return reminder;
        }

        public void RemoveReminder(string reminderName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();

                string deleteStatement = "DELETE FROM Reminder WHERE Name = @Name";

                using (SqlCommand deleteCommand = new SqlCommand(deleteStatement, conn))
                {
                    deleteCommand.Parameters.AddWithValue("@Name", reminderName);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Reminder deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No Reminder found with that name.");
                    }
                }
            }
        }

        public void RemoveEvent(string eventName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();

                string deleteStatement = "DELETE FROM Event WHERE Name = @Name";

                using (SqlCommand deleteCommand = new SqlCommand(deleteStatement, conn))
                {
                    deleteCommand.Parameters.AddWithValue("@Name", eventName);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Event deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No Event found with that name.");
                    }
                }
            }
        }

        public void UpdateEvent(Event ev)
        {

            if (SqlConnection.State != ConnectionState.Open)
            {
                SqlConnection.Open();
            }
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
            if (SqlConnection.State != ConnectionState.Open)
            {
                SqlConnection.Open();
            }

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

        public void DeleteReminder(string reminderName)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();

                string deleteStatement = "DELETE FROM Reminder WHERE Name = @Name";

                using (SqlCommand deleteCommand = new SqlCommand(deleteStatement, conn))
                {
                    deleteCommand.Parameters.AddWithValue("@Name", reminderName);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Reminder deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No Reminder found with that name.");
                    }
                }
            }
        }

        public void DeleteEvents(string eventName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string deleteStatement = "DELETE FROM Event WHERE Name = @Name";

                using (SqlCommand deleteCommand = new SqlCommand(deleteStatement, conn))
                {
                    deleteCommand.Parameters.AddWithValue("@Name", eventName);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Event deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No event found with that name.");
                    }
                }
            } 
        }


        public void Remove(string reminderName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();

                string deleteStatement = "DELETE FROM Reminder WHERE Name = @Name";

                using (SqlCommand deleteCommand = new SqlCommand(deleteStatement, conn))
                {
                    deleteCommand.Parameters.AddWithValue("@Name", reminderName);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Reminder deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No Reminder found with that name.");
                    }
                }
            }
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


        public void Add(object newReminder)
        {
            throw new NotImplementedException();
        }

        public Event? GetEvent(string name)
        {
            throw new NotImplementedException();
        }

        public Event? GetEvent()
        {
            throw new NotImplementedException();
        }
    }
}
