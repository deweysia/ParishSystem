namespace ParishSystem
{
    partial class AddReferences
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
            this.lblSacrament = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRecord = new ParishSystem.CueTextBox();
            this.txtRegistry = new ParishSystem.CueTextBox();
            this.txtPage = new ParishSystem.CueTextBox();
            this.btnSubmit = new MetroFramework.Controls.MetroButton();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSacrament
            // 
            this.lblSacrament.AutoSize = true;
            this.lblSacrament.ForeColor = System.Drawing.Color.White;
            this.lblSacrament.Location = new System.Drawing.Point(103, 48);
            this.lblSacrament.Name = "lblSacrament";
            this.lblSacrament.Size = new System.Drawing.Size(107, 13);
            this.lblSacrament.TabIndex = 0;
            this.lblSacrament.Text = "Whatever Reference";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(67, 71);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(67, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Dewey L Sia";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(18, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Record no.";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtRecord, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtRegistry, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPage, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(56, 103);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(193, 100);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registry no";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(24, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Page no";
            // 
            // txtRecord
            // 
            this.txtRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRecord.Cue = null;
            this.txtRecord.CueColor = System.Drawing.Color.Gray;
            this.txtRecord.Location = new System.Drawing.Point(99, 6);
            this.txtRecord.Name = "txtRecord";
            this.txtRecord.Size = new System.Drawing.Size(91, 20);
            this.txtRecord.TabIndex = 1;
            this.txtRecord.TextChanged += new System.EventHandler(this.txtRecord_TextChanged);
            // 
            // txtRegistry
            // 
            this.txtRegistry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegistry.Cue = null;
            this.txtRegistry.CueColor = System.Drawing.Color.Gray;
            this.txtRegistry.Location = new System.Drawing.Point(99, 39);
            this.txtRegistry.Name = "txtRegistry";
            this.txtRegistry.Size = new System.Drawing.Size(91, 20);
            this.txtRegistry.TabIndex = 1;
            this.txtRegistry.TextChanged += new System.EventHandler(this.txtRecord_TextChanged);
            // 
            // txtPage
            // 
            this.txtPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPage.Cue = null;
            this.txtPage.CueColor = System.Drawing.Color.Gray;
            this.txtPage.Location = new System.Drawing.Point(99, 73);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(91, 20);
            this.txtPage.TabIndex = 1;
            this.txtPage.TextChanged += new System.EventHandler(this.txtRecord_TextChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(121, 293);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseSelectable = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::ParishSystem.Properties.Resources.btn_CANCEL;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(284, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 33);
            this.panel1.TabIndex = 4;
            // 
            // AddReferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(321, 328);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblSacrament);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddReferences";
            this.Text = "AddReferences";
            this.Load += new System.EventHandler(this.AddReferences_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddReferences_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AddReferences_MouseMove);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSacrament;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private CueTextBox txtRecord;
        private CueTextBox txtRegistry;
        private CueTextBox txtPage;
        private MetroFramework.Controls.MetroButton btnSubmit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
    }
}