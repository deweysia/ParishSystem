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
        private enum ScheduleTime
        {
            Start, End
        }

        public AddSchedule()
        {
            InitializeComponent();
            dtpDateStart.MinDate = DateTime.Now.Date;
            dtpDateStart.Value = DateTime.Now.Date;
            dtpDateEnd.MinDate = DateTime.Now.Date;
            dtpDateEnd.Value = DateTime.Now.Date;

            dtpTimeStart.Value = DateTime.Now;
            dtpTimeEnd.Value = DateTime.Now;

            

            DataTable dt = dh.getMinisterWithStatus(MinisterStatus.Active);
            cmbMinister.Items.Add(new ComboboxContent(-1, "Unspecified"));
            foreach (DataRow r in dt.Rows)
            {
                ComboboxContent cc = new ComboboxContent(int.Parse(r["ministerID"].ToString()), r["name"].ToString());
                cmbMinister.Items.Add(cc);
            }

            cmbScheduleType.SelectedIndex = 0;
            cmbMinister.SelectedIndex = 0;

            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

            if (startStartLessThanEnd())
                dtpDateEnd.Value = dtpDateStart.Value.Date;
            //dtpDateEnd.MinDate = dtpDateStart.Value.Date;
        }

        private void dtpDateEnd_ValueChanged(object sender, EventArgs e)
        {
            if (startStartLessThanEnd())
                dtpDateStart.Value = dtpDateEnd.Value.Date;
        }

        private void dtpTimeStart_ValueChanged(object sender, EventArgs e)
        {
            if (startStartLessThanEnd())
                dtpTimeEnd.Value = dtpTimeStart.Value;
        }
        private void dtpTimeEnd_ValueChanged(object sender, EventArgs e)
        {
            if (startStartLessThanEnd())
                dtpTimeStart.Value = dtpTimeEnd.Value;
        }

        private bool startStartLessThanEnd()
        {
            DateTime start = getDateTime(ScheduleTime.Start);
            DateTime end = getDateTime(ScheduleTime.End);

            return start < end;
        }

        private DateTime getDateTime(ScheduleTime t)
        {
            if(t == ScheduleTime.Start)
                return new DateTime(dtpDateStart.Value.Year, dtpDateStart.Value.Month, dtpDateStart.Value.Day, dtpTimeStart.Value.Hour, dtpTimeStart.Value.Minute, 0);
            return new DateTime(dtpDateEnd.Value.Year, dtpDateEnd.Value.Month, dtpDateEnd.Value.Day, dtpTimeEnd.Value.Hour, dtpTimeEnd.Value.Minute, 0);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }
    }
}
