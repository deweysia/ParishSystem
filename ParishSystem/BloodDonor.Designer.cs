namespace ParishSystem
{
    partial class BloodDonor
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
            this.fn = new ParishSystem.CueTextBox();
            this.mn = new ParishSystem.CueTextBox();
            this.ln = new ParishSystem.CueTextBox();
            this.sf = new ParishSystem.CueTextBox();
            this.address = new System.Windows.Forms.TextBox();
            this.contactnum = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.controlBar_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlBar_panel
            // 
            this.controlBar_panel.BackColor = System.Drawing.Color.DimGray;
            this.controlBar_panel.Controls.Add(this.close_button);
            this.controlBar_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlBar_panel.Location = new System.Drawing.Point(0, 0);
            this.controlBar_panel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.controlBar_panel.Name = "controlBar_panel";
            this.controlBar_panel.Size = new System.Drawing.Size(382, 33);
            this.controlBar_panel.TabIndex = 14;
            // 
            // close_button
            // 
            this.close_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.close_button.FlatAppearance.BorderSize = 0;
            this.close_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(108)))), ((int)(((byte)(179)))));
            this.close_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(108)))), ((int)(((byte)(179)))));
            this.close_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_button.Image = global::ParishSystem.Properties.Resources.icons8_Delete_20;
            this.close_button.Location = new System.Drawing.Point(350, 5);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(21, 20);
            this.close_button.TabIndex = 0;
            this.close_button.UseVisualStyleBackColor = true;
            // 
            // fn
            // 
            this.fn.Cue = "Firstname";
            this.fn.CueColor = System.Drawing.Color.Gray;
            this.fn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fn.Location = new System.Drawing.Point(16, 50);
            this.fn.Name = "fn";
            this.fn.Size = new System.Drawing.Size(116, 27);
            this.fn.TabIndex = 15;
            // 
            // mn
            // 
            this.mn.Cue = "MI";
            this.mn.CueColor = System.Drawing.Color.Gray;
            this.mn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mn.Location = new System.Drawing.Point(138, 50);
            this.mn.Name = "mn";
            this.mn.Size = new System.Drawing.Size(46, 27);
            this.mn.TabIndex = 15;
            // 
            // ln
            // 
            this.ln.Cue = "Lastname";
            this.ln.CueColor = System.Drawing.Color.Gray;
            this.ln.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ln.Location = new System.Drawing.Point(190, 50);
            this.ln.Name = "ln";
            this.ln.Size = new System.Drawing.Size(121, 27);
            this.ln.TabIndex = 16;
            // 
            // sf
            // 
            this.sf.Cue = "SF";
            this.sf.CueColor = System.Drawing.Color.Gray;
            this.sf.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sf.Location = new System.Drawing.Point(317, 50);
            this.sf.Name = "sf";
            this.sf.Size = new System.Drawing.Size(46, 27);
            this.sf.TabIndex = 17;
            // 
            // address
            // 
            this.address.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address.Location = new System.Drawing.Point(138, 145);
            this.address.Multiline = true;
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(222, 83);
            this.address.TabIndex = 18;
            // 
            // contactnum
            // 
            this.contactnum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactnum.Location = new System.Drawing.Point(138, 96);
            this.contactnum.Mask = "(+63) 999 999 9999";
            this.contactnum.Name = "contactnum";
            this.contactnum.Size = new System.Drawing.Size(145, 29);
            this.contactnum.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Contact Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Address";
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(217, 248);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 21;
            this.Add.Tag = "a";
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(307, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 22;
            this.button1.Tag = "a";
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BloodDonor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(382, 283);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contactnum);
            this.Controls.Add(this.address);
            this.Controls.Add(this.sf);
            this.Controls.Add(this.ln);
            this.Controls.Add(this.mn);
            this.Controls.Add(this.fn);
            this.Controls.Add(this.controlBar_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BloodDonor";
            this.Text = "BloodDonor";
            this.controlBar_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel controlBar_panel;
        private System.Windows.Forms.Button close_button;
        private CueTextBox fn;
        private CueTextBox mn;
        private CueTextBox ln;
        private CueTextBox sf;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.MaskedTextBox contactnum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button button1;
    }
}