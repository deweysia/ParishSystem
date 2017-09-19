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

       

        public bool verify(string username, string password)
        {
            DataTable dt = runQuery($@"SELECT pass FROM sad2.user where username='{username}'and status=1");
            if (dt.Rows.Count > 0)
            {
                string savedPasswordHash = dt.Rows[0][0].ToString();
                byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);
                byte[] hash = pbkdf2.GetBytes(20);
                for (int i = 0; i < 20; i++)
                    if (hashBytes[i + 16] != hash[i])
                        return false;
                return true;
            }
            else
            {
                return false;
            }
        }
   
    }
}
