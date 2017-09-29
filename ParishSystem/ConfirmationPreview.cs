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
using System.Drawing.Imaging;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.IO;
using System.Diagnostics;
using System.Drawing.Printing;

namespace ParishSystem
{
    public partial class ConfirmationPreview : Form
    {
        public ConfirmationPreview(String name, String confirmationDay, String confirmationMonthYear, String priestname, String fathername,
            String mothername, String godfathername, String godmothername)
        {
            InitializeComponent();

            Name.Text = name;
            lblConfirmationDay.Text = confirmationDay;
            lblConfirmationMonthYear.Text = confirmationMonthYear;
            priestName.Text = priestname;
            fatherName.Text = fathername;
            motherName.Text = mothername;
            godFatherName.Text = godfathername;
            godMotherName.Text = godmothername;
            lblGivenDay.Text = confirmationDay;
            lblGivenMonthYear.Text = confirmationMonthYear;


        }
        private void ConfirmationPreview_Load(object sender, EventArgs e)
        {
            #region FINDING PRINTERS AND SETTING DEFAULT
            // Find all of the installed printers.
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                cmbSelectPrinter.Items.Add(printer);
            }

            // Find and select the default printer.
            try
            {
                PrinterSettings settings = new PrinterSettings();
                cmbSelectPrinter.Text = settings.PrinterName;
            }
            catch
            {
            }
            # endregion
        }

        #region SCREEN CAPTURE
        public enum enmScreenCaptureMode
        {
            Screen,
            Window
        }

        class ScreenCapturer
        {
            [DllImport("user32.dll")]
            private static extern IntPtr GetForegroundWindow();

            [DllImport("user32.dll")]
            private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

            [StructLayout(LayoutKind.Sequential)]
            private struct Rect
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }

            public Bitmap Capture(enmScreenCaptureMode screenCaptureMode = enmScreenCaptureMode.Window)
            {
                Rectangle bounds;

                if (screenCaptureMode == enmScreenCaptureMode.Screen)
                {
                    bounds = Screen.GetBounds(Point.Empty);
                    CursorPosition = Cursor.Position;
                }
                else
                {
                    var foregroundWindowsHandle = GetForegroundWindow();
                    var rect = new Rect();
                    GetWindowRect(foregroundWindowsHandle, ref rect);
                    bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
                    CursorPosition = new Point(Cursor.Position.X - rect.Left, Cursor.Position.Y - rect.Top);
                }

                var result = new Bitmap(bounds.Width, bounds.Height);

                using (var g = Graphics.FromImage(result))
                {
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }

                return result;
            }

            public Point CursorPosition
            {
                get;
                protected set;
            }
        }
        #endregion

        #region VARIABLES
        string filepath;
        String DEFAULTPRINTER;
        Boolean isSaved = false;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region saving file as pdf
        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            int width = panel1.Size.Width;
            int height = panel1.Size.Height;
            saveFileDialog1.FileName = "Confirmation - " + Name.Text;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                // --------------------FINDING FILEPATH---------------------- //
                filepath = saveFileDialog1.FileName;

                Bitmap bm = new Bitmap(width, height);
                panel1.DrawToBitmap(bm, new Rectangle(0, 0, width, height));


                string tempFolder = Path.GetTempPath();
                bm.Save(tempFolder + "//tempRep.bmp", ImageFormat.Bmp);


                // --------------------DOCUMENT---------------------- //

                PdfDocument doc = new PdfDocument();
                PdfPage page = new PdfPage();
                page.Height = height;
                page.Width = width;
                page.Orientation = PageOrientation.Portrait;
                doc.Pages.Add(page);

                // --------------------DRAWING PDF---------------------- //
                XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[0]);
                XImage saved = XImage.FromFile(tempFolder + "//tempRep.bmp");
                xgr.DrawImage(saved, 0, 0, width, height);

                doc.Save(filepath);
                doc.Close();
                saved.Dispose();
                this.Close();
            }
        }
        #endregion

        #region sending file to printer 
        private void button3_Click(object sender, EventArgs e)
        {
            string tempFolder = Path.GetTempPath();
            if (isSaved == false)
            {
                #region SAVING PDF TO TEMP
                // --------------------FINDING FILEPATH---------------------- //
                int width = panel1.Size.Width;
                int height = panel1.Size.Height;


                Bitmap bm = new Bitmap(width, height);
                panel1.DrawToBitmap(bm, new Rectangle(0, 0, width, height));



                bm.Save(tempFolder + "//tempREPORTPREVIEW.bmp", ImageFormat.Bmp);


                // --------------------DOCUMENT---------------------- //

                PdfDocument doc = new PdfDocument();
                PdfPage page = new PdfPage();
                page.Height = height;
                page.Width = width;
                page.Orientation = PageOrientation.Portrait;
                doc.Pages.Add(page);

                // --------------------DRAWING PDF---------------------- //
                XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[0]);
                XImage saved = XImage.FromFile(tempFolder + "//tempREPORTPREVIEW.bmp");
                xgr.DrawImage(saved, 0, 0, width, height);

                doc.Save(tempFolder + "//rep.pdf");
                doc.Close();
                #endregion
                isSaved = true;
            }

            DEFAULTPRINTER = cmbSelectPrinter.SelectedItem.ToString();
            PrintDocument pdfPrinter = new PrintDocument()
            {
                PrinterSettings = new PrinterSettings()
                {
                    // set the printer to 'Microsoft Print to PDF'
                    PrinterName = DEFAULTPRINTER,

                    // tell the object this document will print to file
                    PrintToFile = true,

                    // set the filename to whatever you like (full path)
                    PrintFileName = Path.Combine(tempFolder + "//rep.pdf")


                }
            };

            pdfPrinter.Print();

        }

        #endregion

        private void btnSaveDocument_Click(object sender, EventArgs e)
        {

        }
    }
}
