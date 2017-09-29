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
        DataHandler dh = DataHandler.getDataHandler();
        //List<CalendarItem> _items = new List<CalendarItem>();
        Dictionary<CalendarItem, CalendarEvent> _events;


        public ScheduleModule()
        {
            InitializeComponent();
            //Loading and placing moved to LoadItems Event
            loadEvents();
            PlaceItems();

            //Monthview colors
            monthView1.MonthTitleColor = CalendarColorTable.FromHex("#262626");
            //monthView1.ForeColor = Color.Wheat;
            //monthView1.ArrowsColor = CalendarColorTable.FromHex("#77A1D3");
            //monthView1.DaySelectedBackgroundColor = CalendarColorTable.FromHex("#F4CC52");
            monthView1.DaySelectedTextColor = monthView1.ForeColor;

            calendar1.BackColor = Color.Black;

        }

        private void calendar1_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            PlaceItems();
        }


        private void loadEvents()
        {
            DateTime Start = DateTime.Now.Date.AddMonths(-6);
            DateTime End = DateTime.Now.Date.AddMonths(6);
            //Get schedule of past and upcoming 6 months
            DataTable dt = dh.getSchedules(Start, End);

            _events = new Dictionary<CalendarItem, CalendarEvent>();
            
            foreach(CalendarItem item in calendar1.Items.ToList())
            {
                calendar1.Items.Remove(item);
            }

            //Loads Schedule Table
            foreach (DataRow r in dt.Rows)
            {
                DateTime start = DateTime.ParseExact(r["startDateTime"].ToString(), "yyyy-MM-dd HH:mm", null);
                DateTime end = DateTime.ParseExact(r["endDateTime"].ToString(), "yyyy-MM-dd HH:mm", null);
                string title = r["title"].ToString();
                CalendarItem item = new CalendarItem(calendar1, start, end, title);

                int scheduleID = Convert.ToInt32(r["scheduleID"]);
                string details = r["details"].ToString();
                CalendarEvent e = new CalendarEvent(scheduleID, item, ScheduleType.Unspecified, details);

                _events.Add(item, e);
            }

            dt = dh.getMinisterSchedules(Start, End);
            foreach (DataRow r in dt.Rows)
            {
                DateTime start = DateTime.ParseExact(r["startDateTime"].ToString(), "yyyy-MM-dd HH:mm", null);
                DateTime end = DateTime.ParseExact(r["endDateTime"].ToString(), "yyyy-MM-dd HH:mm", null);
                string title = r["title"].ToString();
                CalendarItem item = new CalendarItem(calendar1, start, end, title);

                int ministerScheduleID = Convert.ToInt32(r["ministerScheduleID"]);
                int ministerID = Convert.ToInt32(r["ministerID"]);
                string details = r["details"].ToString();
                CalendarEvent e = new CalendarEvent(ministerScheduleID, item, ScheduleType.Appointment, details, ministerID);

                _events.Add(item, e);
            }

            dt = dh.getBloodDonationEvents(Start, End);
            foreach (DataRow r in dt.Rows)
            {
                DateTime start = DateTime.ParseExact(r["startDateTime"].ToString(), "yyyy-MM-dd HH:mm", null);
                DateTime end = DateTime.ParseExact(r["endDateTime"].ToString(), "yyyy-MM-dd HH:mm", null);
                string eventName = r["eventName"].ToString();
                CalendarItem item = new CalendarItem(calendar1, start, end, eventName);

                int bloodDonationEventID = Convert.ToInt32(r["bloodDonationEventID"]);
                string venue = r["eventVenue"].ToString();
                string details = r["eventDetails"].ToString();
                CalendarEvent e = new CalendarEvent(bloodDonationEventID, item, ScheduleType.BloodDonation, details, venue);

                _events.Add(item, e);
            }

        }

        private void PlaceItems()
        {
            //Update Dictionary with database before placing items
            
            
            foreach (CalendarItem item in _events.Keys)
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
            //toolTip1.SetToolTip(calendar1, e.Item.Text);
        }

        private void calendar1_ItemClick(object sender, CalendarItemEventArgs e)
        {
            loadDetails(e.Item);
        }

        private void loadDetails(CalendarItem item)
        {
            CalendarEvent ev = _events[item];
            lblTitle.Text = ev.item.Text;
            lblDetails.Text = ev.details;
            lblStart.Text = ev.item.StartDate.ToString("yyyy-MM-dd\n hh:mm tt");
            lblEnd.Text = ev.item.EndDate.ToString("yyyy-MM-dd\n hh:mm tt");


            lblExtra.Visible = ev.type != ScheduleType.Unspecified;
            lblExtraInfo.Visible = ev.type != ScheduleType.Unspecified;

            if (ev.type == ScheduleType.Unspecified)
                return;


            if (ev.type == ScheduleType.Appointment)
            {
                lblExtra.Text = "Minister";

                string ministerName = dh.getMinister(ev.ministerID).Rows[0]["name"].ToString();
                lblExtraInfo.Text = ministerName;
            }
            else if (ev.type == ScheduleType.BloodDonation)
            {
                lblExtra.Text = "Event Name";
                lblExtraInfo.Text = ev.venue;
            }
        }

        private void calendar1_ItemDeleted(object sender, CalendarItemEventArgs e)
        {
            //_items.Remove(e.Item);
            _events.Remove(e.Item);
        }

        private void calendar1_DayHeaderClick(object sender, CalendarDayEventArgs e)
        {
            calendar1.SetViewRange(e.CalendarDay.Date, e.CalendarDay.Date);
        }

        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            calendar1.SetViewRange(monthView1.SelectionStart, monthView1.SelectionEnd);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gbDetails_Enter(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSchedule f = new AddSchedule();
            f.ShowDialog();
            panelRemoveEdit.Enabled = false;
            clearLabels();

            loadEvents();
            PlaceItems();
        }



        private void clearLabels()
        {
            lblDetails.Text = lblEnd.Text = lblExtra.Text = lblExtraInfo.Text = lblStart.Text = lblTitle.Text = "";
        }

        
        private void ScheduleModule_Load(object sender, EventArgs e)
        {

        }

        private void calendar1_MouseClick(object sender, MouseEventArgs e)
        {
            panelRemoveEdit.Enabled = calendar1.GetSelectedItems().Count() != 0;
            clearLabels();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            CalendarItem i = calendar1.GetSelectedItems().ToList()[0];
            CalendarEvent ev = _events[i];

            AddSchedule f = new AddSchedule(ev.type, ev);
            f.ShowDialog();

            panelRemoveEdit.Enabled = false;
            clearLabels();

            loadEvents();
            PlaceItems();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            CalendarItem i = calendar1.GetSelectedItems().ToList()[0];
            CalendarEvent ev = _events[i];

            Delete delete;
            switch (ev.type)
            {
                case ScheduleType.Appointment:
                    delete = dh.deleteMinisterSchedule;
                    break;
                case ScheduleType.BloodDonation:
                    delete = dh.deleteBloodDonationEvent;
                    break;
                default: //Unspecified event
                    delete = dh.deleteSchedule;
                    break;
            }

            //Deletes the specified event
            delete(ev.id);

            panelRemoveEdit.Enabled = false;
            clearLabels();

            loadEvents();
            PlaceItems();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void calendar1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void calendar1_ItemCreating(object sender, CalendarItemCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
