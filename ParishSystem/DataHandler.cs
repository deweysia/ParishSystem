using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ParishSystem
{

    public class DataHandler
    {
        public MySqlConnection conn;
        public MySqlCommand com;

        private int userID;

        public DataHandler(string server, string database, string user, string password, int userID)
        {
            conn = new MySqlConnection("Server=" + server + ";Database=" + database + ";Uid=" + user + ";Pwd=" + password + ";");
            this.userID = userID;
        }

        //                                         ========[HELPER FUNCTIONS]=========

        public bool runNonQuery(string q)
        {
            conn.Open();
            com = new MySqlCommand(q, conn);
            int rowsAffected = com.ExecuteNonQuery();
            conn.Close();
            Console.Write(q);
            return rowsAffected > 0;
        }

        public DataTable runQuery(string q)
        {
            conn.Open();
            com = new MySqlCommand(q, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
            return dt;
        }

        public string[,] toArray(DataTable dt)
        {
            string[,] arr = new string[dt.Rows.Count, dt.Columns.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    arr[i, j] = dt.Rows[i][j].ToString();
                }
            }

            return arr;
        }



        /*
                                         =============================================================
                                               ================ GENERAL PROFILE =================
                                         =============================================================
        */

        public bool addGeneralProfile(string firstName, string midName, string lastName, string suffix, string gender, DateTime birthDate)
        {
            if (generalProfileExists(firstName, midName, lastName, suffix, gender, birthDate))
                throw new Exception("DataHandler: Duplicate in GeneralProfile");

            string q = "INSERT INTO generalProfile(firstName, midName, lastName, suffix, gender, birthDate, lastModified, userID) VALUES " +
                "(" + firstName + ", " + midName + ", " + lastName + ", " + suffix + ", " + gender + ", " + birthDate.ToString("yyyy-mm-dd") +
                "NOW(), " + userID + ")";

            return runNonQuery(q);
        }

        public bool generalProfileExists(string firstName, string midName, string lastName, string suffix, string gender, DateTime birthDate)
        {
            string q = "SELECT COUNT(*) FROM generalProfile WHERE firstName = '"+ firstName + "' AND midName = '"+ midName + "' " +
                " AND lastName = '"+ lastName + "' AND suffix = '"+ suffix + "' AND gender = '"+ gender + "' AND DATE(birthDate) = '"+ birthDate.ToString("yyyy-mm-dd") + "'";

            DataTable dt = runQuery(q);

            return int.Parse(dt.Rows[0][0].ToString()) > 0;
        }

        //Returns the profileID of an entry with fields matching the columns
        public int getGeneralProfileID(string firstName, string midName, string lastName, string suffix, string gender, DateTime birthDate)
        {
            string q = "SELECT profileID FROM generalProfile WHERE firstName = '" + firstName + "' AND midName = '" + midName + "' " +
                " AND lastName = '" + lastName + "' AND suffix = '" + suffix + "' AND gender = '" + gender + "' AND DATE(birthDate) = '" + birthDate.ToString("yyyy-mm-dd") + "'";

            DataTable dt = runQuery(q);
            if (dt.Rows.Count == 0)
                return -1;
            else
                return int.Parse(dt.Rows[0][0].ToString());
        }


        public string[,] getGeneralProfile(int profileID)
        {
            string q = "SELECT firstName, midName, lastName, suffix, gender, birthdate FROM generalProfile WHERE profileID = " + profileID;

            DataTable dt = runQuery(q);

            return toArray(dt);
        }

        public bool editGeneralProfile(int profileID, string firstName, string midName, string lastName, string suffix, string gender, DateTime birthDate)
        {
            addGeneralProfileLog(profileID);

            string q = "UPDATE TABLE generalProfile SET firstName = '" + firstName + "', midName = '" + midName + "', lastName = '" + lastName +
                "', suffix = '" + suffix + "', gender = '" + gender + "', birthDate = '" + birthDate.ToString("yyyy-mm-dd") + 
                "', lastModified = NOW(), userID = " + userID + ");";

            return runNonQuery(q);
        }

        public bool deleteGeneralProfile(int profileID)
        {
            addGeneralProfileLog(profileID);

            string q = "DELETE FROM generalProfile WHERE profileID = " + profileID + ";";

            return runNonQuery(q);
        }

        public bool addGeneralProfileLog(int profileID)
        {
            string q = "INSERT INTO generalProfileLog VALUES (SELECT * from generalProfile WHERE profileID = " + profileID + ");";
            return runNonQuery(q);
        }



        /*
                                         =============================================================
                                               ================ BLOOD DONATION =================
                                         =============================================================
        */

        public bool addBloodDonor(string firstName, string midName, string lastName, string suffix, string gender, DateTime birthDate, string bloodType)
        {

            if (!generalProfileExists(firstName, midName, lastName, suffix, gender, birthDate))
                addGeneralProfile(firstName, midName, lastName, suffix, gender, birthDate);

            string q = "INSERT INTO generalProfile(firstName, midName, lastName, suffix, gender, birthDate, bloodType) VALUES " +
                "(" + firstName + ", " + midName + ", " + lastName + ", " + suffix + ", " + gender + ", " + birthDate.ToString("yyyy-mm-dd") + ", " + bloodType + ");";

            return runNonQuery(q);

            return true; //TEST1
        }


        public bool addBloodDonationEvent(string eventName, DateTime eventDate, string eventStatus, string eventVenue, string eventDetails, int userID)
        {
            string q = "INSERT INTO bloodDonationEvent(eventName, eventDate, eventStatus, eventVenue, eventDetails, userID) VALUES " +
                "(" + eventName + ", " + eventDate + ", " + eventStatus + ", " + eventVenue + ", " + eventDetails + ", " + userID + ")";
            return runNonQuery(q);
        }

        public bool addBloodDonation(int profileID, double donationAmount, int bloodDonationEventID)
        {
            string q = "INSERT INTO  blooddonation VALUES (profileID, donationAmount, bloodDonationEventID, userID) VALUES " +
                "(" + profileID + ", " + donationAmount + ", " + bloodDonationEventID + ", " + userID + ");";
            return runNonQuery(q);
        }

        



    }

}
