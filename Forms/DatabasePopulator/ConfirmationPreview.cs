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

namespace DatabasePopulator
{
    public partial class ConfirmationPreview : Form
    {
        public ConfirmationPreview(String name, String day, String monthyear, String priestname, String fathername,
            String mothername, String godfathername, String godmothername)
        {
            InitializeComponent();

            Name.Text = name;
            date.Text = day;
            MonthYear.Text = monthyear;
            priestName.Text = priestname;
            fatherName.Text = fathername;
            motherName.Text = mothername;
            godFatherName.Text = godfathername;
            godMotherName.Text = godmothername;
            day2.Text = day;
            monthYear2.Text = monthyear;


        }


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




        private void label12_Click(object sender, EventArgs e)
        {

        }
        string filepath;
        private void button1_Click(object sender, EventArgs e)
        {

            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            int width = panel1.Size.Width;
            int height = panel1.Size.Height;

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
                XImage saved = XImage.FromFile(tempFolder + "//temp2.bmp");
                xgr.DrawImage(saved, 0, 0, width, height);

                doc.Save(filepath);
                doc.Close();

                this.Close();
            }


        }

        private void ConfirmationPreview_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            #region SAVING PDF TO TEMP
            // --------------------FINDING FILEPATH---------------------- //
            int width = panel1.Size.Width;
            int height = panel1.Size.Height;


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
            XImage saved = XImage.FromFile(tempFolder + "//temp2.bmp");
            xgr.DrawImage(saved, 0, 0, width, height);

            doc.Save(tempFolder + "//rep.pdf");
            doc.Close();
            #endregion

            Process p = new Process();
            p.StartInfo = new ProcessStartInfo()
            {
                CreateNoWindow = true,
                Verb = "open",
                FileName = tempFolder + "//rep.pdf"
            };
            p.Start();



        }
    }
}
