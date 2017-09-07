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
    public partial class BaptismalPreview : Form
    {
        public BaptismalPreview(String baptizedName, String bPlace
            , String bdate, String fname, String mname
            , String fOrigin, String mOrigin, String datemonthyear, String sponsorsname, String issueDate

            , String rno, String bno, String pno, String purpose, String OMinister)
        {
            InitializeComponent();

            nameOfBaptized.Text = baptizedName;
            dateOfBirth.Text = bdate;
            nameOfFather.Text = fname;
            nameOfMother.Text = mname;
            fPlaceOfOrigin.Text = fOrigin;
            mPlaceofOrigin.Text = mOrigin;
            dateOfBaptism.Text = datemonthyear;
            sponsorNames.Text = sponsorsname;
            purposeField.Text = purpose;
            minister.Text = OMinister;
            dateIssued.Text = issueDate;
            registrynum.Text = rno;
            pagenum.Text = pno;
            booknum.Text = bno;
            placeOfBirth.Text = bPlace;
        }
        

private void Form1_Load(object sender, EventArgs e)
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




       

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int width = panel1.Size.Width;
            int height = panel1.Size.Height;

            Bitmap bm = new Bitmap(width, height);
            panel1.DrawToBitmap(bm, new Rectangle(0, 0, width, height));

            bm.Save(@"C://Users//Josh//Desktop//Reports//temp2.bmp", ImageFormat.Bmp);

            // --------------------DOCUMENT---------------------- //

            PdfDocument doc = new PdfDocument();
            PdfPage page = new PdfPage();
            page.Height = height;
            page.Width = width;
            page.Orientation = PageOrientation.Portrait;
            doc.Pages.Add(page);
            
            
            XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[0]);

            

            XImage poop = XImage.FromFile("C://Users//Josh//Desktop//Reports//temp2.bmp");

            xgr.DrawImage(poop, 0, 0, width, height);
            doc.Save("C://Users//Josh//Desktop//Reports//Report.pdf");
            doc.Close();

            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
