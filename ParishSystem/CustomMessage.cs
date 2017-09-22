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
    public partial class CustomMessage : Form
    {
        public CustomMessage()
        {
            InitializeComponent();
            Draggable drag = new Draggable(this);
            drag.makeDraggable(this);
            infoLabel.MaximumSize = this.Size - this.Padding.Size;
        }

        private void CustomMessage_Load(object sender, EventArgs e)
        {
            
        }

        public DialogResult Show(string information, MessageDialogButtons b = MessageDialogButtons.OK, MessageDialogIcon i = MessageDialogIcon.Information)
        {
            infoLabel.Text = information;
            hiddenTabControl1.SelectedIndex = (int)b;
            iconPictureBox.Image = imageList1.Images[(int)i];
            return this.ShowDialog();                
        }

        public DialogResult Show(string information, string title, MessageDialogButtons b = MessageDialogButtons.OK, MessageDialogIcon i = MessageDialogIcon.Information)
        {
            infoLabel.Text = information;
            titleLabel.Text = title;
            hiddenTabControl1.SelectedIndex = (int)b;
            iconPictureBox.Image = imageList1.Images[(int)i];
            return this.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }

    public static class MessageDialog
    {
        /// <summary>
        /// Shows a message. Default button is CustomMessageButtons.OK. Default icon is CustomMessageIcon.Information
        /// </summary>
        /// <param name="m"></param>
        /// <param name="b"></param>
        /// <param name="i"></param>
        public static DialogResult Show(string information, MessageDialogButtons b = MessageDialogButtons.OK, MessageDialogIcon i = MessageDialogIcon.Information)
        {
            CustomMessage cm = new CustomMessage();
            return cm.Show(information, b, i);
        }

        public static DialogResult Show(State s)
        {
            CustomMessage cm = new CustomMessage();
            return cm.Show(s._msg, s._btn, s._icon);
            
        }

        public static DialogResult Show(string information, string title, MessageDialogButtons b = MessageDialogButtons.OK, MessageDialogIcon i = MessageDialogIcon.Information)
        {
            CustomMessage cm = new CustomMessage();
            return cm.Show(information, title, b, i);
        }

        public class State
        {
            public string _msg { get; }
            public MessageDialogButtons _btn { get; }
            public MessageDialogIcon _icon { get; }
            private State(string msg, MessageDialogButtons btn, MessageDialogIcon icon)
            {
                this._msg = msg;
                this._btn = btn;
                this._icon = icon;
            }

            public static State ProfileExists = new State("A profile record with the same name, birthday, and gender already exists. This profile will refer to the existing record. Proceed?", MessageDialogButtons.OKCancel, MessageDialogIcon.Information);

        }
    }

    public enum MessageDialogButtons
    {
        AbortRetryIgnore,
        OK,
        OKCancel,
        RetryCancel,
        YesNo,
        YesNoCancel
    }

    public enum MessageDialogIcon
    {
        Information,
        Error,
        Warning,
        Question
    }

    
}
