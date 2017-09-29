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

            Draggable drag = new Draggable(this);
            drag.makeDraggable(panelControl);

            DataTable dt = dh.getMinisters(MinisterStatus.Active);

            cmbMinister.Items.Add(string.Empty);//Added empty item to cmbMinister
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

                DataTable dt = dh.getMinisters(MinisterStatus.Active);

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
                Notification.Show(State.MissingFields);
                return;
            }

            if(cmbScheduleType.SelectedItem.ToString() == "Appointment")
            {
                if (!ministerAvailable()) //Checks if selected minister is available
                {
                    Notification.Show(State.ScheduleMinisterUnavailable);
                    return;
                }
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
            

            string title = txtTitle.Text.Trim();
            string details = txtDetails.Text.Trim();
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

            string title = txtTitle.Text.Trim();
            string details = txtDetails.Text.Trim();
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
            bool success = !string.IsNullOrWhiteSpace(txtTitle.Text);
            if (cmbScheduleType.SelectedIndex == (int)ScheduleType.Appointment) //Checks if Appointment type is selected
                success &= cmbMinister.SelectedIndex != 0;
            else if (cmbScheduleType.SelectedIndex == (int)ScheduleType.BloodDonation)
                success &= txtVenue.Text.Trim().Length != 0;
            return success;
                
        }
        /// <summary>
        /// Indicates whether a minister is available between Start and End
        /// </summary>
        /// <returns></returns>
        public bool ministerAvailable()
        {

            bool available = dh.ministerAvailable(((ComboboxContent)cmbMinister.SelectedItem).id, getDateTime(ScheduleTime.Start), getDateTime(ScheduleTime.End));
            return available;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
