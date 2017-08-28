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
        private string _cue;
        private string _text;
        private Color _cueColor;
        private Color _foreColor;

        public CueTextBox()
        {
            InitializeComponent();
            this._foreColor = this.ForeColor;
            this._text = this.Text;
        }


        public string Cue
        {
            get
            {
                return _cue;
            }

            set
            {
                _cue = value;
                if (!string.IsNullOrWhiteSpace(_cue))
                {
                    _text = this.Text;
                    this.Text = Cue;
                    _foreColor = this.ForeColor;
                    this.ForeColor = CueColor;
                }
            }
        }

        public Color CueColor
        {
            set
            {

                if (_foreColor == _cueColor && _foreColor != Color.Empty)
                    throw new Exception("CueColor and ForeColor cannot be the same!");
                else
                {

                    _cueColor = value;
                }
            }
            get { return _cueColor; }
        }

        //If ForeColor is same as CueColor, clear Cue and change ForeColor
        //If not present, nothing happens
        private void CueTextBox_Enter(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (this.ForeColor == CueColor)
            {
                this.Text = "";
                this.ForeColor = _foreColor;
            }
        }

        //If isEmpty(), set Text and ForeColor to Cue and CueColor
        private void CueTextBox_Leave(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (isEmpty())
            {
                _text = this.Text;
                this.Text = Cue;
                _foreColor = this.ForeColor;
                this.ForeColor = CueColor;
            }
        }

        /// <summary>
        /// Indicates whether the Text is null, empty, consists of white-space characters, or is the CueText
        /// </summary>
        /// <returns></returns>
        public bool isEmpty()
        {
            return (this.ForeColor == CueColor || string.IsNullOrWhiteSpace(this.Text)) && !string.IsNullOrEmpty(this.Cue);
        }
    }
}
