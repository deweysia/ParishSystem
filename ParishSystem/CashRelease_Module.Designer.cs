namespace ParishSystem
{
    partial class CashRelease_Module
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel9 = new System.Windows.Forms.Panel();
            this.editPrice_button = new System.Windows.Forms.Button();
            this.cancelPrice_button = new System.Windows.Forms.Button();
            this.price_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.total_label_cashrelease = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.remarks_textbox_CRB = new System.Windows.Forms.TextBox();
            this.name_textbox_CRB = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.item_dgv_fullpay_CRB = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cancel_button_CRB = new System.Windows.Forms.Button();
            this.final_button_CRB = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.CNNumber_CRB = new System.Windows.Forms.Label();
            this.delete_button_CRB = new System.Windows.Forms.Button();
            this.priceHeader_label = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.CVNumber_CRB = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.clear_button_CRB = new System.Windows.Forms.Button();
            this.add_button_CRB = new System.Windows.Forms.Button();
            this.price_nud_button_CRB = new System.Windows.Forms.NumericUpDown();
            this.itemtype_combobox_CRB = new System.Windows.Forms.ComboBox();
            this.CRB_panel = new System.Windows.Forms.Panel();
            this.paymentPanel = new System.Windows.Forms.Panel();
            this.panel9.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.item_dgv_fullpay_CRB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.price_nud_button_CRB)).BeginInit();
            this.CRB_panel.SuspendLayout();
            this.paymentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.paymentPanel);
            this.panel9.Controls.Add(this.panel1);
            this.panel9.Controls.Add(this.label18);
            this.panel9.Controls.Add(this.CNNumber_CRB);
            this.panel9.Controls.Add(this.delete_button_CRB);
            this.panel9.Controls.Add(this.label16);
            this.panel9.Controls.Add(this.CVNumber_CRB);
            this.panel9.Controls.Add(this.label36);
            this.panel9.Controls.Add(this.clear_button_CRB);
            this.panel9.Controls.Add(this.add_button_CRB);
            this.panel9.Controls.Add(this.itemtype_combobox_CRB);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(935, 547);
            this.panel9.TabIndex = 70;
            // 
            // editPrice_button
            // 
            this.editPrice_button.Location = new System.Drawing.Point(253, 13);
            this.editPrice_button.Name = "editPrice_button";
            this.editPrice_button.Size = new System.Drawing.Size(36, 40);
            this.editPrice_button.TabIndex = 81;
            this.editPrice_button.Tag = "e";
            this.editPrice_button.Text = "E";
            this.editPrice_button.UseVisualStyleBackColor = true;
            this.editPrice_button.Click += new System.EventHandler(this.editPrice_button_Click);
            // 
            // cancelPrice_button
            // 
            this.cancelPrice_button.Location = new System.Drawing.Point(211, 13);
            this.cancelPrice_button.Name = "cancelPrice_button";
            this.cancelPrice_button.Size = new System.Drawing.Size(36, 40);
            this.cancelPrice_button.TabIndex = 80;
            this.cancelPrice_button.Text = "C";
            this.cancelPrice_button.UseVisualStyleBackColor = true;
            this.cancelPrice_button.Visible = false;
            this.cancelPrice_button.Click += new System.EventHandler(this.cancelPrice_button_Click);
            // 
            // price_label
            // 
            this.price_label.AutoSize = true;
            this.price_label.Location = new System.Drawing.Point(91, 13);
            this.price_label.Name = "price_label";
            this.price_label.Size = new System.Drawing.Size(40, 21);
            this.price_label.TabIndex = 79;
            this.price_label.Text = "0.00";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.total_label_cashrelease);
            this.panel1.Controls.Add(this.label32);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.remarks_textbox_CRB);
            this.panel1.Controls.Add(this.name_textbox_CRB);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.item_dgv_fullpay_CRB);
            this.panel1.Controls.Add(this.cancel_button_CRB);
            this.panel1.Controls.Add(this.final_button_CRB);
            this.panel1.Controls.Add(this.label27);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 547);
            this.panel1.TabIndex = 47;
            // 
            // total_label_cashrelease
            // 
            this.total_label_cashrelease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.total_label_cashrelease.AutoSize = true;
            this.total_label_cashrelease.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_label_cashrelease.ForeColor = System.Drawing.Color.Black;
            this.total_label_cashrelease.Location = new System.Drawing.Point(192, 432);
            this.total_label_cashrelease.Name = "total_label_cashrelease";
            this.total_label_cashrelease.Size = new System.Drawing.Size(72, 25);
            this.total_label_cashrelease.TabIndex = 84;
            this.total_label_cashrelease.Text = "12345";
            // 
            // label32
            // 
            this.label32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(100, 432);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(36, 17);
            this.label32.TabIndex = 85;
            this.label32.Text = "Total";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(100, 350);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(42, 17);
            this.label21.TabIndex = 17;
            this.label21.Text = "Payee";
            // 
            // remarks_textbox_CRB
            // 
            this.remarks_textbox_CRB.BackColor = System.Drawing.Color.White;
            this.remarks_textbox_CRB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.remarks_textbox_CRB.ForeColor = System.Drawing.Color.Black;
            this.remarks_textbox_CRB.Location = new System.Drawing.Point(160, 386);
            this.remarks_textbox_CRB.Multiline = true;
            this.remarks_textbox_CRB.Name = "remarks_textbox_CRB";
            this.remarks_textbox_CRB.Size = new System.Drawing.Size(281, 22);
            this.remarks_textbox_CRB.TabIndex = 14;
            // 
            // name_textbox_CRB
            // 
            this.name_textbox_CRB.BackColor = System.Drawing.Color.White;
            this.name_textbox_CRB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.name_textbox_CRB.ForeColor = System.Drawing.Color.Black;
            this.name_textbox_CRB.Location = new System.Drawing.Point(160, 343);
            this.name_textbox_CRB.Name = "name_textbox_CRB";
            this.name_textbox_CRB.Size = new System.Drawing.Size(281, 22);
            this.name_textbox_CRB.TabIndex = 16;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(84, 395);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(58, 17);
            this.label24.TabIndex = 15;
            this.label24.Text = "Remarks";
            // 
            // item_dgv_fullpay_CRB
            // 
            this.item_dgv_fullpay_CRB.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.item_dgv_fullpay_CRB.AllowUserToAddRows = false;
            this.item_dgv_fullpay_CRB.AllowUserToDeleteRows = false;
            this.item_dgv_fullpay_CRB.AllowUserToOrderColumns = true;
            this.item_dgv_fullpay_CRB.AllowUserToResizeRows = false;
            this.item_dgv_fullpay_CRB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.item_dgv_fullpay_CRB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.item_dgv_fullpay_CRB.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.item_dgv_fullpay_CRB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.item_dgv_fullpay_CRB.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.item_dgv_fullpay_CRB.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.item_dgv_fullpay_CRB.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.item_dgv_fullpay_CRB.ColumnHeadersHeight = 40;
            this.item_dgv_fullpay_CRB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.item_dgv_fullpay_CRB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn5});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.item_dgv_fullpay_CRB.DefaultCellStyle = dataGridViewCellStyle2;
            this.item_dgv_fullpay_CRB.EnableHeadersVisualStyles = false;
            this.item_dgv_fullpay_CRB.GridColor = System.Drawing.Color.White;
            this.item_dgv_fullpay_CRB.Location = new System.Drawing.Point(32, 37);
            this.item_dgv_fullpay_CRB.MultiSelect = false;
            this.item_dgv_fullpay_CRB.Name = "item_dgv_fullpay_CRB";
            this.item_dgv_fullpay_CRB.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Magenta;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.item_dgv_fullpay_CRB.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.item_dgv_fullpay_CRB.RowHeadersVisible = false;
            this.item_dgv_fullpay_CRB.RowHeadersWidth = 50;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.DarkRed;
            this.item_dgv_fullpay_CRB.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.item_dgv_fullpay_CRB.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.item_dgv_fullpay_CRB.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.item_dgv_fullpay_CRB.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.item_dgv_fullpay_CRB.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.item_dgv_fullpay_CRB.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.item_dgv_fullpay_CRB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.item_dgv_fullpay_CRB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.item_dgv_fullpay_CRB.Size = new System.Drawing.Size(536, 286);
            this.item_dgv_fullpay_CRB.TabIndex = 3;
            this.item_dgv_fullpay_CRB.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.item_dgv_fullpay_CRB_CellClick);
            this.item_dgv_fullpay_CRB.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.item_dgv_fullpay_CRB_RowsAdded);
            this.item_dgv_fullpay_CRB.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.item_dgv_fullpay_CRB_RowsRemoved);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Item Type";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Price";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "ItemTypeID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // cancel_button_CRB
            // 
            this.cancel_button_CRB.BackColor = System.Drawing.Color.Gray;
            this.cancel_button_CRB.FlatAppearance.BorderSize = 0;
            this.cancel_button_CRB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cancel_button_CRB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_button_CRB.ForeColor = System.Drawing.Color.White;
            this.cancel_button_CRB.Location = new System.Drawing.Point(87, 482);
            this.cancel_button_CRB.Name = "cancel_button_CRB";
            this.cancel_button_CRB.Size = new System.Drawing.Size(204, 37);
            this.cancel_button_CRB.TabIndex = 4;
            this.cancel_button_CRB.Text = "Cancel";
            this.cancel_button_CRB.UseVisualStyleBackColor = false;
            this.cancel_button_CRB.Click += new System.EventHandler(this.cancel_button_CRB_Click);
            // 
            // final_button_CRB
            // 
            this.final_button_CRB.BackColor = System.Drawing.Color.Gray;
            this.final_button_CRB.Enabled = false;
            this.final_button_CRB.FlatAppearance.BorderSize = 0;
            this.final_button_CRB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.final_button_CRB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.final_button_CRB.ForeColor = System.Drawing.Color.White;
            this.final_button_CRB.Location = new System.Drawing.Point(311, 482);
            this.final_button_CRB.Name = "final_button_CRB";
            this.final_button_CRB.Size = new System.Drawing.Size(204, 37);
            this.final_button_CRB.TabIndex = 5;
            this.final_button_CRB.Text = "Final";
            this.final_button_CRB.UseVisualStyleBackColor = false;
            this.final_button_CRB.Click += new System.EventHandler(this.final_button_CRB_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(148, 395);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(304, 21);
            this.label27.TabIndex = 19;
            this.label27.Text = "__________________________________________";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(148, 350);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(304, 21);
            this.label26.TabIndex = 18;
            this.label26.Text = "__________________________________________";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(614, 109);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(114, 21);
            this.label18.TabIndex = 8;
            this.label18.Text = "Check Number";
            // 
            // CNNumber_CRB
            // 
            this.CNNumber_CRB.AutoSize = true;
            this.CNNumber_CRB.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CNNumber_CRB.ForeColor = System.Drawing.Color.Black;
            this.CNNumber_CRB.Location = new System.Drawing.Point(729, 96);
            this.CNNumber_CRB.Name = "CNNumber_CRB";
            this.CNNumber_CRB.Size = new System.Drawing.Size(62, 37);
            this.CNNumber_CRB.TabIndex = 7;
            this.CNNumber_CRB.Text = "123";
            // 
            // delete_button_CRB
            // 
            this.delete_button_CRB.BackColor = System.Drawing.Color.DimGray;
            this.delete_button_CRB.Enabled = false;
            this.delete_button_CRB.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.delete_button_CRB.FlatAppearance.BorderSize = 0;
            this.delete_button_CRB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.delete_button_CRB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.delete_button_CRB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete_button_CRB.ForeColor = System.Drawing.Color.White;
            this.delete_button_CRB.Location = new System.Drawing.Point(628, 482);
            this.delete_button_CRB.Name = "delete_button_CRB";
            this.delete_button_CRB.Size = new System.Drawing.Size(274, 37);
            this.delete_button_CRB.TabIndex = 78;
            this.delete_button_CRB.Text = "Delete";
            this.delete_button_CRB.UseVisualStyleBackColor = false;
            this.delete_button_CRB.Click += new System.EventHandler(this.delete_button_CRB_Click);
            // 
            // priceHeader_label
            // 
            this.priceHeader_label.AutoSize = true;
            this.priceHeader_label.Location = new System.Drawing.Point(16, 12);
            this.priceHeader_label.Name = "priceHeader_label";
            this.priceHeader_label.Size = new System.Drawing.Size(44, 21);
            this.priceHeader_label.TabIndex = 74;
            this.priceHeader_label.Text = "Price";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(609, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(113, 21);
            this.label16.TabIndex = 6;
            this.label16.Text = "Check Voucher";
            // 
            // CVNumber_CRB
            // 
            this.CVNumber_CRB.AutoSize = true;
            this.CVNumber_CRB.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CVNumber_CRB.ForeColor = System.Drawing.Color.Black;
            this.CVNumber_CRB.Location = new System.Drawing.Point(729, 51);
            this.CVNumber_CRB.Name = "CVNumber_CRB";
            this.CVNumber_CRB.Size = new System.Drawing.Size(62, 37);
            this.CVNumber_CRB.TabIndex = 2;
            this.CVNumber_CRB.Text = "123";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(615, 169);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(87, 21);
            this.label36.TabIndex = 75;
            this.label36.Text = "Item Name";
            // 
            // clear_button_CRB
            // 
            this.clear_button_CRB.BackColor = System.Drawing.Color.DimGray;
            this.clear_button_CRB.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.clear_button_CRB.FlatAppearance.BorderSize = 0;
            this.clear_button_CRB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.clear_button_CRB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.clear_button_CRB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clear_button_CRB.ForeColor = System.Drawing.Color.White;
            this.clear_button_CRB.Location = new System.Drawing.Point(628, 432);
            this.clear_button_CRB.Name = "clear_button_CRB";
            this.clear_button_CRB.Size = new System.Drawing.Size(274, 37);
            this.clear_button_CRB.TabIndex = 72;
            this.clear_button_CRB.Text = "Clear";
            this.clear_button_CRB.UseVisualStyleBackColor = false;
            this.clear_button_CRB.Click += new System.EventHandler(this.clear_button_CRB_Click);
            // 
            // add_button_CRB
            // 
            this.add_button_CRB.BackColor = System.Drawing.Color.DimGray;
            this.add_button_CRB.Enabled = false;
            this.add_button_CRB.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.add_button_CRB.FlatAppearance.BorderSize = 0;
            this.add_button_CRB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(91)))), ((int)(((byte)(132)))));
            this.add_button_CRB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.add_button_CRB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_button_CRB.ForeColor = System.Drawing.Color.White;
            this.add_button_CRB.Location = new System.Drawing.Point(628, 378);
            this.add_button_CRB.Name = "add_button_CRB";
            this.add_button_CRB.Size = new System.Drawing.Size(274, 37);
            this.add_button_CRB.TabIndex = 73;
            this.add_button_CRB.Tag = "a";
            this.add_button_CRB.Text = "Add";
            this.add_button_CRB.UseVisualStyleBackColor = false;
            this.add_button_CRB.Click += new System.EventHandler(this.add_button_CRB_Click);
            // 
            // price_nud_button_CRB
            // 
            this.price_nud_button_CRB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.price_nud_button_CRB.DecimalPlaces = 2;
            this.price_nud_button_CRB.Location = new System.Drawing.Point(95, 14);
            this.price_nud_button_CRB.Name = "price_nud_button_CRB";
            this.price_nud_button_CRB.Size = new System.Drawing.Size(54, 25);
            this.price_nud_button_CRB.TabIndex = 71;
            this.price_nud_button_CRB.ThousandsSeparator = true;
            this.price_nud_button_CRB.Visible = false;
            this.price_nud_button_CRB.ValueChanged += new System.EventHandler(this.price_nud_button_CRB_ValueChanged);
            // 
            // itemtype_combobox_CRB
            // 
            this.itemtype_combobox_CRB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemtype_combobox_CRB.FormattingEnabled = true;
            this.itemtype_combobox_CRB.Items.AddRange(new object[] {
            ""});
            this.itemtype_combobox_CRB.Location = new System.Drawing.Point(708, 168);
            this.itemtype_combobox_CRB.Name = "itemtype_combobox_CRB";
            this.itemtype_combobox_CRB.Size = new System.Drawing.Size(200, 29);
            this.itemtype_combobox_CRB.TabIndex = 70;
            this.itemtype_combobox_CRB.SelectedIndexChanged += new System.EventHandler(this.itemtype_combobox_CRB_SelectedIndexChanged);
            // 
            // CRB_panel
            // 
            this.CRB_panel.BackColor = System.Drawing.Color.White;
            this.CRB_panel.Controls.Add(this.panel9);
            this.CRB_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRB_panel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CRB_panel.Location = new System.Drawing.Point(0, 0);
            this.CRB_panel.Name = "CRB_panel";
            this.CRB_panel.Size = new System.Drawing.Size(935, 547);
            this.CRB_panel.TabIndex = 13;
            // 
            // paymentPanel
            // 
            this.paymentPanel.Controls.Add(this.cancelPrice_button);
            this.paymentPanel.Controls.Add(this.price_label);
            this.paymentPanel.Controls.Add(this.editPrice_button);
            this.paymentPanel.Controls.Add(this.price_nud_button_CRB);
            this.paymentPanel.Controls.Add(this.priceHeader_label);
            this.paymentPanel.Location = new System.Drawing.Point(613, 223);
            this.paymentPanel.Name = "paymentPanel";
            this.paymentPanel.Size = new System.Drawing.Size(304, 69);
            this.paymentPanel.TabIndex = 82;
            this.paymentPanel.Visible = false;
            // 
            // CashRelease_Module
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 547);
            this.Controls.Add(this.CRB_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CashRelease_Module";
            this.Text = "CashDisbursment_Module";
            this.Load += new System.EventHandler(this.CashDisbursment_Module_Load);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.item_dgv_fullpay_CRB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.price_nud_button_CRB)).EndInit();
            this.CRB_panel.ResumeLayout(false);
            this.paymentPanel.ResumeLayout(false);
            this.paymentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label total_label_cashrelease;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox remarks_textbox_CRB;
        private System.Windows.Forms.TextBox name_textbox_CRB;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DataGridView item_dgv_fullpay_CRB;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Button cancel_button_CRB;
        private System.Windows.Forms.Button final_button_CRB;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label CNNumber_CRB;
        private System.Windows.Forms.Button delete_button_CRB;
        private System.Windows.Forms.Label priceHeader_label;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label CVNumber_CRB;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Button clear_button_CRB;
        private System.Windows.Forms.Button add_button_CRB;
        private System.Windows.Forms.NumericUpDown price_nud_button_CRB;
        private System.Windows.Forms.ComboBox itemtype_combobox_CRB;
        private System.Windows.Forms.Panel CRB_panel;
        private System.Windows.Forms.Label price_label;
        private System.Windows.Forms.Button editPrice_button;
        private System.Windows.Forms.Button cancelPrice_button;
        private System.Windows.Forms.Panel paymentPanel;
    }
}