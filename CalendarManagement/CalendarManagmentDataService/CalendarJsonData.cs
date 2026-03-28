using CalendarManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace CalendarManagmentDataService
{
    public class CalendarJsonData : ICalendarDataService
    {
        private Dictionary<string, Reminder> reminders = new Dictionary<string, Reminder>();
        private Dictionary<string, Event> events = new Dictionary<string, Event>();

        private string _jsonFileName;

        public CalendarJsonData()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/Calendar.json"; 
            
             PopulateJsonFile();
        }
        private void PopulateJsonFile()
        {
            RetrieveDataFromJsonFile();

            if (reminders.Count <= 0)
            {
                reminders["Test Reminder"] = new Reminder { ReminderId = Guid.NewGuid(),Name = "Test Reminder", Date = "Oct 7, 2026", Day = "Wednesday", Time = "12 PM" };
                reminders["Test Reminder 2"] = new Reminder { ReminderId = Guid.NewGuid(), Name = "Test Reminder 2", Date = "Oct 8, 2026", Day = "Thursday", Time = "1 PM" };
                reminders["Test Reminder 3"] = new Reminder { ReminderId = Guid.NewGuid(), Name = "Test Reminder 3", Date = "Oct 9, 2026", Day = "Friday", Time = "2 PM" };

                SaveDataToJsonFile();
            }
            if (events.Count <= 0)
            {
                events["Test Event"] = new Event { EventId = Guid.NewGuid(), Name = "Test Event", Date = "Oct 7, 2026", Day = "Wednesday", Time = "12 PM" };
                events["Test Event 2"] = new Event { EventId = Guid.NewGuid(), Name = "Test Event 2", Date = "Oct 8, 2026", Day = "Thursday", Time = "1 PM" };
                events["Test Event 3"] = new Event { EventId = Guid.NewGuid(), Name = "Test Event 3", Date = "Oct 9, 2026", Day = "Friday", Time = "2 PM" };
                SaveDataToJsonFile();
            }

        }

        private void SaveDataToJsonFile()
        {
            using (var stream = File.OpenWrite(_jsonFileName))
            using (var writer = new Utf8JsonWriter(stream, new JsonWriterOptions { Indented = true }))
            {
                writer.WriteStartObject(); // {
                writer.WritePropertyName("Reminders");
                JsonSerializer.Serialize(writer, reminders.Values.ToList()); // serialize reminders list
                writer.WritePropertyName("Events");
                JsonSerializer.Serialize(writer, events.Values.ToList());    // serialize events list
                writer.WriteEndObject(); // }
            }
        }

        private void RetrieveDataFromJsonFile()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            using (var jsonFileReader = File.OpenRead(this._jsonFileName))
            {
                this.reminders = JsonSerializer.Deserialize<Dictionary<string, Reminder>>(jsonFileReader, options);
            }

            using (var jsonFileReader = File.OpenRead(this._jsonFileName))
            {
                this.events = JsonSerializer.Deserialize<Dictionary<string, Event>>(jsonFileReader, options);
            }
        }

        public void Add(Reminder reminder)
        {
            reminders.Add(reminder.Name, reminder);
            SaveDataToJsonFile();
        }

        public Reminder? GetReminder() {
            RetrieveDataFromJsonFile();
            return reminders.Values.FirstOrDefault();

        }
        public Reminder? GetReminderById(Guid id)
        {
            RetrieveDataFromJsonFile();
            return reminders.Where(x => x.Value.ReminderId == id).FirstOrDefault().Value;
        }

       public Reminder? GetReminderByName(string name)
        {
            RetrieveDataFromJsonFile();
            return reminders.Where(x => x.Value.Name == name).FirstOrDefault().Value;
        }

        public Dictionary<string, Reminder> GetAllReminders()
        {
            RetrieveDataFromJsonFile();
            return reminders;
        }

        public void UpdateReminder(Reminder reminder)
        {
            RetrieveDataFromJsonFile();

            var existingReminder = GetReminderByName(reminder.Name);

            if (existingReminder != null)
            {
                existingReminder.Date = reminder.Date;
                existingReminder.Day = reminder.Day;
                existingReminder.Time = reminder.Time;
                SaveDataToJsonFile();
            }
        }
        public Event? GetEventByName(string name)
        {
            RetrieveDataFromJsonFile();
            return events.Values.FirstOrDefault(e => e.Name == name);
        }

        public void Add(Event ev)
        {
            events[ev.Name] = ev;
            SaveDataToJsonFile();

        }
        public Dictionary<string, Event> GetAllEvents()
        {
            RetrieveDataFromJsonFile();
            return events;
        }
        
            public void UpdateEvent(Guid id, Event updatedEvent)
        {
            RetrieveDataFromJsonFile();

            var existingEvent = events.Values.FirstOrDefault(e => e.EventId == id);

            if (existingEvent != null)
            {
                existingEvent.Name = updatedEvent.Name;
                existingEvent.Date = updatedEvent.Date;
                existingEvent.Day = updatedEvent.Day;
                existingEvent.Time = updatedEvent.Time;
            }

            SaveDataToJsonFile();
        }
        
        public bool ReminderExists(string name)
        {
            RetrieveDataFromJsonFile();
            return reminders.Where(x => x.Key == name).Any();
        }
        public bool EventExists(string name)
        {
            RetrieveDataFromJsonFile();
            return events.Where(x => x.Key == name).Any();
        }

        public void Remove(string name)
        {
            throw new NotImplementedException();
        }

        public void DeleteReminder(Reminder reminder)
        {
            throw new NotImplementedException();
        }

        public void DeleteEvent(Event ev)
        {
            throw new NotImplementedException();
        }

        public void DeleteEvents(Event ev)
        {
            throw new NotImplementedException();
        }

        public Event? GetEvent(string name)
        {

            RetrieveDataFromJsonFile();
            return events.Values.FirstOrDefault();
        }

           public Event? GetEventById(Guid id)
        {
            RetrieveDataFromJsonFile();
            return events.Values.FirstOrDefault(ev => ev.EventId == id);
        }

        public void UpdateEvent(Event ev)
        {
            throw new NotImplementedException();
        }
    }
}

