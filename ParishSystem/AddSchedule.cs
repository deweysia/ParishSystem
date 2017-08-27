using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParishSystem
{

    
    public partial class AddSchedule : Form
    {
        DataHandler dh = DataHandler.getDataHandler();
        CalendarEvent ev;
        private enum ScheduleTime
        {
            Start, End
        }

        public AddSchedule()
        {
            InitializeComponent();
            dtpDateStart.Value = DateTime.Now.Date;
            dtpDateEnd.Value = DateTime.Now.Date;

            dtpTimeStart.Value = DateTime.Now;
            dtpTimeEnd.Value = DateTime.Now;

            DataTable dt = dh.getMinisterWithStatus(MinisterStatus.Active);
            foreach (DataRow r in dt.Rows)
            {
                ComboboxContent cc = new ComboboxContent(int.Parse(r["ministerID"].ToString()), r["name"].ToString());
                cmbMinister.Items.Add(cc);
            }

            cmbScheduleType.SelectedIndex = 0;
            cmbMinister.SelectedIndex = 0;
        }

        public AddSchedule(ScheduleType t, CalendarEvent ev)
        {
            InitializeComponent();
            this.ev = ev;

            dtpDateStart.Value = ev.item.StartDate;
            dtpDateEnd.Value = ev.item.EndDate;

            dtpTimeStart.Value = ev.item.StartDate;
            dtpTimeEnd.Value = ev.item.EndDate;

            cmbScheduleType.SelectedIndex = (int)t;
            cmbScheduleType.Enabled = false;

            txtTitle.Text = ev.item.Text;
            txtDetails.Text = ev.details;


            if (t == ScheduleType.Appointment)
            {

                DataTable dt = dh.getMinisterWithStatus(MinisterStatus.Active);

                foreach (DataRow r in dt.Rows)
                {
                    ComboboxContent cc = new ComboboxContent(int.Parse(r["ministerID"].ToString()), r["name"].ToString());
                    cmbMinister.Items.Add(cc);
                }

                foreach (ComboboxContent c in cmbMinister.Items)
                {
                    if (c.id == ev.ministerID)
                    {
                        cmbMinister.SelectedIndex = cmbMinister.Items.IndexOf(c);
                        break;
                    }
                }

            }
            else if (t == ScheduleType.BloodDonation)
            {
                txtVenue.Text = ev.venue;
            }
        }

        private void cmbScheduleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabScheduleType.SelectedIndex = cmbScheduleType.SelectedIndex;
        }

        

        private void AddSchedule_Load(object sender, EventArgs e)
        {

        }

        private void dtpDateStart_ValueChanged(object sender, EventArgs e)
        {

            if (StartGreaterThanEnd())
                dtpDateEnd.Value = dtpDateStart.Value.Date;
        }

        private void dtpDateEnd_ValueChanged(object sender, EventArgs e)
        {
            if (StartGreaterThanEnd())
                dtpDateStart.Value = dtpDateEnd.Value.Date;
        }

        private void dtpTimeStart_ValueChanged(object sender, EventArgs e)
        {
            if (StartGreaterThanEnd())
                dtpTimeEnd.Value = dtpTimeStart.Value;
        }
        private void dtpTimeEnd_ValueChanged(object sender, EventArgs e)
        {
            if (StartGreaterThanEnd())
                dtpTimeStart.Value = dtpTimeEnd.Value;
        }

        private bool StartGreaterThanEnd()
        {
            DateTime start = getDateTime(ScheduleTime.Start);
            DateTime end = getDateTime(ScheduleTime.End);

            Console.WriteLine(string.Format("Start: {0} \n End: {1}", start.ToString("yyyy-MM-dd hh:mm"), end.ToString("yyyy-MM-dd hh:mm")));
            return start > end;
        }

        private DateTime getDateTime(ScheduleTime t)
        {
            if(t == ScheduleTime.Start)
                return new DateTime(dtpDateStart.Value.Year, dtpDateStart.Value.Month, dtpDateStart.Value.Day, dtpTimeStart.Value.Hour, dtpTimeStart.Value.Minute, 0);
            return new DateTime(dtpDateEnd.Value.Year, dtpDateEnd.Value.Month, dtpDateEnd.Value.Day, dtpTimeEnd.Value.Hour, dtpTimeEnd.Value.Minute, 0);
        }

        private void btnAdd_ClickAdd(object sender, EventArgs e)
        {
            if (!allFilled())
            {
                Notification.Show(State.ScheduleMissingTitle);
            }

            bool success = ev == null ? addEntry() : editEntry();

            if (success)
                Notification.Show(State.ScheduleAddSuccess);
            else
                Notification.Show(State.ScheduleAddFail);

            this.Close();

        }

        private bool editEntry()
        {
            string title = txtTitle.Text;
            string details = txtDetails.Text;
            DateTime start = getDateTime(ScheduleTime.Start);
            DateTime end = getDateTime(ScheduleTime.End);

            bool success = false;
            if (cmbScheduleType.SelectedIndex == 0)
                success = dh.editSchedule(ev.id, title, start, end, details);
            else if (cmbScheduleType.SelectedIndex == 1)
            {
                int ministerID = ((ComboboxContent)cmbMinister.SelectedItem).id;
                success = dh.editMinisterSchedule(ev.id, ministerID, title, start, end, details);
            }
            else
            {
                string venue = txtVenue.Text;
                success = dh.editBloodDonationEvent(ev.id, title, start, end, venue, details);
            }

            return success;
        }



        private bool addEntry()
        {
            string title = txtTitle.Text;
            string details = txtDetails.Text;
            DateTime start = getDateTime(ScheduleTime.Start);
            DateTime end = getDateTime(ScheduleTime.End);

            bool success = false;
            if (cmbScheduleType.SelectedIndex == 0)
                success = dh.addSchedule(title, start, end, details);
            else if (cmbScheduleType.SelectedIndex == 1)
            {
                int ministerID = ((ComboboxContent)cmbMinister.SelectedItem).id;
                success = dh.addMinisterSchedule(ministerID, title, start, end, details);
            }
            else
            {
                string venue = txtVenue.Text;
                success = dh.addBloodDonationEvent(title, start, end, venue, details);
            }

            return success;
        }

        private bool allFilled()
        {
            return !string.IsNullOrWhiteSpace(txtTitle.Text);
                
        }
    }
}
