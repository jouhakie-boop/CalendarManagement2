using System;

namespace CalendarManagementModels
{
    public class Reminder
    {
        public string Name { get; set;  }
        public string Date { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }

        public DateTime? Start { get; set; }
        public TimeSpan? Duration { get; set; }
        public int Priority { get; set; } = 0; 

        public DateTime? End => Start.HasValue && Duration.HasValue ? Start + Duration : null;
    }

    public class Event
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }

        public DateTime? Start { get; set; }
        public TimeSpan? Duration { get; set; }
        public int Priority { get; set; } = 0; 

        public DateTime? End => Start.HasValue && Duration.HasValue ? Start + Duration : null;
    }
}

