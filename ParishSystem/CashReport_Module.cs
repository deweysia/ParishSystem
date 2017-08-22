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
    public partial class CashReport_Module : Form
    {
        int cashDisbursmentMode; //cashdisbursment OR cashrelease
        int bookReportMode; // book type parish community postulancy
        treasurerBackend dh = new treasurerBackend();
        public CashReport_Module(int cashdisbursment_cashrelease, int parish_community_postulancy)
        {
            InitializeComponent();
            this.cashDisbursmentMode = cashdisbursment_cashrelease;
            this.bookReportMode = parish_community_postulancy;
            if (cashdisbursment_cashrelease == 1)
            {
                filterBy_combobox_disbursment.Items.Remove("CV num");
                filterBy_combobox_disbursment.Items.Remove("CN num");
                filterBy_combobox_disbursment.Items.Add("OR Number");
            }
            else if (cashdisbursment_cashrelease == 2)
            {
                filterBy_combobox_disbursment.Items.Add("CV num");
                filterBy_combobox_disbursment.Items.Add("CN num");
                filterBy_combobox_disbursment.Items.Remove("OR Number");
            }
            filterBy_combobox_disbursment.SelectedIndex = 0;
        }



        private void breakdown_datagridview_report_disbursment_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Form A = new ORdetailsPopUp(int.Parse(report_datagridview_cashdisbursment.CurrentRow.Cells["ORnum"].Value.ToString()), cashDisbursmentMode, dh);
           // A.ShowDialog();
        }
        private void searchbar_textbox_report_disbursment_TextChanged(object sender, EventArgs e)
        {
            refreshReports();
        }
        private void from_dtp_cashdisbursment_ValueChanged(object sender, EventArgs e)
        {
            refreshReports();
        }
        private void to_dtp_cashdisbursment_ValueChanged(object sender, EventArgs e)
        {
            refreshReports();
        }
        private void filterBy_combobox_disbursment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterBy_combobox_disbursment.SelectedIndex == 0)
            {
                //refreshReports();
            }
            if (filterBy_combobox_disbursment.Text == "Recent")
            {
                searchbar_textbox_report_disbursment.Visible = false;
                from_dtp_cashdisbursment.Visible = false;
                to_dtp_cashdisbursment.Visible = false;
                CV_textbox_report_disbursment.Visible = false;
                CN_textbox_report_disbursment.Visible = false;
            }
            else if (filterBy_combobox_disbursment.Text == "Day")
            {
                searchbar_textbox_report_disbursment.Visible = false;
                from_dtp_cashdisbursment.Visible = true;
                to_dtp_cashdisbursment.Visible = false;
                CV_textbox_report_disbursment.Visible = false;
                CN_textbox_report_disbursment.Visible = false;
            }
            else if (filterBy_combobox_disbursment.Text == "Month")
            {
                searchbar_textbox_report_disbursment.Visible = false;
                from_dtp_cashdisbursment.Visible = true;
                to_dtp_cashdisbursment.Visible = false;
                CV_textbox_report_disbursment.Visible = false;
                CN_textbox_report_disbursment.Visible = false;
            }
            else if (filterBy_combobox_disbursment.Text == "Year")
            {
                searchbar_textbox_report_disbursment.Visible = false;
                from_dtp_cashdisbursment.Visible = true;
                to_dtp_cashdisbursment.Visible = false;
                CV_textbox_report_disbursment.Visible = false;
                CN_textbox_report_disbursment.Visible = false;
            }
            else if (filterBy_combobox_disbursment.Text == "Date Range")
            {
                searchbar_textbox_report_disbursment.Visible = false;
                from_dtp_cashdisbursment.Visible = true;
                to_dtp_cashdisbursment.Visible = true;
                CV_textbox_report_disbursment.Visible = false;
                CN_textbox_report_disbursment.Visible = false;
            }
            else if (filterBy_combobox_disbursment.Text == "OR Number")
            {
                searchbar_textbox_report_disbursment.Visible = true;
                from_dtp_cashdisbursment.Visible = false;
                to_dtp_cashdisbursment.Visible = false;
                CV_textbox_report_disbursment.Visible = false;
                CN_textbox_report_disbursment.Visible = false;
            }
            else if (filterBy_combobox_disbursment.Text == "CV num")
            {
                searchbar_textbox_report_disbursment.Visible = false;
                from_dtp_cashdisbursment.Visible = false;
                to_dtp_cashdisbursment.Visible = false;
                CV_textbox_report_disbursment.Visible = true;
                CN_textbox_report_disbursment.Visible = false;
            }
            else if (filterBy_combobox_disbursment.Text == "CN num")
            {
                searchbar_textbox_report_disbursment.Visible = false;
                from_dtp_cashdisbursment.Visible = false;
                to_dtp_cashdisbursment.Visible = false;
                CV_textbox_report_disbursment.Visible = false;
                CN_textbox_report_disbursment.Visible = true;
            }
            /*
            if(filterBy_combobox_disbursment.SelectedIndex == 1|| filterBy_combobox_disbursment.SelectedIndex == 2|| filterBy_combobox_disbursment.SelectedIndex == 3 || filterBy_combobox_disbursment.SelectedIndex == 4 || filterBy_combobox_disbursment.SelectedIndex == 6) { from_dtp_cashdisbursment.Visible = true; } else { from_dtp_cashdisbursment.Visible = false; }
            if (filterBy_combobox_disbursment.SelectedIndex == 0) { }
            if (filterBy_combobox_disbursment.SelectedIndex == 1) { }
            if (filterBy_combobox_disbursment.SelectedIndex == 2) { }
            if (filterBy_combobox_disbursment.SelectedIndex == 3) { to_dtp_cashdisbursment.Visible = true; } else { to_dtp_cashdisbursment.Visible = false; }
            if (filterBy_combobox_disbursment.SelectedIndex == 4) { searchbar_textbox_report_disbursment.Visible = true; } else { searchbar_textbox_report_disbursment.Visible = false; }
            if (filterBy_combobox_disbursment.SelectedIndex == 5) { }
            if (filterBy_combobox_disbursment.SelectedIndex == 6) { }
            if (filterBy_combobox_disbursment.SelectedIndex == 7) { }
            if (filterBy_combobox_disbursment.SelectedIndex == 8) { }
            
            */
        }
        private void breakdown_radiobutton_cashdisbursment_CheckedChanged(object sender, EventArgs e)
        {
            refreshReports();
        }
        private void total_radiobutton_cashdisbursment_CheckedChanged(object sender, EventArgs e)
        {
            refreshReports();
        }
        private void refreshReports()
        {
            try
            {
                if (bookReportMode == 1)
                {

                    report_datagridview_cashdisbursment.DataSource = null;
                    if (grouped_radiobutton_cashdisbursment.Checked)
                    {
                        if (total_radiobutton_cashdisbursment.Checked)
                        {
                            if (filterBy_combobox_disbursment.SelectedIndex == 0)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatRecent(cashDisbursmentMode);
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalGroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 1)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByDay(cashDisbursmentMode,
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("dd")),
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalGroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 2)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByMonth(cashDisbursmentMode,
                                                                                               int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                               int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalGroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 3)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByYear(cashDisbursmentMode,
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalGroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 4)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatBetweenDates(cashDisbursmentMode,
                                                                                                    from_dtp_cashdisbursment.Value,
                                                                                                    to_dtp_cashdisbursment.Value);
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalGroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 5)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByOrNumber(cashDisbursmentMode,
                                                                                                 int.Parse(searchbar_textbox_report_disbursment.Text));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalGroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                        }
                        else if (breakdown_radiobutton_cashdisbursment.Checked)
                        {
                            if (filterBy_combobox_disbursment.SelectedIndex == 0)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatRecent(cashDisbursmentMode);
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownGroupedCashDisbursment(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 1)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByDay(cashDisbursmentMode,
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("dd")),
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownGroupedCashDisbursment(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 2)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByMonth(cashDisbursmentMode,
                                                                                               int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                               int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownGroupedCashDisbursment(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 3)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByYear(cashDisbursmentMode,
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownGroupedCashDisbursment(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 4)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatBetweenDates(cashDisbursmentMode,
                                                                                                    from_dtp_cashdisbursment.Value,
                                                                                                    to_dtp_cashdisbursment.Value);
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownGroupedCashDisbursment(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 5)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByOrNumber(cashDisbursmentMode,
                                                                                                 int.Parse(searchbar_textbox_report_disbursment.Text));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownGroupedCashDisbursment(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                        }

                    }
                    else if (notGrouped_radiobutton_cashdisbursment.Checked)
                    {
                        if (total_radiobutton_cashdisbursment.Checked)
                        {
                            if (filterBy_combobox_disbursment.SelectedIndex == 0)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatRecent(cashDisbursmentMode);
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalUngroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 1)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByDay(cashDisbursmentMode,
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("dd")),
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalUngroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 2)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByMonth(cashDisbursmentMode,
                                                                                               int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                               int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalUngroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 3)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByYear(cashDisbursmentMode,
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalUngroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 4)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatBetweenDates(cashDisbursmentMode,
                                                                                                    from_dtp_cashdisbursment.Value,
                                                                                                    to_dtp_cashdisbursment.Value);
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalUngroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 5)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByOrNumber(cashDisbursmentMode,
                                                                                                 int.Parse(searchbar_textbox_report_disbursment.Text));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalUngroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                        }
                        else if (breakdown_radiobutton_cashdisbursment.Checked)
                        {
                            if (filterBy_combobox_disbursment.SelectedIndex == 0)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatRecent(cashDisbursmentMode);
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownUngroupedCashDisbursment(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 1)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByDay(cashDisbursmentMode,
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("dd")),
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownUngroupedCashDisbursment(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 2)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByMonth(cashDisbursmentMode,
                                                                                               int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                               int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownUngroupedCashDisbursment(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 3)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByYear(cashDisbursmentMode,
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownUngroupedCashDisbursment(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 4)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatBetweenDates(cashDisbursmentMode,
                                                                                                    from_dtp_cashdisbursment.Value,
                                                                                                    to_dtp_cashdisbursment.Value);
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownUngroupedCashDisbursment(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 5)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByOrNumber(cashDisbursmentMode,
                                                                                                 int.Parse(searchbar_textbox_report_disbursment.Text));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownUngroupedCashDisbursment(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }

                        }
                    }
                }

                else if (bookReportMode == 2)
                {
                    report_datagridview_cashdisbursment.DataSource = null;
                    if (grouped_radiobutton_cashdisbursment.Checked)
                    {
                        if (total_radiobutton_cashdisbursment.Checked)
                        {
                            if (filterBy_combobox_disbursment.SelectedIndex == 0)
                            {
                                DataTable dt = dh.getTransactionsCRBByAccountingBookFormatRecent(cashDisbursmentMode);
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalGroupedCashRelease(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 1)
                            {
                                DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByDay(cashDisbursmentMode,
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("dd")),
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalGroupedCashRelease(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 2)
                            {
                                DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByMonth(cashDisbursmentMode,
                                                                                               int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                               int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalGroupedCashRelease(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 3)
                            {
                                DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByYear(cashDisbursmentMode,
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalGroupedCashRelease(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 4)
                            {
                                DataTable dt = dh.getTransactionsCRBByAccountingBookFormatBetweenDates(cashDisbursmentMode,
                                                                                                    from_dtp_cashdisbursment.Value,
                                                                                                    to_dtp_cashdisbursment.Value);
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalGroupedCashRelease(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 5)
                            {
                                DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByOrNumber(cashDisbursmentMode,
                                                                                                 int.Parse(CN_textbox_report_disbursment.Text),
                                                                                                 int.Parse(CV_textbox_report_disbursment.Text));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalGroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                            }
                        }
                        else if (breakdown_radiobutton_cashdisbursment.Checked)
                        {
                            if (filterBy_combobox_disbursment.SelectedIndex == 0)
                            {
                                DataTable dt = dh.getTransactionsCRBByAccountingBookFormatRecent(cashDisbursmentMode);
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownGroupedCashRelease(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 1)
                            {
                                DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByDay(cashDisbursmentMode,
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("dd")),
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownGroupedCashRelease(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 2)
                            {
                                DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByMonth(cashDisbursmentMode,
                                                                                               int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                               int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownGroupedCashRelease(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 3)
                            {
                                DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByYear(cashDisbursmentMode,
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownGroupedCashRelease(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 4)
                            {
                                DataTable dt = dh.getTransactionsCRBByAccountingBookFormatBetweenDates(cashDisbursmentMode,
                                                                                                    from_dtp_cashdisbursment.Value,
                                                                                                    to_dtp_cashdisbursment.Value);
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownGroupedCashRelease(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 5)
                            {
                                DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByOrNumber(cashDisbursmentMode,
                                                                                                 int.Parse(CN_textbox_report_disbursment.Text),
                                                                                                 int.Parse(CV_textbox_report_disbursment.Text));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownGroupedCashRelease(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                            }
                        }

                    }
                    else if (notGrouped_radiobutton_cashdisbursment.Checked)
                    {
                        if (total_radiobutton_cashdisbursment.Checked)
                        {
                            if (filterBy_combobox_disbursment.SelectedIndex == 0)
                            {
                                DataTable dt = dh.getTransactionsCRBByAccountingBookFormatRecent(cashDisbursmentMode);
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalUngroupedCashRelease(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 1)
                            {
                                DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByDay(cashDisbursmentMode,
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("dd")),
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalUngroupedCashRelease(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 2)
                            {
                                DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByMonth(cashDisbursmentMode,
                                                                                               int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                               int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalUngroupedCashRelease(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 3)
                            {
                                DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByYear(cashDisbursmentMode,
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalUngroupedCashRelease(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 4)
                            {
                                DataTable dt = dh.getTransactionsCRBByAccountingBookFormatBetweenDates(cashDisbursmentMode,
                                                                                                    from_dtp_cashdisbursment.Value,
                                                                                                    to_dtp_cashdisbursment.Value);
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalUngroupedCashRelease(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 5)
                            {
                                DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByOrNumber(cashDisbursmentMode,
                                                                                                 int.Parse(CN_textbox_report_disbursment.Text),
                                                                                                 int.Parse(CV_textbox_report_disbursment.Text));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalUngroupedCashRelease(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                            }
                        }
                        else if (breakdown_radiobutton_cashdisbursment.Checked)
                        {
                            if (filterBy_combobox_disbursment.SelectedIndex == 0)
                            {
                                DataTable dt = dh.getTransactionsCRBByAccountingBookFormatRecent(cashDisbursmentMode);
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownUngroupedCashRelease(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 1)
                            {
                                DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByDay(cashDisbursmentMode,
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("dd")),
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownUngroupedCashRelease(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 2)
                            {
                                DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByMonth(cashDisbursmentMode,
                                                                                               int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                               int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownUngroupedCashRelease(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 3)
                            {
                                DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByYear(cashDisbursmentMode,
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownUngroupedCashRelease(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 4)
                            {
                                DataTable dt = dh.getTransactionsCRBByAccountingBookFormatBetweenDates(cashDisbursmentMode,
                                                                                                    from_dtp_cashdisbursment.Value,
                                                                                                    to_dtp_cashdisbursment.Value);
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownUngroupedCashRelease(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 5)
                            {
                                DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByOrNumber(cashDisbursmentMode,
                                                                                                 int.Parse(CN_textbox_report_disbursment.Text),
                                                                                                 int.Parse(CV_textbox_report_disbursment.Text));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownUngroupedCashRelease(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                            }

                        }
                    }
                }
            }
            catch { }


        }

       
        private void generate_report(object sender, EventArgs e)
        {
            refreshReports();
        }

     
    }
}
