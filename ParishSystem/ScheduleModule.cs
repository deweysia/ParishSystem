using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;

namespace ParishSystem
{
    public partial class ScheduleModule : Form
    {
        List<CalendarItem> _items = new List<CalendarItem>();
        CalendarItem contextItem = null;

        public ScheduleModule()
        {
            InitializeComponent();

            //Monthview colors
            monthView1.MonthTitleColor = monthView1.MonthTitleColorInactive = CalendarColorTable.FromHex("#C2DAFC");
            monthView1.ArrowsColor = CalendarColorTable.FromHex("#77A1D3");
            monthView1.DaySelectedBackgroundColor = CalendarColorTable.FromHex("#F4CC52");
            monthView1.DaySelectedTextColor = monthView1.ForeColor;

            CalendarItem c = new CalendarItem(calendar1, DateTime.Now.AddMinutes(-10), DateTime.Now, "End of SAD");
            c.ApplyColor(Color.GreenYellow);
            _items.Add(c);
            _items.Add(new CalendarItem(calendar1, DateTime.Now, DateTime.Now.AddMinutes(10), "Start of Mig"));
            _items.Add(new CalendarItem(calendar1, DateTime.Now.AddMinutes(30), DateTime.Now.AddMinutes(10), "Magic"));
            _items.Add(new CalendarItem(calendar1, DateTime.Now, DateTime.Now.AddMinutes(60), "Chill Jazz Time"));
            _items.Add(new CalendarItem(calendar1, DateTime.Now, DateTime.Now.AddHours(2), "Chill Jazz Time"));
            
            PlaceItems();

        }



        private void calendar1_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            PlaceItems();
        }

        private void PlaceItems()
        {
            foreach (CalendarItem item in _items)
            {
                if (calendar1.ViewIntersects(item))
                {
                    calendar1.Items.Add(item);
                }
            }
        }


        private void calendar1_ItemMouseHover(object sender, CalendarItemEventArgs e)
        {
            Text = e.Item.Text;
        }

        private void calendar1_ItemClick(object sender, CalendarItemEventArgs e)
        {
            //MessageBox.Show(e.Item.Text);
        }

        private void calendar1_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            MessageBox.Show("Double click: " + e.Item.Text);
        }

        private void calendar1_ItemDeleted(object sender, CalendarItemEventArgs e)
        {
            _items.Remove(e.Item);
        }

        private void calendar1_DayHeaderClick(object sender, CalendarDayEventArgs e)
        {
            calendar1.SetViewRange(e.CalendarDay.Date, e.CalendarDay.Date);
        }

        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            calendar1.SetViewRange(monthView1.SelectionStart, monthView1.SelectionEnd);
        }

    }
}
