using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text.RegularExpressions;
namespace ParishSystem
{

    class ParameterizedSQL
    {


        public MySqlConnection conn;
        public MySqlCommand com;





        public ParameterizedSQL()
        {
            conn = new MySqlConnection("Server= localhost;Database= sad2 ;Uid= root ;Pwd=root;pooling = false; convert zero datetime=True;");

        }

        private string[] getParameters(string query)
        {
            List<string> l = new List<string>();
            foreach (Match match in Regex.Matches(query, @"(?<!\w)@\w+"))
            {
                Console.WriteLine(match.Value);
                l.Add(match.Value);
            }

            return l.ToArray();
        }


        public void Main()
        {

            getApplicationIncomeDetails(43);


        }

        public DataTable getApplicationIncomeDetails(int applicationID)
        {
            string q = "SELECT sacramentIncome.sacramentIncomeID, price, sacramentincome.remarks, "
                + "COALESCE(SUM(paymentAmount),0) AS 'totalPayment' "
                + "FROM Application NATURAL JOIN SacramentIncome "
                + "LEFT JOIN Payment ON Payment.sacramentIncomeID = sacramentIncome.sacramentIncomeID"
                + " WHERE applicationID = " + applicationID;

            DataTable dt = ExecuteQuery(q);

            return dt;
        }

        public bool addGeneralProfile(string firstName, string midName, string lastName, string suffix, Gender gender, DateTime birthDate, string contactNumber, string address, string birthplace)
        {

            string q = "INSERT INTO GeneralProfile(firstName, midName, lastName, suffix, gender, birthDate, contactNumber, address, birthplace) VALUES (@firstName, @midName, @lastName, @suffix, @gender, @birthDate, @contactNumber, @address, @birthplace)";

            bool success = ExecuteNonQuery(q, firstName, midName, lastName, suffix, (int)gender, DateTime.Now.ToString("yyyy-MM-dd"), contactNumber, address, birthplace);

            return success;
        }

        private DataTable ExecuteQuery(string q, params object[] values)
        {
            string[] parameters = getParameters(q);

            if (parameters.Length != values.Length)
                throw new Exception("Number of parameters does not match number of values");

            var ParameterValues = parameters.Zip(values, (p, v) => new { Parameter = p, Value = v });

            conn.Open();
            com = new MySqlCommand(q, conn);
            foreach (var pv in ParameterValues)
            {
                com.Parameters.AddWithValue(pv.Parameter, pv.Value);
                Console.WriteLine(pv.Parameter + " " + pv.Value);
            }

            Console.WriteLine(q);

            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Rows[0].ItemArray.Length; j++)
                {
                    Console.WriteLine(dt.Rows[0].ItemArray[j]);
                }
                Console.WriteLine();
            }
            return dt;
        }

        private bool ExecuteNonQuery(string q, params object[] values)
        {
            string[] parameters = getParameters(q);

            if (parameters.Length != values.Length)
                throw new Exception("Number of parameters does not match number of values");

            var ParameterValues = parameters.Zip(values, (p, v) => new { Parameter = p, Value = v });

            conn.Open();
            com = new MySqlCommand(q, conn);
            foreach (var pv in ParameterValues)
            {
                com.Parameters.AddWithValue(pv.Parameter, pv.Value);
                Console.WriteLine(pv.Parameter + " " + pv.Value);
            }

            Console.WriteLine(q);

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

