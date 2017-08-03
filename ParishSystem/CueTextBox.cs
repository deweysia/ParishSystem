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
    partial class CueTextBox : TextBox
    {
        public string Cue
        {
            get; set;
        }

        public Color CueColor
        {
            get; set;
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
    }
}
