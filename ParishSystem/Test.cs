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
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
            label1.Text = folderBrowserDialog1.SelectedPath;
            folderBrowserDialog1.ShowNewFolderButton = true;
            label1.Text = Properties.Settings.Default["PDFSaveLocation"] as string;

        }

        private void Test_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();

            Properties.Settings.Default["PDFSaveLocation"] = folderBrowserDialog1.SelectedPath;
            Properties.Settings.Default.Save();

            label1.Text = Properties.Settings.Default["PDFSaveLocation"] as string;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            printDialog1.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SystemSettings sys = new SystemSettings();
            sys.Show();
        }
    }
}
