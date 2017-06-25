using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ParishSystem
{
    //I changed something

    public class DataHandler
    {
        public MySqlConnection conn;
        public MySqlCommand com;

        private int userID;

      

        public DataHandler(string server, string database, string user, string password)
        {
            conn = new MySqlConnection("Server=" + server + ";Database=" + database + ";Uid=" + user + ";Pwd=" + password + ";");
           
        }

        public DataHandler(string server, string database, string user, string password)
        {
            conn = new MySqlConnection("Server=" + server + ";Database=" + database + ";Uid=" + user + ";Pwd=" + password + ";");
            this.userID = -1;
        }

        //                                         ========[HELPER FUNCTIONS]=========
        #region
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
            string q = "UPDATE " + tableName  + " SET " + primaryKeyName + " = "+ primaryKeyValue + ", lastModified = NOW(), userID = '"+ userID + "'";

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

        public bool idExists(string tableName, string primaryKeyName, int primaryKeyValue)
        {
            string q = "SELECT * FROM "+ tableName + " WHERE "+ primaryKeyName + " = "+ primaryKeyValue;

            DataTable dt = runQuery(q);

            return dt.Rows.Count > 0;
        }

        public bool addSponsors(int sacramentID, int[,] sponsorIDs, string sacramentType)
        {
            bool success = true;
            foreach (int sponsorID in sponsorIDs)
            {
                string q = "INSERT INTO Sacrament_Sponsor(sacramentID, sponsorID, sacramentType) VALUES ('"
                    + sacramentID + "', '"+ sponsorID + "', '"+ sacramentType + "')";

                success = success && runNonQuery(q);

            }

            return success;
            
        }

        public bool addSponsor(int sacramentID, int sponsorID, string sacramentType)
        {
            string q = "INSERT INTO Sacrament_Sponsor(sacramentID, sponsorID, sacramentType) VALUES ('"
                        + sacramentID + "', '" + sponsorID + "', '" + sacramentType + "')";

            // *Still record changes to log or nah?
            return runNonQuery(q);
        }
        #endregion
        /*
                                         =============================================================
                                               ================ GENERAL PROFILE =================
                                         =============================================================
        */
        #region
        //ADD
        public bool addGeneralProfile(string firstName, string midName, string lastName, string suffix, string gender, DateTime birthDate)
        {
            if (generalProfileExists(firstName, midName, lastName, suffix, gender, birthDate))
                throw new Exception("DataHandler: Duplicate in GeneralProfile");

            string q = "INSERT INTO generalProfile(firstName, midName, lastName, suffix, gender, birthDate, lastModified, userID) VALUES " +
                "('" + firstName + "', '" + midName + "', '" + lastName + "', '" + suffix + "', '" + gender + "', '" + birthDate.ToString("yyyy-MM-dd") + "')";

            bool success =  runNonQuery(q);

            updateModificationInfo("generalProfile", "profileID", getLatestID("generalProfile", "profileID"));

            return success;
        }

        //EDIT
        public bool editGeneralProfile(int profileID, string firstName, string midName, string lastName, string suffix, string gender, DateTime birthDate)
        {
            addGeneralProfileLog(profileID);

            string q = "UPDATE TABLE generalProfile SET firstName = '" + firstName + "', midName = '" + midName + "', lastName = '" + lastName +
                "', suffix = '" + suffix + "', gender = '" + gender + "', birthDate = '" + birthDate.ToString("yyyy-MM-dd") + ")";

            updateModificationInfo("generalProfile", "profileID", profileID);

            return runNonQuery(q);
        }

        //DELETE
        public bool deleteGeneralProfile(int profileID)
        {
            if (!idExists("generalProfile", "profileID", profileID))
                return false;

            addGeneralProfileLog(profileID);
            updateModificationInfo("generalProfile", "profileID", profileID);
            addGeneralProfileLog(profileID);

            string q = "DELETE FROM generalProfile WHERE profileID = " + profileID + ";";

            bool success = runNonQuery(q);

            return success;

            
        }


        public bool generalProfileExists(string firstName, string midName, string lastName, string suffix, string gender, DateTime birthDate)
        {
            string q = "SELECT COUNT(*) FROM generalProfile WHERE firstName = '"+ firstName + "' AND midName = '"+ midName + "' " +
                " AND lastName = '"+ lastName + "' AND suffix = '"+ suffix + "' AND gender = '"+ gender + "' AND DATE(birthDate) = '"+ birthDate.ToString("yyyy-MM-dd") + "'";

            DataTable dt = runQuery(q);

            return int.Parse(dt.Rows[0][0].ToString()) > 0;
        }


        //Returns the profileID of an entry with fields matching the columns
        public int getGeneralProfileID(string firstName, string midName, string lastName, string suffix, string gender, DateTime birthDate)
        {
            string q = "SELECT profileID FROM generalProfile WHERE firstName = '" + firstName + "' AND midName = '" + midName + "' " +
                " AND lastName = '" + lastName + "' AND suffix = '" + suffix + "' AND gender = '" + gender + "' AND DATE(birthDate) = '" + birthDate.ToString("yyyy-MM-dd") + "'";

            DataTable dt = runQuery(q);
            if (dt.Rows.Count == 0)
                return -1;
            else
                return int.Parse(dt.Rows[0][0].ToString());
        }


        public DataTable getGeneralProfile(int profileID)
        {
            string q = "SELECT * FROM generalProfile WHERE profileID = " + profileID;

            DataTable dt = runQuery(q);

            if (dt.Rows.Count == 0)
                return null;

            return dt;
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






        #endregion
        /*
                                         =============================================================
                                            ================ BLOOD DONATION MODULE=================
                                         =============================================================
        */
        #region

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
            string q = "INSERT INTO blooddonation(profileID, donationAmount, bloodDonationEventID) VALUES " +
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
            if (!idExists("bloodDonation", "bloodDonationID", bloodDonationID))
                return false;

            addBloodDonationLog(bloodDonationID); //ModInfo before deletion
            updateModificationInfo("bloodDonation", "bloodDonationID", bloodDonationID);

            addBloodDonationLog(bloodDonationID); //ModInfo after deletion

            string q = "DELETE FROM bloodDonation WHERE bloodDonationID = " + bloodDonationID;
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
                "('" + eventName + "', '" + eventDate.ToString("yyyy-MM-dd") + "', '" + eventStatus + "', '" + eventVenue + "', '" + eventDetails + "')";

            bool success = runNonQuery(q);
            if (success)
                updateModificationInfo("BloodDnationEvent", "donationEventID", getLatestID("BloodDonationEvent", "donationEventID"));

            return success;
        }

        public bool editBloodDonationEvent(int donationEventID, string eventName, DateTime eventDate, string eventStatus, string eventVenue, string eventDetails)
        {
            string q = "UPDATE TABLE bloodDonationEvent SET eventName = '"+ eventName +"', eventDate = '"+ eventDate.ToString("yyyy-MM-dd") + "', "
                + "eventStatus = '"+ eventStatus + "', eventVenue = '"+ eventVenue + "', eventDetails = '"+ eventDetails 
                + "' WHERE donationEventID = " + donationEventID;

            bool success = runNonQuery(q);
            if(success)
                updateModificationInfo("bloodDonationEvent", "donationEventID", donationEventID);

            return success;
        }

        public bool deleteBloodDonationEvent(int donationEventID)
        {

            if (!idExists("bloodDonationEvent", "donationEventID", donationEventID))
                return false;

            addBloodDonationLog(donationEventID);
            updateModificationInfo("bloodDonationEvent", "donationEventID", donationEventID);
            addBloodDonationLog(donationEventID);

            string q = "DELETE FROM bloodDonationEvent WHERE donationEventID = " + donationEventID;
            
            return runNonQuery(q);
        }

        public bool addBloodDonationEventLog(int donationEventID)
        {
            string q = "INSERT INTO bloodDonationEventLog VALUES (SELECT * FROM bloodDonationEvent "
                + "WHERE donationEventID = "+ donationEventID + ")";

            return runNonQuery(q);
        }

        public DataTable getBloodDonation(int profileID)
        {
            string q = "SELECT * FROM BloodDonation WHERE profileID = " + profileID;
            DataTable dt = runQuery(q);

            if (dt.Rows.Count == 0)
                return null;

            return dt;
        }

        public bool addBloodDonationRetrieval(int bloodDonationID, DateTime claimDate, string firstName, string midName, string lastName, string suffix, DateTime birthDate, int gender)
        {
            string q = "INSERT INTO bloodDonationRetrieval(bloodDonationID, claimDate, firstName, midName, lastName, suffix, birthDate, gender, userID) "
                + "VALUES ('" + bloodDonationID + "', '" + claimDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', '" + firstName + "', '" + midName + "', '"+ lastName 
                + "', '" + suffix + "', '" + birthDate.ToString("yyyy-MM-dd") + "', '" + gender + "', '" + userID + "')";

            bool success = runNonQuery(q);

            return success;

        }

        public bool editBloodDonationRetrieval(int bloodDonationID, DateTime claimDate, string firstName, string midName, string lastName, string suffix, DateTime birthDate, int gender)
        {
            string q = "UPDATE TABLE BloodDonationRetrieval SET VALUES bloodDonationID = '"+ bloodDonationID 
                + "', claimDate = '"+ claimDate.ToString("yyyy-MM-dd HH:mm:ss.fff")
                + "', firstName = '"+ firstName + "', lastName = '"+ lastName 
                + "', suffix = '"+ suffix + "', birthDate = '"+ birthDate.ToString("yyyy-MM-dd") 
                + "', gender = '"+ gender 
                + "' WHERE bloodDonationID = 'bloodDonationID'";

            bool success = runNonQuery(q);

            return success;
        }

        public DataTable getBloodDonationRetrieval(int bloodDonationID)
        {
            string q = "SELECT * FROM BloodDonationRetrieval WHERE bloodDonationID = " + bloodDonationID;
            DataTable dt = runQuery(q);

            if (dt.Rows.Count == 0)
                return null;

            return dt;
        }

        #endregion
        /*
                                         =============================================================
                                                    ================ PARENT =================
                                         =============================================================
        */
        #region
        public int getParentID(string firstName, string midName, string lastName, string suffix, char gender, string birthPlace)
        {
            string q = "SELECT parentID from Parent WHERE firstName = '"+ firstName 
                + "' AND midName = '"+ midName + "' AND lastName = '"+ lastName 
                + "' AND suffix = '"+ suffix + "' AND  gender = '"+ gender 
                + "' AND birthPlace = '"+ birthPlace + "'";

            DataTable dt = runQuery(q);

            if (dt.Rows.Count == 0)
                return -1;

            return int.Parse(dt.Rows[0][0].ToString());
            
        }

        public bool addParent(string firstName, string midName, string lastName, string suffix, char gender, string birthPlace)
        {
            string q = "INSERT INTO Parent(firstName,  midName,  lastName,  suffix, gender, birthPlace, userID) VALUES ('"
                + firstName + "',  '" + midName + "',  '" + lastName + "',  '" + suffix + "', '" + gender + "', '" + birthPlace + "', '"+ userID + "')";

            return runNonQuery(q);
        }

        public bool editParent(int parentID, string firstName, string midName, string lastName, string suffix, char gender, string birthPlace)
        {
            string q = "UPDATE TABLE Parent SET  firstName = '"+ firstName 
                + "',  midName = '"+ midName + "',  lastName = '"+ lastName 
                + "',  suffix = '"+ suffix + "' , gender = '"+ gender + "',  birthPlace = '"+ birthPlace 
                + "' WHERE parentID = '" + parentID + "' ";

            return runNonQuery(q);
        }

        public DataTable getParent(int parentID)
        {
            string q = "SELECT * FROM Parent WHERE parentID = " + parentID;

            DataTable dt = runQuery(q);

            if (dt.Rows.Count == 0)
                return null;

            return dt;
        }


        #endregion
        /*
                                         =============================================================
                                                ================ INCOME TABLE =================
                                         =============================================================
        */
        #region
        public bool addIncome(int incomeTypeID, int profileID, string incomeDescription, double incomeAmount, DateTime incomeDateTime, string ORnum)
        {
            string q = "INSERT INTO Income(incomeTypeID,  profileID,  incomeDescription, incomeAmount, incomeDateTime,  ORnum, lastModified)"
                + " VALUES ('"+ incomeTypeID + "',  '"+ profileID + "',  '"+ incomeDescription + "', '"+ incomeAmount + "', '"
                + incomeDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff") + "',  '"+ ORnum + "', NOW())";

            bool success = runNonQuery(q);
            if(success)
                updateModificationInfo("income", "incomeID", getLatestID("income", "incomeID"));

            return success;
        }

        public bool editIncome(int incomeID, int incomeTypeID, int profileID, string incomeDescription, double incomeAmount, DateTime incomeDateTime, string ORnum)
        {
            addIncomeLog(incomeID);

            string q = "UPDATE TABLE income SET incomeTypeID = '" + incomeTypeID + "', profileID = '" + profileID
                + "', incomeDescription = '" + incomeDescription + "', incomeAmount = '" + incomeAmount
                + "', incomeDateTime = '" + incomeDateTime.ToString("yyyy-MM-dd HH:mm:ss.ff") + "', ORnum = '" + ORnum
                + "' WHERE incomeID = 'incomeID'";

            bool success = runNonQuery(q);
            if (success)
                updateModificationInfo("income", "incomeID", incomeID);

            return success;
        }

        public bool addIncomeLog(int incomeID)
        {
            string q = "INSERT INTO incomeLog VALUES (SELECT * FROM income WHERE incomeID = '"+ incomeID + "')";

            return runNonQuery(q);
        }

        public bool deleteIncome(int incomeID)
        {
            if (!idExists("income", "incomeID", incomeID))
                return false;

            addIncomeLog(incomeID);
            updateModificationInfo("income", "incomeID", incomeID);
            addIncomeLog(incomeID);

            string q = "DELETE FROM income WHERE incomeID = " + incomeID;

            bool success = runNonQuery(q);
            return success;
        }


        public DataTable getIncomeBetweenDates(DateTime start, DateTime end)
        {
            string q = "SELECT * FROM income WHERE incomeDateTime => '"+ start.ToString("yyyy-MM-dd") 
                + "' AND incomeDateTime <= '"+ end.ToString("yyyy-MM-dd") + "'";

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getIncomeOfMonth(DateTime month, DateTime year)
        {
            string q = "SELECT * FROM income WHERE MONTH(incomeDateTime) = '" + int.Parse(month.ToString("MM")) + "' AND YEAR(incomeDateTime) = '" + int.Parse(year.ToString("yyyy")) + "'";

            DataTable dt = runQuery(q);

            return dt;
        }

        #endregion
        /*
                                         =============================================================
                                         ================= SACRAMENT TABLE (obsolete)=================
                                         =============================================================
        */
        #region
        public bool addSacrament(int profileID, int ministerID, int sponsorID, string sacramentType)
        {
            string q = "INSERT INTO Sacrament(profileID, ministerID, sponsorID, sacramentType) VALUES ('"
                + profileID + "', '"+ ministerID +"', '"+ sponsorID + "', '"+ sacramentType + "')";

            bool success = runNonQuery(q);

            if (success)
                updateModificationInfo("sacrament", "sacramentID", getLatestID("sacrament", "sacramentID"));

            return success;

        }

        public bool editSacrament(int sacramentID, int profileID, int ministerID, int sponsorID, string sacramentType)
        {
            string q = "UPDATE TABLE Sacrament SET sacramentID = '"+ sacramentID + "',  profileID = '"+ profileID 
                + "',  ministerID = '"+ ministerID + "',  sponsorID = '"+ sponsorID + "',  sacramentType = '"+ sacramentType 
                +"' WHERE sacramentID = '"+ sacramentID + "'";

            bool success = runNonQuery(q);

            if(success)
                updateModificationInfo("sacrament", "sacramentID", sacramentID);


            return success;

        }

        public bool addSacramentLog(int sacramentID)
        {
            string q = "INSERT INTO SacramentLog VALUES (SELECT * FROM Sacrament WHERE sacramentID = '"+ sacramentID+"')";

            return runNonQuery(q);
        }

        public DataTable getSacrament(int sacramentID)
        {
            string q = "SELECT * FROM Sacrament WHERE sacramentID = '"+ sacramentID + "'";

            DataTable dt = runQuery(q);

            return dt;
        }
        #endregion

        /*
                                         =============================================================
                                              ================ BAPTISM TABLE =================
                                         =============================================================
        */
        #region
        public bool addBaptism(int profileID, int ministerID, DateTime baptismDate)
        {
            string q = "INSERT INTO Baptism(profileID, ministerID, baptismDate) VALUES ('" 
                + profileID + "', '" + ministerID + "', '"  + baptismDate.ToString("yyyy-MM-dd") + "')";

            bool success = runNonQuery(q);

            if (success)
                updateModificationInfo("baptism", "baptismID", getLatestID("baptism", "baptismID"));

            return success;
        }


        public bool editBaptism(int baptismID, int ministerID, DateTime baptismDate)
        {
            if (!idExists("baptism", "baptismID", baptismID))
                return false;

            string q = "UPDATE baptism(ministerID, baptismDate) VALUES ('"
                + ministerID + "', '"+ baptismDate.ToString("yyyy - MM - dd") 
                + "' WHERE baptismID = '"+ baptismID + "'";

            bool success = runNonQuery(q);

            if (success)
                updateModificationInfo("baptism", "baptismID", baptismID);

            return success;

        }

        public bool deleteBaptism(int baptismID)
        {
            if (!idExists("Baptism", "baptismID", baptismID))
                return false;

            addBaptismLog(baptismID);
            updateModificationInfo("Baptism", "baptismID", baptismID);
            addBaptismLog(baptismID);

            string q = "DELETE FROM Baptism WHERE baptismID = " + baptismID;

            bool success = runNonQuery(q);

            return success;
        }

        public DataTable getBaptism(int baptismID)
        {
            string q = "SELECT * FROM Baptism WHERE baptismID = " + baptismID;

            DataTable dt = runQuery(q);

            if (dt.Rows.Count == 0)
                return null;

            return dt;
        }

        public DataTable getBaptismBetweenDates(DateTime start, DateTime end)
        {
            string q = "SELECT * FROM Baptism WHERE baptismDate >= '"
                + start.ToString("yyyy-MM-dd") + "' AND baptismDate =< '"
                + end.ToString("yyyy-MM-dd") + "'";

            DataTable dt = runQuery(q);

            return dt;
        }

        

        public bool addBaptismLog(int baptismID)
        {
            string q = "INSERT INTO BaptismLog VALUES (SELECT * FROM Baptism WHERE baptismID = " + baptismID;

            return runNonQuery(q);
        }

        public bool editBaptismReference(int baptismID, string recordNumber, string pageNumber, string registryNumber)
        {
            if (!idExists("baptism", "baptismID", baptismID))
                return false;

            addBaptismLog(baptismID);

            string q = "UPDATE TABLE Baptism SET recordNumber = '"+ recordNumber 
                + "', pageNumber = '"+ pageNumber + "', registryNumber = '"+ registryNumber 
                + "' WHERE baptismID = '"+ baptismID + "'";

            bool success = runNonQuery(q);

            if (success)
                updateModificationInfo("baptism", "baptismID", baptismID);

            return success;
        }

        public bool removeBaptismReference(int baptismID)
        {
            if (!idExists("baptism", "baptismID", baptismID))
                return false;

            addBaptismLog(baptismID);

            string q = "UPDATE Baptism SET recordNumber = NULL, pageNumber = NULL, registryNumber = NULL WHERE baptismID =  " + baptismID;

            bool success = runNonQuery(q);

            if (success)
                updateModificationInfo("baptism", "baptismID", baptismID);

            return success;

        }


        public DataTable getBaptismReference(int baptismID)
        {
            string q = "SELECT * FROM Baptism WHERE baptismID = " + baptismID;

            DataTable dt = runQuery(q);

            return dt;
        }
        #endregion

        /*
                                         =============================================================
                                            ================= CONFIRMATION TABLE =================
                                         =============================================================
        */
        #region
        public bool addConfirmation(int profileID, int ministerID, DateTime confirmationDate)
        {
            string q = "INSERT INTO Confirmation(profileID, ministerID, confirmationDate) VALUES ('"
                + profileID + "', '"+ ministerID + "', '"+ confirmationDate.ToString("yyyy-MM-dd") + "')";

            
            bool success = runNonQuery(q);

            if (success)
                updateModificationInfo("confirmation", "confirmationID", getLatestID("confirmation", "confirmationID"));

            return success;
        }

        public bool editConfirmation(int confirmationID, int ministerID, DateTime confirmationDate)
        {
            if (!idExists("Confirmation", "confirmationID", confirmationID))
                return false;

            addConfirmationLog(confirmationID);


            string q = "UPDATE Confirmation SET ministerID = '"
                + ministerID + "', confirmationDate = '"+ confirmationDate.ToString("yyyy-MM-dd") 
                + "' WHERE confirmationID = " + confirmationID;

            bool success = runNonQuery(q);

            if(success)
                updateModificationInfo("Confirmation", "confirmationID", confirmationID);

            return success;
        }

        public bool editConfirmationReference(int confirmationID, string recordNumber, string pageNumber, string registryNumber)
        {
            if (!idExists("Confirmation", "confirmationID", confirmationID))
                return false;

            addConfirmationLog(confirmationID);

            string q = "UPDATE Confirmation SET recordNumber = '"
                + recordNumber + "', pageNumber = '"+ pageNumber 
                + "', registryNumber = '"+ registryNumber 
                + "' WHERE confirmationID = " + confirmationID;

            bool success = runNonQuery(q);

            if (success)
                updateModificationInfo("Confirmation", "confirmationID", confirmationID);

            return success;

        }

        public bool addConfirmationLog(int confirmationID)
        {
            if (!idExists("Confirmation", "confirmationID", confirmationID))
                return false;

            string q = "INSERT INTO ConfirmationLog VALUES ( SELECT * FROM Confirmation WHERE confirmationID = " + confirmationID + ")";

            return runNonQuery(q);
        }


        public DataTable getConfirmation(int confirmationID)
        {
            string q = "SELECT * FROM Confirmation WHERE confirmationID = " + confirmationID;

            DataTable dt = runQuery(q);

            if (dt.Rows.Count == 0)
                return null;

            return dt;
        }

        public DataTable getConfirmationBetweenDates(DateTime start, DateTime end)
        {
            string q = "SELECT * FROM Confirmation WHERE confirmationDate >= '" 
                + start.ToString("yyyy-MM-dd") + "' AND confirmationDate <= '"+ start.ToString("yyyy-MM-dd") + "'";

            DataTable dt = runQuery(q);

            if (dt.Rows.Count == 0)
                return null;

            return dt;
        }

        public bool removeConfirmationReference(int confirmationID)
        {
            if (!idExists("Confirmation", "confirmationID", confirmationID))
                return false;

            addBaptismLog(confirmationID);

            string q = "UPDATE Confirmation SET recordNumber = NULL, pageNumber = NULL, registryNumber = NULL WHERE confirmationID =  " + confirmationID;

            bool success = runNonQuery(q);

            if (success)
                updateModificationInfo("Confirmation", "confirmationID", confirmationID);

            return success;

        }


        public DataTable getConfirmationReference(int confirmationID)
        {
            string q = "SELECT * FROM Confirmation WHERE confirmationID = " + confirmationID;

            DataTable dt = runQuery(q);

            return dt;
        }


        #endregion
        /*
                                         =============================================================
                                            ================= MARRIAGE TABLE =================
                                         =============================================================
        */
        #region

        public bool addMarriage(int groomID, int brideID, int ministerID, string licenseDate, DateTime marriageDate, string status)
        {
            string q = "INSERT INTO Marriage(groomID, brideID, ministerID, licenseDate, marriageDate, status) VALUES ('"
                + groomID + "', '"+ brideID+"', '"+ ministerID + "', '"+ licenseDate + "', '"+ marriageDate + "', '"+ status + "')";

            bool success = runNonQuery(q);

            if (success)
                updateModificationInfo("Marriage", "marriageID", getLatestID("Marriage", "marriageID"));

            return success;
        }

        public bool editMarriage(int marriageID, int groomID, int brideID, int ministerID, DateTime licenseDate, DateTime marriageDate, string status)
        {
            if (!idExists("Marriage", "marriageID", marriageID))
                return false;

            addMarriageLog(marriageID);

            string q = "UPDATE Marriage SET groomID = groomID, brideID = '" + brideID
                + "', ministerID = '" + ministerID + "', licenseDate = '" + licenseDate.ToString("yyyy-MM-dd")
                + "', marriageDate = '" + marriageDate.ToString("yyyy-MM-dd") + "', status = '"+ status + "' WHERE marriageID = " + marriageID;

            bool success = runNonQuery(q);

            if (success)
                updateModificationInfo("Marriage", "marriageID", marriageID);

            return success;
        }

        public bool addMarriageLog(int marriageID)
        {
            if (idExists("Marriage", "marriageID", marriageID))
                return false;

            string q = "INSERT INTO MarriageLog VALUES (SELECT * FROM Marriage WHERE marriageID = " + marriageID;

            return runNonQuery(q);
        }

        public bool editMarriageReference(int marriageID, string recordNumber, string pageNumber, string registryNumber)
        {
            if (!idExists("Marriage", "marriageID", marriageID))
                return false;

            string q = "UPDATE Marriage SET recordNumber = '"+ recordNumber 
                + "', pageNumber = '"+ pageNumber + "', registryNumber = '"+ registryNumber 
                + "' WHERE marriageID = '"+ marriageID + "'";

            bool success = runNonQuery(q);

            if (success)
                updateModificationInfo("marriage", "marriageID", marriageID);

            return success;
        }

        public bool removeMarriageReference(int marriageID)
        {
            if (!idExists("Marriage", "marriageID", marriageID))
                return false;

            addBaptismLog(marriageID);

            string q = "UPDATE Marriage SET recordNumber = NULL, pageNumber = NULL, registryNumber = NULL WHERE marriageID =  " + marriageID;

            bool success = runNonQuery(q);

            if (success)
                updateModificationInfo("Marriage", "marriageID", marriageID);

            return success;

        }

        public bool deleteMarriage(int marriageID)
        {
            if (!idExists("Marriage", "marriageID", marriageID))
                return false;

            addBaptismLog(marriageID);

            updateModificationInfo("Marriage", "marriageID", marriageID);

            addBaptismLog(marriageID);

            string q = "DELETE FROM Marriage WHERE marriageID = " + marriageID;

            return runNonQuery(q);
        }

        public DataTable getMarriage(int marriageID)
        {
            string q = "SELECT * FROM Marriage WHERE marriageID = " + marriageID;

            DataTable dt = runQuery(q);

            if (dt.Rows.Count == 0)
                return null;

            return dt;
        }

        public DataTable getMarriageBetweenDates(DateTime start, DateTime end)
        {
            string q = "SELECT * FROM Marriage WHERE marriageDate >= '"
                + start.ToString("yyyy-MM-dd") + "' AND marriageDate <= '" + start.ToString("yyyy-MM-dd") + "'";

            DataTable dt = runQuery(q);

            if (dt.Rows.Count == 0)
                return null;

            return dt;
        }

        public DataTable getMarriageReference(int marriageID)
        {
            string q = "SELECT * FROM Marriage WHERE marriageID = " + marriageID;

            DataTable dt = runQuery(q);

            return dt;
        }

        #endregion
        /*
                                         =============================================================
                                            ================= MINISTER TABLE =================
                                         =============================================================
        */
        #region

        public bool addMinister(string firstName, string midName, string lastName, string suffix, DateTime birthDate, string ministryType, string status, string licenseNumber, DateTime expirationDate)
        {
            string q = "INSERT INTO Minister(firstName, midName, lastName, suffix, birthDate, ministryType, status, licenseNumber, expirationDate) VALUES ('"
                + firstName + "', '"+ midName + "', '"+ lastName+"', '"+ suffix + "', '"
                + birthDate.ToString("yyyy-MM-dd")+"', ministryType, status, licenseNumber, expirationDate)";

            bool success = runNonQuery(q);

            if (success)
                updateModificationInfo("Minister", "ministerID", getLatestID("Minister", "ministerID"));

            return success;
        }

        public bool editMinister(int ministerID, string firstName, string midName, string lastName, string suffix, DateTime birthDate, string ministryType, string status, string licenseNumber, DateTime expirationDate)
        {
            if (!idExists("Minister", "ministerID", ministerID))
                return false;

            //No need addMinisterLog

            string q = "UPDATE Minister SET firstName = '"+ firstName 
                + "', midName = '"+ midName + "', lastName = '"+ lastName
                + "', suffix = '"+ suffix + "', birthDate = '"+ birthDate 
                + "', ministryType = '"+ ministryType + "', status = '"+ status 
                + "', licenseNumber = '"+ licenseNumber 
                + "', expirationDate = '"+ expirationDate 
                + "' WHERE ministerID =" + ministerID;

            bool success = runNonQuery(q);

            if (success)
                updateModificationInfo("Minister", "ministerID", ministerID);

            return success;


        }

        public int getMinisterID(string firstName, string midName, string lastName, string suffix, DateTime birthDate)
        {
            string q = "SELECT ministerID from Minister WHERE firstName = '"
                + firstName + "' AND midName = '"+ midName + "' AND lastName = '"+ lastName 
                + "' AND suffix = '"+ suffix + "' AND birthDate = '"+ birthDate.ToString("yyyy-MM-dd") + "'";

            DataTable dt = runQuery(q);

            if (dt.Rows.Count == 0)
                return -1;

            return int.Parse(dt.Rows[0][0].ToString());
        }

        public bool ministerIsActive(int ministerID)
        {
            if (!idExists("Minister", "ministerID", ministerID))
                throw new MissingPrimaryKeyException();

            string q = "SELECT status FROM Minister WHERE ministerID = " + ministerID;

            DataTable dt = runQuery(q);

            bool active = dt.Rows[0][0].ToString().ToUpper() == "ACTIVE" ? true : false;

            return active;
             
        }

        public bool ministerChangeStatus(int ministerID, string status)
        {
            if (!idExists("Minister", "ministerID", ministerID))
                throw new MissingPrimaryKeyException();

            string q = "UPDATE Minister SET status = '"+ status + "' WHERE ministerID = '"+ ministerID + "'";

            bool success = runNonQuery(q);

            if (success)
                updateModificationInfo("Minister", "ministerID", ministerID);

            return success;

        }

        public DataTable getMinister(int ministerID)
        {
            string q = "SELECT * FROM Minister WHERE ministerID = " + ministerID;

            DataTable dt = runQuery(q);

            if (dt.Rows.Count == 0)
                return null;
            return dt;
        }

        #endregion
        /*
                                         =============================================================
                                            ================= SPONSOR TABLE =================
                                         =============================================================
        */
        #region

        public bool addSponsor(string firstName, string midName, string lastName, string suffix, string gender)
        {
            string q = "INSERT INTO Sponsor(firstName, midName, lastName, suffix, gender) VALUES ('"
                + firstName + "', '"+ midName + "', '"+ lastName + "', '"+ suffix + "', '"+ gender + "')";

            bool success = runNonQuery(q);

            if (success)
                updateModificationInfo("Sponsor", "sponsorID", getLatestID("Sponsor", "sponsorID"));

            return success;
        }

        public bool editSponsor(int sponsorID, string firstName, string midName, string lastName, string suffix, string gender)
        {
            if (!idExists("Sponsor", "sponsorID", sponsorID))
                return false;

            string q = "UPDATE Sponsor SET  firstName = '" + firstName 
                + "', midName = '" + midName + "', lastName = '" + lastName 
                + "', suffix = '"+ suffix + "', gender = '"+ gender 
                + "' WHERE sponsorID = " + sponsorID;

            bool success = runNonQuery(q);

            if (success)
                updateModificationInfo("Sponsor", "sponsorID", sponsorID);

            return success;

       } 

       public DataTable getSponsor(int sponsorID)
        {
            string q = "SELECT * FROM Sponsor WHERE sponsorID = " + sponsorID;

            DataTable dt = runQuery(q);

            if (dt.Rows.Count == 0)
                return null;

            return dt;
        }

        //Gets sponsors of a sacrament
        public DataTable getSacramentSponsors(string sacramentType, int sacramentID)
        {
            string q = "SELECT * FROM Sponsor WHERE sacramentType = '"
                + sacramentType + "' AND sacramentID = '" + sacramentID + "'";

            DataTable dt = runQuery(q);

            if (dt.Rows.Count == 0)
                return null;

            return dt;

        }
        #endregion
        /*
                                         =============================================================
                                            ================= APPOINTMENT TABLE =================
                                         =============================================================
        */



































    }

}
