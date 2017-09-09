using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabasePopulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BaptismalPreview("Josh", "Earth", "July 2, 1998", "Sir Yancy", "Sir Raul"
                , "Davao", "Manila", "August 3, 1999", "bulao", "August 3, 1999", "312", "31"
                , "5", "tabora", "no purpose"));
        }
    }
}
