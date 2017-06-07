using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ParishSystem
{

    public class DataHandler //Data Handler for BloodDonation
    {
        public MySqlConnection conn;
        public MySqlCommand com;
        int userID;

        public DataHandler(string server, string database, string user, string password, int userID)
        {
            conn = new MySqlConnection("Server=" + server + ";Database=" + database + ";Uid=" + user + ";Pwd=" + password + ";");
            this.userID = userID;
        }


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


        
        public bool addGeneralProfile(string firstName, string midName, string lastName, string suffix, string gender, DateTime birthDate)
        {
            string q = "INSERT INTO generalProfile(firstName, midName, lastName, suffix, gender, birthDate) VALUES " +
                "(" + firstName + ", " + midName + ", " + lastName + ", " + suffix + ", " + gender + ", " + birthDate.ToString("yyyy-mm-dd") + ")";

            return runNonQuery(q);
        }

        public bool generalProfileExists(string firstName, string midName, string lastName, string suffix, string gender, DateTime birthDate)
        {
            string q = "SELECT COUNT(*) FROM generalProfile WHERE firstName = '"+ firstName + "' AND midName = '"+ midName + "' " +
                " AND lastName = '"+ lastName + "' AND suffix = '"+ suffix + "' AND gender = '"+ gender + "' AND DATE(birthDate) = '"+ birthDate.ToString("yyyy-mm-dd") + "'";

            DataTable dt = runQuery(q);

            return int.Parse(dt.Rows[0][0].ToString()) > 0;
        }

        

        public bool addBloodDonor(string firstName, string midName, string lastName, string suffix, string gender, DateTime birthDate, string bloodType)
        {

            if (generalProfileExists(firstName, midName, lastName, suffix, gender, birthDate)) ;
            //INITIAL COMMIT

            /*string q = "INSERT INTO generalProfile(firstName, midName, lastName, suffix, gender, birthDate, bloodType) VALUES " +
                "(" + firstName + ", " + midName + ", " + lastName + ", " + suffix + ", " + gender + ", " + birthDate.ToString("yyyy-mm-dd") + ", " + bloodType + ");";

            return runNonQuery(q);*/

            return true; //TEST
        }

        public bool editGeneralProfile(int profileID, string firstName, string midName, string lastName, string suffix, string gender, DateTime birthDate, string bloodType)
        {
            addToGeneralProfileLog(profileID);
            string q = "UPDATE TABLE generalProfile SET firstName = '" + firstName + "', midName = '" + midName + "', lastName = '" + lastName +
                "', suffix = '" + suffix + "', gender = '" + gender + "', birthDate = '" + birthDate.ToString("yyyy-mm-dd") + "', bloodType = '" + bloodType + "');";

            return runNonQuery(q);
        }

        public bool logGeneralProfile(int profileID)
        {
            return addToGeneralProfileLog(profileID) && deleteGeneralProfile(profileID);
        }

        public bool deleteGeneralProfile(int profileID)
        {
            string q = "DELETE FROM generalProfile WHERE profileID = " + profileID + ";";
            return runNonQuery(q);
        }

        public bool addToGeneralProfileLog(int profileID)
        {
            string q = "INSERT INTO generalProfileLog VALUES (SELECT * from generalProfile WHERE profileID = " + profileID + ");";
            return runNonQuery(q);
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
