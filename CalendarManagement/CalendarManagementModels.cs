using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarManagement
{
    // data lang
    // Data Representation (Objects/data)
    // your Reminder/Event classes
    internal class CalendarManagementModels
    {
        public class Reminder
        {
            public string Title { get; set; }
            public string Date { get; set; }
            public string Day { get; set; }
            public string Time { get; set; }
        }

        public class Event
        {
            public string Title { get; set; }
            public string Date { get; set; }
            public string Day { get; set; }
            public string Time { get; set; }
        }

    }
}
