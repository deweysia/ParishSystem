namespace ParishSystem
{
    partial class DownPaymentProfile
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
            this.lastname_textbox = new System.Windows.Forms.TextBox();
            this.firstname_textbox = new System.Windows.Forms.TextBox();
            this.sf_textbox = new System.Windows.Forms.TextBox();
            this.mi_textbox = new System.Windows.Forms.TextBox();
            this.address_textbox = new System.Windows.Forms.TextBox();
            this.contactNumber_textbox = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.add_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.controlBar_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlBar_panel
            // 
            this.controlBar_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.controlBar_panel.Controls.Add(this.close_button);
            this.controlBar_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlBar_panel.Location = new System.Drawing.Point(0, 0);
            this.controlBar_panel.Margin = new System.Windows.Forms.Padding(0);
            this.controlBar_panel.Name = "controlBar_panel";
            this.controlBar_panel.Size = new System.Drawing.Size(435, 31);
            this.controlBar_panel.TabIndex = 22;
            // 
            // close_button
            // 
            this.close_button.Location = new System.Drawing.Point(402, 1);
            this.close_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(33, 30);
            this.close_button.TabIndex = 0;
            this.close_button.Text = "x";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // lastname_textbox
            // 
            this.lastname_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lastname_textbox.ForeColor = System.Drawing.Color.Gray;
            this.lastname_textbox.Location = new System.Drawing.Point(13, 49);
            this.lastname_textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lastname_textbox.Name = "lastname_textbox";
            this.lastname_textbox.Size = new System.Drawing.Size(148, 22);
            this.lastname_textbox.TabIndex = 23;
            this.lastname_textbox.Text = "Lastname";
            this.lastname_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lastname_textbox.Enter += new System.EventHandler(this.textbox_Enter);
            this.lastname_textbox.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // firstname_textbox
            // 
            this.firstname_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.firstname_textbox.ForeColor = System.Drawing.Color.Gray;
            this.firstname_textbox.Location = new System.Drawing.Point(222, 49);
            this.firstname_textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.firstname_textbox.Name = "firstname_textbox";
            this.firstname_textbox.Size = new System.Drawing.Size(148, 22);
            this.firstname_textbox.TabIndex = 24;
            this.firstname_textbox.Text = "Firstname";
            this.firstname_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.firstname_textbox.Enter += new System.EventHandler(this.textbox_Enter);
            this.firstname_textbox.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // sf_textbox
            // 
            this.sf_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sf_textbox.ForeColor = System.Drawing.Color.Gray;
            this.sf_textbox.Location = new System.Drawing.Point(169, 49);
            this.sf_textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sf_textbox.Name = "sf_textbox";
            this.sf_textbox.Size = new System.Drawing.Size(45, 22);
            this.sf_textbox.TabIndex = 25;
            this.sf_textbox.Text = "SF";
            this.sf_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sf_textbox.Enter += new System.EventHandler(this.textbox_Enter);
            this.sf_textbox.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // mi_textbox
            // 
            this.mi_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mi_textbox.ForeColor = System.Drawing.Color.Gray;
            this.mi_textbox.Location = new System.Drawing.Point(378, 49);
            this.mi_textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mi_textbox.Name = "mi_textbox";
            this.mi_textbox.Size = new System.Drawing.Size(40, 22);
            this.mi_textbox.TabIndex = 26;
            this.mi_textbox.Text = "MI";
            this.mi_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mi_textbox.Enter += new System.EventHandler(this.textbox_Enter);
            this.mi_textbox.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // address_textbox
            // 
            this.address_textbox.Location = new System.Drawing.Point(145, 130);
            this.address_textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.address_textbox.Multiline = true;
            this.address_textbox.Name = "address_textbox";
            this.address_textbox.Size = new System.Drawing.Size(273, 80);
            this.address_textbox.TabIndex = 27;
            // 
            // contactNumber_textbox
            // 
            this.contactNumber_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contactNumber_textbox.Location = new System.Drawing.Point(145, 97);
            this.contactNumber_textbox.Mask = "(+63) 999 999 9999";
            this.contactNumber_textbox.Name = "contactNumber_textbox";
            this.contactNumber_textbox.Size = new System.Drawing.Size(133, 22);
            this.contactNumber_textbox.TabIndex = 28;
            this.contactNumber_textbox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 21);
            this.label1.TabIndex = 29;
            this.label1.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 21);
            this.label2.TabIndex = 30;
            this.label2.Text = "Contact Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(423, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "______________________________________________";
            // 
            // add_button
            // 
            this.add_button.Location = new System.Drawing.Point(351, 3);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(75, 32);
            this.add_button.TabIndex = 32;
            this.add_button.Text = "Add";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(270, 3);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 32);
            this.cancel_button.TabIndex = 33;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.add_button);
            this.panel1.Controls.Add(this.cancel_button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 221);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 39);
            this.panel1.TabIndex = 34;
            // 
            // DownPaymentProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(435, 260);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contactNumber_textbox);
            this.Controls.Add(this.address_textbox);
            this.Controls.Add(this.mi_textbox);
            this.Controls.Add(this.sf_textbox);
            this.Controls.Add(this.firstname_textbox);
            this.Controls.Add(this.lastname_textbox);
            this.Controls.Add(this.controlBar_panel);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DownPaymentProfile";
            this.controlBar_panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel controlBar_panel;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.TextBox lastname_textbox;
        private System.Windows.Forms.TextBox firstname_textbox;
        private System.Windows.Forms.TextBox sf_textbox;
        private System.Windows.Forms.TextBox mi_textbox;
        private System.Windows.Forms.TextBox address_textbox;
        private System.Windows.Forms.MaskedTextBox contactNumber_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Panel panel1;
    }
}