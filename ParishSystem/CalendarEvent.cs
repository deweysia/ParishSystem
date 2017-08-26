using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Calendar;

namespace ParishSystem
{
    class CalendarEvent
    {
        CalendarItem item;
        ScheduleType type;
        string details;
        public CalendarEvent(CalendarItem item, ScheduleType type, string details) 
        {
            this.item = item;
            this.type = type;
            this.details = details;
        }


    }
}
