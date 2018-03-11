namespace ParishSystem
{
    partial class BloodlettingEventPopUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BloodlettingEventPopUp));
            this.controlBar_panel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.close_button = new System.Windows.Forms.Button();
            this.start_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.end_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.details_textarea = new System.Windows.Forms.RichTextBox();
            this.edit_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.event_name = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.delete_button = new System.Windows.Forms.Button();
            this.venue_textbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpTimeStart = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.controlBar_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlBar_panel
            // 
            this.controlBar_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.controlBar_panel.Controls.Add(this.label8);
            this.controlBar_panel.Controls.Add(this.close_button);
            this.controlBar_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlBar_panel.Location = new System.Drawing.Point(0, 0);
            this.controlBar_panel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.controlBar_panel.Name = "controlBar_panel";
            this.controlBar_panel.Size = new System.Drawing.Size(378, 33);
            this.controlBar_panel.TabIndex = 14;
            this.controlBar_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.controlBar_panel_Paint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(3, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Bloodletting Events";
            // 
            // close_button
            // 
            this.close_button.BackgroundImage = global::ParishSystem.Properties.Resources.icons8_Delete_20;
            this.close_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.close_button.FlatAppearance.BorderSize = 0;
            this.close_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_button.Location = new System.Drawing.Point(351, 5);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(20, 20);
            this.close_button.TabIndex = 0;
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // start_dateTimePicker
            // 
            this.start_dateTimePicker.CustomFormat = "MMMM dd yyyy";
            this.start_dateTimePicker.Enabled = false;
            this.start_dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.start_dateTimePicker.Location = new System.Drawing.Point(65, 12);
            this.start_dateTimePicker.Name = "start_dateTimePicker";
            this.start_dateTimePicker.Size = new System.Drawing.Size(183, 29);
            this.start_dateTimePicker.TabIndex = 16;
            this.start_dateTimePicker.ValueChanged += new System.EventHandler(this.start_dateTimePicker_ValueChanged);
            this.start_dateTimePicker.Enter += new System.EventHandler(this.start_dateTimePicker_Enter);
            // 
            // end_DateTimePicker
            // 
            this.end_DateTimePicker.CustomFormat = "MMMM dd yyyy";
            this.end_DateTimePicker.Enabled = false;
            this.end_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.end_DateTimePicker.Location = new System.Drawing.Point(65, 57);
            this.end_DateTimePicker.Name = "end_DateTimePicker";
            this.end_DateTimePicker.Size = new System.Drawing.Size(183, 29);
            this.end_DateTimePicker.TabIndex = 17;
            // 
            // details_textarea
            // 
            this.details_textarea.BackColor = System.Drawing.Color.White;
            this.details_textarea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.details_textarea.Location = new System.Drawing.Point(10, 298);
            this.details_textarea.Name = "details_textarea";
            this.details_textarea.ReadOnly = true;
            this.details_textarea.Size = new System.Drawing.Size(354, 151);
            this.details_textarea.TabIndex = 18;
            this.details_textarea.Text = "";
            // 
            // edit_button
            // 
            this.edit_button.FlatAppearance.BorderSize = 0;
            this.edit_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.edit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edit_button.Image = global::ParishSystem.Properties.Resources.icons8_Pencil_32__1_;
            this.edit_button.Location = new System.Drawing.Point(331, 7);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(44, 35);
            this.edit_button.TabIndex = 21;
            this.edit_button.Tag = "e";
            this.edit_button.UseVisualStyleBackColor = true;
            this.edit_button.Click += new System.EventHandler(this.edit_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.FlatAppearance.BorderSize = 0;
            this.cancel_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.cancel_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_button.Image = global::ParishSystem.Properties.Resources.icons8_Refresh_Filled_32;
            this.cancel_button.Location = new System.Drawing.Point(331, 62);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(44, 35);
            this.cancel_button.TabIndex = 22;
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // event_name
            // 
            this.event_name.BackColor = System.Drawing.Color.White;
            this.event_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.event_name.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.event_name.ForeColor = System.Drawing.Color.Black;
            this.event_name.Location = new System.Drawing.Point(65, 12);
            this.event_name.Name = "event_name";
            this.event_name.ReadOnly = true;
            this.event_name.Size = new System.Drawing.Size(260, 97);
            this.event_name.TabIndex = 23;
            this.event_name.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Start";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cancel_button);
            this.panel1.Controls.Add(this.edit_button);
            this.panel1.Controls.Add(this.event_name);
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 116);
            this.panel1.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(15, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "Name";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dtpTimeEnd);
            this.panel2.Controls.Add(this.dtpTimeStart);
            this.panel2.Controls.Add(this.start_dateTimePicker);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.end_DateTimePicker);
            this.panel2.Location = new System.Drawing.Point(0, 149);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(378, 102);
            this.panel2.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(24, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "End";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.delete_button);
            this.panel3.Location = new System.Drawing.Point(0, 455);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(378, 49);
            this.panel3.TabIndex = 27;
            // 
            // delete_button
            // 
            this.delete_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.delete_button.FlatAppearance.BorderSize = 0;
            this.delete_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.delete_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete_button.Image = global::ParishSystem.Properties.Resources.icons8_Trash_32;
            this.delete_button.Location = new System.Drawing.Point(333, 6);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(36, 33);
            this.delete_button.TabIndex = 23;
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // venue_textbox
            // 
            this.venue_textbox.BackColor = System.Drawing.Color.White;
            this.venue_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.venue_textbox.ForeColor = System.Drawing.Color.Black;
            this.venue_textbox.Location = new System.Drawing.Point(65, 264);
            this.venue_textbox.Name = "venue_textbox";
            this.venue_textbox.ReadOnly = true;
            this.venue_textbox.Size = new System.Drawing.Size(246, 22);
            this.venue_textbox.TabIndex = 25;
            this.venue_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(19, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Venue";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(68, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(243, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "__________________________";
            // 
            // dtpTimeStart
            // 
            this.dtpTimeStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpTimeStart.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeStart.CustomFormat = "hh:mm tt";
            this.dtpTimeStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeStart.Location = new System.Drawing.Point(254, 12);
            this.dtpTimeStart.Name = "dtpTimeStart";
            this.dtpTimeStart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpTimeStart.ShowUpDown = true;
            this.dtpTimeStart.Size = new System.Drawing.Size(110, 29);
            this.dtpTimeStart.TabIndex = 25;
            this.dtpTimeStart.ValueChanged += new System.EventHandler(this.start_dateTimePicker_ValueChanged);
            this.dtpTimeStart.Enter += new System.EventHandler(this.start_dateTimePicker_Enter);
            // 
            // dtpTimeEnd
            // 
            this.dtpTimeEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpTimeEnd.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeEnd.CustomFormat = "hh:mm tt";
            this.dtpTimeEnd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeEnd.Location = new System.Drawing.Point(254, 57);
            this.dtpTimeEnd.Name = "dtpTimeEnd";
            this.dtpTimeEnd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpTimeEnd.ShowUpDown = true;
            this.dtpTimeEnd.Size = new System.Drawing.Size(110, 29);
            this.dtpTimeEnd.TabIndex = 26;
            // 
            // BloodlettingEventPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(378, 503);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.venue_textbox);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.details_textarea);
            this.Controls.Add(this.controlBar_panel);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BloodlettingEventPopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.BloodlettingEventPopUp_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BloodlettingEventPopUp_KeyDown);
            this.controlBar_panel.ResumeLayout(false);
            this.controlBar_panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel controlBar_panel;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.DateTimePicker start_dateTimePicker;
        private System.Windows.Forms.DateTimePicker end_DateTimePicker;
        private System.Windows.Forms.RichTextBox details_textarea;
        private System.Windows.Forms.Button edit_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.RichTextBox event_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox venue_textbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpTimeEnd;
        private System.Windows.Forms.DateTimePicker dtpTimeStart;
    }
}