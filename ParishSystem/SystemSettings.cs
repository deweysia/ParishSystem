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
    public partial class SystemSettings : Form
    {
        const string PDF_SAVE_LOCATION = "PDFSaveLocation";
        const string EXCEL_SAVE_LOCATION = "ExcelSaveLocation";
        public SystemSettings()
        {
            InitializeComponent();
            txtPDF.Text = Properties.Settings.Default[PDF_SAVE_LOCATION] as string;
            txtExcel.Text = Properties.Settings.Default[EXCEL_SAVE_LOCATION] as string;
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowser.ShowDialog();
            if(dr == DialogResult.OK)
            {
                savePath(PDF_SAVE_LOCATION);
                updatePaths(txtPDF, folderBrowser.SelectedPath);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowser.ShowDialog();
            if (dr == DialogResult.OK)
            {
                savePath(EXCEL_SAVE_LOCATION);
                updatePaths(txtExcel, folderBrowser.SelectedPath);
            }
        }

        private void updatePaths(Control txt, string filePath)
        {
            txt.Text = filePath;
        }

        private void savePath(string systemDefaultPropertyName)
        {
            Properties.Settings.Default[systemDefaultPropertyName] = folderBrowser.SelectedPath;
            Properties.Settings.Default.Save();

        }

        
    }
}
