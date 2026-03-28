using System;

namespace CalendarManagementModels
{
    public class Reminder
    {
        public int Counts { get; set; }
        public Guid ReminderId { get; set; }    
        public string Name { get; set;  }
        public string Date { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public bool Count { get; set; }
    }

    public class Event
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public bool Count { get; set; }
        public int Counts { get; set; }
    }
}

