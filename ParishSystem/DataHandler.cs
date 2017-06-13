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

        public bool updateModificationInfo(string tableName, string primaryKeyName, int primaryKeyValue)
        {
            string q = "UPDATE TABLE " + tableName  + " SET " + primaryKeyName + " = "+ primaryKeyValue + ", lastModified = NOW()";

            return runNonQuery(q);
        }

        public int getLatestID(string tableName, string primaryKeyName)
        {
            string q = "SELECT MAX(" + primaryKeyName + ") FROM " + tableName;

            DataTable dt = runQuery(q);

            if (dt.Rows.Count == 0)
                return -1;
            return int.Parse(dt.Rows[0][0].ToString());
        }



        /*
                                         =============================================================
                                               ================ GENERAL PROFILE =================
                                         =============================================================
        */

        //ADD
        public bool addGeneralProfile(string firstName, string midName, string lastName, string suffix, string gender, DateTime birthDate)
        {
            if (generalProfileExists(firstName, midName, lastName, suffix, gender, birthDate))
                throw new Exception("DataHandler: Duplicate in GeneralProfile");

            string q = "INSERT INTO generalProfile(firstName, midName, lastName, suffix, gender, birthDate, lastModified, userID) VALUES " +
                "('" + firstName + "', '" + midName + "', '" + lastName + "', '" + suffix + "', '" + gender + "', '" + birthDate.ToString("yyyy-mm-dd") + "')";

            bool success =  runNonQuery(q);

            updateModificationInfo("generalProfile", "profileID", getLatestID("generalProfile", "profileID"));

            return success;
        }

        //EDIT
        public bool editGeneralProfile(int profileID, string firstName, string midName, string lastName, string suffix, string gender, DateTime birthDate)
        {
            addGeneralProfileLog(profileID);

            string q = "UPDATE TABLE generalProfile SET firstName = '" + firstName + "', midName = '" + midName + "', lastName = '" + lastName +
                "', suffix = '" + suffix + "', gender = '" + gender + "', birthDate = '" + birthDate.ToString("yyyy-mm-dd") + ")";

            updateModificationInfo("generalProfile", "profileID", profileID);

            return runNonQuery(q);
        }

        //DELETE
        public bool deleteGeneralProfile(int profileID)
        {
            addGeneralProfileLog(profileID);

            string q = "DELETE FROM generalProfile WHERE profileID = " + profileID + ";";

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
            string q = "SELECT * FROM generalProfile WHERE profileID = " + profileID;

            DataTable dt = runQuery(q);

            return toArray(dt);
        }

        public bool addGeneralProfileLog(int profileID)
        {
            string q = "INSERT INTO generalProfileLog VALUES (SELECT * from generalProfile WHERE profileID = " + profileID + ");";
            return runNonQuery(q);
        }

        public bool isBaptized(int profileID)
        {
            string q = "SELECT COUNT(*) FROM Sacrament JOIN Baptism ON sacrament.sacramentID = baptism.sacramentID"
                +" WHERE sacrament.profileID = " + profileID;
            DataTable dt = runQuery(q);

            return int.Parse(dt.Rows[0][0].ToString()) > 0;
        }

        public bool isConfirmed(int profileID)
        {
            string q = "SELECT COUNT(*) FROM Sacrament JOIN Confirmation ON Sacrament.sacramentID = Confirmation.sacramentID"
                + " WHERE sacrament.profileID = " + profileID;
            DataTable dt = runQuery(q);

            return int.Parse(dt.Rows[0][0].ToString()) > 0;
        }

        public bool isMarried(int profileID)
        {
            string q = "SELECT COUNT(*) FROM Sacrament JOIN Marriage ON Sacrament.sacramentID = Marriage.sacramentID"
                + " WHERE sacrament.profileID = " + profileID;
            DataTable dt = runQuery(q);

            return int.Parse(dt.Rows[0][0].ToString()) > 0;
        }

        





        /*
                                         =============================================================
                                            ================ BLOOD DONATION MODULE=================
                                         =============================================================
        */


        //EDIT AND ADD have same processes
        public bool addBloodDonor(int profileID, string bloodType)
        {
            string q = "UPDATE TABLE generalProfile SET bloodType = '" + bloodType + "'"
                + " WHERE profileID = " + profileID;

            updateModificationInfo("generalProfile", "profileID", profileID);

            return runNonQuery(q);
        }

        public bool editBloodType(int profileID, string bloodType)
        {
            string q = "UPDATE TABLE generalProfile SET bloodType = '" + bloodType + "'"
                + " WHERE profileID = " + profileID;

            updateModificationInfo("generalProfile", "profileID", profileID);

            return runNonQuery(q);
        }


        public bool addBloodDonation(int profileID, double donationAmount, int bloodDonationEventID)
        {
            string q = "INSERT INTO blooddonation VALUES (profileID, donationAmount, bloodDonationEventID) VALUES " +
                "('" + profileID + "', '" + donationAmount + "', '" + bloodDonationEventID + "')";
            
            bool success = runNonQuery(q);
            if(success)
                updateModificationInfo("BloodDonation", "bloodDonationID", getLatestID("BloodDonation", "bloodDonationID"));

            return success; 
        }

        public bool editBloodDonation(int bloodDonationID, int profileID, int donationEventID, int donationAmount)
        {
            addBloodDonationLog(bloodDonationID);

            string q = "UPDATE TABLE bloodDonation SET profileID = "+ profileID + ","
                + " donationEventID = "+ donationEventID + ", donationAmount = "+ donationAmount 
                + " WHERE bloodDonationID = " + bloodDonationID;

            updateModificationInfo("BloodDonation", "bloodDonationID", bloodDonationID);

            return runNonQuery(q);
        }

        public bool deleteBloodDonation(int bloodDonationID)
        {
            addBloodDonationLog(bloodDonationID); //ModInfo before deletion

            string q = "DELETE FROM bloodDonation WHERE bloodDonationID = " + bloodDonationID;
            updateModificationInfo("bloodDonation", "bloodDonationID", bloodDonationID);

            addBloodDonationLog(bloodDonationID); //ModInfo after deletion

            return runNonQuery(q);
        }


        public bool addBloodDonationLog(int bloodDonationID)
        {
            string q = "INSERT INTO bloodDonationLog VALUES (SELECT * FROM bloodDonation WHERE bloodDonationID = "+ bloodDonationID + ")";
            return runNonQuery(q);

        }


        public bool addBloodDonationEvent(string eventName, DateTime eventDate, string eventStatus, string eventVenue, string eventDetails)
        {
            string q = "INSERT INTO bloodDonationEvent(eventName, eventDate, eventStatus, eventVenue, eventDetails, userID) VALUES " +
                "('" + eventName + "', '" + eventDate.ToString("yyyy-mm-dd") + "', '" + eventStatus + "', '" + eventVenue + "', '" + eventDetails + "')";

            bool success = runNonQuery(q);
            if (success)
                updateModificationInfo("BloodDnationEvent", "donationEventID", getLatestID("BloodDonationEvent", "donationEventID"));

            return success;
        }

        public bool editBloodDonationEvent(int donationEventID, string eventName, DateTime eventDate, string eventStatus, string eventVenue, string eventDetails)
        {
            string q = "UPDATE TABLE bloodDonationEvent SET eventName = '"+ eventName +"', eventDate = '"+ eventDate.ToString("yyyy-mm-dd") + "', "
                + "eventStatus = '"+ eventStatus + "', eventVenue = '"+ eventVenue + "', eventDetails = '"+ eventDetails 
                + "' WHERE donationEventID = " + donationEventID;

            bool success = runNonQuery(q);
            if(success)
                updateModificationInfo("bloodDonationEvent", "donationEventID", donationEventID);

            return success;
        }

        public bool deleteBloodDonationEvent(int donationEventID)
        {
            addBloodDonationLog(donationEventID);

            string q = "DELETE FROM bloodDonationEvent WHERE donationEventID = " + donationEventID;
            updateModificationInfo("bloodDonationEvent" , "donationEventID", donationEventID);
            addBloodDonationLog(donationEventID);

            return runNonQuery(q)
        }

        public bool addBloodDonationEventLog(int donationEventID)
        {
            string q = "INSERT INTO bloodDonationEventLog VALUES (SELECT * FROM bloodDonationEvent "
                + "WHERE donationEventID = "+ donationEventID + ")";

            return runNonQuery(q);
        }

        public string[,] getBloodDonation(int profileID)
        {
            string q = "SELECT * FROM BloodDonation WHERE profileID = " + profileID;
            DataTable dt = runQuery(q);

            return toArray(dt);
        }

        public bool addBloodDonationRetrieval(int bloodDonationID, DateTime claimDate, string firstName, string midName, string lastName, string suffix, DateTime birthDate, int gender)
        {
            string q = "INSERT INTO bloodDonationRetrieval(bloodDonationID, claimDate, firstName, midName, lastName, suffix, birthDate, gender, userID) "
                + "VALUES ('" + bloodDonationID + "', '" + claimDate.ToString("yyyy-mm-dd") + "', '" + firstName + "', '" + midName + "', '"+ lastName 
                + "', '" + suffix + "', '" + birthDate.ToString("yyyy-mm-dd") + "', '" + gender + "', '" + userID + "')";

            return false;

        }



        








    }

}
