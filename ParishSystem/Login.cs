using System;
using System.Security.Cryptography;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace ParishSystem
{
    class Login
    {
        MySqlConnection conn = new MySqlConnection("Server=" + "localhost" + ";Database=" + "sad2" + ";Uid=" + "root" + ";Pwd=" + "root" + ";pooling = false; convert zero datetime=True;");
        public MySqlCommand com;
        public bool runNonQuery(string q)
        {
            Console.WriteLine(q);
            conn.Open();
            com = new MySqlCommand(q, conn);
            int rowsAffected = com.ExecuteNonQuery();
            conn.Close();

            return rowsAffected > 0;
        }

        public DataTable runQuery(string q)
        {
            Console.WriteLine(q);
            conn.Open();
            com = new MySqlCommand(q, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
            return dt;
        }
   
    }
}
