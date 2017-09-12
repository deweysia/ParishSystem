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
        int cashDisbursmentMode; //parish community post
        int bookReportMode; // cash disburs cash release  -->opposite sila
        DataHandler dh = new DataHandler();
        public CashReport_Module(int cashdisbursment_cashrelease, int parish_community_postulancy)
        {
            InitializeComponent();
            this.bookReportMode = cashdisbursment_cashrelease;
            this.cashDisbursmentMode = parish_community_postulancy;
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
            if (notGrouped_radiobutton_cashdisbursment.Checked)
            {
                Form A = new ORdetailsPopUp(int.Parse(report_datagridview_cashdisbursment.CurrentRow.Cells[0].Value.ToString()), cashDisbursmentMode, dh);
                A.ShowDialog();
            }
            else
            {

            }
        }
       
        private void filterBy_combobox_disbursment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterBy_combobox_disbursment.Text == "Recent")
            {
                searchbar_textbox_report_disbursment.Visible = false;
                from_dtp_cashdisbursment.Visible = false;
                to_dtp_cashdisbursment.Visible = false;
                CV_textbox_report_disbursment.Visible = false;
                CN_textbox_report_disbursment.Visible = false;

                date_lbl.Visible = false;
                from_lbl.Visible = false;
                to_lbl.Visible = false;
                OR_lbl.Visible = false;
                CV_lbl.Visible = false;
                CN_lbl.Visible = false;
                date_pnl.Visible = false;

                input_panel.Visible = false;

            }
            else if (filterBy_combobox_disbursment.Text == "Day")
            {
                searchbar_textbox_report_disbursment.Visible = false;
                from_dtp_cashdisbursment.Visible = true;
                to_dtp_cashdisbursment.Visible = false;
                CV_textbox_report_disbursment.Visible = false;
                CN_textbox_report_disbursment.Visible = false;

                date_lbl.Visible = true;
                from_lbl.Visible = false;
                to_lbl.Visible = false;
                OR_lbl.Visible = false;
                CV_lbl.Visible = false;
                CN_lbl.Visible = false;
                date_pnl.Visible = true;

                input_panel.Visible = true;

                from_dtp_cashdisbursment.CustomFormat = "MM/dd/yyyy";
            }
            else if (filterBy_combobox_disbursment.Text == "Month")
            {
                searchbar_textbox_report_disbursment.Visible = false;
                from_dtp_cashdisbursment.Visible = true;
                to_dtp_cashdisbursment.Visible = false;
                CV_textbox_report_disbursment.Visible = false;
                CN_textbox_report_disbursment.Visible = false;

                date_lbl.Visible = true;
                from_lbl.Visible = false;
                to_lbl.Visible = false;
                OR_lbl.Visible = false;
                CV_lbl.Visible = false;
                CN_lbl.Visible = false;
                date_pnl.Visible = true;

                input_panel.Visible = true;

                from_dtp_cashdisbursment.CustomFormat = "MM/yyyy";
            }
            else if (filterBy_combobox_disbursment.Text == "Year")
            {
                searchbar_textbox_report_disbursment.Visible = false;
                from_dtp_cashdisbursment.Visible = true;
                to_dtp_cashdisbursment.Visible = false;
                CV_textbox_report_disbursment.Visible = false;
                CN_textbox_report_disbursment.Visible = false;

                date_lbl.Visible = true;
                from_lbl.Visible = false;
                to_lbl.Visible = false;
                OR_lbl.Visible = false;
                CV_lbl.Visible = false;
                CN_lbl.Visible = false;
                date_pnl.Visible = true;

                input_panel.Visible = true;

                from_dtp_cashdisbursment.CustomFormat = "yyyy";
            }
            else if (filterBy_combobox_disbursment.Text == "Date Range")
            {
                searchbar_textbox_report_disbursment.Visible = false;
                from_dtp_cashdisbursment.Visible = true;
                to_dtp_cashdisbursment.Visible = true;
                CV_textbox_report_disbursment.Visible = false;
                CN_textbox_report_disbursment.Visible = false;

                date_lbl.Visible = false;
                from_lbl.Visible = true;
                to_lbl.Visible = true;
                OR_lbl.Visible = false;
                CV_lbl.Visible = false;
                CN_lbl.Visible = false;
                date_pnl.Visible = true;

                input_panel.Visible = true;

                from_dtp_cashdisbursment.CustomFormat = "MM/dd/yyyy";
                to_dtp_cashdisbursment.CustomFormat = "MM/dd/yyyy";
            }
            else if (filterBy_combobox_disbursment.Text == "OR Number")
            {
                searchbar_textbox_report_disbursment.Visible = true;
                from_dtp_cashdisbursment.Visible = false;
                to_dtp_cashdisbursment.Visible = false;
                CV_textbox_report_disbursment.Visible = false;
                CN_textbox_report_disbursment.Visible = false;

                date_lbl.Visible = false;
                from_lbl.Visible = false;
                to_lbl.Visible = false;
                OR_lbl.Visible = true;
                CV_lbl.Visible = false;
                CN_lbl.Visible = false;
                date_pnl.Visible = false;

                input_panel.Visible = true;
            }
            else if (filterBy_combobox_disbursment.Text == "CV num")
            {
                searchbar_textbox_report_disbursment.Visible = false;
                from_dtp_cashdisbursment.Visible = false;
                to_dtp_cashdisbursment.Visible = false;
                CV_textbox_report_disbursment.Visible = true;
                CN_textbox_report_disbursment.Visible = false;

                date_lbl.Visible = false;
                from_lbl.Visible = false;
                to_lbl.Visible = false;
                OR_lbl.Visible = false;
                CV_lbl.Visible = true;
                CN_lbl.Visible = false;
                date_pnl.Visible = false;

                input_panel.Visible = true;
            }
            else if (filterBy_combobox_disbursment.Text == "CN num")
            {
                searchbar_textbox_report_disbursment.Visible = false;
                from_dtp_cashdisbursment.Visible = false;
                to_dtp_cashdisbursment.Visible = false;
                CV_textbox_report_disbursment.Visible = false;
                CN_textbox_report_disbursment.Visible = true;

                date_lbl.Visible = false;
                from_lbl.Visible = false;
                to_lbl.Visible = false;
                OR_lbl.Visible = false;
                CV_lbl.Visible = false;
                CN_lbl.Visible = true;
                date_pnl.Visible = false;

                input_panel.Visible = true;
            }
        }
       
        private void refreshReports()
        {
            summary_datagridview_report_disbursment.DataSource = null;
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

        private void refreshReport()
        {

        }
       
        private void generate_report(object sender, EventArgs e)
        {
            refreshReports();
            open = !open;
            timer1.Start();
            if (breakdown_radiobutton_cashdisbursment.Checked) 
            {
                report_datagridview_cashdisbursment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }
            else
            {
                report_datagridview_cashdisbursment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            excel.Enabled = true;
        }
        bool open = false;
        int velocity = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (open)
            {
                if (reportFilter_panel.Height <= 300)
                {
                    reportFilter_panel.Height = reportFilter_panel.Height + velocity;
                    velocity++;
                }
                else
                {
                    timer1.Stop();
                    reportFilter_panel.Height = 300;
                    velocity = 0;
                   
                }
            }
            else
            {
                if (reportFilter_panel.Height >= 35)
                {
                    reportFilter_panel.Height = reportFilter_panel.Height - velocity;
                    velocity++;
                }
                else
                {
                    timer1.Stop();
                    reportFilter_panel.Height = 35;
                    velocity = 0;
                  
                }
            }
        }

        private void Open_button_Click(object sender, EventArgs e)
        {
            timer1.Start();
            open = !open;
         
        }

        private void excel_Click(object sender, EventArgs e)
        {
            dh.DisplayInExcel(report_datagridview_cashdisbursment);
        }

        private void reportFilter_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void parish_label_Click(object sender, EventArgs e)
        {
            this.bookReportMode = 1;
            report_datagridview_cashdisbursment.DataSource = null;
            summary_datagridview_report_disbursment.DataSource = null;
            parish_label.Font = new Font(parish_label.Font, FontStyle.Bold);
            community_label.Font = new Font(community_label.Font, FontStyle.Regular);
            postulancy_label.Font = new Font(postulancy_label.Font, FontStyle.Regular);
            parish_label.ForeColor = Color.Black;
            community_label.ForeColor = Color.FromArgb(64, 64, 64);
            postulancy_label.ForeColor = Color.FromArgb(64, 64, 64);
            excel.Enabled = false;
        }

        private void community_label_Click(object sender, EventArgs e)
        {
            this.bookReportMode = 2;
            report_datagridview_cashdisbursment.DataSource = null;
            summary_datagridview_report_disbursment.DataSource = null;
            parish_label.Font = new Font(parish_label.Font, FontStyle.Regular);
            community_label.Font = new Font(community_label.Font, FontStyle.Bold);
            postulancy_label.Font = new Font(postulancy_label.Font, FontStyle.Regular);
            parish_label.ForeColor = Color.FromArgb(64, 64, 64);
            community_label.ForeColor = Color.Black;
            postulancy_label.ForeColor = Color.FromArgb(64, 64, 64);
            excel.Enabled = false;
        }

        private void postulancy_label_Click(object sender, EventArgs e)
        {
            this.bookReportMode = 3;
            report_datagridview_cashdisbursment.DataSource = null;
            summary_datagridview_report_disbursment.DataSource = null;
            parish_label.Font = new Font(parish_label.Font, FontStyle.Regular);
            community_label.Font = new Font(community_label.Font, FontStyle.Regular);
            postulancy_label.Font = new Font(postulancy_label.Font, FontStyle.Bold);
            parish_label.ForeColor = Color.FromArgb(64, 64, 64);
            community_label.ForeColor = Color.FromArgb(64, 64, 64);
            postulancy_label.ForeColor = Color.Black;
            excel.Enabled = false;
        }
    }
}
