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
    public partial class MarriagePreview : Form
    {
        public MarriagePreview(String groomname, String groomage, String groomstatus, String groommother, String groomfather,
            String groomresidency, String groombornin, String bridename, String brideage, String bridestatus, String bridemother,
            String bridefather, String brideresidency, String bridebornin, String priest, 
            String marriageDay, String marriageMonthYear, String givenDay, String givenMonthYear,
            String witness1, String witness2)
        {
            InitializeComponent();
            //GROOM
            GroomName.Text = groomname;
            gAge.Text = groomage;
            gStatus.Text = groomstatus;
            gMotherName.Text = groommother;
            gFatherName.Text = groomfather;
            gResidency.Text = groomresidency;
            gBornIn.Text = groombornin;

            //BRIDE
            BrideName.Text = bridename;
            bAge.Text = brideage;
            bStatus.Text = bridestatus;
            bMotherName.Text = bridemother;
            bFatherName.Text = bridefather;
            bResidency.Text = brideresidency;
            bBornIn.Text = bridebornin;

            //MISC.
            Minister.Text = priest;
            this.lblMarriageDay.Text = marriageDay;
            lblGivenDay.Text = givenDay;
            lblGivenMonthYear.Text = givenMonthYear;
            this.lblMarriageMonthYear.Text = marriageMonthYear;
            lblGivenMonthYear.Text = marriageMonthYear;
            lblWitness1.Text = witness1;
            lblWithness2.Text = witness2;


        }

        private void MarriagePreview_Load(object sender, EventArgs e)
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
            #endregion
        } //ASSIGNS DEFAULT PRINTER

        #region VARIABLES
        String DEFAULTPRINTER;
        Boolean isSaved = false;
        string filepath;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region screen capture
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

        #region saving file as pdf
        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            int width = panel1.Size.Width;
            int height = panel1.Size.Height;

            saveFileDialog1.FileName = string.Format("Marriage - {0} & {1}", GroomName.Text, BrideName.Text);
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                // --------------------FINDING FILEPATH---------------------- //
                filepath = saveFileDialog1.FileName;

                Bitmap bm = new Bitmap(width, height);
                panel1.DrawToBitmap(bm, new Rectangle(0, 0, width, height));


                string tempFolder = Path.GetTempPath();
                bm.Save(tempFolder + "//tempReport.bmp", ImageFormat.Bmp);


                // --------------------DOCUMENT---------------------- //

                PdfDocument doc = new PdfDocument();
                PdfPage page = new PdfPage();
                page.Height = height;
                page.Width = width;
                page.Orientation = PageOrientation.Portrait;
                doc.Pages.Add(page);

                // --------------------DRAWING PDF---------------------- //
                XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[0]);
                XImage saved = XImage.FromFile(tempFolder + "//tempReport.bmp");
                xgr.DrawImage(saved, 0, 0, width, height);

                doc.Save(filepath);
                doc.Close();
                saved.Dispose();
                this.Close();
            }

        }
        #endregion

        #region Sending file to printer

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


    }



}
