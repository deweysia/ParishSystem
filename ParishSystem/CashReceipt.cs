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
    public partial class CashReceipt : Form
    {
        int bookModeFullPay;
        DataHandler dh = new DataHandler();
        public CashReceipt(int bookModeFullPay)
        {
            InitializeComponent();
            this.bookModeFullPay = bookModeFullPay;
            suggestedPrice_nud_fullpay.Maximum = decimal.MaxValue;
        }

        private void CDB_FullPayment_Module_Load(object sender, EventArgs e)
        {
            RefreshMain();
        }

        #region Clean and Load
        private void RefreshMain()
        {
            itemType_combobox_fullpay.SelectedIndex = 0;
            orNumber_label_fullpay.Text=dh.getnextORof(bookModeFullPay).ToString();
            item_dgv_fullpay.Rows.Clear();
            sourceName_textbox_fullpay.Clear();
            remarks_textbox_fullpay.Clear();
            final_button_fullpay.Enabled = false;
            DataTable dt = dh.getItemsActive(bookModeFullPay,1);
            itemType_combobox_fullpay.Items.Clear();
            itemType_combobox_fullpay.Items.Add("");
            foreach (DataRow dr in dt.Rows)
            {
                itemType_combobox_fullpay.Items.Add(new ComboboxContent(int.Parse(dr["itemTypeID"].ToString()), dr["itemType"].ToString(), dr["suggestedPrice"].ToString()));
            }
            suggestedPrice_nud_fullpay.Value = 0;
            subtotal_panel.Visible = false;
            Person_panel.Visible = false;
            price_panel.Visible = false;
            ClearNonPerson();
        }
        private void suggestedPrice_nud_fullpay_parish_ValueChanged(object sender, EventArgs e)
        {
            suggestedPrice_label.Text = suggestedPrice_nud_fullpay.Value.ToString();
            subTotal_label_fullpay.Text = (suggestedPrice_nud_fullpay.Value * quantity_nud_fullpay.Value).ToString("0.00"); ;
            AddButtonDataValidation();
        }
        private void editSuggestedPrice_button_Click(object sender, EventArgs e)
        {
            if (editSuggestedPrice_button.Tag.ToString() == "e")
            {
                suggestedPrice_nud_fullpay.Visible = true;
                suggestedPrice_label.Visible = false;
                editSuggestedPrice_button.Tag = "s";
                cancelSuggestedPrice_button.Visible = true;

            }
            else
            {
                suggestedPrice_nud_fullpay.Visible = false;
                suggestedPrice_label.Visible = true;
                editSuggestedPrice_button.Tag = "e";
                cancelSuggestedPrice_button.Visible = false;
                
            }
        }
        private void cancelSuggestedPrice_button_Click(object sender, EventArgs e)
        {
            if (applicant_combox_fullpay.Text!="")// if non person mode, payments that are not baptism conf or mar
            {
                suggestedPrice_nud_fullpay.Value = decimal.Parse(targetPrice_label.Text) - decimal.Parse(pricePaid_label.Text);
            }
            else if (itemType_combobox_fullpay.SelectedIndex!=0)
            {
                suggestedPrice_nud_fullpay.Value = decimal.Parse(((ComboboxContent)itemType_combobox_fullpay.SelectedItem).Content2);
            }
            else
            {
                suggestedPrice_nud_fullpay.Value = 0;
            }
            suggestedPrice_nud_fullpay.Visible = false;
            suggestedPrice_label.Visible = true;
            editSuggestedPrice_button.Tag = "e";
            cancelSuggestedPrice_button.Visible = false;
        }
        private void AddButtonDataValidation()
        {
            if (Person_panel.Visible)//bap,conf,mar
            {
                add_button_fullpay.Enabled = (suggestedPrice_nud_fullpay.Value > 0 && applicant_combox_fullpay.Text != "" ? true : false);
            }
            else if(subtotal_panel.Visible)//normal pay
            {
                add_button_fullpay.Enabled = (decimal.Parse(subTotal_label_fullpay.Text) != 0 ? true : false); 
            }
        }

        private void itemType_combobox_fullpay_SelectedIndexChanged(object sender, EventArgs e)
        {
            suggestedPrice_nud_fullpay.Maximum = decimal.MaxValue;
            cancelSuggestedPrice_button.PerformClick();//click cancel edit price so everything is set to uneditable
            if (itemType_combobox_fullpay.SelectedIndex != 0)
            {
                if (decimal.Parse(((ComboboxContent)itemType_combobox_fullpay.SelectedItem).Content2) == 0)// if there is no set suggested price
                {
                    suggestedPrice_nud_fullpay.Maximum = decimal.MaxValue;
                    suggestedPrice_nud_fullpay.Value = 0;
                    suggestedPrice_label.Visible = false;
                    editSuggestedPrice_button.Visible = false;
                    suggestedPrice_nud_fullpay.Visible = true;
                }
                else
                {
                    
                    suggestedPrice_nud_fullpay.Value = decimal.Parse(((ComboboxContent)itemType_combobox_fullpay.SelectedItem).Content2);
                    suggestedPrice_label.Visible = true;
                    editSuggestedPrice_button.Visible = false;
                    suggestedPrice_nud_fullpay.Visible = false;

                }
                price_panel.Visible = true;
                if (bookModeFullPay == 1 && (itemType_combobox_fullpay.Text == "Baptism" || itemType_combobox_fullpay.Text == "Confirmation" || itemType_combobox_fullpay.Text == "Marriage"))
                {
                    subtotal_panel.Visible = false;
                    Person_panel.Visible = true;
                    RefreshPerson();
                    
                }
                else
                {
                    subtotal_panel.Visible = true;
                    Person_panel.Visible = false;          
                }
            }
            else
            {
                suggestedPrice_nud_fullpay.Value = 0;
                subtotal_panel.Visible = false;
                Person_panel.Visible = false;
                price_panel.Visible = false;
                ClearNonPerson();
            }
            AddButtonDataValidation();
        }
        private void RefreshPerson()
        {
            DataTable dt = new DataTable();
            if (itemType_combobox_fullpay.Text == "Baptism")
            {
                dt = dh.getApplicationsWithoutPay((int)SacramentType.Baptism);
                editSuggestedPrice_button.Visible = true;
            }
            else if (itemType_combobox_fullpay.Text == "Confirmation")
            {
                dt = dh.getApplicationsWithoutPay((int)SacramentType.Confirmation);
                editSuggestedPrice_button.Visible = true;
            }
            else if (itemType_combobox_fullpay.Text == "Marriage")
            {
                dt = dh.getApplicationsWithoutPay((int)SacramentType.Marriage);
            }
            applicant_combox_fullpay.Items.Clear();
            applicant_combox_fullpay.Items.Add("");
            foreach (DataRow dr in dt.Rows)
            {
                applicant_combox_fullpay.Items.Add(new ComboboxContent(int.Parse(dr["applicationID"].ToString()), dr["name"].ToString()));
            }
            targetPrice_label.Text = "0.00";
            pricePaid_label.Text = "0.00";
        }
        private void ClearNonPerson()
        {
            quantity_nud_fullpay.Value = 1;
            subTotal_label_fullpay.Text = "0.00";
        }

        private void suggestedPrice_label_TextChanged(object sender, EventArgs e)
        {
            subTotal_label_fullpay.Text=(suggestedPrice_nud_fullpay.Value * quantity_nud_fullpay.Value).ToString();
            AddButtonDataValidation();
        }
        private void quantity_nud_fullpay_parish_ValueChanged(object sender, EventArgs e)
        {
            subTotal_label_fullpay.Text = (suggestedPrice_nud_fullpay.Value * quantity_nud_fullpay.Value).ToString("0.00");
            AddButtonDataValidation();
        }

        private void applicant_combox_fullpay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (applicant_combox_fullpay.SelectedIndex != 0)
            {
                person_SubPanel.Visible = true;
                bool notExist = true;
                if (applicant_combox_fullpay.Items.Count > 0)
                {
                    if (add_button_fullpay.Tag.ToString() == "a")
                    {
                        if (applicant_combox_fullpay.SelectedIndex != 0)
                        {
                            foreach (DataGridViewRow dr in item_dgv_fullpay.Rows)
                            {
                                if ((dr.Cells[5].Value == null ? "" : dr.Cells[5].Value.ToString()) == ((ComboboxContent)applicant_combox_fullpay.SelectedItem).ID.ToString())
                                {
                                    notExist = false;
                                }
                            }
                        }
                    }
                }
                if (notExist)
                {
                    DataTable paymentDetails = dh.getApplicationPaymentOf(((ComboboxContent)applicant_combox_fullpay.SelectedItem).ID);
                    if (paymentDetails.Rows[0][0].ToString() != "")//has set a price in application
                    {
                        if (decimal.Parse(paymentDetails.Rows[0][0].ToString()) <= (paymentDetails.Rows[0][1].ToString() == "" ? 0 : decimal.Parse(paymentDetails.Rows[0][1].ToString())))
                        {
                            Notification.Show(State.AlreadyPaid);
                            applicant_combox_fullpay.SelectedIndex = 0;
                        }
                        else
                        {
                            targetPrice_label.Text = float.Parse(paymentDetails.Rows[0][0].ToString()).ToString("0.00");
                            pricePaid_label.Text = (paymentDetails.Rows[0][1].ToString() == "" ? "0.00" : paymentDetails.Rows[0][1].ToString());
                            suggestedPrice_nud_fullpay.Maximum = decimal.Parse(targetPrice_label.Text) - decimal.Parse(pricePaid_label.Text);
                            suggestedPrice_nud_fullpay.Value = decimal.Parse(targetPrice_label.Text) - decimal.Parse(pricePaid_label.Text);
                        }
                    }
                    else
                    {
                        if (add_button_fullpay.Tag.ToString() == "a")//make target price= default and paid= 0
                        {
                            targetPrice_label.Text = float.Parse(((ComboboxContent)itemType_combobox_fullpay.SelectedItem).content2).ToString("0.00");
                            pricePaid_label.Text = 0.ToString();
                            suggestedPrice_nud_fullpay.Maximum = decimal.Parse(((ComboboxContent)itemType_combobox_fullpay.SelectedItem).content2);
                            suggestedPrice_nud_fullpay.Value = decimal.Parse(((ComboboxContent)itemType_combobox_fullpay.SelectedItem).content2);
                        }
                    }
                }
            else
            {
                Notification.Show(State.HasTransaction);
                applicant_combox_fullpay.SelectedIndex = 0;
            }
            }
            else
            {
                person_SubPanel.Visible = false;//hide target price, hide paid
                suggestedPrice_nud_fullpay.Value = decimal.Parse(((ComboboxContent)itemType_combobox_fullpay.SelectedItem).Content2);//reset price to default
            }
            AddButtonDataValidation();
        }
        private void clearProfile()
        {
            pricePaid_label.Text = "0.00";
            targetPrice_label.Text = "0.00";
        }
       
        private void cancelTransaction_button_fullpay_parish_Click(object sender, EventArgs e)
        {
            if (item_dgv_fullpay.Rows.Count > 0)
            {
                if (MessageDialog.Show("This will clear your current transaction. Are you sure you want to proceed?", MessageDialogButtons.YesNo, MessageDialogIcon.Question) == DialogResult.Yes)
                {
                    itemType_combobox_fullpay.Enabled = true;
                    itemType_combobox_fullpay.SelectedIndex = 0;
                    item_dgv_fullpay.Rows.Clear();
                    sourceName_textbox_fullpay.Text = "";
                    remarks_textbox_fullpay.Text = "";
                    total_label_fullpay.Text = "0.00";
                    add_button_fullpay.Enabled = false;
                    delete_button_fullpay.Enabled = false;
                    add_button_fullpay.Text = "Add";
                    add_button_fullpay.Tag = "a";
                }
            }
            else
            {
                itemType_combobox_fullpay.Enabled = true;
                itemType_combobox_fullpay.SelectedIndex = 0;
                item_dgv_fullpay.Rows.Clear();
                sourceName_textbox_fullpay.Text = "";
                remarks_textbox_fullpay.Text = "";
                total_label_fullpay.Text = "0.00";
                add_button_fullpay.Enabled = false;
                delete_button_fullpay.Enabled = false;
                add_button_fullpay.Text = "Add";
                add_button_fullpay.Tag = "a";
            }
        }
  
        
        #endregion
      
        
       
        private void refreshTotalLabel()
        {
            
            decimal sum = 0;
            foreach (DataGridViewRow dr in item_dgv_fullpay.Rows)
            {
                sum += decimal.Parse(dr.Cells["TotalDataGridViewColumn"].Value.ToString());
            }
            total_label_fullpay.Text = sum.ToString();
            
        }
        private void add_button_fullpay_parish_Click(object sender, EventArgs e)
        {
                if ((itemType_combobox_fullpay.Text == "Baptism" || itemType_combobox_fullpay.Text == "Confirmation" || itemType_combobox_fullpay.Text == "Marriage") && bookModeFullPay == (int)BookType.Parish)
                {
                    if ((string)add_button_fullpay.Tag == "a")
                    {

                        int index = item_dgv_fullpay.Rows.Add();
                        item_dgv_fullpay.Rows[index].Cells[0].Value = itemType_combobox_fullpay.SelectedItem.ToString();
                        item_dgv_fullpay.Rows[index].Cells[1].Value = suggestedPrice_nud_fullpay.Value.ToString();
                        item_dgv_fullpay.Rows[index].Cells[2].Value = 1;
                        item_dgv_fullpay.Rows[index].Cells[3].Value = subTotal_label_fullpay.Text;
                        item_dgv_fullpay.Rows[index].Cells[4].Value = itemType_combobox_fullpay.SelectedIndex;//hidden
                        item_dgv_fullpay.Rows[index].Cells[5].Value = ((ComboboxContent)applicant_combox_fullpay.SelectedItem).ID.ToString();//hidden
                        item_dgv_fullpay.Rows[index].Cells[6].Value = applicant_combox_fullpay.SelectedIndex;
                        item_dgv_fullpay.Rows[index].Cells[7].Value = targetPrice_label.Text;
                        item_dgv_fullpay.Rows[index].Cells[8].Value = pricePaid_label.Text;
                        //add_button_fullpay.Enabled = true;
                        //itemType_combobox_fullpay.Enabled = true;
                }
                    else//edit mode
                    {
                        item_dgv_fullpay.SelectedRows[0].Cells[0].Value = itemType_combobox_fullpay.SelectedItem.ToString();
                        item_dgv_fullpay.SelectedRows[0].Cells[1].Value = suggestedPrice_nud_fullpay.Value.ToString();
                        item_dgv_fullpay.SelectedRows[0].Cells[2].Value = 1;
                        item_dgv_fullpay.SelectedRows[0].Cells[3].Value = subTotal_label_fullpay.Text;
                        item_dgv_fullpay.SelectedRows[0].Cells[4].Value = itemType_combobox_fullpay.SelectedIndex;//hidden
                        item_dgv_fullpay.SelectedRows[0].Cells[5].Value = ((ComboboxContent)applicant_combox_fullpay.SelectedItem).ID.ToString();//hidden
                        item_dgv_fullpay.SelectedRows[0].Cells[6].Value = applicant_combox_fullpay.SelectedIndex;
                        item_dgv_fullpay.SelectedRows[0].Cells[7].Value = targetPrice_label.Text;
                        item_dgv_fullpay.SelectedRows[0].Cells[8].Value = pricePaid_label.Text;
                        delete_button_fullpay.Enabled = false;
                        add_button_fullpay.Text = "Add";
                        add_button_fullpay.Tag = "a";
                        add_button_fullpay.Enabled = false;
                        itemType_combobox_fullpay.Enabled = true;
                    }
                    refreshTotalLabel();
                    itemType_combobox_fullpay.SelectedIndex = 0;
            }
            
            else
            {
                if (itemType_combobox_fullpay.Text != "" && quantity_nud_fullpay.Value != 0)
                {
                    if ((string)add_button_fullpay.Tag == "a")
                    {
                        int index = item_dgv_fullpay.Rows.Add();
                        item_dgv_fullpay.Rows[index].Cells[0].Value = itemType_combobox_fullpay.SelectedItem.ToString();
                        item_dgv_fullpay.Rows[index].Cells[1].Value = suggestedPrice_nud_fullpay.Value.ToString("0.00");
                        item_dgv_fullpay.Rows[index].Cells[2].Value = quantity_nud_fullpay.Value.ToString();
                        item_dgv_fullpay.Rows[index].Cells[3].Value = subTotal_label_fullpay.Text;
                        item_dgv_fullpay.Rows[index].Cells[4].Value = itemType_combobox_fullpay.SelectedIndex;//hidden
                        item_dgv_fullpay.Rows[index].Cells[5].Value = null;
                        item_dgv_fullpay.Rows[index].Cells[6].Value = null;
                        item_dgv_fullpay.Rows[index].Cells[7].Value = null;
                    }
                    else
                    {
                        item_dgv_fullpay.SelectedRows[0].Cells[0].Value = itemType_combobox_fullpay.SelectedItem.ToString();
                        item_dgv_fullpay.SelectedRows[0].Cells[1].Value = suggestedPrice_nud_fullpay.Value.ToString("0.00");
                        item_dgv_fullpay.SelectedRows[0].Cells[2].Value = quantity_nud_fullpay.Value.ToString();
                        item_dgv_fullpay.SelectedRows[0].Cells[3].Value = subTotal_label_fullpay.Text;
                        item_dgv_fullpay.SelectedRows[0].Cells[4].Value = itemType_combobox_fullpay.SelectedIndex;//hidden
                        item_dgv_fullpay.SelectedRows[0].Cells[5].Value = null;
                        item_dgv_fullpay.SelectedRows[0].Cells[6].Value = null;
                        item_dgv_fullpay.SelectedRows[0].Cells[7].Value = null;
                        delete_button_fullpay.Enabled = false;
                        add_button_fullpay.Text = "Add";
                        add_button_fullpay.Tag = "a";
                        add_button_fullpay.Enabled = false;
                        itemType_combobox_fullpay.Enabled = true;
                    }
                    refreshTotalLabel();
                    itemType_combobox_fullpay.SelectedIndex = 0;
                }


                else { Notification.Show(State.InvalidPayment); }

            }
        }
        
        private void cancel_button_fullpay_parish_Click(object sender, EventArgs e)
        {
            itemType_combobox_fullpay.SelectedIndex = 0;
            itemType_combobox_fullpay.Enabled = true;
            add_button_fullpay.Text = "Add";
            add_button_fullpay.Tag = "a";
            add_button_fullpay.Enabled = false;
            delete_button_fullpay.Enabled = false; 
        }
        private void delete_button_fullpay_parish_Click(object sender, EventArgs e)
        {
            if (MessageDialog.Show("This delete the current item. Are you sure you want to proceed?", MessageDialogButtons.YesNo, MessageDialogIcon.Question) == DialogResult.Yes)
            {
                delete_button_fullpay.Enabled = false;
                item_dgv_fullpay.Rows.RemoveAt(item_dgv_fullpay.SelectedRows[0].Index);
                refreshTotalLabel();

                itemType_combobox_fullpay.SelectedIndex = 0;
                itemType_combobox_fullpay.Enabled = true;
                add_button_fullpay.Text = "Add";
                add_button_fullpay.Tag = "a";
            }
        }

        private void item_dgv_fullpay_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //these things have to be in order do not edit 
            add_button_fullpay.Tag = "e";
            add_button_fullpay.Text = "Edit";
            itemType_combobox_fullpay.SelectedIndex = int.Parse(item_dgv_fullpay.SelectedRows[0].Cells[4].Value.ToString());
            itemType_combobox_fullpay.Enabled = false;
            if (item_dgv_fullpay.SelectedRows[0].Cells[5].Value != null)
            {
                applicant_combox_fullpay.SelectedIndex = int.Parse(item_dgv_fullpay.SelectedRows[0].Cells[6].Value.ToString());
                targetPrice_label.Text = item_dgv_fullpay.SelectedRows[0].Cells["targetPrice"].Value.ToString();
                pricePaid_label.Text = item_dgv_fullpay.SelectedRows[0].Cells["totalpaid"].Value.ToString();
            }
            if (item_dgv_fullpay.SelectedRows[0].Cells["applicationid"].Value!=null)
            {
                suggestedPrice_nud_fullpay.Maximum = decimal.Parse(item_dgv_fullpay.SelectedRows[0].Cells["targetPrice"].Value.ToString())- decimal.Parse(item_dgv_fullpay.SelectedRows[0].Cells["totalpaid"].Value.ToString());
            }
            else
            {
                suggestedPrice_nud_fullpay.Maximum = decimal.MaxValue;
            }
            suggestedPrice_nud_fullpay.Value = decimal.Parse(item_dgv_fullpay.SelectedRows[0].Cells[1].Value.ToString());
            quantity_nud_fullpay.Value = decimal.Parse(item_dgv_fullpay.SelectedRows[0].Cells[2].Value.ToString());
            delete_button_fullpay.Enabled = true;
           
        }
        private void itemType_combobox_fullpay_SelectedValueChanged(object sender, EventArgs e)
        {
          /*
            if (itemType_combobox_fullpay.SelectedIndex != 0)
            {
                suggestedPrice_nud_fullpay.Maximum = decimal.Parse(((ComboboxContent)itemType_combobox_fullpay.SelectedItem).Content2);
                suggestedPrice_nud_fullpay.Value = decimal.Parse(((ComboboxContent)(itemType_combobox_fullpay.SelectedItem)).Content2);

            }
            else
            {
                clearIncomeTab();
            }
            */
        }
        private void final_button_fullpay_Click(object sender, EventArgs e)
        {
            if (item_dgv_fullpay.Rows.Count > 0)
            {
                int primaryIncomeID = dh.addPrimaryIncome(sourceName_textbox_fullpay.Text, bookModeFullPay, int.Parse(orNumber_label_fullpay.Text), remarks_textbox_fullpay.Text);
                foreach (DataGridViewRow dgvr in item_dgv_fullpay.Rows)
                {
                    bool normal;
                    try
                    {
                        int.Parse(dgvr.Cells[5].Value.ToString());
                        normal = false;
                    }
                    catch
                    {
                        normal = true;
                    }

                    if (normal)
                    {
                        dh.addItem(((ComboboxContent)itemType_combobox_fullpay.Items[int.Parse(dgvr.Cells[4].Value.ToString())]).ID, primaryIncomeID, decimal.Parse(dgvr.Cells["priceDataGridViewColumn"].Value.ToString()), int.Parse(dgvr.Cells["QuantityDataGridViewColumn"].Value.ToString()));
                    }
                    else
                    {
                        int sacramentincomeID = dh.getSacramentIncomeID(int.Parse(dgvr.Cells[5].Value.ToString()));
                        if (sacramentincomeID == -1)
                        {
                            dh.addSacramentIncome(int.Parse(dgvr.Cells[5].Value.ToString()), double.Parse(dgvr.Cells[7].Value.ToString()), "");
                            sacramentincomeID = dh.getLastSacramentIncome();
                        }
                        dh.addPayment(sacramentincomeID, primaryIncomeID, decimal.Parse(dgvr.Cells[3].Value.ToString()));
                    }
                    
                }
                orNumber_label_fullpay.Text = (int.Parse(orNumber_label_fullpay.Text) + 1).ToString();
                itemType_combobox_fullpay.SelectedIndex = 0;
                sourceName_textbox_fullpay.Clear();
                remarks_textbox_fullpay.Clear();
                final_button_fullpay.Enabled = false;
                add_button_fullpay.Text = "Add";
                add_button_fullpay.Tag = "a";
                add_button_fullpay.Enabled = false;
                delete_button_fullpay.Enabled = false;
                total_label_fullpay.Text = "0.00";
                item_dgv_fullpay.Rows.Clear();
                Notification.Show(State.TransactionAdded);
            }
            else
            {
                Notification.Show(State.InvalidTransaction);
            }
        }
        

       

    
    

        
        private void targetPriceNUD_ValueChanged(object sender, EventArgs e)
        {
            
            //targetPriceNUD.Tag = "b";
            
        }

        bool editTarget=true;
        decimal lastargetprice;
        private void editPrice_button_Click(object sender, EventArgs e)
        {
            /*
            lastargetprice = decimal.Parse(targetPrice_label.Text);
            if (editTarget)
            {
                targetPriceNUD.Visible = true;
                targetPriceNUD.Value = decimal.Parse(targetPrice_label.Text);
                editTarget = false;
            }
            else
            {
              
                if (suggestedPrice_nud_fullpay.Value + decimal.Parse(pricePaid_label.Text)  <= targetPriceNUD.Value )
                {
                    targetPrice_label.Text = targetPriceNUD.Value.ToString();
                    suggestedPrice_nud_fullpay.Maximum = targetPriceNUD.Value;
                    suggestedPrice_nud_fullpay.Value = targetPriceNUD.Value - decimal.Parse(pricePaid_label.Text);
                    targetPriceNUD.Visible = false;
                    targetPriceNUD.Value = 0;
                    editTarget = true;
                }
                else
                {
                    Notification.Show(State.InvalidPrice);
                    editTarget = true;
                }

            }
            */
        }

        private void applicant_combox_fullpay_SelectedValueChanged(object sender, EventArgs e)
        {
            AddButtonDataValidation();
        }

        private void Person_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            /*
            targetPriceNUD.Visible = false;
            targetPrice_label.Text = lastargetprice.ToString();
            */
        }

        private void targetPriceNUD_VisibleChanged(object sender, EventArgs e)
        {
            /*
            if (targetPriceNUD.Visible)
            {
                Cancel_button.Enabled = true;
            }
            else
            {
                Cancel_button.Enabled = false;
            }
            */
        }

        private void subTotal_label_fullpay_TextChanged(object sender, EventArgs e)
        {
            /*
            if (decimal.Parse(subTotal_label_fullpay.Text) != 0)
            {
                add_button_fullpay.Enabled = true;
            }
            else
            {
                add_button_fullpay.Enabled = false;
            }
            */
        }

        private void item_dgv_fullpay_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            final_button_fullpay.Enabled = true;
        }

        private void item_dgv_fullpay_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (item_dgv_fullpay.Rows.Count == 0)
            {
                final_button_fullpay.Enabled = false;
            }
            else
            {
                final_button_fullpay.Enabled = true;
            }
        }

        private void parish_label_Click(object sender, EventArgs e)
        {
            if (item_dgv_fullpay.Rows.Count > 0)
            {
                if (MessageDialog.Show("This will clear your current transaction. Are you sure you want to proceed?", MessageDialogButtons.YesNo, MessageDialogIcon.Question) == DialogResult.Yes)
                {
                    this.bookModeFullPay = 1;
                    RefreshMain();
                    parish_label.Font = new Font(parish_label.Font, FontStyle.Bold);
                    community_label.Font = new Font(community_label.Font, FontStyle.Regular);
                    postulancy_label.Font = new Font(postulancy_label.Font, FontStyle.Regular);
                    delete_button_fullpay.Enabled = false;
                    add_button_fullpay.Text = "Add";
                    add_button_fullpay.Tag = "a";
                    add_button_fullpay.Enabled = false;
                    itemType_combobox_fullpay.Enabled = true;
                }//HERE JUSTIN
            }
            else
            {
                this.bookModeFullPay = 1;
                RefreshMain();
                parish_label.Font = new Font(parish_label.Font, FontStyle.Bold);
                community_label.Font = new Font(community_label.Font, FontStyle.Regular);
                postulancy_label.Font = new Font(postulancy_label.Font, FontStyle.Regular);
            }
        }

        private void community_label_Click(object sender, EventArgs e)
        {
            if (item_dgv_fullpay.Rows.Count > 0)
            {
                if (MessageDialog.Show("This will clear your current transaction. Are you sure you want to proceed?", MessageDialogButtons.YesNo, MessageDialogIcon.Question) == DialogResult.Yes)
                {
                    this.bookModeFullPay = 2;
                    RefreshMain();
                    parish_label.Font = new Font(parish_label.Font, FontStyle.Regular);
                    community_label.Font = new Font(community_label.Font, FontStyle.Bold);
                    postulancy_label.Font = new Font(postulancy_label.Font, FontStyle.Regular);
                    delete_button_fullpay.Enabled = false;
                    add_button_fullpay.Text = "Add";
                    add_button_fullpay.Tag = "a";
                    add_button_fullpay.Enabled = false;
                    itemType_combobox_fullpay.Enabled = true;
                }
            }
            else
            {
                this.bookModeFullPay = 2;
                RefreshMain();
                parish_label.Font = new Font(parish_label.Font, FontStyle.Regular);
                community_label.Font = new Font(community_label.Font, FontStyle.Bold);
                postulancy_label.Font = new Font(postulancy_label.Font, FontStyle.Regular);
            }
        }

        private void postulancy_label_Click(object sender, EventArgs e)
        {
            if (item_dgv_fullpay.Rows.Count > 0)
            {
                if (MessageDialog.Show("This will clear your current transaction. Are you sure you want to proceed?", MessageDialogButtons.YesNo, MessageDialogIcon.Question) == DialogResult.Yes)
                {
                    this.bookModeFullPay = 3;
                    RefreshMain();
                    parish_label.Font = new Font(parish_label.Font, FontStyle.Regular);
                    community_label.Font = new Font(community_label.Font, FontStyle.Regular);
                    postulancy_label.Font = new Font(postulancy_label.Font, FontStyle.Bold);
                    delete_button_fullpay.Enabled = false;
                    add_button_fullpay.Text = "Add";
                    add_button_fullpay.Tag = "a";
                    add_button_fullpay.Enabled = false;
                    itemType_combobox_fullpay.Enabled = true;
                }
            }
            else
            {
                this.bookModeFullPay = 3;
                RefreshMain();
                parish_label.Font = new Font(parish_label.Font, FontStyle.Regular);
                community_label.Font = new Font(community_label.Font, FontStyle.Regular);
                postulancy_label.Font = new Font(postulancy_label.Font, FontStyle.Bold);
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void quantity_nud_fullpay_KeyDown(object sender, KeyEventArgs e)
        {
            subTotal_label_fullpay.Text = (suggestedPrice_nud_fullpay.Value * quantity_nud_fullpay.Value).ToString("0.00"); ;
            AddButtonDataValidation();
        }

        private void CashReceipt_VisibleChanged(object sender, EventArgs e)
        {
            parish_label.PerformClick();
        }
    }
}
