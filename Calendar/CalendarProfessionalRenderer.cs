using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace System.Windows.Forms.Calendar
{
    public class CalendarProfessionalRenderer
        : CalendarSystemRenderer
    {
        #region Fields

        public Color HeaderA = Color.White; //FromHex("#333333");//FromHex("#E4ECF6");
        public Color HeaderB = Color.White; //FromHex("#333333");//FromHex("#D6E2F1");
        public Color HeaderC = Color.White; //FromHex("#333333");//FromHex("#C2D4EB");
        public Color HeaderD = Color.White; //FromHex("#333333");//FromHex("#D0DEEF");

        public Color TodayA = FromHex("#7f7f7f");
        public Color TodayB = FromHex("#7f7f7f");
        public Color TodayC = FromHex("#7f7f7f");
        public Color TodayD = FromHex("#7f7f7f");

        #endregion

        #region Ctor

        public CalendarProfessionalRenderer(Calendar c)
            : base(c)
        {

            ColorTable.Background = FromHex("#262626"); //Formerly E3EFFF
            ColorTable.DayBackgroundEven = FromHex("#696969"); //FromHex("#A5BFE1");
            ColorTable.DayBackgroundOdd = FromHex("#C6C7C8"); //FromHex("#FFFFFF");
            ColorTable.DayBackgroundSelected = Color.WhiteSmoke;//FromHex("#00B294"); //Formerly E6EDF7
            ColorTable.DayBorder = Color.Wheat;//FromHex("#171918"); //Color.Red;//FromHex("#5D8CC9");
            ColorTable.DayHeaderBackground = FromHex("#DFE8F5"); //Done
            ColorTable.DayHeaderText = Color.Wheat;//FromHex("#656B64"); //Color.Black;
            ColorTable.DayHeaderSecondaryText = Color.Black;
            ColorTable.DayTopBorder = FromHex("#5D8CC9"); //Color.Green; //FromHex("#5D8CC9");
            ColorTable.DayTopSelectedBorder = FromHex("#5D8CC9"); //Color.Pink; //FromHex("#5D8CC9");
            ColorTable.DayTopBackground = FromHex("#333333");//Color.Purple; //FromHex("#A5BFE1");
            ColorTable.DayTopSelectedBackground = FromHex("#262626"); //Color.Tomato; //FromHex("#294C7A");
            ColorTable.ItemBorder = FromHex("#5D8CC9"); //Color.Lime; //FromHex("#5D8CC9");
            ColorTable.ItemBackground = FromHex("#C0D3EA");
            ColorTable.ItemText = FromHex("#373737"); //Formerly Color.Black
            ColorTable.ItemSecondaryText = FromHex("#262626"); //FromHex("#294C7A");
            ColorTable.ItemSelectedBorder = Color.White; //Formerly Color.Black
            ColorTable.ItemSelectedBackground = FromHex("#C0D3EA");
            ColorTable.ItemSelectedText = Color.Black;
            ColorTable.WeekHeaderBackground = FromHex("#262626"); //Color.Red; //FromHex("#DFE8F5");
            ColorTable.WeekHeaderBorder = FromHex("#171918"); //Color.Red;// FromHex("#5D8CC9");
            ColorTable.WeekHeaderText = Color.Wheat;//Color.Red;// FromHex("#5D8CC9");
            ColorTable.TodayBorder = Color.WhiteSmoke; //FromHex("#00B294"); //Color.Red;// FromHex("#EE9311");
            ColorTable.TodayTopBackground = Color.WhiteSmoke;// FromHex("#00B294"); //Color.Gray; //FromHex("#EE9311");
            ColorTable.TimeScaleLine = Color.White;// FromHex("#515151"); //FromHex("#1A1A1A");// FromHex("#ff0000"); //Formerly 6593CF
            ColorTable.TimeScaleHours = Color.White;// FromHex("#515151"); //Color.White; //FromHex("#6593CF");
            ColorTable.TimeScaleMinutes = Color.White;//FromHex("#515151");// Color.White; //FromHex("#6593CF");
            ColorTable.TimeUnitBackground = FromHex("#E6EDF7"); //FromHex("#00B294"); 
            ColorTable.TimeUnitHighlightedBackground = Color.White;
            ColorTable.TimeUnitSelectedBackground = Color.WhiteSmoke; //FromHex("#00B294"); //294C7A
            ColorTable.TimeUnitBorderLight = FromHex("#D5E1F1");
            ColorTable.TimeUnitBorderDark = FromHex("#696969"); // FromHex("#A5BFE1");
            ColorTable.WeekDayName = Color.Wheat; //FromHex("#515151"); //Color.White; // FromHex("#6593CF");

            SelectedItemBorder = 2f;
            ItemRoundness = 2;
        }

        #endregion

        #region Private Method

        public static void GradientRect(Graphics g, Rectangle bounds, Color a, Color b)
        {
            using (LinearGradientBrush br = new LinearGradientBrush(bounds, b, a, -90))
            {
                g.FillRectangle(br, bounds);
            }
        }

        public static void GlossyRect(Graphics g, Rectangle bounds, Color a, Color b, Color c, Color d)
        {
            Rectangle top = new Rectangle(bounds.Left, bounds.Top, bounds.Width, bounds.Height / 2);
            Rectangle bot = Rectangle.FromLTRB(bounds.Left, top.Bottom, bounds.Right, bounds.Bottom);

            GradientRect(g, top, a, b);
            GradientRect(g, bot, c, d);

        }

        /// <summary>
        /// Shortcut to one on CalendarColorTable
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private static Color FromHex(string color)
        {
            return CalendarColorTable.FromHex(color);
        }

        #endregion

        #region Overrides

        public override void OnInitialize(CalendarRendererEventArgs e)
        {
            base.OnInitialize(e);

            e.Calendar.Font = SystemFonts.CaptionFont;
        }

        public override void OnDrawDayHeaderBackground(CalendarRendererDayEventArgs e)
        {
            Rectangle r = e.Day.HeaderBounds;

            if (e.Day.Date == DateTime.Today)
            {
                GlossyRect(e.Graphics, e.Day.HeaderBounds, TodayA, TodayB, TodayC, TodayD);
            }
            else
            {
                GlossyRect(e.Graphics, e.Day.HeaderBounds, HeaderA, HeaderB, HeaderC, HeaderD);
            }

            if (e.Calendar.DaysMode == CalendarDaysMode.Short)
            {
                using (Pen p = new Pen(ColorTable.DayBorder))
                {
                    e.Graphics.DrawLine(p, r.Left, r.Top, r.Right, r.Top);
                    e.Graphics.DrawLine(p, r.Left, r.Bottom, r.Right, r.Bottom);
                } 
            }
        }

        public override void OnDrawItemBorder(CalendarRendererItemBoundsEventArgs e)
        {
            base.OnDrawItemBorder(e);

            using (Pen p = new Pen(Color.FromArgb(150, Color.White)))
            {
                e.Graphics.DrawLine(p, e.Bounds.Left + ItemRoundness, e.Bounds.Top + 1, e.Bounds.Right - ItemRoundness, e.Bounds.Top + 1); 
            }

            if (e.Item.Selected && !e.Item.IsDragging)
            {
                bool horizontal = false;
                bool vertical = false;
                Rectangle r1 = new Rectangle(0, 0, 5, 5);
                Rectangle r2 = new Rectangle(0, 0, 5, 5);

                horizontal = e.Item.IsOnDayTop;
                vertical = !e.Item.IsOnDayTop && e.Calendar.DaysMode == CalendarDaysMode.Expanded;

                if (horizontal)
                {
                    r1.X = e.Bounds.Left - 2;
                    r2.X = e.Bounds.Right - r1.Width + 2;
                    r1.Y = e.Bounds.Top + (e.Bounds.Height - r1.Height) / 2;
                    r2.Y = r1.Y;
                }

                if (vertical)
                {
                    r1.Y = e.Bounds.Top - 2;
                    r2.Y = e.Bounds.Bottom - r1.Height + 2;
                    r1.X = e.Bounds.Left + (e.Bounds.Width - r1.Width) / 2;
                    r2.X = r1.X;
                }

                if ((horizontal || vertical) && Calendar.AllowItemResize)
                {
                    if (!e.Item.IsOpenStart && e.IsFirst)
                    {
                        e.Graphics.FillRectangle(Brushes.White, r1);
                        e.Graphics.DrawRectangle(Pens.Black, r1);
                    }

                    if (!e.Item.IsOpenEnd && e.IsLast)
                    {
                        e.Graphics.FillRectangle(Brushes.White, r2);
                        e.Graphics.DrawRectangle(Pens.Black, r2);
                    }
                } 
            }
        }

        #endregion
    }
}
