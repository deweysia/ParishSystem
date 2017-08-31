using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Calendar;
using System.Drawing;

namespace ParishSystem
{
    public class CalendarEvent
    {
        public int id;
        public CalendarItem item;
        public ScheduleType type;
        public string details;
        public int ministerID;
        public string venue;
        public CalendarEvent(int id, CalendarItem item, ScheduleType type, string details) 
        {
            this.id = id;
            this.item = item;
            this.type = type;
            this.details = details;

            if(type == ScheduleType.Unspecified)
            {
                item.BackgroundColor = Color.AliceBlue;
                item.ApplyColor(Color.DarkViolet);
            }else if(type == ScheduleType.Appointment)
            {
                item.BackgroundColor = Color.DarkOrange;
                item.ApplyColor(Color.DarkOrange);
            }
            else
            {
                item.BackgroundColor = Color.Yellow;
                item.ApplyColor(Color.Maroon);
            }
            
            
        }

        public CalendarEvent(int id, CalendarItem item, ScheduleType type, string details, int ministerID) : this(id, item, type, details)
        {
            this.ministerID = ministerID;
        }

        public CalendarEvent(int id, CalendarItem item, ScheduleType type, string details, string venue) : this(id, item, type, details)
        {
            this.venue = venue;
        }


    }
}
