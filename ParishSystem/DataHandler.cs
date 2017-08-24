using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace ParishSystem
{
    //I changed something


    

    public class DataHandler
    {

        public MySqlConnection conn;
        public MySqlCommand com;

        private int userID = 1;

        public DataHandler()
        {
            conn = new MySqlConnection("Server=" + "localhost" + ";Database=" + "sad2" + ";Uid=" + "root" + ";Pwd=" + "root" + ";pooling = false; convert zero datetime=True;");
            
        }
        //  MySqlConnection connect = new MySqlConnection("server=localhost; database=sad2; user=root; password=root; pooling = false; convert zero datetime=True");
        public DataHandler(string server, string database, string user, string password, int UserID)
        {
            conn = new MySqlConnection("Server=" + server + ";Database=" + database + ";Uid=" + user + ";Pwd=" + password + ";pooling = false; convert zero datetime=True;");
            userID = UserID;
        }

        public DataHandler(string server, string database, string user, string password)
        {
            conn = new MySqlConnection("Server=" + server + ";Database=" + database + ";Uid=" + user + ";Pwd=" + password + ";pooling = false; convert zero datetime=True;");
            this.userID = -1;
        }

        //====== SINGLETON PATTERN IMPLEMENTATION OF DATAHANDLER
        private static DataHandler _dh;
        public static DataHandler getDataHandler()
        {
            if (_dh != null)
                return _dh;
            else
            {
                _dh = new DataHandler();
                return _dh;
            }
        }
        //======================================================

        
        //                                         ========[HELPER FUNCTIONS]=========
        #region
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
            return dt;
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
            string q = "UPDATE " + tableName + " SET " + primaryKeyName + " = " + primaryKeyValue + ", lastModified = NOW(), userID = '" + userID + "'";

            return runNonQuery(q);
        }

        public int getLatestID(string tableName, string primaryKeyName)
        {
            MySqlCommand msq = new MySqlCommand();
            string q = "SELECT MAX(" + primaryKeyName + ") FROM " + tableName;

            DataTable dt = runQuery(q);

            if (dt.Rows.Count == 0)
                return -1;
            return int.Parse(dt.Rows[0][0].ToString());
        }

        public bool idExists(string tableName, string primaryKeyName, int primaryKeyValue)
        {
            string q = "SELECT * FROM " + tableName + " WHERE " + primaryKeyName + " = " + primaryKeyValue;

            DataTable dt = runQuery(q);

            return dt.Rows.Count > 0;
        }




        public DateTime toDateTime(string s, bool timePortion)
        {
          
                string[] components = s.Split(' ');
                string[] date = components[0].Split('/');

                int month = int.Parse(date[0]);
                int day = int.Parse(date[1]);
                int year = int.Parse(date[2]);



                if (timePortion)
                {
                    string[] time = components[1].Split(':');

                    int hour = int.Parse(time[0]) % 12;
                    if (components[components.Length - 1] == "PM")
                        hour += 12;

                    int min = int.Parse(time[1]);
                    int sec = int.Parse(time[2]);

                    return new DateTime(year, month, day, hour, min, sec);
                }
          
                return new DateTime(year, month, day);
            
          

        }

        #endregion
        /*
                                         =============================================================
                                               ================ GENERAL PROFILE =================
                                         =============================================================
        */
        #region
        //ADD

        public bool addGeneralProfile(string firstName, string midName, string lastName, string suffix, Gender gender, DateTime birthDate)
        {
            if (generalProfileExists(firstName, midName, lastName, suffix, gender, birthDate))
                throw new Exception("DataHandler: Duplicate in GeneralProfile");

            string q = "INSERT INTO GeneralProfile(firstName, midName, lastName, suffix, gender, birthDate) VALUES ('"
                + firstName + "', '" + midName + "', '" + lastName + "', '" + suffix + "', '" + (int)gender + "', '" + birthDate.ToString("yyyy-MM-dd") + "')";

            bool success = runNonQuery(q);

            return success;
        }

        //EDIT
        public bool editGeneralProfile(int profileID, string firstName, string midName, string lastName, string suffix, Gender gender, DateTime birthDate, string contactNumber, string address, string birthplace, string bloodtype)
        {
            if (!idExists("generalProfile", "profileID", profileID))
                return false;

            //addGeneralProfileLog(profileID);

            string q = "UPDATE GeneralProfile SET midName = '" + midName + "', lastName = '" + lastName
                + "', suffix = '" + suffix + "', gender = '" + (int)gender
                + "', birthDate = '" + birthDate.ToString("yyyy-MM-dd HH:mm:ss.fff")
                + "', contactNumber = '" + contactNumber + "', address = '" + address
                + "', birthplace = '" + birthplace + "',bloodType='" + bloodtype + "' WHERE profileID = '" + profileID + "'";
            Console.WriteLine(q);
            //updateModificationInfo("generalProfile", "profileID", profileID);

            bool success = runNonQuery(q);

            return success;
        }

        public bool editGeneralProfile(int profileID, string firstName, string midName, string lastName, string suffix, Gender gender, DateTime birthDate)
        {
            string q = "UPDATE GeneralProfile SET firstName = '" + firstName
                + "', midName = '" + midName + "', lastName = '" + lastName
                + "', suffix = '" + suffix + "', gender = '" + (int)gender
                + "', birthDate = '" + birthDate.ToString("yyyy-MM-dd")
                + "' WHERE profileID = '" + profileID + "'";

            bool success = runNonQuery(q);

            return success;
        }

        public bool editGeneralProfile(int profileID, string address, string birthplace)
        {
            string q = "UPDATE GeneralProfile SET address = '" + address
                + "', birthplace = '" + birthplace
                + "' WHERE profileID = '" + profileID + "'";

            bool success = runNonQuery(q);

            return success;
        }



        //DELETE
        public bool deleteGeneralProfile(int profileID)
        {
            if (!idExists("generalProfile", "profileID", profileID))
                return false;

            //addGeneralProfileLog(profileID);
            //updateModificationInfo("generalProfile", "profileID", profileID);
            //addGeneralProfileLog(profileID);

            string q = "DELETE FROM generalProfile WHERE profileID = " + profileID + ";";

            bool success = runNonQuery(q);

            return success;


        }


        public bool generalProfileExists(string firstName, string midName, string lastName, string suffix, Gender gender, DateTime birthDate)
        {
            string q = "SELECT COUNT(*) FROM generalProfile WHERE firstName = '" + firstName + "' AND midName = '" + midName + "' " +
                " AND lastName = '" + lastName + "' AND suffix = '" + suffix + "' AND gender = '" + (int)gender + "' AND DATE(birthDate) = '" + birthDate.ToString("yyyy-MM-dd") + "'";

            DataTable dt = runQuery(q);

            return int.Parse(dt.Rows[0][0].ToString()) > 0;
        }

        public bool generalProfileExists(int profileID, string firstName, string midName, string lastName, string suffix, Gender gender, DateTime birthDate)
        {
            string q = @"SELECT COUNT(*) FROM generalProfile 
                        WHERE firstName = @firstName AND midName = @midName 
                        AND lastName = @lastName AND gender = @gender AND birthDate = @birthDate 
                        AND profileID != @profileID";

            DataTable dt = ExecuteQuery(q, firstName, midName, lastName, suffix, (int)gender, birthDate.ToString("yyyy-MM-dd"));

            return int.Parse(dt.Rows[0][0].ToString()) > 0;

        }


        //Returns the profileID of an entry with fields matching the columns
        public int getGeneralProfileID(string firstName, string midName, string lastName, string suffix, Gender gender, DateTime birthDate)
        {
            string q = "SELECT profileID FROM generalProfile WHERE firstName = '" + firstName + "' AND midName = '" + midName + "' " +
                " AND lastName = '" + lastName + "' AND suffix = '" + suffix + "' AND gender = '" + (int)gender + "' AND DATE(birthDate) = '" + birthDate.ToString("yyyy-MM-dd") + "'";

            DataTable dt = runQuery(q);
            if (dt.Rows.Count == 0)
                return -1;
            else
                return int.Parse(dt.Rows[0][0].ToString());
        }


        public DataTable getGeneralProfile(int profileID)
        {
            string q = "SELECT *, firstName, midName, lastName, suffix, gender, DATE(birthdate), address, birthplace, contactNumber, bloodType FROM generalProfile WHERE profileID = " + profileID;

            DataTable dt = runQuery(q);

            if (dt.Rows.Count == 0)
                return null;
            return dt;
        }
        public DataTable getGeneralProfile(int profileID, int sacramentType)
        {
            string q = "select * from generalprofile inner join applicant on applicant.profileID=generalprofile.profileID inner join application on applicant.applicationID = application.applicationID where generalprofile.profileID=" + profileID + " and sacramentType=" + sacramentType;

            DataTable dt = runQuery(q);

            if (dt.Rows.Count == 0)
                return null;


            return dt;
        }

        public DataTable getGeneralProfiles()
        {
            string q = "SELECT *, CONCAT(firstname, ' ', midname, ' ' , lastname, ' ', COALESCE(suffix, '')) as Name FROM GeneralProfile";

            DataTable dt = runQuery(q);


            return dt;
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

        public double getTotalBalanceOf(int profileID)
        {

            string q = "SELECT IF(SUM(Item.Price * Item.Quantity) IS NULL, 0, SUM(Item.Price * Item.Quantity)) FROM Item JOIN Income ON item.incomeID = income.incomeID "
                + "JOIN GeneralProfile ON generalprofile.profileID = income.sourceID WHERE generalprofile.profileID = " + profileID;

            DataTable dt = runQuery(q);

            return double.Parse(dt.Rows[0][0].ToString());
        }

        /// <summary>
        /// Gets total price of Application and remarks
        /// </summary>
        /// <param name="applicationID"></param>
        /// <returns></returns>
        public double getApplicationPrice(int applicationID)
        {
            string q = "SELECT price, remarks FROM Application NATURAL JOIN SacramentIncome WHERE applicationID = " + applicationID;

            DataTable dt = runQuery(q);

            return double.Parse(dt.Rows[0].ToString());
        }

        /// <summary>
        /// Returns sacramentIncomeID, price, sacramentIncome.remarks, totalPayment
        /// </summary>
        /// <param name="applicationID"></param>
        /// <returns></returns>
        public DataTable getApplicationIncomeDetails(int applicationID)
        {
            string q = "SELECT sacramentIncome.sacramentIncomeID, price, sacramentincome.remarks, "
                + "COALESCE(SUM(amount),0) AS 'totalPayment' "
                + "FROM Application NATURAL JOIN SacramentIncome "
                + "LEFT JOIN Payment ON Payment.sacramentIncomeID = sacramentIncome.sacramentIncomeID"
                + " WHERE applicationID = " + applicationID;

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getGeneralProfilesByName(string firstName, string midName, string lastName)
        {
            string q = "SELECT * FROM GeneralProfile WHERE firstName LIKE '%" + firstName
                + "%' AND midName LIKE '%" + midName
                + "%' AND lastName LIKE '%" + lastName + "%'";

            DataTable dt = runQuery(q);

            return dt;
        }
        






        #endregion
        /*
                                         =============================================================
                                            ================ BLOOD DONOR TABLE=================
                                         =============================================================
        */
        #region

        //EDIT AND ADD have same processes
        public bool addBloodDonor(int profileID, string bloodType)
        {
            string q = "INSERT INTO BloodDonor(profileID, bloodType) VALUES ('" + profileID + "', '" + bloodType + "')";

            //updateModificationInfo("bloodDonorID", bloodDonor);

            return runNonQuery(q);
        }

        public bool editBloodDonor(int bloodDonorID, string bloodType)
        {
            string q = "UPDATE BloodDonor SET bloodType = '" + bloodType + "' WHERE bloodDonorID = '" + bloodDonorID + "'";

            //updateModificationInfo("bloodDonorID", bloodDonor);

            return runNonQuery(q);

        }

        public bool deleteBloodDonor(int bloodDonorID)
        {
            string q = "DELETE FROM bloodDonor WHERE bloodDonorID = " + bloodDonorID;

            return runNonQuery(q);
        }
        public DataTable getBloodDonor(int bloodDonorID)
        {
            string q = "SELECT firstName, midName, lastName, suffix, gender, bloodType, birthDate, contactNumber "
                + "FROM bloodDonor "
                + "JOIN generalProfile ON generalProfile.profileID = bloodDonor.profileID"
                + " WHERE bloodDonor.bloodDonorID = " + bloodDonorID;

            DataTable dt = runQuery(q);

            return dt;
        }




        #endregion

        /*
                                         =============================================================
                                            ================ BLOOD DONATION TABLE =================
                                         =============================================================
        */

        #region




        public bool deleteBloodDonation(int bloodDonationID)
        {
            if (!idExists("bloodDonation", "bloodDonationID", bloodDonationID))
                return false;

            //addBloodDonationLog(bloodDonationID); //ModInfo before deletion
            //updateModificationInfo("bloodDonation", "bloodDonationID", bloodDonationID);

            //addBloodDonationLog(bloodDonationID); //ModInfo after deletion

            string q = "DELETE FROM bloodDonation WHERE bloodDonationID = " + bloodDonationID;
            return runNonQuery(q);
        }


        //SPECIAL FUNCTION
        public int getTotalBloodDonationOf(int generalProfileID)
        {
            string q = "SELECT SUM(quantity) FROM BloodDonation WHERE profileID = " + generalProfileID;

            DataTable dt = runQuery(q);
            try
            {
                return int.Parse(dt.Rows[0][0].ToString());
            }
            catch
            {
                return 0;
            }
        }


        public bool addBloodDonationLog(int bloodDonationID)
        {
            string q = "INSERT INTO bloodDonationLog VALUES (SELECT * FROM bloodDonation WHERE bloodDonationID = " + bloodDonationID + ")";
            return runNonQuery(q);

        }
        public DataTable getBloodDonorsBetweenDates(DateTime start, DateTime end)
        {
            string q = "SELECT DISTINCT GeneralProfile.profileID, firstName, midName, lastName, suffix, gender, "
                + "DATE_FORMAT(birthdate, '%m-%d-%Y %H:%i'), contactNumber, address, birthplace, bloodType  "
                + "FROM GeneralProfile JOIN bloodDonation ON GeneralProfile.profileID = BloodDonation.profileID "
                + "WHERE bloodDonationDate BETWEEN '" + start.ToString("yyyy-MM-dd") + "' AND '" + end.ToString("yyyy-MM-dd") + "'";

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getBloodDonorsOfMonth(DateTime date)
        {
            string q = "SELECT DISTINCT GeneralProfile.profileID, firstName, midName, lastName, suffix, gender, "
                + "DATE_FORMAT(birthdate, '%m-%d-%Y %H:%i'), contactNumber, address, birthplace, bloodType  "
                + "FROM GeneralProfile JOIN bloodDonation ON GeneralProfile.profileID = BloodDonation.profileID "
                + "WHERE MONTH(bloodDonationDateTime) = '" + date.ToString("MM")
                + "' AND YEAR(bloodDonationDateTime) = '" + date.ToString("yyyy") + "'";

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getBloodDonationsOfEvent(string eventName)
        {
            string q = "SELECT GeneralProfile.profileID, firstName, midName, lastName, suffix,"
                + " gender, birthdate, bloodType, donationAmount "
                + " FROM GeneralProfile JOIN BloodDonation "
                + " ON GeneralProfile.profileID = BloodDonation.profileID"
                + " JOIN BloodDonationEvent ON BloodDonationEvent.bloodbloodDonationEventID = BloodDonation.bloodbloodDonationEventID"
                + " WHERE eventName = '%" + eventName + "%' ";

            DataTable dt = runQuery(q);

            return dt;
        }

        public int getTotalBloodDonationOfGeneralProfile(int profileID)
        {
            string q = "SELECT SUM(donationAmount) FROM BloodDonation WHERE profileID = " + profileID;

            DataTable dt = runQuery(q);

            return int.Parse(dt.Rows[0][0].ToString());
        }


        #endregion



        /*
                                         =============================================================
                                           ============== BLOOD DONATION EVENT TABLE ==============
                                         =============================================================
        */

        #region

        public bool addBloodDonationEvent(string eventName, DateTime startTime, DateTime endTime, string eventVenue, string eventDetails)
        {
            string q = $@"INSERT INTO `sad2`.`blooddonationevent` (`eventName`, `startDateTime`, `endDateTime`, `eventVenue`, `eventDetails`) VALUES ('{eventName}','{startTime.ToString("yyyy-MM-dd HH:mm:ss")}', '{endTime.ToString("yyyy-MM-dd HH:mm:ss")}','{eventVenue}','{eventDetails}');";
            bool success = runNonQuery(q);
            //if (success)
            //    updateModificationInfo("BloodDnationEvent", "bloodbloodDonationEventID", getLatestID("BloodDonationEvent", "bloodbloodDonationEventID"));

            return success;
        }

        public bool editBloodDonationEvent(int bloodDonationEventID, string eventName, DateTime startTime, DateTime endTime, string eventVenue, string eventDetails)
        {
            string q = "UPDATE BloodDonationEvent SET eventName = '" + eventName
                + "', startDateTime = '" + startTime.ToString("yyyy-MM-dd HH:mm:ss")
                + "', endDateTime = '" + endTime.ToString("yyyy-MM-dd HH:mm:ss")
                + "', eventVenue = '" + eventVenue + "', eventDetails = '" + eventDetails
                + "' WHERE bloodDonationEventID = " + bloodDonationEventID;

            bool success = runNonQuery(q);
            //if (success)
            //    updateModificationInfo("bloodDonationEvent", "bloodbloodDonationEventID", bloodbloodDonationEventID);

            return success;
        }

        public bool deleteBloodDonationEvent(int bloodDonationEventID)
        {

            //if (!idExists("bloodDonationEvent", "bloodbloodDonationEventID", bloodbloodDonationEventID))
            //    return false;

            //addBloodDonationLog(bloodDonationEventID);
            //updateModificationInfo("bloodDonationEvent", "bloodDonationEventID", bloodDonationEventID);
            //addBloodDonationLog(bloodDonationEventID);

            string q = "DELETE FROM bloodDonationEvent WHERE bloodDonationEventID = " + bloodDonationEventID;

            return runNonQuery(q);
        }

        public bool addBloodDonationEventLog(int bloodDonationEventID)
        {
            string q = "INSERT INTO bloodDonationEventLog VALUES (SELECT * FROM bloodDonationEvent "
                + "WHERE bloodDonationEventID = " + bloodDonationEventID + ")";

            return runNonQuery(q);
        }

        public DataTable getActiveBloodDonationEvents()
        {
            string q = "SELECT * FROM BloodDonationEvent WHERE eventStatus = 'active'";

            DataTable dt = runQuery(q);

            return dt;
        }

        #endregion

        /*
                                         =============================================================
                                                    ================ PARENT =================
                                         =============================================================
        */

        #region


        public bool addParent(int profileID, string firstName, string midName, string lastName, string suffix, Gender gender, string birthPlace = null)
        {
            string q = "INSERT INTO Parent(profileID, firstName, midName, lastName, suffix, gender, birthPlace) VALUES ('"
                + profileID + "', '" + firstName + "', '" + midName
                + "', '" + lastName + "', '" + suffix + "', '" + (int)gender
                + "', '" + birthPlace + "')";

            return runNonQuery(q);
        }

        public bool editParent(int parentID, string firstName, string midName, string lastName, string suffix, Gender gender, string birthPlace)
        {
            string q = "UPDATE Parent SET  firstName = '" + firstName
                + "',  midName = '" + midName + "',  lastName = '" + lastName
                + "',  suffix = '" + suffix + "' , gender = '" + (int)gender + "',  birthPlace = '" + birthPlace
                + "' WHERE parentID = '" + parentID + "' ";

            return runNonQuery(q);
        }

        public bool editParent(int parentID, string firstName, string midName, string lastName, string suffix, Gender gender)
        {
            string q = "UPDATE Parent SET  firstName = '" + firstName
                + "',  midName = '" + midName + "',  lastName = '" + lastName
                + "',  suffix = '" + suffix + "' , gender = '" + (int)gender
                + "' WHERE parentID = '" + parentID + "' ";

            return runNonQuery(q);
        }


        public bool addEditParent(int profileID, string PfirstName, string PmidName, string PlastName, string Psuffix, Gender Pgender, string PbirthPlace)
        {
            DataTable dt = getParentsOf(profileID);

            bool success = true;
            if (dt.Rows.Count == 0)
            {
                //add parents
                success &= addParent(profileID, PfirstName, PmidName, PlastName, Psuffix, Pgender, PbirthPlace);

            }
            else
            {
                //update parent
                int pID = int.Parse(dt.Rows[0][0].ToString());
                success &= editParent(pID, PfirstName, PmidName, PlastName, Psuffix, Pgender, PbirthPlace);
            }

            return success;
        }

        public bool addEditParent(int profileID, string PfirstName, string PmidName, string PlastName, string Psuffix, Gender Pgender)
        {
            DataTable dt = getParentsOf(profileID);

            bool success = true;
            if (dt.Rows.Count == 0)
            {
                //add parents
                success &= addParent(profileID, PfirstName, PmidName, PlastName, Psuffix, Pgender);

            }
            else
            {
                //update parent
                int pID = int.Parse(dt.Rows[0][0].ToString());
                success &= editParent(pID, PfirstName, PmidName, PlastName, Psuffix, Pgender);
            }

            return success;
        }

        /// <summary>
        /// Gets the parents of a profile. Ordered by gender, thus, father is in index 0
        /// </summary>
        /// <param name="profileID"></param>
        /// <returns></returns>
        public DataTable getParentsOf(int profileID)
        {
            string q = "SELECT * FROM Parent WHERE profileID = '" + profileID + "' ORDER BY gender";

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getParentOf(int profileID, Gender g)
        {
            string q = "SELECT * FROM Parent WHERE profileID = '" + profileID + "' AND gender = " + (int)g;

            DataTable dt = runQuery(q);

            return dt;
        }
        public DataTable getParent(int parentID)
        {
            string q = "SELECT * FROM Parent WHERE parentID = " + parentID;

            DataTable dt = runQuery(q);

            if (dt.Rows.Count == 0)
                return null;

            return dt;
        }

        public bool isMaxParents(int profileID)
        {
            string q = "SELECT * FROM Parent WHERE profileID = " + profileID;

            DataTable dt = runQuery(q);

            return dt.Rows.Count == 2;
        }

        public int getParentID(string firstName, string midName, string lastName, string suffix, char gender, string birthPlace)
        {
            string q = "SELECT parentID from Parent WHERE firstName = '" + firstName
                + "' AND midName = '" + midName + "' AND lastName = '" + lastName
                + "' AND suffix = '" + suffix + "' AND  gender = '" + gender
                + "' AND birthPlace = '" + birthPlace + "'";

            DataTable dt = runQuery(q);

            if (dt.Rows.Count == 0)
                return -1;

            return int.Parse(dt.Rows[0][0].ToString());
        }


        public bool deleteParent(int parentID)
        {
            string q = "DELETE FROM Parent WHERE parentID = " + parentID;

            bool success = runNonQuery(q);

            return success;
        }




        #endregion
        /*
                                         =============================================================
                                                ================ INCOME TABLE =================
                                         =============================================================
        */
        #region

        /// <summary>
        /// Adds Sacrament Income for an Application. SacramentIncomeDateTime is set to the value of MySQL NOW()
        /// </summary>
        /// <param name="itemTypeID"></param>
        /// <param name="applicationID"></param>
        /// <param name="price"></param>
        /// <param name="remarks"></param>
        /// <returns></returns>
        public bool addSacramentIncome(int applicationID, int itemTypeID, double price, string remarks)
        {
            string q = "INSERT INTO SacramentIncome(itemTypeID, applicationID, price, remarks, sacramentIncomeDateTime) VALUES ('"
                + itemTypeID + "', '" + applicationID + "', '" + price + "', '" + remarks + "', NOW())";

            bool success = runNonQuery(q);

            return success;
        }
        public bool addPayment(int sacramentIncomeID, int primaryIncomeID, decimal amount)
        {
            string q = $"INSERT INTO `sad2`.`payment` (`sacramentIncomeID`, `primaryIncomeID`, `amount`) VALUES ({sacramentIncomeID}, {primaryIncomeID}, {amount})";
            bool success = runNonQuery(q);
            return success;
        }
        public DataTable getSacramentIncomeOfID(int sacramentIncomeID)
        {
            string q = "SELECT * FROM SacramentIncome WHERE sacramentIncomeID = " + sacramentIncomeID;

        
            DataTable dt = runQuery(q);

            return dt;
        }

        public int getSacramentIncomeID(int applicationID)
        {
           
            string q = "SELECT sacramentIncomeID FROM SacramentIncome WHERE applicationID = " + applicationID;

            DataTable dt = runQuery(q);

            int id = int.Parse(dt.Rows[0]["sacramentIncomeID"].ToString());
            return id;
        }

        public DataTable getSacramentIncomesUnpaid()
        {
            throw new Exception();
            return new DataTable();
        }

        public bool addSacramentPayment(int sacramentIncomeID, double amount, int ORnum, string remarks, DateTime paymentDateTime)
        {

            bool success = addPrimaryIncome((int)BookType.Parish, ORnum, remarks);
            success &= addPayment(sacramentIncomeID, getLatestID("PrimaryIncome", "primaryIncomeID"), Convert.ToDecimal(amount));

            return success;
        }

        public double getTotalPaymentOfSacramentIncome(int sacramentIncomeID)
        {
            //AS sum
            string q = "SELECT COALESCE(SUM(amount), 0) AS sum FROM Payment WHERE sacramentIncomeID = " + sacramentIncomeID;

            DataTable dt = runQuery(q);

            //MessageBox.Show(dt.Rows[0]["sum"].ToString());
            double sum = double.Parse(dt.Rows[0]["sum"].ToString());
            return sum;
        }

        public double getBalanceOfSacramentIncome(int sacramentIncomeID)
        {
            DataTable dt = getSacramentIncomeOfID(sacramentIncomeID);
            double price = double.Parse(dt.Rows[0]["price"].ToString());
            double totalPayment = getTotalPaymentOfSacramentIncome(sacramentIncomeID); //chec
            return price - totalPayment;
        }




        public bool addIncome(int sourceID, string sourceType, string bookType, string remarks)
        {
            string q = "INSERT INTO Income(sourceID, sourceType, bookType, remarks, incomeDateTime) VALUES ('"
                + sourceID + "', '" + sourceType + "', '" + bookType + "', '"
                + remarks + "', NOW())";

            bool success = runNonQuery(q);
            //if(success)
            //    updateModificationInfo("income", "incomeID", getLatestID("income", "incomeID"));

            return success;
        }

        public bool editIncome(int incomeID, int sourceID, string sourceType, string bookType, string remarks)
        {


            string q = "UPDATE Income SET sourceID = '"
                + sourceID + "', sourceType = '" + sourceType + "', bookType = '" + bookType
                + "', remarks = '" + remarks
                + "' WHERE incomeID = '" + incomeID + "'";

            bool success = runNonQuery(q);
            //if (success)
            //    updateModificationInfo("income", "incomeID", incomeID);

            return success;
        }

        public bool addIncomeLog(int incomeID)
        {
            string q = "INSERT INTO incomeLog VALUES (SELECT * FROM income WHERE incomeID = '" + incomeID + "')";

            return runNonQuery(q);
        }

        public bool deleteIncome(int incomeID)
        {
            string q = "DELETE FROM income WHERE incomeID = " + incomeID;

            bool success = runNonQuery(q);
            return success;
        }


        public DataTable getIncomeBetweenDates(DateTime start, DateTime end)
        {
            string q = "SELECT * FROM income WHERE incomeDateTime => '" + start.ToString("yyyy-MM-dd")
                + "' AND incomeDateTime <= '" + end.ToString("yyyy-MM-dd") + "'";

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getIncomeOfMonth(DateTime date)
        {
            string q = "SELECT * FROM income WHERE MONTH(incomeDateTime) = '"
                + int.Parse(date.ToString("MM")) + "' AND YEAR(incomeDateTime) = '"
                + int.Parse(date.ToString("yyyy")) + "'";

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getIncome(int incomeID)
        {
            string q = "SELECT * FROM Income WHERE incomeID = " + incomeID;

            DataTable dt = runQuery(q);
            return dt;
        }

        public double getTotalPrice(int incomeID)
        {
            string q = "SELECT SUM(item.price * item.quantity) FROM Item JOIN Income ON Income.incomeID = Item.incomeID WHERE Income.incomeID = " + incomeID;

            DataTable dt = runQuery(q);

            return double.Parse(dt.Rows[0][0].ToString());
        }

        public double getTotalPayment(int incomeID)
        {
            string q = "SELECT SUM(amount) FROM SacramentIncome JOIN Payment ON SacramentIncome.SacramentIncomeID = Invoice.invoiceID WHERE Income.incomeID = " + incomeID;

            DataTable dt = runQuery(q);

            return double.Parse(dt.Rows[0][0].ToString());
        }

        public bool isPaid(int incomeID)
        {
            return getTotalPrice(incomeID) == getTotalPayment(incomeID);
        }

        public DataTable getInvoices(int incomeID)
        {
            string q = "SELECT * FROM Invoice WHERE incomeID = " + incomeID;

            DataTable dt = runQuery(q);

            return dt;

        }

        public int getNextOR(BookType type)
        {
            string q = "SELECT COALESCE(MAX(ORnum), 0) + 1 FROM PrimaryIncome WHERE bookType = " + (int) type;
            DataTable dt = runQuery(q);

            return int.Parse(dt.Rows[0][0].ToString());
        }

        public DataTable getPaymentHistory(int sacramentIncomeID)
        {
            string q = "SELECT Payment.amount, PrimaryIncome.ORnum, PrimaryIncome.remarks, primaryIncomeDateTime "
                + "FROM Payment NATURAL JOIN PrimaryIncome "
                + " JOIN SacramentIncome ON SacramentIncome.SacramentIncomeID = Payment.SacramentIncomeID "
                + " NATURAL JOIN Application"
                + " WHERE SacramentIncome.sacramentIncomeID = " + sacramentIncomeID;

            DataTable dt = runQuery(q);

            return dt;
        }


        #endregion
        /*
                                       =============================================================
                                                ================= ITEM TABLE =================
                                       =============================================================
      */

        public bool addItem(int itemType, int incomeID, double price, int quantity)
        {
            string q = "INSERT INTO Item(itemType, incomeID, price, quantity) VALUES ('"
                + itemType + "', '" + incomeID + "', '" + price + "', '" + quantity + "')";

            bool success = runNonQuery(q);

            return success;
        }

        public bool editItem(int itemID, int itemType, int incomeID, double price, int quantity)
        {
            string q = "UPDATE Item SET itemType = '" + itemType
                + "', incomeID = '" + incomeID
                + "', price = '" + price
                + "', quantity = '" + quantity
                + "' WHERE itemID = '" + itemID + "'";

            bool success = runNonQuery(q);

            return success;
        }

        public bool deleteItem(int itemID)
        {
            string q = "DELETE FROM Income WHERE itemID = " + itemID;

            bool success = runNonQuery(q);

            return success;
        }

        public DataTable getItem(int itemID)
        {
            string q = "SELECT * FROM ItemType WHERE itemID = " + itemID;


            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getItem(string itemType)
        {
            string q = "SELECT * FROM ItemType WHERE itemType = '" + itemType + "'";

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getItemsOfIncomeFromItems(int ORnum,int bookType)
        {
            string q = $"select * from primaryincome inner  join item on primaryincome.primaryIncomeID = item.primaryIncomeID inner join itemtype on itemtype.itemTypeID = item.itemTypeID where ORnum={ORnum} and primaryincome.bookType={bookType};";

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getItemsOfIncomeFromSacramentIncome(int ORnum,int bookType)
        {
            string q = $"select * from primaryincome inner join payment on payment.primaryIncomeID=primaryincome.primaryIncomeID inner join sacramentincome on sacramentincome.sacramentIncomeID = payment.sacramentIncomeID inner join application on application.applicationID= sacramentincome.applicationID where ORnum ={ORnum} and primaryincome.bookType={bookType}";
            return runQuery(q);
        }

        /*
                                        =============================================================
                                           ================= ITEM TYPE TABLE =================
                                        =============================================================
       */

        public bool addItemType(string itemType, string bookType, double suggestedPrice, ItemTypeStatus status)
        {
            string q = "INSERT INTO ItemType(itemType, bookType, suggestedPrice, status) VALUES ('"
                + itemType + "', '" + bookType + "', '" + suggestedPrice + "', '" + (int)status + "')";

            bool success = runNonQuery(q);

            return success;
        }

        public bool editItemType(int itemTypeID, string itemType, string bookType, double suggestedPrice, ItemTypeStatus status)
        {
            string q = "UPDATE ItemType SET itemType = '" + itemType
                + "', bookType = '" + bookType
                + "', suggestedPrice = '" + suggestedPrice
                + "', status = '" + (int)status
                + "' WHERE itemTypeID = '" + itemTypeID + "'";

            bool success = runNonQuery(q);

            return success;
        }

        public bool deleteItemType(int itemTypeID)
        {
            string q = "DELETE FROM ItemType WHERE itemTypeID = " + itemTypeID;

            bool success = runNonQuery(q);

            return success;
        }

        public int getItemTypeID(string itemType, BookType bookType)
        {
            string q = "SELECT itemTypeID FROM ItemType WHERE itemType = '" + itemType + "' AND bookType = '" + (int)bookType + "'";

            DataTable dt = runQuery(q);


            if (dt.Rows.Count == 0)
                return -1;
            else if (dt.Rows.Count > 1)
                throw new DuplicateNameException("DUPLICATE NAME FOR ITEM TYPE in ItemType! btch");

            return int.Parse(dt.Rows[0][0].ToString());
        }

        public DataTable getItemType(int itemTypeID)
        {
            string q = "SELECT * FROM ItemType WHERE itemTypeID = " + itemTypeID;

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getItemTypesOfBook(BookType bookType)
        {
            string q = "SELECT * FROM ItemType WHERE bookType = '" + (int)bookType + "' AND status = " + ItemTypeStatus.Active;

            DataTable dt = runQuery(q);

            return dt;
        }

        public bool setItemTypeStatus(int itemTypeID, ItemTypeStatus status)
        {
            string q = "UPDATE ItemType SET status = '" + (int)status + "'";
            bool success = runNonQuery(q);

            return success;
        }



        /*
                                         =============================================================
                                             ================ APPLICANT TABLE =================
                                         =============================================================
        */

        /// <summary>
        /// Adds Applicant and Application for the Applicant
        /// </summary>
        /// <param name="profileID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool addNewApplicant(int profileID, SacramentType type)
        {
            addApplication(type);
            int applicationID = getLatestID("Application", "applicationID");
            bool success = addApplicant(profileID, applicationID);
            return success;
        }

        public bool addNewMarriageApplicants(int groomID, int brideID)
        {
            addApplication(SacramentType.Marriage);
            int applicationID = getLatestID("Application", "applicationID");
            bool success = true;
            success &= addApplicant(groomID, applicationID);
            success &= addApplicant(brideID, applicationID);

            return success;
        }

        public bool addApplicant(int profileID, int applicationID)
        {
            string q = "INSERT INTO Applicant(profileID, applicationID) VALUES (" + profileID + ", " + applicationID + ")";
            bool success = runNonQuery(q);

            return success;
        }

        public bool deleteApplicant(int applicantID)
        {
            string q = "DELETE FROM Applicant WHERE applicantID = " + applicantID;

            bool success = runNonQuery(q);

            return success;
        }

        /*
                                         =============================================================
                                             ================ APPLICATION TABLE =================
                                         =============================================================
        */



        public bool addApplication(SacramentType type)
        {
            string requirements = "";
            switch (type)
            {
                case SacramentType.Baptism:
                    requirements = "000000";
                    break;
                case SacramentType.Confirmation:
                    requirements = "000";
                    break;
                case SacramentType.Marriage:
                    requirements = "0000000";
                    break;
            }

            string q = "INSERT INTO Application(sacramentType, status, requirements) VALUES('"
                + ((int)type) + "', '" + (int)ApplicationStatus.Pending + "', '" + requirements + "')";

            bool success = runNonQuery(q);

            return success;
        }

        public bool addApplication(SacramentType type, ApplicationStatus status)
        {
            string q = "INSERT INTO Application(sacramentType, status) VALUES('" + ((int)type) + "', '" + ((int)status) + "')";

            bool success = runNonQuery(q);

            return success;
        }


        public bool editApplication(int applicationID, ApplicationStatus status, string requirements)
        {
            string q = "UPDATE Application SET status = '" + ((int)status) + "', requirements = '" + requirements + "' WHERE applicationID = '" + applicationID + "'";

            bool success = runNonQuery(q);

            return success;
        }

        public bool editApplication(int applicationID, ApplicationStatus status)
        {
            string q = "UPDATE Application SET status = '" + (int)status + "' WHERE applicationID = '" + applicationID + "'";

            bool success = runNonQuery(q);

            return success;
        }

        public bool editApplication(int applicationID, string requirements)
        {
            string q = "UPDATE Application SET requirements = '" + requirements + "' WHERE applicationID = '" + applicationID + "'";

            bool success = runNonQuery(q);

            return success;
        }

        public string getApplicationStatus(int applicationID)
        {
            string q = "SELECT status FROM Application WHERE applicationID = '" + applicationID + "'";

            DataTable dt = runQuery(q);

            return dt.Rows[0][0].ToString();
        }

        public DataTable getBaptismApplications(ApplicationStatus s = ApplicationStatus.Pending)
        {
            string q = "SELECT lastName, firstName, midName, suffix, gender, birthdate FROM GeneralProfile"
                + " JOIN Applicant ON  GeneralProfile.profileID = Applicant.profileID "
                + " JOIN Application ON Application.applicationID = Applicant.applicationID"
                + " WHERE Application.sacramentType = " + (int)SacramentType.Baptism
                + " AND Application.status = " + (int)s;

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getConfirmationApplications(ApplicationStatus s = ApplicationStatus.Pending)
        {
            string q = "SELECT lastName, firstName, midName, suffix, gender, birthdate FROM GeneralProfile"
                + " JOIN Applicant ON  GeneralProfile.profileID = Applicant.profileID "
                + " JOIN Application ON Application.applicationID = Applicant.applicationID"
                + " WHERE Application.sacramentType = " + SacramentType.Confirmation
                + " AND Application.status = " + s;

            DataTable dt = runQuery(q);

            return dt;
        }




        /*
                                         =============================================================
                                              ================ BAPTISM TABLE =================
                                         =============================================================
        */

        #region

        public bool isBaptized(int profileID)
        {
            string q = "SELECT COUNT(*) FROM Baptism   WHERE profileID = " + profileID;
            DataTable dt = runQuery(q);

            return int.Parse(dt.Rows[0][0].ToString()) > 0;
        }

        public bool addBaptism(int applicationID, int ministerID, Legitimacy legitimacy, DateTime baptismDate, string remarks)
        {
            string q = "INSERT INTO Baptism(applicationID, ministerID, legitimacy, baptismDate, remarks) VALUES ('"
                + applicationID + "', '" + ministerID + "', '"
                + (int)legitimacy + "', '" + baptismDate.ToString("yyyy-MM-dd") + "', '" + remarks + "')";

            bool success = runNonQuery(q);

            //if (success)
            //    updateModificationInfo("baptism", "baptismID", getLatestID("baptism", "baptismID"));

            return success;
        }


        public bool editBaptism(int baptismID, int ministerID, string legitimacy, DateTime baptismDate)
        {
            //if (!idExists("baptism", "baptismID", baptismID))
            //    return false;

            string q = "UPDATE Baptism SET ministerID = '" + ministerID
                + "', legitimacy = '" + legitimacy
                + "', baptismDate = '" + baptismDate.ToString("yyyy-MM-dd")
                + "' WHERE baptismID = '" + baptismID + "'";

            bool success = runNonQuery(q);

            //if (success)
            //    updateModificationInfo("baptism", "baptismID", baptismID);

            return success;

        }

        public bool deleteBaptism(int baptismID)
        {
            //if (!idExists("Baptism", "baptismID", baptismID))
            //    return false;

            //addBaptismLog(baptismID);
            //updateModificationInfo("Baptism", "baptismID", baptismID);
            //addBaptismLog(baptismID);

            string q = "DELETE FROM Baptism WHERE baptismID = " + baptismID;

            bool success = runNonQuery(q);

            return success;
        }

        public DataTable getBaptism(int applicationID)
        {
            string q = "SELECT * FROM Baptism WHERE applicationID = " + applicationID;

            DataTable dt = runQuery(q);

            //if (dt.Rows.Count == 0)
            //    return null;

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

        //addReference is same as editReference!!!!!!!!!
        public bool addBaptismReference(int baptismID, string registryNumber, string recordNumber, string pageNumber)
        {
            string q = "UPDATE Baptism SET registryNumber = '" + registryNumber
                + "', recordNumber = '" + recordNumber
                + "', pageNumber = '" + pageNumber
                + "' WHERE baptismID = '" + baptismID + "'";

            bool success = runNonQuery(q);

            return success;
        }

        public bool editBaptismReference(int baptismID, string registryNumber, string recordNumber, string pageNumber)
        {
            //if (!idExists("baptism", "baptismID", baptismID))
            //    return false;

            //addBaptismLog(baptismID);

            bool success = addBaptismReference(baptismID, registryNumber, recordNumber, pageNumber);


            //if (success)
            //    updateModificationInfo("baptism", "baptismID", baptismID);

            return success;
        }

        public DataTable getBaptisms()
        {
            string q = "SELECT profileID, applicationID, baptismID, firstName, midname, lastName, suffix, baptismDate, registryNumber, pageNumber, recordNumber  "
                +"FROM Baptism NATURAL JOIN Application NATURAL JOIN Applicant NATURAL JOIN GeneralProfile";

            
            DataTable dt = runQuery(q);

            return dt;
        }


        public DataTable getBaptismsByYear(int year)
        {
            string q = "SELECT profileID, CONCAT(firstname, ' ', midname, ' ' , lastname, ' ', suffix),"
                + " gender, birthdate FROM Baptism WHERE YEAR(baptismDate) = " + year;

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getBaptismsByMonth(DateTime date)
        {
            string q = "SELECT profileID, CONCAT(firstname, ' ', midname, ' ' , lastname, ' ', suffix),"
                + " gender, birthdate FROM Baptism"
                + " WHERE YEAR(baptismDate) = '" + date.ToString("yyyy")
                + "' AND MONTH(baptismDate) = '" + date.ToString("MM") + "'";

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getBaptismsByName(string firstName, string midName, string lastName)
        {
            string q = "SELECT profileID, CONCAT(firstname, ' ', midname, ' ' , lastname, ' ', suffix),"
                + " gender, birthdate FROM Baptism WHERE firstName LIKE '%" + firstName
                + "%' AND midName LIKE '%" + midName + "%' AND lastName LIKE '%" + lastName + "%'";

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getBaptismsWithNoReference()
        {
            string q = "SELECT profileID, CONCAT(firstname, ' ', midname, ' ' , lastname, ' ', suffix),"
                + " gender, birthdate, remarks FROM Baptism"
                + " JOIN Application ON applicationID = applicationID"
                + " JOIN GeneralProfile ON generalProfile.profileID = Application.profileID "
                + " WHERE registryNumber IS NULL AND recordNumber IS NULL AND pageNumber IS NULL "
                + " AND sacramentType = 'bap'";

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getBaptismsWithReference()
        {
            string q = "SELECT profileID, CONCAT(firstname, ' ', midname, ' ' , lastname, ' ', suffix),"
                + " gender, birthdate, remarks FROM Baptism"
                + " JOIN Application ON applicationID = applicationID"
                + " JOIN GeneralProfile ON generalProfile.profileID = Application.profileID "
                + " WHERE registryNumber IS NOT NULL AND recordNumber IS NOT NULL AND pageNumber IS NOT NULL"
                + " AND sacramentType = 'b'";

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getBaptismOf(int profileID)//COMMENT: ambiguous profile id
        {
            string q = " SELECT *,concat(generalprofile.firstName,\" \",generalprofile.midName,\" \",generalprofile.lastName,\" \",generalprofile.suffix,\" \") as profile , " +
                        " concat(minister.firstName, \" \", minister.midName, \" \", minister.lastName, \" \", minister.suffix, \" \") as minister," +
                         " generalprofile.firstname as fng," +
                         " generalprofile.midname as mng," +
                         " generalprofile.lastName as lng," +
                         " generalprofile.suffix as sg," +
                         " generalprofile.birthdate as bdg," +
                         " generalprofile.gender as gg," +
                         " minister.firstname as fnm," +
                         " minister.midname as mnm," +
                         " minister.lastname as lnm," +
                         " minister.suffix as sm" +
                         " FROM generalprofile left outer join applicant on applicant.profileID = generalprofile.profileID" +
                         " left outer join application on applicant.applicationID = application.applicationID" +
                         " left outer join baptism on baptism.applicationID = application.applicationID" +
                         " left outer join minister on minister.ministerID = baptism.ministerID" +
                         " WHERE sacramentType=1 and generalprofile.profileID =" + profileID;

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
        public bool addConfirmation(int applicationID, int ministerID, DateTime confirmationDate, string remarks)
        {
            string q = "INSERT INTO Confirmation(applicationID, ministerID, confirmationDate, remarks) VALUES ('"
                + applicationID + "', '" + ministerID + "', '"
                + confirmationDate.ToString("yyyy-MM-dd")
                + "', '" + remarks + "')";


            bool success = runNonQuery(q);

            //if (success)
            //    updateModificationInfo("confirmation", "confirmationID", getLatestID("confirmation", "confirmationID"));

            return success;
        }

        public bool editConfirmation(int confirmationID, int ministerID, DateTime confirmationDate)
        {
            //if (!idExists("Confirmation", "confirmationID", confirmationID))
            //    return false;

            //addConfirmationLog(confirmationID);


            string q = "UPDATE Confirmation SET ministerID = '"
                + ministerID + "', confirmationDate = '" + confirmationDate.ToString("yyyy-MM-dd")
                + "' WHERE confirmationID = '" + confirmationID + "'";

            bool success = runNonQuery(q);

            //if(success)
            //    updateModificationInfo("Confirmation", "confirmationID", confirmationID);

            return success;
        }


        public bool deleteConfirmation(int confirmationID)
        {
            string q = "DELETE FROM Confirmation WHERE confirmationID = " + confirmationID;

            bool success = runNonQuery(q);

            return success;
        }

        public bool addConfirmationReference(int confirmationID, string registryNumber, string pageNumber, string recordNumber)
        {
            string q = "UPDATE Confirmation SET registryNumber = '" + registryNumber
                + "', pageNumber = '" + pageNumber
                + "', recordNumber = '" + recordNumber
                + "' WHERE confirmationID = '" + confirmationID + "'";

            bool success = runNonQuery(q);

            return success;
        }

        public bool editConfirmationReference(int confirmationID, string recordNumber, string pageNumber, string registryNumber)
        {
            //if (!idExists("Confirmation", "confirmationID", confirmationID))
            //    return false;

            //addConfirmationLog(confirmationID);



            bool success = addConfirmationReference(confirmationID, recordNumber, pageNumber, registryNumber);

            //if (success)
            //    updateModificationInfo("Confirmation", "confirmationID", confirmationID);

            return success;

        }

        public bool addConfirmationLog(int confirmationID)
        {
            if (!idExists("Confirmation", "confirmationID", confirmationID))
                return false;

            string q = "INSERT INTO ConfirmationLog VALUES ( SELECT * FROM Confirmation WHERE confirmationID = " + confirmationID + ")";

            return runNonQuery(q);
        }


        public DataTable getConfirmation(int applicationID)
        {
            string q = "SELECT * FROM Confirmation WHERE applicationID = " + applicationID;

            DataTable dt = runQuery(q);

            //if (dt.Rows.Count == 0)
            //    return null;

            return dt;
        }

        public DataTable getConfirmationBetweenDates(DateTime start, DateTime end)
        {
            string q = "SELECT profileID, confirmationID, CONCAT(firstname, ' ', midname, ' ' , lastname, ' ', suffix) AS Name,"
                + " gender, birthdate, registryNumber, pageNumber, recordNumber, DATE_FORMAT(confirmationDate, '%m-%d-%Y %H:%i') FROM Confirmation "
                + "JOIN Application ON Confirmation.applicationID = Application.applicationID "
                + "JOIN GeneralProfile ON GeneralProfile.profileID = Application.profileID "
                + " WHERE confirmationDate >= '"
                + start.ToString("yyyy-MM-dd") + "' AND confirmationDate <= '" + end.ToString("yyyy-MM-dd") + "'";

            DataTable dt = runQuery(q);

            //if (dt.Rows.Count == 0)
            //    return null;

            return dt;
        }


        public DataTable getConfirmations()
        {
            string q = "SELECT profileID, applicationID, confirmationID, firstName, midname, lastName, suffix, baptismDate, registryNumber, pageNumber, recordNumber  "
                + "FROM Confirmation NATURAL JOIN Application NATURAL JOIN Applicant NATURAL JOIN GeneralProfile";

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getConfirmationsByYear(DateTime date)
        {
            string q = "SELECT profileID, confirmationID, CONCAT(firstname, ' ', midname, ' ' , lastname, ' ', suffix) AS Name,"
                + " gender, birthdate, registryNumber, pageNumber, recordNumber, DATE_FORMAT(confirmationDate, '%m-%d-%Y %H:%i') FROM Confirmation "
                + "JOIN Application ON Confirmation.applicationID = Application.applicationID "
                + "JOIN GeneralProfile ON GeneralProfile.profileID = Application.profileID "
                + "WHERE YEAR(confirmationDate) = '" + date.ToString("yyyy") + "'";

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getConfirmationByMonth(DateTime date)
        {
            string q = "SELECT profileID, confirmationID, CONCAT(firstname, ' ', midname, ' ' , lastname, ' ', suffix) AS Name,"
                + " gender, birthdate, registryNumber, pageNumber, recordNumber, DATE_FORMAT(confirmationDate, '%m-%d-%Y %H:%i') FROM Confirmation "
                + "JOIN Application ON Confirmation.applicationID = Application.applicationID "
                + "JOIN GeneralProfile ON GeneralProfile.profileID = Application.profileID "
                + " WHERE YEAR(confirmationDate) = '" + date.ToString("yyyy")
                + "' AND MONTH(confirmationDate) = '" + date.ToString("yyyy") + "'";

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getConfirmationByName(string firstName, string midName, string lastName, string suffix)
        {
            string q = "SELECT profileID, confirmationID, CONCAT(firstname, ' ', midname, ' ' , lastname, ' ', suffix) AS Name,"
                + " gender, birthdate, registryNumber, pageNumber, recordNumber, DATE_FORMAT(confirmationDate, '%m-%d-%Y %H:%i') FROM Confirmation "
                + "JOIN Application ON Confirmation.applicationID = Application.applicationID "
                + "JOIN GeneralProfile ON GeneralProfile.profileID = Application.profileID "
                + "WHERE firstName LIKE '%" + firstName
                + "%' AND midName LIKE '%" + midName + "%' AND lastName LIKE '%" + lastName + "%'";

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getConfirmationsWithNotReference()
        {
            string q = "SELECT profileID, confirmationID, CONCAT(firstname, ' ', midname, ' ' , lastname, ' ', suffix),"
                + " gender, birthdate, remarks FROM Confirmation"
                + " JOIN Application ON applicationID = applicationID"
                + " JOIN GeneralProfile ON generalProfile.profileID = Application.profileID "
                + " WHERE registryNumber IS NULL AND recordNumber IS NULL AND pageNumber IS NULL "
                + " AND sacramentType = 'con'";

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getConfirmationWithReference()
        {
            string q = "SELECT profileID, CONCAT(firstname, ' ', midname, ' ' , lastname, ' ', suffix),"
                + " gender, birthdate, remarks FROM Confirmation"
                + " JOIN Application ON applicationID = applicationID"
                + " JOIN GeneralProfile ON generalProfile.profileID = Application.profileID "
                + " WHERE registryNumber IS NOT NULL AND recordNumber IS NOT NULL AND pageNumber IS NOT NULL"
                + " AND sacramentType = 'con'";

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getConfirmationOf(int profileID)
        {
            string q = " SELECT *,concat(generalprofile.firstName,\" \",generalprofile.midName,\" \",generalprofile.lastName,\" \",generalprofile.suffix,\" \") as profile , " +
                        "concat(minister.firstName, \" \", minister.midName, \" \", minister.lastName, \" \", minister.suffix, \" \") as minister, " +
                       " generalprofile.firstname as fng, " +
                       " generalprofile.midname as mng, " +
                       " generalprofile.lastName as lng, " +
                       " generalprofile.suffix as sg,  " +
                       " generalprofile.birthdate as bdg," +
                       " generalprofile.gender as gg," +
                       " minister.firstname as fnm, " +
                       " minister.midname as mnm, " +
                       " minister.lastname as lnm, " +
                       " minister.suffix as sm " +
                       " FROM generalprofile left outer join applicant on applicant.profileID = generalprofile.profileID " +
                       " left outer join application on applicant.applicationID = application.applicationID " +
                       " left outer join confirmation on confirmation.applicationID = application.applicationID " +
                       " left outer join minister on minister.ministerID = confirmation.ministerID WHERE sacramentType=2 and generalprofile.profileID =" + profileID;

            DataTable dt = runQuery(q);

            return dt;
        }











        #endregion
        /*
                                         =============================================================
                                             =================== MARRIAGE TABLE =================
                                         =============================================================
        */
        #region

        public bool addMarriage(int applicationID, int ministerID, DateTime licenseDate, DateTime marriageDate, MarriageStatus status)
        {
            string q = "INSERT INTO Marriage(applicationID, ministerID, licenseDate, marriageDate, status) VALUES (@applicationID, @ministerID, @licenseDate, @marriageDate, @status)";
            bool success = ExecuteNonQuery(q, applicationID, ministerID, licenseDate.ToString("yyyy-MM-dd HH:mm:ss"), marriageDate.ToString("yyyy-MM-dd HH:mm:ss"), status);
            
            return success;
        }

        public bool addMarriage(int applicationID, int ministerID, DateTime licenseDate, DateTime marriageDate, CivilStatus groomCivilStatus, CivilStatus brideCivilStatus)
        {
            string q = "INSERT INTO Marriage(applicationID, ministerID, licenseDate, marriageDate, groomCivilStatus, brideCivilStatus) VALUES (@applicationID, @ministerID, @licenseDate, @marriageDate, @groomCivilStatus, @brideCivilStatus)";
            bool success = ExecuteNonQuery(q, applicationID, ministerID, licenseDate.ToString("yyyy-MM-dd"), marriageDate.ToString("yyyy-MM-dd"), (int)groomCivilStatus, (int)brideCivilStatus);

            return success;
        }

        public bool editMarriage(int marriageID, int groomID, int brideID, int ministerID, DateTime licenseDate, DateTime marriageDate, MarriageStatus status)
        {
            string q = "INSERT INTO Marriage(marriageID, groomID, brideID, ministerID, licenseDate, marriageDate, status) VALUES "
                +"(@marriageID, @groomID, @brideID, @ministerID, @licenseDate, @marriageDate, @status)";
            bool success = ExecuteNonQuery(q, marriageID, groomID, brideID, ministerID, licenseDate.ToString("yyyy-MM-dd HH:mm:ss"), marriageDate.ToString("yyyy-MM-dd HH:mm:ss"), status);
            return success;
        }

        public bool deleteMarriage(int marriageID)
        {
            string q = "DELETE FROM Marriage WHERE marriageID = " + marriageID;

            bool success = runNonQuery(q);

            return success;
        }

        public bool addMarriageReference(int marriageID, string registryNumber, string pageNumber, string recordNumber)
        {
            string q = "UPDATE Marriage SET recordNumber = '" + recordNumber
                + "', pageNumber = '" + pageNumber + "', registryNumber = '" + registryNumber
                + "' WHERE marriageID = '" + marriageID + "'";

            bool success = runNonQuery(q);

            //if (success)
            //    updateModificationInfo("marriage", "marriageID", marriageID);

            return success;
        }

        public bool editMarriageReference(int marriageID, string recordNumber, string pageNumber, string registryNumber)
        {
            //if (!idExists("Marriage", "marriageID", marriageID))
            //    return false;

            return addMarriageReference(marriageID, recordNumber, pageNumber, registryNumber);

        }

        public DataTable getMarriage(int applicationID)
        {
            string q = "SELECT *,concat(firstName,\" \",midname,\" \",lastname,\"\",suffix)as ministerName  FROM Marriage inner join minister on marriage.ministerID=minister.ministerID where  applicationID =" + applicationID;
            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getMarriageBetweenDates(DateTime start, DateTime end)
        {
            string q = "SELECT * FROM Marriage WHERE marriageDate >= '"
                + start.ToString("yyyy-MM-dd") + "' AND marriageDate <= '" + end.ToString("yyyy-MM-dd") + "'";

            DataTable dt = runQuery(q);

            if (dt.Rows.Count == 0)
                return null;

            return dt;
        }

        public bool marriageIsActive(int marriageID)
        {
            string q = "SELECT status FROM Marriage WHERE marriageID = " + marriageID;

            DataTable dt = runQuery(q);

            return dt.Rows[0][0].ToString() == "active";
        }

        public DataTable getMarriagesByYear(DateTime date)
        {
            string q = "SELECT Marriage.profileID, marriageID, CONCAT(firstname, ' ', midname, ' ' , lastname, ' ', suffix) AS Name,"
                + " gender, birthdate, registryNumber, pageNumber, recordNumber, DATE_FORMAT(marriageDate, '%m-%d-%Y %H:%i') FROM Marriage "
                + "JOIN Application ON Marriage.applicationID = Application.applicationID "
                + "JOIN GeneralProfile ON GeneralProfile.profileID = Application.profileID "
                + "WHERE YEAR(marriageDate) = '" + date.ToString("yyyy") + "'";

            Console.WriteLine(q);
            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getMarriagesByMonth(DateTime date)
        {
            string q = "SELECT profileID, marriageID, CONCAT(firstname, ' ', midname, ' ' , lastname, ' ', suffix),"
                + " gender, birthdate FROM Marriage"
                + " WHERE YEAR(marriageDate) = '" + date.ToString("yyyy")
                + "' AND MONTH(marriageDate) = '" + date.ToString("MM") + "'";

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getMarriagesByName(string firstName, string midName, string lastName)
        {
            string q = "SELECT profileID, marriageID, CONCAT(firstname, ' ', midname, ' ' , lastname, ' ', suffix),"
                + " gender, birthdate FROM Marriage JOIN GeneralProfile "
                + " ON (generalProfile.profileID = Marriage.groomID) "
                + " OR (generalProfile.profileID = Marriage.brideID) "
                + " WHERE firstName LIKE '%" + firstName
                + "%' AND midName LIKE '%" + midName + "%' AND lastName LIKE '%" + lastName + "%'";

            DataTable dt = runQuery(q);

            return dt;
        }

        

        

        public DataTable getMarriagesWithNoReference()
        {
            return new DataTable();
        }





        #endregion
        /*
                                         =============================================================
                                            ================= MINISTER TABLE =================
                                         =============================================================
        */
        #region

        public bool addMinister(string firstName, string midName, string lastName, string suffix, DateTime birthDate, MinistryType ministryType, MinisterStatus status, string licenseNumber, DateTime expirationDate)
        {
            string q = "INSERT INTO Minister(firstName, midName, lastName, suffix, birthDate, ministryType, status, licenseNumber, expirationDate) VALUES ('"
                + firstName + "', '" + midName + "', '"
                + lastName + "', '" + suffix + "', '"
                + birthDate.ToString("yyyy-MM-dd") + "', '"
                + (int)ministryType + "', '" + (int)status + "', '"
                + licenseNumber + "', '"
                + expirationDate.ToString("yyyy-MM-dd") + "')";

            bool success = runNonQuery(q);

            //if (success)
            //    updateModificationInfo("Minister", "ministerID", getLatestID("Minister", "ministerID"));

            return success;
        }

        public bool editMinister(int ministerID, string firstName, string midName, string lastName, string suffix, DateTime birthDate, string ministryType, string status, string licenseNumber, DateTime expirationDate)
        {
            if (!idExists("Minister", "ministerID", ministerID))
                return false;

            //No need addMinisterLog

            string q = "UPDATE Minister SET firstName = '" + firstName
                + "', midName = '" + midName + "', lastName = '" + lastName
                + "', suffix = '" + suffix + "', birthDate = '" + birthDate
                + "', ministryType = '" + ministryType + "', status = '" + status
                + "', licenseNumber = '" + licenseNumber
                + "', expirationDate = '" + expirationDate
                + "' WHERE ministerID =" + ministerID;

            bool success = runNonQuery(q);

            //if (success)
            //    updateModificationInfo("Minister", "ministerID", ministerID);

            return success;


        }

        public int getMinisterID(string firstName, string midName, string lastName, string suffix, DateTime birthDate)
        {
            string q = "SELECT ministerID from Minister WHERE firstName = '"
                + firstName + "' AND midName = '" + midName + "' AND lastName = '" + lastName
                + "' AND suffix = '" + suffix + "' AND birthDate = '" + birthDate.ToString("yyyy-MM-dd") + "'";

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

            string q = "UPDATE Minister SET status = '" + status + "' WHERE ministerID = '" + ministerID + "'";

            bool success = runNonQuery(q);

            //if (success)
            //    updateModificationInfo("Minister", "ministerID", ministerID);

            return success;

        }


        #endregion


        /*
                                         =============================================================
                                            ================= SPONSOR TABLE =================
                                         =============================================================
        */
        #region



        public bool editSponsor(int sponsorID, string firstName, string midName, string lastName, string suffix, char sacramentType, string residence, char gender)
        {
            //if (!idExists("Sponsor", "sponsorID", sponsorID))
            //    return false;

            string q = "UPDATE Sponsor SET firstName = '"
                + firstName + "', midName = '" + midName
                + "', lastName = '" + lastName
                + "', suffix = '" + suffix
                + "', sacramentType = '" + sacramentType
                + "', residence = '" + residence
                + "', gender = '" + gender
                + "' WHERE sponsorID = '" + sponsorID + "'";

            bool success = runNonQuery(q);

            //if (success)
            //    updateModificationInfo("Sponsor", "sponsorID", sponsorID);

            return success;

        }

        public DataTable getSponsor(int sponsorID)
        {
            string q = "SELECT * FROM Sponsor WHERE sponsorID = " + sponsorID;

            DataTable dt = runQuery(q);

            //if (dt.Rows.Count == 0)
            //    return null;

            return dt;
        }

        //Gets sponsors of a sacrament
        public DataTable getSacramentSponsors(int sacramentID, char sacramentType)
        {
            string q = "SELECT * FROM Sponsor WHERE sacramentType = '"
                + sacramentType + "' AND sacramentID = '" + sacramentID + "'";

            DataTable dt = runQuery(q);

            //if (dt.Rows.Count == 0)
            //    return null;

            return dt;

        }
        #endregion



        /*
                                         =============================================================
                                            ================= SCHEDULE TABLE =================
                                         =============================================================
        */

        public bool addSchedule(string scheduleType, DateTime startTimeDate, DateTime endDateTime, string details, string priority)
        {
            string q = "INSERT INTO Schedule(scheduleType, startTimeDate, endDateTime, details, priority) VALUES ('"
                + scheduleType + "', '" + startTimeDate.ToString("yyyy-MM-dd HH:mm:ss.fff")
                + "', '" + endDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff")
                + "', '" + details + "', '" + priority + "')";

            bool success = runNonQuery(q);

            return success;
        }

        public bool editSchedule(int scheduleID, string scheduleType, DateTime startTimeDate, DateTime endDateTime, string details, string status, string priority)
        {
            string q = "UPDATE Schedule SET scheduleType = '" + scheduleType
                + "', startTimeDate = '" + startTimeDate.ToString("yyyy-MM-dd HH:mm:ss.fff")
                + "', endDateTime = '" + endDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff")
                + "', details = '" + details + "', status = '" + status
                + "', priority = '" + priority
                + "' WHERE scheduleID = '" + scheduleID + "'";

            bool success = runNonQuery(q);

            return success;
        }

        public DataTable getSchedule(int scheduleID)
        {
            string q = "SELECT * FROM Schedule WHERE scheduleID = " + scheduleID;

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getScheduleOfDay(DateTime day)
        {
            string q = "SELECT * FROM Schedule WHERE DAY(startDateTime) = DAY(" + day.ToString("yyyy-MM-dd") + ")";

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getScheduleOfToday()
        {
            string q = "SELECT * FROM Schedule WHERE DAY(startDateTime) = DAY(NOW())";

            DataTable dt = runQuery(q);

            return dt;
        }

        public int getLatestScheduleID()
        {
            int id = getLatestID("Schedule", "scheduleID");

            return id;
        }


        /*
                                         =============================================================
                                            ================= APPOINTMENT TABLE =================
                                         =============================================================
        */

        public bool addAppointment(int profileID, int ministerID, int scheduleID)
        {
            string q = "INSERT INTO Appointment(profileID, ministerID, scheduleID) VALUES ('"
                + profileID + "', '" + ministerID + "', '" + scheduleID + "')";

            bool success = runNonQuery(q);

            return success;
        }

        public bool editAppointment(int appointmentID, int ministerID, int scheduleID)
        {
            string q = "UPDATE Application SET ministerID = '" + ministerID
                + "', scheduleID = '" + scheduleID
                + "' WHERE appointmentID = '" + appointmentID + "'";

            bool success = runNonQuery(q);

            return success;
        }

        public bool setSchedule(int profileID, int ministerID, int scheduleID, string scheduleType, DateTime startDateTime, DateTime endDateTime, string details, string priority)
        {
            bool success = addSchedule(scheduleType, startDateTime, endDateTime, details, priority);

            bool success2 = addAppointment(profileID, ministerID, getLatestScheduleID());

            if (!(success && success2))
                throw new Exception("One of the Successes don't work. Btch");


            return true;
        }

        public DataTable getAppointment(int appointmentID)
        {
            string q = "SELECT GeneralProfile.firstName, GeneralProfile.midName, GeneralProfile.lastName, GeneralProfile.suffix, GeneralProfile.gender, "
                + " DATE_FORMAT(GeneralProfile.birthDate, '%m-%d-%Y'), "
                + " GeneralProfile.contactNumber, DATE_FORMAT(startTimeDate, '%m-%d-%Y'),"
                + " DATE_FORMAT(Schedule.endDateTime, '%m-%d-%Y'), "
                + " Schedule.details, Schedule.priority, Minister.firstName, Minister.midName, Minister.lastName, Minister.suffix "
                + " FROM GeneralProfile JOIN Appointment ON GeneralProfile.profileID = Appointment.profileID"
                + " JOIN Schedule ON Schedule.scheduleID = Appointment.appointmentID "
                + " WHERE appointmentID = " + appointmentID;

            DataTable dt = runQuery(q);

            return dt;

        }

        public bool appointmentHasConflict(DateTime start, DateTime end, int ministerID)
        {
            string q = "SELECT * FROM Schedule JOIN Appointment ON Appointment.scheduleID = Schedule.scheduleID "
                + "WHERE DATE_FORMAT(startDateTime, '%m-%d-%Y %H:%i') < '" + end.ToString("yyyy-MM-dd HH:mm")
                + "' AND DATE_FORMAT(endDateTime, '%m-%d-%Y %H:%i') > '" + start.ToString("yyyy - MM - dd HH:mm")
                + "' AND ministerID = '" + ministerID + "'";

            DataTable dt = runQuery(q);

            return dt.Rows.Count > 0;
        }



        /*
                                         =============================================================
                                            ================= USER TABLE =================
                                         =============================================================
        */

        public bool addUser(string username, string password, string userType, int active)
        {
            string q = "INSERT INTO User(username, password, userType, active) VALUES ('"
                + username + "', '" + password + "', '" + userType + "', '" + active + "')";

            bool success = runNonQuery(q);

            return success;


        }

        public bool addUser(string username, string password, string userType)
        {
            //SHOULD BE INSERT IGNORE User
            string q = "INSERT INTO User(username, password, userType) VALUES ('"
                + username + "', '" + password + "', '" + userType + "')";

            bool succcess = runNonQuery(q);

            return succcess;
        }

        public bool editUser(int userID, string password, string userType)
        {
            string q = "UPDATE User SET password = '" + password
                + "', userType = '" + userType
                + "' WHERE userID = '" + userID + "'";

            bool success = runNonQuery(q);

            return success;
        }

        public DataTable getUser(int userID)
        {
            string q = "SELECT * FROM User WHERE userID = " + userID;

            DataTable dt = runQuery(q);

            return dt;
        }

        /*
                                         =============================================================
                                            ================= REQUIREMENT TABLE =================
                                         =============================================================
        */

        public bool addRequirement(string requirementName, char sacramentType)
        {
            string q = "INSERT INTO Requirement(requirementName, sacramentType) VALUES ('" + requirementName + "', '" + sacramentType + "')";

            bool success = runNonQuery(q);

            return success;
        }

        public bool editRequirement(int requirementID, string requirementName, char sacramentType)
        {
            string q = "UPDATE Requirement SET requirementName = '" + requirementName
                + "', sacramentType = '" + sacramentType
                + "' WHERE requirementID = '" + requirementID + "'";

            bool success = runNonQuery(q);

            return success;
        }

        public DataTable getRequirementsFor(char sacramentType)
        {
            string q = "SELECT * FROM Requirement WHERE sacramentType = '" + sacramentType + "'";

            DataTable dt = runQuery(q);

            return dt;
        }

        /*
                                         =============================================================
                                            ================= CASH RELEASE TABLE =================
                                         =============================================================
        */
       

        public bool editCashRelease(int cashReleaseID, int cashReleaseTypeID, DateTime cashReleaseDateTime, string remark, double releaseAmount, int checkNum, int CVnum)
        {
            string q = "UPDATE CashRelease SET cashReleaseTypeID = '" + cashReleaseTypeID
                + "', cashReleaseDateTime = '" + cashReleaseDateTime.ToString("yyyy-MM-dd HH:mm:ss")
                + "', remark = '" + remark + "', releaseAmount = '" + releaseAmount
                + "', checkNum = '" + checkNum + "', CVnum = '" + CVnum
                + "' WHERE cashReleaseID = '" + cashReleaseID + "'";

            bool success = runNonQuery(q);

            return success;
        }

        public bool deleteCashRelease(int cashReleaseID)
        {
            string q = "DELETE FROM CashRelease WHERE cashReleaseID = " + cashReleaseID;

            bool success = runNonQuery(q);

            return success;
        }

        public DataTable getCashReleaseBetweenDates(DateTime start, DateTime end)
        {
            string q = "SELECT DATE_FORMAT(cashReleaseDateTime, '%m-%d-%Y %H:%i'),"
                + " remark, releaseAmount, description "
                + "FROM CashRelease "
                + "JOIN CashReleaseType "
                + "ON cashRelease.cashReleaseTypeID = cashReleaseType.cashReleaseTypeID "
                + "WHERE cashReleaseDateTime BETWEEN '" + start.ToString("yyyy-MM-dd")
                + "' AND '" + end.ToString("yyyy-MM-dd") + "'";

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getCashReleaseOfMonth(DateTime date)
        {
            string q = "SELECT DATE_FORMAT(cashReleaseDateTime, 'MM-dd-yyyy HH:mm:ss'), "
                + " remark, releaseAmount, description"
                + " FROM CashRelease WHERE MONTH(cashReleaseDateTime) = '"
                + int.Parse(date.ToString("MM")) + "' AND YEAR(cashReleaseDateTime) = '"
                + int.Parse(date.ToString("yyyy")) + "'";

            DataTable dt = runQuery(q);

            return dt;
        }



        /*
                                         =============================================================
                                            ================= CASH RELEASE TYPE TABLE =================
                                         =============================================================
        */

        public bool addCashReleaseType(string cashReleaseType, string description, int active)
        {
            string q = "INSERT INTO CashReleaseType(cashReleaseType, description, status) VALUES ('"
                + cashReleaseType + "', '" + description + "', '" + active + "')";

            bool success = runNonQuery(q);

            return success;
        }


        public bool addCashReleaseType(string cashReleaseType, string description)
        {
            string q = "INSERT INTO CashReleaseType(cashReleaseType, description) VALUES ('"
                + cashReleaseType + "', '" + description + "')";

            bool success = runNonQuery(q);

            return success;
        }


        public bool editCashReleaseType(int cashReleaseTypeID, string cashReleaseType, string description, int active)
        {
            string q = "UPDATE CashReleaseType SET cashReleaseType = '" + cashReleaseType
                + "', description = '" + description
                + "', active = '" + active
                + "' WHERE cashReleaseTypeID = '" + cashReleaseTypeID + "'";

            bool success = runNonQuery(q);

            return success;
        }

        public bool cashReleaseTypeIsActive(int cashReleaseTypeID)
        {
            string q = "SELECT * FROM CashReleaseType WHERE cashReleaseTypeID = " + cashReleaseTypeID + " AND active = 1";

            DataTable dt = runQuery(q);

            return dt.Rows.Count > 0;
        }

        public DataTable getCashReleaseTypes()
        {
            string q = "SELECT cashReleaseTypeID,cashReleaseType,description,case when booktype=1 then 'Parish' when booktype=2 then 'Community' when booktype=3 then 'Postulancy' end as booktype,case when status=1 then 'Active' when status=2 then 'Inactive' end as status FROM CashReleaseType ";

            DataTable dt = runQuery(q);

            return dt;
        }


        /*
                                         =============================================================
                                            ================= SACRAMENT INCOME TABLE =================
                                         =============================================================
        */



        //-------------functions i need-----------------------//


        public DataTable getMotherOf(int profileID)
        {
            string q = "SELECT *,concat(lastname,\" \",coalesce(suffix,\" \"),\"\",firstName,\" \",midname,\".\")as name FROM sad2.parent where gender =2 and profileID = " + profileID;

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getFatherOf(int profileID)
        {
            string q = "SELECT *,concat(lastname,\" \",coalesce(suffix,\" \"),\"\",firstName,\" \",midname,\".\")as name FROM sad2.parent where gender =1 and profileID = " + profileID;

            DataTable dt = runQuery(q);

            return dt;
        }

        /// <summary>
        /// Gets Application of a Profile with status Approved, Pending, or Final
        /// </summary>
        /// <param name="profileID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable getActiveApplicationOf(int profileID, SacramentType type)
        {
            string q = "SELECT * FROM GeneralProfile NATURAL JOIN Applicant NATURAl JOIN Application "
                +"WHERE profileID = '" + profileID 
                + "' AND status != '" + (int) ApplicationStatus.Revoked 
                + "' AND sacramentType = '" + (int) type + "'";
            DataTable dt = runQuery(q);

            return dt;
        }

        /// <summary>
        /// Checks if a Profile has a certain Application with status Approved, Pending, or Final
        /// </summary>
        /// <param name="profileID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool hasActiveApplication(int profileID, SacramentType type)
        {
            DataTable dt = getActiveApplicationOf(profileID, type);

            return dt.Rows.Count > 0;
        }

        public bool hasBaptismApplication(int profileID)
        {
            string q = "select * from generalprofile natural join applicant natural join application where (status != " + (int)ApplicationStatus.Revoked + ") AND sacramentType = 1 and generalprofile.profileID =" + profileID;
            
            DataTable dt = runQuery(q);

            return dt.Rows.Count > 0;
        }

        public bool hasConfirmationApplication(int profileID)
        {
            string q = "select * from generalprofile natural join applicant natural join application where (status != " + (int)ApplicationStatus.Revoked + ") AND sacramentType = 2 and generalprofile.profileID =" + profileID;

            DataTable dt = runQuery(q);

            return dt.Rows.Count > 0;
        }

        public bool hasMarriageApplication(int profileID)
        {
            string q = "select * from generalprofile natural join applicant natural join application where (Application.status != " + ApplicationStatus.Revoked + ") AND sacramentType = 3 and generalprofile.profileID = " + profileID;

            DataTable dt = runQuery(q);

            return dt.Rows.Count > 0;
        }

        public DataTable getMinisters()
        {
            string q = "SELECT ministerID, CONCAT(firstName, ' ', midName, ' ', lastName, ' ', suffix)as Name, birthdate, ministryType, status, licenseNumber, expirationDate FROM Minister";

            DataTable dt = runQuery(q);

            return dt;
        }
        public int getBaptismID(int profileID)
        {
            string q = "SELECT baptismID FROM Baptism "
                + " JOIN Application ON Baptism.applicationID = Application.applicationID"
                + " JOIN Applicant ON Applicant.applicantID = Application.applicantID "
                + " JOIN GeneralProfile ON GeneralProfile.profileID = Applicant.profileID"
                + " WHERE GeneralProfile.profileID = " + profileID;
            DataTable dt = runQuery(q);

            if (dt.Rows.Count == 0)
                return -1;

            return int.Parse(dt.Rows[0]["profileID"].ToString());

        }



        //COMMENT: merge names into field "Name"
        public DataTable getMinister(int ministerID)
        {
            string q = "SELECT *,CONCAT(firstName, ' ', midName, ' ', lastName, ' ', suffix) as name FROM Minister WHERE ministerID = " + ministerID;

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getMinisterWithStatus(MinisterStatus status)
        {
            string q = "SELECT ministerID, CONCAT(firstName, ' ', midName, ' ', lastName, ' ', suffix) as name FROM Minister WHERE status = " + (int)status;

            DataTable dt = runQuery(q);

            return dt;
        }

        public bool addBloodDonation(int profleID, int quantity, int bloodDonationEventID)
        {
            string q = "INSERT INTO BloodDonation(profileID, quantity, bloodDonationEventID) VALUES ('"
                + profleID + "', '" + quantity + "', '" + bloodDonationEventID + "')";

            bool success = runNonQuery(q);

            return success;
        }

        public bool editBloodDonation(int profleID, int quantity, int bloodDonationEventID)
        {
            //edit donation
            string q = "UPDATE BloodDonation SET quantity = '" + quantity
                + "', bloodDonationEventID = '" + bloodDonationEventID
                + "' WHERE blooddonationID = '" + profleID + "'";

            bool success = runNonQuery(q);
            return success;
        }

        public DataTable getBloodDonations(int profileID)
        {
            // add quantity here.. change db and add quantity in query


            string q = "select * from blooddonation inner join generalprofile on blooddonation.profileID = generalprofile.profileID inner join blooddonationevent on blooddonationevent.bloodDonationEventID = blooddonation.bloodDonationEventID where generalprofile.profileID = " + profileID;

            DataTable dt = runQuery(q);

            return dt;

        }
        public DataTable getBloodlettingEvents()
        {
            string q = "SELECT * FROM sad2.blooddonationevent;"; //where status is not finished

            DataTable dt = runQuery(q);

            return dt;
        }
        public DataTable getMarriageApplications(int profileID)
        {
            string q = "select * from generalprofile inner join applicant on applicant.profileID = generalprofile.profileID inner join application on application.applicationID = applicant.applicationID where sacramentType = 3 and generalprofile.profileID =" + profileID;
            DataTable dt = runQuery(q);

            return dt;
        }
        public DataTable getPartners(int applicationID, int profileID)//yung sino yung maraming asawa na profile ID
        {
            string q = "select *,concat(firstname,\" \",midName,\" \",lastName) as Name from generalprofile  inner join applicant on applicant.profileID = generalprofile.profileID  inner join application on application.applicationID = applicant.applicationID  where application.applicationID= " + applicationID + " and generalprofile.profileID!= " + profileID + "";

            DataTable dt = runQuery(q);

            return dt;
        }
        public DataTable getApplications(SacramentType type)
        {
            string q;
            if (type == SacramentType.Marriage)
            {
                q = "SELECT application.applicationID, a.profileID AS groomProfileID, b.profileID AS brideProfileID, requirements, "
                    + "CONCAT_WS(' ', a.firstName, a.midName, a.lastName, a.suffix) AS groomName, DATE_FORMAT(a.birthdate, '%Y-%m-%d') AS groomBirthDate, "
                    + "CONCAT_WS(' ', b.firstName, b.midName, b.lastName, b.suffix) AS brideName, DATE_FORMAT(b.birthdate, '%Y-%m-%d') AS brideBirthDate, "
                    + "application.status FROM GeneralProfile AS a "
                    + "JOIN Applicant AS aa ON aa.profileID = a.profileID "
                    + "JOIN(SELECT profileID, firstName, midName, lastName, suffix, birthdate FROM GeneralProfile) AS b "
                    + "JOIN Applicant AS bb ON bb.profileID = b.profileID "
                    + "JOIN Application ON(Application.applicationID = aa.applicationID AND Application.applicationID = bb.applicationID) "
                    + "WHERE sacramentType = " + (int)type + " AND a.profileID != b.profileID AND a.gender = 1";

            }
            else
            {
                q = "SELECT applicationID, profileID, requirements, firstName, midName, lastName, suffix,"
                    + " gender, DATE_FORMAT(birthdate,'%Y-%m-%d') AS birthDate, status "
                    + "FROM GeneralProfile"
                    + " NATURAL JOIN Applicant "
                    + "NATURAL JOIN Application "
                    + "WHERE sacramentType = " + (int)type;


            }

            DataTable dt = runQuery(q);
            return dt;

        }

        public DataTable getApplications(SacramentType type, ApplicationStatus status)
        {
            string q = "SELECT applicationID, profileID, firstName, midName, lastName, suffix,"
                + " gender, DATE_FORMAT(birthdate,'%m-%d-%Y'), sacramentType, status "
                + "FROM GeneralProfile"
                + " NATURAL JOIN Applicant "
                + "NATURAL JOIN Application "
                + "WHERE sacramentType = " + (int)type + " AND status = " + (int)status;

            DataTable dt = runQuery(q);
            return dt;
        }
        public bool addSponsor(int applicationID, string firstname, string midname, string lastname, string suffix, Gender gender, string residence)
        {
            string q = "INSERT INTO Sponsor(applicationID, firstname, midname, lastname, suffix, gender, residence) VALUES ('" + applicationID + "', '" + firstname + "', '" + midname + "', '" + lastname + "', '" + suffix + "', '" + (int)gender + "', '" + residence + "')";
            bool success = runNonQuery(q);

            return success;

        }
        public DataTable getSponsors(int applicationID)
        {
            string q = "select * from sponsor inner join application on application.applicationID = sponsor.applicationID where application.applicationID =" + applicationID + " order by gender";
            return runQuery(q);
        }
        public DataTable getApplicationsOf(int profileID)
        {
            string q = $@"select * from generalprofile inner join applicant on applicant.profileID=generalprofile.profileID inner join application on applicant.applicationID=application.applicationID where (status = {(int)ApplicationStatus.Final} or status = {(int)ApplicationStatus.Approved}) and generalProfile.profileID=" + profileID;
            return runQuery(q);
        }
      
        public void editFather(int profileID, string fn, string mi, string ln, string sf, string residence, string birthplace)
        {
            string q = "UPDATE `sad2`.`parent` SET `firstName`='" + fn + "', `midName`='" + mi + "', `lastName`='" + ln + "', `suffix`='" + sf + "', `birthplace`='" + birthplace + "', `residence`='" + residence + "' WHERE gender='1' and profileID=+" + profileID;
            runNonQuery(q);
        }
        public void editMother(int profileID, string fn, string mi, string ln, string sf, string residence, string birthplace)
        {
            string q = "UPDATE `sad2`.`parent` SET `firstName`='" + fn + "', `midName`='" + mi + "', `lastName`='" + ln + "', `suffix`='" + sf + "', `birthplace`='" + birthplace + "', `residence`='" + residence + "' WHERE gender='2' and profileID=+" + profileID;
            runNonQuery(q);
        }
        public DataTable getGodFatherOn(int applicationID)
        {
            string q = "select * ,concat(lastname,\" \",coalesce(suffix,\" \"),\"\",firstName,\" \",midname,\".\")as name  from sponsor inner join application on application.applicationID = sponsor.applicationID where gender=1 and application.applicationID =" + applicationID;
            return runQuery(q);
        }
        public DataTable getGodMotherOn(int applicationID)
        {
            string q = "select * ,concat(lastname,\" \",coalesce(suffix,\" \"),\"\",firstName,\" \",midname,\".\")as name  from sponsor inner join application on application.applicationID = sponsor.applicationID where gender=2 and application.applicationID =" + applicationID;
            return runQuery(q);
        }
        public DataTable getPartner(int profileID)
        {
            string q = "select * from (select application.applicationID from generalprofile inner join applicant on applicant.profileID = generalprofile.profileID inner join application on application.applicationID = applicant.applicationID where sacramentType = 3 and generalprofile.profileID = " + profileID + ") as A left outer join (select concat(lastname, \" \", coalesce(suffix, \" \"), \"\", firstName, \" \", midname, \".\") as name, generalprofile.profileID, address, contactNumber, gender, birthplace, birthdate, residence, application.applicationID from generalprofile inner join applicant on applicant.profileID = generalprofile.profileID inner join application on application.applicationID = applicant.applicationID where sacramentType = 3 and generalprofile.profileID != " + profileID + ") as B on A.applicationID = B.applicationID";
            return runQuery(q);
        }

        public int getNextProfileID()
        {
            string q = "SELECT max(profileID)+1 as max FROM sad2.generalprofile;";
            return int.Parse(runQuery(q).Rows[0]["max"].ToString());
        }
        public void editBloodDonor(int profileID, string fn, string mn, string ln, string sf, string add, string contact, int blood)
        {
            string q = "UPDATE `sad2`.`generalprofile` SET `firstName`='" + fn + "', `midName`='" + mn + "', `lastName`='" + ln + "', `suffix`='" + sf + "', `address`='" + add + "', `contactNumber`='" + contact + "',`bloodtype`='" + blood + "' WHERE `profileID`='" + profileID + "';";
            runNonQuery(q);
        }
        public void addBloodDonor(string fn, string mn, string ln, string sf, string add, string contact, int blood)
        {
            string q = "INSERT INTO `sad2`.`generalprofile` (`firstName`, `midName`, `lastName`, `suffix`, `address`, `contactNumber`, `bloodType`) VALUES ('" + fn + "', '" + mn + "', '" + ln + "', '" + sf + "', '" + add + "', '" + contact + "', '" + blood + "');";
            runNonQuery(q);
        }
        public DataTable getbloodlettingEvent(int EventID)
        {
            string q = "select * from blooddonationevent where bloodDonationEventID= " + EventID;
            return runQuery(q);
        }
        public int getMaxBloodEvent()
        {
            string q = " select max(bloodDonationEventID) from blooddonationevent";
            return int.Parse(runQuery(q).Rows[0][0].ToString());
        }
        public DataTable getCashRelease(int cashRelreaseID)
        {
            string q = "select * from cashreleasetype where cashReleaseTypeID =" + cashRelreaseID;
            return runQuery(q);
        }
        public void addCashReleaseType(string cashReleaseType, string description, bool active, int bookType)
        {
            int A;
            if (active) A = 1;
            else A = 2;
            string q = "INSERT INTO `sad2`.`cashreleasetype` (`cashReleaseType`, `description`, `status`, `bookType`) VALUES ('" + cashReleaseType + "', '" + description + "', '" + A + "','" + bookType + "')";
            runNonQuery(q);
        }
        public int getMaxCashReleaseType()
        {
            string q = " select max(cashReleaseTypeID) from cashreleasetype";
            return int.Parse(runQuery(q).Rows[0][0].ToString());
        }
        public void editCashReleaseType(int cashReleaseID, string cashReleaseType, string description, bool active, int bookType)
        {
            int A;
            if (active) A = 1;
            else A = 2;
            string q = "UPDATE `sad2`.`cashreleasetype` SET `cashReleaseType`='" + cashReleaseType + "', `description`='" + description + "', `status`='" + A + "', `bookType`='" + bookType + "' WHERE `cashReleaseTypeID`='" + cashReleaseID + "'";
            runNonQuery(q);
        }
        public void addIncomeType(string itemType, int bookType, Decimal suggestedPrice, int status, string details)
        {
            string q = "INSERT INTO `sad2`.`itemtype` (`itemType`, `bookType`, `suggestedPrice`, `status`,`details`) VALUES ('" + itemType + "', '" + bookType + "', '" + suggestedPrice + "', '" + status + "','" + details + "')";
            runNonQuery(q);
        }
        public void editIncomeType(int incomeTypeID, string itemType, int bookType, Decimal suggestedPrice, int status, string details)
        {
            string q = "UPDATE `sad2`.`itemtype` SET `itemType`='" + itemType + "', `bookType`='" + bookType + "', `suggestedPrice`='" + suggestedPrice + "', `status`='" + status + "',details='" + details + "' WHERE `itemTypeID`='" + incomeTypeID + "'";
            runNonQuery(q);
        }
        public int getMaxIncomeType()
        {
            string q = "SELECT max(itemTypeID) FROM sad2.itemtype;";
            return int.Parse(runQuery(q).Rows[0][0].ToString());
        }
        public DataTable getIncomeType(int IncomeTypeID)
        {
            string q = "select * from itemType where itemTypeID= " + IncomeTypeID + ";";
            return runQuery(q);
        }
        public DataTable getIncomeTypes()
        {
            string q = @"SELECT itemType, itemTypeID  ,case when bookType=1 then 'Parish' when bookType=2 then 'Community' when bookType=3 then 'Postulancy' end as Book,
                     case when status=1 then 'Active' when status=2 then 'Inactive' end as Status , concat('₱',' ',suggestedprice)as SuggestedPrice FROM sad2.itemtype;";
            return runQuery(q);
        }
        public void disableIncomeType(int IncomeTypeID)
        {
            string q = $"UPDATE `sad2`.`itemtype` SET `status`='2' WHERE `itemTypeID`='{IncomeTypeID}'";
            runNonQuery(q);
        }
        public DataTable getIncomeTypesOf(int bookType)
        {
            string q = @"SELECT itemType, itemTypeID  ,case when bookType=1 then 'Parish' when bookType=2 then 'Community' when bookType=3 then 'Postulancy' end as Book,
                     case when status=1 then 'Active' when status=2 then 'Inactive' end as Status , suggestedprice as SuggestedPrice FROM sad2.itemtype where status=1 and bookType='" + bookType + "';";
            return runQuery(q);
        }
        public void enableIncomeType(int IncomeTypeID)
        {
            string q = $"UPDATE `sad2`.`itemtype` SET `status`='1' WHERE `itemTypeID`='{IncomeTypeID}'";
            runNonQuery(q);
        }
        public void disableCashReleaseType(int CashReleaseTypeID)
        {
            string q = $"UPDATE `sad2`.`cashreleasetype` SET `status`='2' WHERE `cashreleasetypeID`='{CashReleaseTypeID}'";
            runNonQuery(q);
        }
        public void enableCashReleaseType(int CashReleaseTypeID)
        {
            string q = $"UPDATE `sad2`.`cashreleasetype` SET `status`='1' WHERE `cashreleasetypeID`='{CashReleaseTypeID}'";
            runNonQuery(q);
        }
        public int getnextORof(int bookType)
        {
            string q = $"select max(ORnum) as max from primaryincome where bookType={bookType};";
            
            int holder = 1;
            if (int.TryParse(runQuery(q).Rows[0]["max"].ToString(), out holder))
            {
                return holder + 1;
            }
            return 1;
          
        }
        public int addPrimaryIncome(string sourceName, int bookType, int ORnum, string remarks)
        {
            string q = $"INSERT INTO `sad2`.`primaryincome` ( `sourceName`, `bookType`, `ORnum`, `remarks`, `primaryIncomeDateTime`) VALUES ('{sourceName}', '{bookType}', '{ORnum}', '{remarks}', '{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}'); SELECT LAST_INSERT_ID();";
            return int.Parse(runQuery(q).Rows[0][0].ToString());
        }

        public bool addPrimaryIncome(int bookType, int ORnum, string remarks)
        {
            string q = "INSERT INTO PrimaryIncome(bookType, ORnum, remarks) VALUES (@bookType, @ORnum, @remarks)";
            bool success = ExecuteNonQuery(q, bookType, ORnum, remarks);
            return success;
        }

        public void addItem(int itemTypeID, int primaryIncomeID, decimal price, int quantity)
        {
            string q = $"INSERT INTO `sad2`.`item` (`itemTypeID`, `primaryIncomeID`, `price`, `quantity`) VALUES ('{itemTypeID}', '{primaryIncomeID}', '{price}', '{quantity}')";
            runNonQuery(q);
        }
        public DataTable getApplicationsWhereNameLike(string name, SacramentType sacrament, ApplicationStatus applicationStatus)
        {

            string q = "SELECT generalprofile.profileid, concat(lastname,\" \",coalesce(suffix,\" \"),\",\",firstName,\" \",midName,\".\") as name,  gender, birthdate FROM GeneralProfile"
                + " JOIN Applicant ON  GeneralProfile.profileID = Applicant.profileID "
                + " JOIN Application ON Application.applicationID = Applicant.applicationID"
                + " WHERE Application.sacramentType = " + (int)sacrament
                + " AND Application.status = " + (int)applicationStatus
                + " AND (firstname like '%" + name + "%' or lastname like '%" + name + "%')";

            DataTable dt = runQuery(q);

            return dt;
        }
        public DataTable getPendingApplications()
        {
            string q = $@"SELECT generalprofile.profileid,address,contactnumber,firstname,midname,lastname,suffix,application.applicationID,concat(lastname,"" "",coalesce(suffix,"" ""),"","",firstName,"" "",midName,""."") as name,  sacramentType
                        FROM GeneralProfile JOIN Applicant ON  GeneralProfile.profileID = Applicant.profileID  JOIN Application ON Application.applicationID = Applicant.applicationID WHERE  Application.status = {(int)ApplicationStatus.Pending}";

            DataTable dt = runQuery(q);

            return dt;
        }
        public void addDownPaymentProfile(string firstname, string middlename, string lastname, string suffix, string address, string contactnumber)
        {
            string q = $@"INSERT INTO `sad2`.`downpaymentprofile` (`firstname`, `middlename`, `lastname`, `suffix`, `address`, `contactnumber`) 
                        VALUES ('{firstname}', '{middlename}', '{lastname}', '{suffix}', '{address}', '{contactnumber}');";
            runNonQuery(q);

        }
        public DataTable test(string a)
        {
            string q = $"SELECT generalprofile.profileid, concat(lastname,\"\",coalesce(suffix,\" \"),\",\",firstName,\"\",midName,\".\") as name from generalprofile where firstname like \"%" + a + "%\" or lastname like \"%" + a + "%\"";
            return runQuery(q);
        }
        public bool hasSacramentIncome(int applicationID, int type)
        {
            string q = $"select* from application inner join sacramentincome on sacramentincome.applicationID = application.applicationID where sacramentType = {type} and application.applicationid = {applicationID} and application.status={(int)ApplicationStatus.Pending}";
            return (runQuery(q).Rows.Count > 0 ? true : false);
        }
        public DataTable getPayments(int sacramentIncome)
        {
            string q = $"select* from primaryincome inner join payment on payment.primaryIncomeID = primaryincome.primaryIncomeID where sacramentIncomeID = {sacramentIncome};";
            return runQuery(q);
        }
        public DataTable getSacramentIncome(int applicationID)
        {
            string q = $"select * from sacramentIncome where applicationID ={applicationID};";
            return runQuery(q);
        }
       public DataTable getPendingApplicationsOfType(int sacramentType)
        {
            string q = $@"SELECT generalprofile.profileid,address,contactnumber,firstname,midname,lastname,suffix,application.applicationID,concat(lastname, "" "", coalesce(suffix, "" ""), "", "", firstName, "" "", midName, ""."") as name,  sacramentType
                                 FROM GeneralProfile JOIN Applicant ON  GeneralProfile.profileID = Applicant.profileID  JOIN Application ON Application.applicationID = Applicant.applicationID WHERE Application.status = {(int)ApplicationStatus.Pending} and sacramenttype= {sacramentType}";
            return runQuery(q);
        }
    } 

}
