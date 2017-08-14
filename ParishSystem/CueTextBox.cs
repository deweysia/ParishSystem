using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ParishSystem
{
    public partial class CueTextBox : TextBox
    {
        public string Cue
        {
            get; set;
        }

        Color cueColor = Color.Gray;

        public Color CueColor
        {
            set
            {
                if (value == this.ForeColor)
                    throw new Exception("CueColor and ForeColor cannot be the same!");
                cueColor = value;
            }
            get { return cueColor; }
        }

        private void CueTextBox_Enter(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.ForeColor == this.CueColor)
            {
                t.Text = "";
                t.ForeColor = this.ForeColor;
            }
        }

        private void CueTextBox_Leave(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text.Trim().Length == 0)
            {
                t.Text = Cue;
                t.ForeColor = this.CueColor;
            }
        }

        public bool isEmpty()
        {
            return this.ForeColor == CueColor || string.IsNullOrWhiteSpace(this.Text);
        }
    }
}
