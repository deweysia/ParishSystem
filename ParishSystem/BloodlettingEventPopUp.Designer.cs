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
            this.controlBar_panel = new System.Windows.Forms.Panel();
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
            this.controlBar_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlBar_panel
            // 
            this.controlBar_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.controlBar_panel.Controls.Add(this.close_button);
            this.controlBar_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlBar_panel.Location = new System.Drawing.Point(0, 0);
            this.controlBar_panel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.controlBar_panel.Name = "controlBar_panel";
            this.controlBar_panel.Size = new System.Drawing.Size(378, 33);
            this.controlBar_panel.TabIndex = 14;
            // 
            // close_button
            // 
            this.close_button.Location = new System.Drawing.Point(338, 2);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(40, 29);
            this.close_button.TabIndex = 0;
            this.close_button.Text = "x";
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
            this.start_dateTimePicker.Size = new System.Drawing.Size(246, 29);
            this.start_dateTimePicker.TabIndex = 16;
            // 
            // end_DateTimePicker
            // 
            this.end_DateTimePicker.CustomFormat = "MMMM dd yyyy";
            this.end_DateTimePicker.Enabled = false;
            this.end_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.end_DateTimePicker.Location = new System.Drawing.Point(65, 57);
            this.end_DateTimePicker.Name = "end_DateTimePicker";
            this.end_DateTimePicker.Size = new System.Drawing.Size(246, 29);
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
            this.edit_button.Location = new System.Drawing.Point(40, 8);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(86, 27);
            this.edit_button.TabIndex = 21;
            this.edit_button.Text = "E";
            this.edit_button.UseVisualStyleBackColor = true;
            this.edit_button.Click += new System.EventHandler(this.edit_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(145, 8);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(86, 27);
            this.cancel_button.TabIndex = 22;
            this.cancel_button.Text = "C";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // event_name
            // 
            this.event_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.event_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.event_name.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.event_name.ForeColor = System.Drawing.Color.White;
            this.event_name.Location = new System.Drawing.Point(65, 12);
            this.event_name.Name = "event_name";
            this.event_name.ReadOnly = true;
            this.event_name.Size = new System.Drawing.Size(301, 97);
            this.event_name.TabIndex = 23;
            this.event_name.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Start";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.label3);
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
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "Name";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
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
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(24, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "End";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel3.Controls.Add(this.delete_button);
            this.panel3.Controls.Add(this.edit_button);
            this.panel3.Controls.Add(this.cancel_button);
            this.panel3.Location = new System.Drawing.Point(0, 455);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(378, 49);
            this.panel3.TabIndex = 27;
            // 
            // delete_button
            // 
            this.delete_button.Location = new System.Drawing.Point(254, 8);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(86, 28);
            this.delete_button.TabIndex = 23;
            this.delete_button.Text = "D";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // venue_textbox
            // 
            this.venue_textbox.BackColor = System.Drawing.Color.White;
            this.venue_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BloodlettingEventPopUp";
            this.Load += new System.EventHandler(this.BloodlettingEventPopUp_Load);
            this.controlBar_panel.ResumeLayout(false);
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
    }
}