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



        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        public CustomMessage()
        {
            InitializeComponent();
            infoLabel.MaximumSize = this.Size - this.Padding.Size;
        }

        private void CustomMessage_Load(object sender, EventArgs e)
        {

        }

        private void customControlBar1_Load(object sender, EventArgs e)
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

        private void customControlBar1_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.Cancel;
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

        public static DialogResult Show(string information, string title, MessageDialogButtons b = MessageDialogButtons.OK, MessageDialogIcon i = MessageDialogIcon.Information)
        {
            CustomMessage cm = new CustomMessage();
            return cm.Show(information, title, b, i);
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
