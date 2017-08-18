using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Data;
using System.Reflection;

namespace ParishSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        static DataHandler dh;
        [STAThread]
        static void Main()
        {
            dh = new DataHandler("localhost", "sad2", "root", "root");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //MessageBox.Show((dh == null).ToString());
            //MessageBox.Show((new Sacraments(dh) == null).ToString());
            Application.Run(new CDB_FullPayment_Module(1));
        }
    }

}
