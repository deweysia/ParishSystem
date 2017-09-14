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
                
                item.ApplyColor(Color.FromArgb(181, 230, 29));
            }else if(type == ScheduleType.Appointment)
            {
                
                item.ApplyColor(Color.FromArgb(255, 127, 39));
            }
            else
            {
                
                item.ApplyColor(Color.FromArgb(112, 146, 190));
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
