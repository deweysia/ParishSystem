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

namespace DatabasePopulator
{
    public partial class MarriagePreview : Form
    {
        public MarriagePreview(String groomname, String groomage, String groomstatus, String groommother, String groomfather,
            String groomresidency, String groombornin, String bridename, String brideage, String bridestatus, String bridemother,
            String bridefather, String brideresidency, String bridebornin, String priest, String day, String monthyear, String witness)
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
            Day.Text = day;
            Day2.Text = day;
            MonthYear.Text = monthyear;
            MonthYear2.Text = monthyear;


        }

        private void MarriagePreview_Load(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            int width = panel1.Size.Width;
            int height = panel1.Size.Height;

            Bitmap bm = new Bitmap(width, height);
            panel1.DrawToBitmap(bm, new Rectangle(0, 0, width, height));

            bm.Save(@"C://Users//Josh//Desktop//Reports//marriage.bmp", ImageFormat.Bmp);

            // --------------------DOCUMENT---------------------- //

            PdfDocument doc = new PdfDocument();
            PdfPage page = new PdfPage();
            page.Height = height;
            page.Width = width;
            page.Orientation = PageOrientation.Portrait;
            doc.Pages.Add(page);


            XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[0]);



            XImage poop = XImage.FromFile("C://Users//Josh//Desktop//Reports//marriage.bmp");

            xgr.DrawImage(poop, 0, 0, width, height);
            doc.Save("C://Users//Josh//Desktop//Reports//MarriageReport.pdf");
            doc.Close();


        }
    }



}
