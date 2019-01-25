using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Globalization;

namespace ParishSystem
{
    //I changed something




    public class DataHandler
    {

        public MySqlConnection conn;
        public MySqlCommand com;

        public const string CONNECTION_STRING = "Server=" + "localhost" + ";Database=" + "sad2" + ";Uid=" + "root" + ";Pwd=" + "root" + ";pooling = false; convert zero datetime=True; Allow User Variables=True;";
        //public int userID = 1;

        public DataHandler()
        {
            conn = new MySqlConnection(CONNECTION_STRING);
        }

        //  MySqlConnection connect = new MySqlConnection("server=localhost; database=sad2; user=root; password=root; pooling = false; convert zero datetime=True");
        //public DataHandler(string server, string database, string user, string password, int UserID)
        //{
        //    conn = new MySqlConnection("Server=" + server + ";Database=" + database + ";Uid=" + user + ";Pwd=" + password + ";pooling = false; convert zero datetime=True; Allow User Variables=True");
        //    //userID = UserID;
        //}

        //public DataHandler(string server, string database, string user, string password)
        //{
        //    conn = new MySqlConnection("Server=" + server + ";Database=" + database + ";Uid=" + user + ";Pwd=" + password + ";pooling = false; convert zero datetime=True; Allow User Variables=True");
        //    //this.userID = -1;
        //}




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


        /// <summary>
        /// Returns a user that is either active or inactive
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        //public DataTable getUser(string userName, string password, UserStatus status = UserStatus.Active)
        //{
        //    string q = "SELECT * FROM User WHERE userName = @userName AND pass = @pass AND status = @status;";
        //    DataTable dt = ExecuteQuery(q, userName, password, status);

        //    return dt;
        //}

        public DataTable getUser(string userName)
        {
            string q = "SELECT * FROM User WHERE userName = @userName";
            DataTable dt = ExecuteQuery(q, userName);

            return dt;
        }




        //                                         ========[HELPER FUNCTIONS]=========
        #region

        /// <summary>
        /// Assumes database connection is open. Stores the userID of User as a User Defined variable in MySQL.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        private void _storeUserID()
        {
            string q = "SET @userID = " + User.getCurrentUser().userID;
            com = new MySqlCommand(q, conn);
            com.ExecuteNonQuery();
        }

        public bool runNonQuery(string q)
        {
            Console.WriteLine(q);
            conn.Open();
            _storeUserID();
            com = new MySqlCommand(q, conn);
            int rowsAffected = com.ExecuteNonQuery();
            conn.Close();

            return rowsAffected > 0;
        }

        public DataTable runQuery(string q)
        {
            Console.WriteLine(q);
            conn.Open();
            _storeUserID();
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
            _storeUserID();
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

            HashSet<string> set = new HashSet<string>();
            foreach (string s in parameters)
            {
                set.Add(s);
            }

            if (set.Count != values.Length)
                throw new Exception("Number of parameters does not match number of values");

            var ParameterValues = parameters.Zip(values, (p, v) => new { Parameter = p, Value = v });

            conn.Open();
            _storeUserID();
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

        /// <summary>
        /// Returns list containing the parameter names of a parameterized query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
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
            User user = User.getCurrentUser();
            string q = "UPDATE " + tableName + " SET " + primaryKeyName + " = " + primaryKeyValue + ", lastModified = NOW(), userID = '" + user.userID + "'";

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
            int month = int.Parse(date[1]);
            int day = int.Parse(date[0]);
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
        public bool editGeneralProfile(int profileID, string firstName, string midName, string lastName, string suffix, Gender gender, DateTime birthDate, string contactNumber, string residence, string birthplace, string bloodtype)
        {
            if (!idExists("generalProfile", "profileID", profileID))
                return false;

            //addGeneralProfileLog(profileID);

            string q = "UPDATE GeneralProfile SET midName = '" + midName + "', lastName = '" + lastName
                + "', suffix = '" + suffix + "', gender = '" + (int)gender
                + "', birthDate = '" + birthDate.ToString("yyyy-MM-dd HH:mm:ss.fff")
                + "', contactNumber = '" + contactNumber + "', residence = '" + residence
                + "', birthplace = '" + birthplace + "',bloodType='" + bloodtype + "' WHERE profileID = '" + profileID + "'";
            Console.WriteLine(q);
            //updateModificationInfo("generalProfile", "profileID", profileID);

            bool success = runNonQuery(q);

            return success;
        }


        public bool editPlaceOfBirth(int profileID, string placeOfBirth)
        {
            string q = "UPDATE GeneralProfile SET birthPlace = @birthPlace WHERE profileID = @profileID";
            bool success = ExecuteNonQuery(q, placeOfBirth, profileID);

            return success;
        }

        public bool editGeneralProfile(int profileID, string firstName, string midName, string lastName, string suffix, Gender gender, DateTime birthDate)
        {
            string q = @"UPDATE GeneralProfile SET firstName = @firstName, midName = @midName, lastName = @lastName, suffix = @suffix, 
                        gender = @gender, birthDate = @birthDate 
                        WHERE profileID = @profileID";
            bool success = ExecuteNonQuery(q, firstName, midName, lastName, suffix, gender, birthDate.ToString("yyyy-MM-dd"), profileID);
            return success;

        }

        public bool editGeneralProfile(int profileID, string residence, string birthplace)
        {
            string q = "UPDATE GeneralProfile SET residence = @residence, birthplace = @birthplace WHERE profileID = @profileID";
            bool success = ExecuteNonQuery(q, residence, birthplace, profileID);
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
                        AND lastName = @lastName AND suffix = @suffix AND gender = @gender AND birthDate = @birthDate 
                        AND profileID != @profileID";

            DataTable dt = ExecuteQuery(q, firstName, midName, lastName, suffix, (int)gender, birthDate.ToString("yyyy-MM-dd"), profileID);

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
                return Convert.ToInt32(dt.Rows[0][0].ToString());
        }


        public DataTable getGeneralProfile(int profileID)
        {
            string q = "SELECT firstName, midName, lastName, suffix, gender, DATE(birthdate) AS birthDate, birthplace,residence FROM generalProfile WHERE profileID = " + profileID;

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
            string q = $@"SELECT  profileid, CONCAT(firstname, ' ', midname, ' ' , lastname, ' ', COALESCE(suffix, '')) as Name,birthdate,case 
                        when gender = 1 then 'Male'
                        when gender = 2 then 'Female'
                        end as gender,birthplace, residence FROM GeneralProfile";

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

        //public bool isInSameMarriage(int groomID, int brideID)
        //{
        //    string q = @"SELECT * FROM generalprofile NATURAL JOIN Applicant NATURAL JOIN Application 
        //                    WHERE sacramentType = @sacramentType 
        //                    AND (profileID = @profileID1 OR profileID = @profileID2)";



        //}


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
            string q = "SELECT * "
                + "FROM bloodDonor where blooddonorid=" + bloodDonorID;

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
            //addBloodDonationLog(bloodDonationID); //ModInfo before deletion
            //updateModificationInfo("bloodDonation", "bloodDonationID", bloodDonationID);

            //addBloodDonationLog(bloodDonationID); //ModInfo after deletion

            string q = "DELETE FROM bloodDonation WHERE bloodDonationID = " + bloodDonationID;
            return runNonQuery(q);
        }


        //SPECIAL FUNCTION
        public int getTotalBloodDonationOf(int generalProfileID)
        {
            string q = "SELECT count(donationid) FROM BloodDonation WHERE profileID = " + generalProfileID;

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

        public bool addBloodDonationEvent(string eventName, DateTime startDateTime, DateTime endDateTime, string eventVenue, string eventDetails)
        {
            string q = "INSERT INTO BloodDonationEvent(eventName, startDateTime, endDateTime, eventVenue, eventDetails) VALUES (@eventName, @startDateTime, @endDateTime, @eventVenue, @eventDetails)";
            bool success = ExecuteNonQuery(q, eventName, startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"), eventVenue, eventDetails);
            return success;


        }

        public bool editBloodDonationEvent(int bloodDonationEventID, string eventName, DateTime startDateTime, DateTime endDateTime, string eventVenue, string eventDetails)
        {
            string q = "UPDATE BloodDonationEvent SET eventName = @eventName, startDateTime = @startDateTime, endDateTime = @endDateTime, eventVenue = @eventVenue, eventDetails = @eventDetails WHERE bloodDonationEventID = @bloodDonationEventID";
            bool success = ExecuteNonQuery(q, eventName, startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"), eventVenue, eventDetails, bloodDonationEventID);
            return success;

        }

        public bool deleteBloodDonationEvent(int bloodDonationEventID)
        {

            string q = "DELETE FROM bloodDonationEvent WHERE bloodDonationEventID = @bloodDonationEventID";

            return ExecuteNonQuery(q, bloodDonationEventID);
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

        public DataTable getBloodDonationEvents(DateTime startDateTime, DateTime endDateTime)
        {
            string q = @"SELECT bloodDonationEventID, eventName, eventDetails, eventVenue,
                            DATE_FORMAT(startDateTime, '%Y-%m-%d %H:%i') AS startDateTime, DATE_FORMAT(endDateTime, '%Y-%m-%d %H:%i') AS endDateTime
                            FROM BloodDonationEvent WHERE startDateTime >= @startDateTime AND endDateTime <= @endDateTime";

            DataTable dt = ExecuteQuery(q, startDateTime.ToString("yyyy-MM-dd hh:mm:ss"), endDateTime.ToString("yyyy-MM-dd hh:mm:ss"));

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
            DataTable dt = getParentOf(profileID, Pgender);

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
            if (dt.Rows.Count < 2)
            {
                //add parents
                success &= addParent(profileID, PfirstName, PmidName, PlastName, Psuffix, Pgender);

            }
            else
            {
                //update parent; The parent is based on the int value of gender - 1;
                int pID = int.Parse(dt.Rows[(int)Pgender - 1][0].ToString());
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
        public bool addSacramentIncome(int applicationID, double price, string remarks)
        {
            string q = "INSERT INTO SacramentIncome(applicationID, price, remarks) VALUES (@applicationID, @price, @remarks)";
            bool success = ExecuteNonQuery(q, applicationID, price, remarks);

            return success;
        }

        /// <summary>
        /// Reassigns a sacramentIncome to another application
        /// </summary>
        /// <param name="oldApplicationID"></param>
        /// <param name="newApplicationID"></param>
        /// <returns></returns>
        public bool editSacramentIncome(int oldApplicationID, int newApplicationID)
        {
            string q = "UPDATE SacramentIncome SET applicationID = @newApplicationID WHERE applicationID = @oldApplicationID";
            bool success = ExecuteNonQuery(q, newApplicationID, oldApplicationID);
            return success;
        }

        public int getLastSacramentIncome()
        {
            string q = "SELECT max(sacramentIncomeID)as ID FROM sad2.sacramentincome";
            return int.Parse(runQuery(q).Rows[0][0].ToString());
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

            try { return int.Parse(dt.Rows[0]["sacramentIncomeID"].ToString()); }
            catch { return -1; }
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
            string q = "SELECT COALESCE(MAX(ORnum), 0) + 1 FROM PrimaryIncome WHERE bookType = " + (int)type;
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

        public DataTable getItemsOfIncomeFromItems(int ORnum, int bookType)
        {
            string q = $"select * from primaryincome inner  join item on primaryincome.primaryIncomeID = item.primaryIncomeID inner join itemtype on itemtype.itemTypeID = item.itemTypeID where ORnum={ORnum} and primaryincome.bookType={bookType};";

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getItemsOfIncomeFromSacramentIncome(int ORnum, int bookType)
        {
            string q = $"select * from primaryincome inner join payment on payment.primaryIncomeID=primaryincome.primaryIncomeID inner join sacramentincome on sacramentincome.sacramentIncomeID = payment.sacramentIncomeID inner join application on application.applicationID= sacramentincome.applicationID where ORnum ={ORnum} and primaryincome.bookType={bookType}";
            return runQuery(q);
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
                    requirements = "000";
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

        public bool hasApplication(int profileID, SacramentType type, ApplicationStatus status)
        {
            string q = "SELECT COUNT(*) FROM Application NATURAL JOIN Applicant NATURAL JOIN GeneralProfile WHERE profileID = @profileID AND sacramentType = @sacramentType AND status = @status";
            DataTable dt = ExecuteQuery(q, profileID, (int)type, (int)status);
            return Convert.ToInt32(dt.Rows[0][0]) > 0;
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





        public bool editSacramentReference(SacramentType t, int sacramentID, string registryNumber, string recordNumber, string pageNumber)
        {
            bool success;
            if (t == SacramentType.Baptism)
                success = editBaptismReference(sacramentID, registryNumber, recordNumber, pageNumber);
            else if (t == SacramentType.Confirmation)
                success = editConfirmationReference(sacramentID, registryNumber, recordNumber, pageNumber);
            else
                success = editMarriageReference(sacramentID, registryNumber, recordNumber, pageNumber);

            return success;

        }

        /*
                                         =============================================================
                                              ================ BAPTISM TABLE =================
                                         =============================================================
        */

        #region


        public bool addBaptism(int applicationID, int ministerID, Legitimacy legitimacy, DateTime baptismDate, string remarks)
        {
            string q = "INSERT INTO Baptism(applicationID, ministerID, legitimacy, baptismDate, remarks) VALUES (@applicationID, @ministerID, @legitimacy, @baptismDate, @remarks)";
            bool success = ExecuteNonQuery(q, applicationID, ministerID, legitimacy, baptismDate.ToString("yyyy-MM-dd"), remarks);
            return success;

        }


        public bool editBaptism(int applicationID, int ministerID, DateTime baptismDate, Legitimacy legitimacy, string remarks)
        {

            string q = "UPDATE Baptism SET ministerID = @ministerID, baptismDate = @baptismDate, legitimacy = @legitimacy, remarks = @remarks WHERE applicationID = @applicationID";
            bool success = ExecuteNonQuery(q, ministerID, baptismDate.ToString("yyyy-MM-dd"), legitimacy, remarks, applicationID);
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

            return dt;
        }

        public Baptism getBaptismObject(int applicationID)
        {
            DataRow dr = getBaptism(applicationID).Rows[0];

            int ministerID = Convert.ToInt32(dr["ministerID"].ToString());
            string registry = Convert.ToString(dr["registryNumber"].ToString());
            string page = Convert.ToString(dr["pageNumber"].ToString());
            string record = Convert.ToString(dr["recordNumber"].ToString());
            string remarks = Convert.ToString(dr["remarks"].ToString());
            DateTime baptismDate = DateTime.ParseExact(dr["baptismDate"].ToString(), "dd/MM/yyyy", null);
            Legitimacy legitimacy = (Legitimacy)Convert.ToInt32(dr["legitimacy"].ToString());

            Baptism bap = new Baptism(applicationID, ministerID, registry, page, record, remarks, baptismDate, legitimacy);

            return bap;
        }

        //addReference is same as editReference!!!!!!!!!

        public bool editBaptismReference(int baptismID, string registryNumber, string recordNumber, string pageNumber)
        {
            string q = "UPDATE Baptism SET registryNumber = @registryNumber, recordNumber = @recordNumber, pageNumber = @pageNumber WHERE baptismID = @baptismID";
            bool success = ExecuteNonQuery(q, registryNumber, recordNumber, pageNumber, baptismID);

            return success;
        }

        public DataTable getBaptisms()
        {
            string q = "SELECT profileID, applicationID, baptismID, Minister.ministerID, CONCAT_WS(' ', Minister.firstName, Minister.midName, Minister.lastName, Minister.suffix) AS ministerName,  p.firstName, p.midname, p.lastName, p.suffix, DATE_FORMAT(baptismDate, '%Y-%m-%d') AS baptismDate, registryNumber, pageNumber, recordNumber, remarks  "
                + "FROM Baptism NATURAL JOIN Application NATURAL JOIN Applicant NATURAL JOIN GeneralProfile AS p JOIN Minister ON Baptism.ministerID = Minister.ministerID";


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
            string q = "INSERT INTO Confirmation(applicationID, ministerID, confirmationDate, remarks) VALUES (@applicationID, @ministerID, @confirmationDate, @remarks)";
            bool success = ExecuteNonQuery(q, applicationID, ministerID, confirmationDate.ToString("yyyy-MM-dd"), remarks);
            return success;

        }

        public bool editConfirmation(int applicationID, int ministerID, DateTime confirmationDate, string remarks)
        {
            string q = "UPDATE Confirmation SET ministerID = @ministerID, confirmationDate = @confirmationDate, remarks = @remarks WHERE applicationID = @applicationID";
            bool success = ExecuteNonQuery(q, ministerID, confirmationDate.ToString("yyyy-MM-dd"), remarks, applicationID);
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

        public bool editConfirmationReference(int confirmationID, string registryNumber, string recordNumber, string pageNumber)
        {
            string q = "UPDATE Confirmation SET registryNumber = @registryNumber, recordNumber = @recordNumber, pageNumber = @pageNumber WHERE confirmationID = @confirmationID";
            bool success = ExecuteNonQuery(q, registryNumber, recordNumber, pageNumber, confirmationID);

            return success;

        }

        public DataTable getConfirmation(int applicationID)
        {
            string q = "SELECT * FROM Confirmation WHERE applicationID = " + applicationID;

            DataTable dt = runQuery(q);

            return dt;
        }

        public DataTable getConfirmations()
        {
            string q = @"SELECT profileID, applicationID, confirmationID, Minister.ministerID, CONCAT_WS(' ', Minister.firstName, Minister.midName, Minister.lastName, Minister.suffix) AS ministerName,
                p.firstName, p.midname, p.lastName, p.suffix, DATE_FORMAT(confirmationDate, '%Y-%m-%d') AS confirmationDate, registryNumber, pageNumber, recordNumber, remarks  
                FROM Confirmation NATURAL JOIN Application NATURAL JOIN Applicant NATURAL JOIN GeneralProfile AS p JOIN Minister ON Confirmation.ministerID = Minister.ministerID";

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

        public Confirmation getConfirmationObject(int applicationID)
        {
            DataRow dr = getConfirmation(applicationID).Rows[0];

            int ministerID = Convert.ToInt32(dr["ministerID"].ToString());
            string registry = Convert.ToString(dr["registryNumber"].ToString());
            string page = Convert.ToString(dr["pageNumber"].ToString());
            string record = Convert.ToString(dr["recordNumber"].ToString());
            string remarks = Convert.ToString(dr["remarks"].ToString());
            DateTime confirmationDate = DateTime.ParseExact(dr["confirmationDate"].ToString(), "dd/MM/yyyy hh:mm:tt", null);

            Confirmation con = new Confirmation(applicationID, ministerID, registry, page, record, remarks, confirmationDate);

            return con;
        }











        #endregion
        /*
                                         =============================================================
                                             =================== MARRIAGE TABLE =================
                                         =============================================================
        */
        #region

        public bool addMarriage(int applicationID, int ministerID, DateTime licenseDate, DateTime marriageDate, CivilStatus civilStatusGroom, CivilStatus civilStatusBride, string remarks)
        {
            string q = "INSERT INTO Marriage(applicationID, ministerID, licenseDate, marriageDate, civilStatusGroom, civilStatusBride, remarks, status) VALUES (@applicationID, @ministerID, @licenseDate, @marriageDate, @civilStatusGroom, @civilStatusBride, @remarks, @status)";
            bool success = ExecuteNonQuery(q, applicationID, ministerID, licenseDate.ToString("yyyy-MM-dd HH:mm:ss"), marriageDate.ToString("yyyy-MM-dd"), civilStatusGroom, civilStatusBride, remarks, MarriageStatus.Active);

            return success;
        }

        public bool editMarriage(int applicationID, int ministerID, DateTime licenseDate, DateTime marriageDate, CivilStatus civilStatusGroom, CivilStatus civilStatusBride, string remarks)
        {
            string q = @"UPDATE Marriage SET ministerID = @ministerID, licenseDate = @licenseDate, marriageDate = @marriageDate, 
                        civilStatusGroom = @civilStatusGroom, civilStatusBride = @civilStatusBride, remarks = @remarks 
                        WHERE applicationID = @applicationID";
            bool success = ExecuteNonQuery(q, ministerID, licenseDate.ToString("yyyy-MM-dd"), marriageDate.ToString("yyyy-MM-dd"), (int)civilStatusGroom, (int)civilStatusBride, remarks, applicationID);
            return success;

        }

        public bool deleteMarriage(int marriageID)
        {
            string q = "DELETE FROM Marriage WHERE marriageID = " + marriageID;

            bool success = runNonQuery(q);

            return success;
        }

        public bool editMarriageReference(int marriageID, string recordNumber, string pageNumber, string registryNumber)
        {
            string q = "UPDATE Marriage SET recordNumber = @recordNumber, pageNumber = @pageNumber, registryNumber = @registryNumber WHERE marriageID = @marriageID";
            bool success = ExecuteNonQuery(q, recordNumber, pageNumber, registryNumber, marriageID);
            return success;

        }

        public DataTable getMarriage(int applicationID)
        {
            //string q = "SELECT *,concat(firstName,\" \",midname,\" \",lastname,\"\",suffix)as ministerName  FROM Marriage inner join minister on marriage.ministerID=minister.ministerID where  applicationID =" + applicationID;

            string q = "SELECT *, CONCAT_WS(' ', firstName, midName, lastName, suffix) as MinisterName FROM Marriage JOIN Minister ON Marriage.ministerID = Minister.ministerID WHERE applicationID = @applicationID";

            DataTable dt = ExecuteQuery(q, applicationID);

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
                + " gender, birthdate, registryNumber, pageNumber, recordNumber, DATE_FORMAT(marriageDate, '%m-%Y-%d') FROM Marriage "
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

        public DataTable getMarriages()
        {
            string q = @"SELECT marriageID, groom.applicationID, groom.profileID AS groomID, bride.profileID AS brideID, Minister.ministerID, CONCAT_WS(' ', Minister.firstName, Minister.midName, Minister.lastName, Minister.suffix) AS ministerName,
                        DATE_FORMAT(marriageDate, '%Y-%m-%d') as marriageDate,
                        CONCAT_WS(' ', groom.firstName, groom.midName, groom.lastName, groom.suffix) AS groomName, 
                        CONCAT_WS(' ', bride.firstName, bride.midName, bride.lastName, bride.suffix) AS brideName,
                        registryNumber, recordNumber, pageNumber, remarks
                        FROM 
                        (SELECT * FROM GeneralProfile NATURAL JOIN Applicant NATURAL JOIN Application WHERE gender = 1)
                        AS groom 
                        JOIN 
                        (SELECT * FROM GeneralProfile NATURAL JOIN Applicant NATURAL JOIN Application WHERE gender = 2)
                        AS bride
                        ON groom.applicationID = bride.applicationID 
                        JOIN Marriage ON Marriage.applicationID = groom.applicationID JOIN Minister ON Minister.ministerID = Marriage.ministerID 
                        WHERE groom.profileID != bride.profileID";
            DataTable dt = ExecuteQuery(q);
            return dt;
        }

        public Marriage getMarriageObject(int applicationID)
        {
            DataTable dt = getMarriage(applicationID);

            DataRow dr = getMarriage(applicationID).Rows[0];

            int ministerID = Convert.ToInt32(dr["ministerID"].ToString());
            string registry = Convert.ToString(dr["registryNumber"].ToString());
            string page = Convert.ToString(dr["pageNumber"].ToString());
            string record = Convert.ToString(dr["recordNumber"].ToString());
            string remarks = Convert.ToString(dr["remarks"].ToString());
            MessageBox.Show(dr["marriageDate"].ToString());
            DateTime marriageDate = DateTime.ParseExact(dr["marriageDate"].ToString(), "dd/MM/yyyy hh:mm:ss tt", null);
            DateTime licenseDate = DateTime.ParseExact(dr["licenseDate"].ToString(), "dd/MM/yyyy hh:mm:ss tt", null);
            CivilStatus groomStatus = (CivilStatus)Convert.ToInt32(dr["civilStatusGroom"]);
            CivilStatus brideStatus = (CivilStatus)Convert.ToInt32(dr["civilStatusBride"]);

            Marriage mar = new Marriage(applicationID, ministerID, registry, page, record, remarks, marriageDate, licenseDate, groomStatus, brideStatus);

            return mar;
        }


        #endregion
        /*
                                         =============================================================
                                            ================= MINISTER TABLE =================
                                         =============================================================
        */
        #region

        public bool addMinister(string firstName, string midName, string lastName, string suffix, DateTime birthDate, MinistryType ministryType, MinisterStatus status)
        {
            string q = "INSERT INTO Minister(firstName, midName, lastName, suffix, birthDate, ministryType, status) VALUES (@firstName, @midName, @lastName, @suffix, @birthDate, @ministryType, @status)";
            bool success = ExecuteNonQuery(q, firstName, midName, lastName, suffix, birthDate.ToString("yyyy-MM-dd"), ministryType, status);
            return success;
        }

        public bool editMinister(int ministerID, string firstName, string midName, string lastName, string suffix, DateTime birthDate, MinistryType ministryType, MinisterStatus status)
        {
            if (!idExists("Minister", "ministerID", ministerID))
                return false;

            //No need addMinisterLog

            string q = "UPDATE Minister SET firstName = @firstName, midName = @midName, lastName = @lastName, suffix = @suffix, birthDate = @birthDate, ministryType = @ministryType, status = @status WHERE ministerID = @ministerID";
            bool success = ExecuteNonQuery(q, firstName, midName, lastName, suffix, birthDate.ToString("yyyy-MM-dd HH:mm:ss"), ministryType, status, ministerID);
            return success;
        }



        //COMMENT: merge names into field "Name"
        public DataTable getMinister(int ministerID)
        {
            string q = "SELECT *,CONCAT(firstName, ' ', midName, ' ', lastName, ' ', suffix) as name FROM Minister WHERE ministerID = @ministerID";

            DataTable dt = ExecuteQuery(q, ministerID);

            return dt;
        }

        /// <summary>
        /// Returns ministers with indicated status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public DataTable getMinisters(MinisterStatus status)
        {
            string q = "SELECT ministerID, firstName, midName, lastName, suffix, CONCAT(firstName, ' ', midName, ' ', lastName, ' ', suffix) as Name, birthdate, ministryType, status, licenseNumber FROM Minister WHERE status = @status";

            DataTable dt = ExecuteQuery(q, (int)status);

            return dt;
        }

        public DataTable getMinisters(MinistryType type)
        {
            string q = "SELECT ministerID, firstName, midName, lastName, suffix, CONCAT(firstName, ' ', midName, ' ', lastName, ' ', suffix)as Name, birthdate, ministryType, status, licenseNumber FROM Minister WHERE ministryType = @ministryType";

            DataTable dt = ExecuteQuery(q, (int)type);

            return dt;
        }

        public DataTable getMinisters(MinistryType type, MinisterStatus status)
        {
            string q = "SELECT ministerID, firstName, midName, lastName, suffix, CONCAT(firstName, ' ', midName, ' ', lastName, ' ', suffix)as Name, birthdate, ministryType, status, licenseNumber FROM Minister WHERE ministryType = @ministryType AND status = @status";
            DataTable dt = ExecuteQuery(q, (int)type, (int)status);
            return dt;
        }


        /// <summary>
        /// Returns all ministers
        /// </summary>
        /// <returns></returns>
        public DataTable getMinisters()
        {
            string q = "SELECT ministerID, firstName, midName, lastName, suffix, CONCAT(firstName, ' ', midName, ' ', lastName, ' ', suffix)as Name, birthdate, ministryType, status FROM Minister";

            DataTable dt = runQuery(q);

            return dt;
        }

        #endregion


        /*
                                         =============================================================
                                            ================= SPONSOR TABLE =================
                                         =============================================================
        */
        #region


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

        public bool editSponsor(int applicationID, string firstname, string midname, string lastname, string suffix, Gender gender, string residence)
        {
            string q = "UPDATE Sponsor SET firstname = @firstname, midname = @midname, lastname = @lastname, suffix = @suffix, gender = @gender, residence = @residence WHERE applicationID = @applicationID";
            bool success = ExecuteNonQuery(q, firstname, midname, lastname, suffix, gender, residence, applicationID);
            return success;
        }

        public bool editSponsor(int sponsorID, int applicationID, string firstname, string midname, string lastname, string suffix, Gender gender, string residence)
        {
            //ApplicationID is actually not used here. It's just to change the method signature.
            string q = "UPDATE Sponsor SET firstname = @firstname, midname = @midname, lastname = @lastname, suffix = @suffix, gender = @gender, residence = @residence WHERE sponsorID = @sponsorID";
            bool success = ExecuteNonQuery(q, firstname, midname, lastname, suffix, gender, residence, sponsorID);
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


        public bool addSchedule(string title, DateTime startDateTime, DateTime endDateTime, string details)
        {
            string q = "INSERT INTO Schedule(title, startDateTime, endDateTime, details) VALUES (@title, @startDateTime, @endDateTime, @details)";
            bool success = ExecuteNonQuery(q, title, startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"), details);
            return success;
        }

        public bool editSchedule(int scheduleID, string title, DateTime startDateTime, DateTime endDateTime, string details)
        {
            string q = "UPDATE Schedule SET title = @title, startDateTime = @startDateTime, endDateTime = @endDateTime, details = @details WHERE scheduleID = @scheduleID";
            bool success = ExecuteNonQuery(q, title, startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"), details, scheduleID);
            return success;
        }

        public bool deleteSchedule(int scheduleID)
        {
            string q = "DELETE FROM Schedule WHERE scheduleID = @scheduleID";
            bool success = ExecuteNonQuery(q, scheduleID);

            return success;
        }

        public DataTable getSchedule()
        {
            string q = "SELECT * FROM Schedule";
            DataTable dt = ExecuteQuery(q);
            return dt;
        }

        /// <summary>
        /// Retrieves schedules greater than or equal to Start and less than or equal to End
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataTable getSchedules(DateTime Start, DateTime End)
        {
            string q = "SELECT scheduleID, title, details, "
                + "DATE_FORMAT(startDateTime, '%Y-%m-%d %H:%i') AS startDateTime, DATE_FORMAT(endDateTime, '%Y-%m-%d %H:%i') AS endDateTime "
                + "FROM Schedule WHERE startDateTime >= @startDateTime AND endDateTime <= @endDateTime";

            DataTable dt = ExecuteQuery(q, Start.ToString("yyyy-MM-dd hh:mm:ss"), End.ToString("yyyy-MM-dd hh:mm:ss"));

            return dt;
        }



        public bool addMinisterSchedule(int ministerID, string title, DateTime startDateTime, DateTime endDateTime, string details)
        {
            string q = "INSERT INTO MinisterSchedule(ministerID, title, startDateTime, endDateTime, details) VALUES (@ministerID, @title, @startDateTime, @endDateTime, @details)";
            bool success = ExecuteNonQuery(q, ministerID, title, startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"), details);
            return success;

        }

        public bool editMinisterSchedule(int ministerScheduleID, int ministerID, string title, DateTime startDateTime, DateTime endDateTime, string details)
        {
            string q = "UPDATE MinisterSchedule SET ministerID = @ministerID, title = @title, startDateTime = @startDateTime, endDateTime = @endDateTime, details = @details WHERE ministerScheduleID = @ministerScheduleID";
            bool success = ExecuteNonQuery(q, ministerID, title, startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"), details, ministerScheduleID);
            return success;
        }

        /// <summary>
        /// Get the entries from MinisterSchedules with schedules between Start and End
        /// </summary>
        /// <param name="Start"></param>
        /// <param name="End"></param>
        /// <returns></returns>
        public DataTable getMinisterSchedules(DateTime Start, DateTime End)
        {
            string q = "SELECT ministerScheduleID, ministerID, title, details, "
                + "DATE_FORMAT(startDateTime, '%Y-%m-%d %H:%i') AS startDateTime, DATE_FORMAT(endDateTime, '%Y-%m-%d %H:%i') AS endDateTime "
                + "FROM MinisterSchedule WHERE startDateTime >= @startDateTime AND endDateTime <= @endDateTime";

            DataTable dt = ExecuteQuery(q, Start.ToString("yyyy-MM-dd hh:mm:ss"), End.ToString("yyyy-MM-dd hh:mm:ss"));

            return dt;
        }

        public bool deleteMinisterSchedule(int ministerScheduleID)
        {
            string q = "DELETE FROM MinisterSchedule WHERE ministerScheduleID = @ministerScheduleID";
            bool success = ExecuteNonQuery(q);
            return success;
        }

        public bool ministerAvailable(int ministerID, DateTime startDateTime, DateTime endDateTime)
        {
            string q = "SELECT ministerID FROM MinisterSchedule WHERE ministerID = @ministerID AND ((@startDateTime BETWEEN startDateTime AND endDateTime) OR (@endDateTime BETWEEN startDateTime AND endDateTime))";

            string q2 = "SELECT ministerID FROM MinisterSchedule WHERE ministerID = @ministerID AND ((@startDateTime < endDateTime) AND (@endDateTime > startDateTime))";
            string start = startDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            string end = endDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            DataTable dt = ExecuteQuery(q2, ministerID, start, end);

            return dt.Rows.Count == 0;
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
            string q = "SELECT * FROM GeneralProfile NATURAL JOIN Applicant NATURAL JOIN Application WHERE profileID = @profileID AND status != @status AND sacramentType = @sacramentType";
            DataTable dt = ExecuteQuery(q, profileID, (int)ApplicationStatus.Revoked, (int)type);
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

        public bool editApplicant(int applicantID, int profileID, int applicationID)
        {
            string q = "UPDATE Applicant SET profileID = @profileID, applicationID = @applicationID WHERE applicantID = @applicantID";
            bool success = ExecuteNonQuery(q, profileID, applicationID, applicantID);
            return success;
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



        public bool addBloodDonation(int profleID, string donationID, int bloodDonationEventID)
        {
            string q = "INSERT INTO BloodDonation(profileID, donationID, bloodDonationEventID) VALUES ('"
                + profleID + "', '" + donationID + "', '" + bloodDonationEventID + "')";

            bool success = runNonQuery(q);

            return success;
        }

        public bool editBloodDonation(int profleID, string donationID, int bloodDonationEventID)
        {
            //edit donation
            string q = "UPDATE BloodDonation SET donationID = '" + donationID
                + "', bloodDonationEventID = '" + bloodDonationEventID
                + "' WHERE blooddonationID = '" + profleID + "'";

            bool success = runNonQuery(q);
            return success;
        }

        public DataTable getBloodDonations(int profileID)
        {
            // add quantity here.. change db and add quantity in query


            string q = "select * from blooddonation inner join blooddonor on blooddonation.profileID = blooddonor.blooddonorID inner join blooddonationevent on blooddonationevent.bloodDonationEventID = blooddonation.bloodDonationEventID where blooddonor.blooddonorID = " + profileID;

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

                q = "SELECT application.applicationID, a.profileID AS groomID, b.profileID AS brideID, "
                    + "aa.applicantID AS groomApplicantID, bb.applicantID AS brideApplicantID, requirements, "
                    + "CONCAT_WS(' ', a.firstName, a.midName, a.lastName, a.suffix) AS groomName, DATE_FORMAT(a.birthdate, '%Y-%m-%d') AS groomBirthDate, "
                    + "CONCAT_WS(' ', b.firstName, b.midName, b.lastName, b.suffix) AS brideName, DATE_FORMAT(b.birthdate, '%Y-%m-%d') AS brideBirthDate, "
                    + "application.status FROM GeneralProfile AS a "
                    + "JOIN Applicant AS aa ON aa.profileID = a.profileID "
                    + "JOIN(SELECT profileID, firstName, midName, lastName, suffix, birthdate FROM GeneralProfile) AS b "
                    + "JOIN Applicant AS bb ON bb.profileID = b.profileID "
                    + "JOIN Application ON(Application.applicationID = aa.applicationID AND Application.applicationID = bb.applicationID) "
                    + "WHERE sacramentType = " + (int)type + " AND a.profileID != b.profileID GROUP BY application.applicationID ORDER BY application.applicationID DESC";

            }
            else
            {
                q = "SELECT applicationID, profileID, applicantID, requirements, firstName, midName, lastName, suffix,"
                    + " gender, DATE_FORMAT(birthdate,'%Y-%m-%d') AS birthDate, status "
                    + "FROM GeneralProfile"
                    + " NATURAL JOIN Applicant "
                    + "NATURAL JOIN Application "
                    + "WHERE sacramentType = " + (int)type 
                    + " ORDER BY application.applicationID DESC";


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
            string q = "select * from (select application.applicationID from generalprofile inner join applicant on applicant.profileID = generalprofile.profileID inner join application on application.applicationID = applicant.applicationID where sacramentType = 3 and generalprofile.profileID = " + profileID + ") as A left outer join (select CONCAT_WS(' ', firstName, midName, lastName, suffix) as name, generalprofile.profileID, gender, birthplace, birthdate, residence, application.applicationID from generalprofile inner join applicant on applicant.profileID = generalprofile.profileID inner join application on application.applicationID = applicant.applicationID where sacramentType = 3 and generalprofile.profileID != " + profileID + ") as B on A.applicationID = B.applicationID";
            return runQuery(q);
        }

        public int getNextBloodlettingID()
        {
            string q = "SELECT case when count(blooddonorID) = 0 then 1 else max(blooddonorID)+1 end  as max FROM sad2.blooddonor;";
            return int.Parse(runQuery(q).Rows[0]["max"].ToString());
        }

        public void addBloodDonor(string fn, string mn, string ln, string sf, string add, string contact, int blood)
        {
            string q = "INSERT INTO `sad2`.`blooddonor` (`firstName`, `midName`, `lastName`, `suffix`, `address`, `contactNumber`, `bloodType`) VALUES ('" + fn + "', '" + mn + "', '" + ln + "', '" + sf + "', '" + add + "', '" + contact + "', '" + blood + "');";
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
        public void addItemType(string itemType, int bookType, Decimal suggestedPrice, int status, int cashreceipt_cashdisbursment, string details)
        {
            string q = "INSERT INTO `sad2`.`itemtype` (`itemType`, `bookType`, `suggestedPrice`, `status`,`details`,`cashreceipt_cashdisbursment`) VALUES ('" + itemType + "', '" + bookType + "', '" + suggestedPrice + "', '" + status + "','" + details + "','" + cashreceipt_cashdisbursment + "')";
            runNonQuery(q);
        }
        public void editIncomeType(int incomeTypeID, string itemType, int bookType, Decimal suggestedPrice, int status, int cashreceipt_cashdisbursment, string details)
        {
            string q = $@"UPDATE `sad2`.`itemtype` SET `itemType`='{itemType}', `bookType`='{bookType}', `suggestedPrice`='{suggestedPrice}', `status`='{status}', `details`='{details}', `cashreceipt_cashdisbursment`='{cashreceipt_cashdisbursment}' WHERE `itemTypeID`='{incomeTypeID}'";
            runNonQuery(q);
        }
        public int getMaxIncomeType()
        {
            string q = "SELECT max(itemTypeID) FROM sad2.itemtype;";
            return int.Parse(runQuery(q).Rows[0][0].ToString());
        }

        public DataTable getItem(int IncomeTypeID, int cashreceipt_cashdisbursment)
        {
            string q = $@"select * from itemType where itemTypeID=  {IncomeTypeID} and cashreceipt_cashdisbursment={cashreceipt_cashdisbursment};";
            return runQuery(q);
        }

        public DataTable getIncomeTypes(int cashreceipt_cashdisbursment)
        {
            string q = $@"SELECT itemType, itemTypeID  ,case when bookType=1 then 'Parish' when bookType=2 then 'Community' when bookType=3 then 'Postulancy' end as Book,
                     case when status=1 then 'Active' when status=2 then 'Inactive' end as Status , concat('₱',' ',suggestedprice)as SuggestedPrice FROM sad2.itemtype where cashreceipt_cashdisbursment={cashreceipt_cashdisbursment};";
            return runQuery(q);
        }
        public void disableIncomeType(int IncomeTypeID, int cashreceipt_cashdisbursment)
        {
            string q = $"UPDATE `sad2`.`itemtype` SET `status`='2' WHERE `itemTypeID`='{IncomeTypeID}' and `cashreceipt_cashdisbursment`='{cashreceipt_cashdisbursment}'";
            runNonQuery(q);
        }

        public void enableIncomeType(int IncomeTypeID, int cashreceipt_cashdisbursment)
        {
            string q = $"UPDATE `sad2`.`itemtype` SET `status`='1' WHERE `itemTypeID`='{IncomeTypeID}' and `cashreceipt_cashdisbursment`='{cashreceipt_cashdisbursment}'";
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
            string q = $@"SELECT generalprofile.profileid,firstname,midname,lastname,suffix,application.applicationID,concat(lastname,"" "",coalesce(suffix,"" ""),"","",firstName,"" "",midName,""."") as name,  sacramentType
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
            string q = $@"SELECT generalprofile.profileid,firstname,midname,lastname,suffix,application.applicationID,concat(lastname, "" "", coalesce(suffix, "" ""), "", "", firstName, "" "", midName, ""."") as name,  sacramentType
                                 FROM GeneralProfile JOIN Applicant ON  GeneralProfile.profileID = Applicant.profileID  JOIN Application ON Application.applicationID = Applicant.applicationID WHERE Application.status = {(int)ApplicationStatus.Pending} and sacramenttype= {sacramentType}";
            return runQuery(q);
        }
        public DataTable getBloodDonorProfile(int ID)
        {
            string q = $@"SELECT * FROM sad2.blooddonor WHERE blooddonorID={ID}";

            return runQuery(q);
        }
        public int countSameDonor(string fn, string mn, string ln, string sf, string address, string contactnum, int bloodtype)
        {
            string q = $@"SELECT count(blooddonorID) from blooddonor where firstname='{fn}' and midname='{mn}' and lastname='{ln}' and suffix='{sf}' and address='{address}' and contactnumber={contactnum} and bloodtype={bloodtype}";

            return int.Parse(runQuery(q).Rows[0][0].ToString());

        }

        public int getBloodDonorWhere(string fn, string mn, string ln, string sf, string address, string contactnum, int bloodtype)
        {
            string q = $@"SELECT blooddonorID from blooddonor where firstname='{fn}' and midname='{mn}' and lastname='{ln}' and suffix='{sf}'and address='{address}' and contactnumber={contactnum} and bloodtype={bloodtype}";

            return int.Parse(runQuery(q).Rows[0][0].ToString());

        }
        public void mergeDonations(int transferFrom, int transferTo)
        {
            DataTable dt = getBloodDonations(transferFrom);
            foreach (DataRow dr in dt.Rows)
            {
                string q = $@"UPDATE `sad2`.`blooddonation` SET `profileID`='{transferTo}' WHERE `bloodDonationID`='{dr[0].ToString()}'";
                runNonQuery(q);
            }
            runNonQuery($@"DELETE FROM `sad2`.`blooddonor` WHERE `blooddonorID`='{transferFrom}'");
        }
        public void editBloodDonor(int blooddonorID, string fn, string mn, string ln, string sf, string address, string contactnum, int bloodtype)
        {
            string q = $@"UPDATE `sad2`.`blooddonor` SET `firstname`='{fn}', `midname`='{mn}', `lastname`='{ln}', `suffix`='{sf}', `bloodtype`='{bloodtype}', `address`='{address}', `contactnumber`='{contactnum}' WHERE `blooddonorID`='{blooddonorID}'";
            runNonQuery(q);
        }

        public DataTable getEmployee(string Username)
        {
            string q = $"Select *,concat(lastname,\" \",coalesce(suffix,\" \"),\"\",firstName,\" \",midname,\".\")as name from user where Username='{Username}'";
            return runQuery(q);
        }

        #region Cash Reciept
        public DataTable getTransactionsByAccountingBookFormatByOrNumber(int BookType, int OR)
        {
            string q = $@"select * from (select primaryincome.primaryIncomeID, sourceName, primaryincome.bookType ,ORnum,primaryIncomeDateTime,(price*quantity)as price,itemType from primaryincome 
                            inner join item on item.primaryIncomeID = primaryincome.primaryincomeid 
                            inner join itemtype on item.itemTypeID=itemtype.itemTypeID 
                            where primaryincome.booktype = {BookType} and 
                            ORnum like '%{OR}%'" +
                            (BookType == 1 ? $@" union all
                            select primaryincome.primaryIncomeID,sourceName,primaryincome.bookType,ORnum,primaryIncomeDateTime,amount,itemType from primaryincome
                            inner join payment on payment.primaryIncomeID = primaryincome.primaryIncomeID
                            inner join sacramentincome on sacramentincome.sacramentIncomeID = payment.sacramentIncomeID
                            inner join application on application.applicationID = sacramentincome.applicationID
                            inner join itemtype on itemtype.itemTypeID = application.sacramentType
                            where primaryincome.booktype = {BookType} and
                            ORnum like '%{OR}%'" : "")
                            + $@") as A  order by ORnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsByAccountingBookFormatByDay(int BookType, int Day, int Month, int Year)
        {
            string q = $@"select * from (select primaryincome.primaryIncomeID, sourceName, primaryincome.bookType ,ORnum,primaryIncomeDateTime,(price*quantity)as price,itemType from primaryincome 
                            inner join item on item.primaryIncomeID = primaryincome.primaryincomeid 
                            inner join itemtype on item.itemTypeID=itemtype.itemTypeID 
                            where DAY(primaryIncomeDateTime) = {Day} and MONTH(primaryIncomeDateTime) = {Month} and YEAR(primaryIncomeDateTime) = {Year} and primaryIncome.bookType = {BookType}" +
                            (BookType == 1 ? $@" union all
                            select primaryincome.primaryIncomeID,sourceName,primaryincome.bookType,ORnum,primaryIncomeDateTime,amount,itemType from primaryincome 
                            inner join payment on payment.primaryIncomeID = primaryincome.primaryIncomeID 
                            inner join sacramentincome on sacramentincome.sacramentIncomeID = payment.sacramentIncomeID 
                            inner join application on application.applicationID = sacramentincome.applicationID 
                            inner join itemtype on itemtype.itemTypeID = application.sacramentType 
                            where DAY(primaryIncomeDateTime) = {Day} and MONTH(primaryIncomeDateTime) = {Month} and YEAR(primaryIncomeDateTime) = {Year} and primaryIncome.bookType = {BookType}" : "") +
                            ") as A  order by ORnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsByAccountingBookFormatByMonth(int BookType, int Month, int Year)
        {
            string q = $@"select * from (select primaryincome.primaryIncomeID, sourceName, primaryincome.bookType ,ORnum,primaryIncomeDateTime,(price*quantity)as price,itemType from primaryincome 
                            inner join item on item.primaryIncomeID = primaryincome.primaryincomeid 
                            inner join itemtype on item.itemTypeID=itemtype.itemTypeID 
                            where MONTH(primaryIncomeDateTime) = {Month} and YEAR(primaryIncomeDateTime) = {Year} and primaryIncome.bookType = {BookType}" +
                            (BookType == 1 ? $@" union all
                            select primaryincome.primaryIncomeID,sourceName,primaryincome.bookType,ORnum,primaryIncomeDateTime,amount,itemType from primaryincome 
                            inner join payment on payment.primaryIncomeID = primaryincome.primaryIncomeID 
                            inner join sacramentincome on sacramentincome.sacramentIncomeID = payment.sacramentIncomeID 
                            inner join application on application.applicationID = sacramentincome.applicationID 
                            inner join itemtype on itemtype.itemTypeID = application.sacramentType 
                            where MONTH(primaryIncomeDateTime) = {Month} and YEAR(primaryIncomeDateTime) = {Year} and primaryIncome.bookType = {BookType}" : "")
                            + ") as A  order by ORnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsByAccountingBookFormatByYear(int BookType, int Year)
        {
            string q = $@"select * from (select primaryincome.primaryIncomeID, sourceName, primaryincome.bookType ,ORnum,primaryIncomeDateTime,(price*quantity)as price,itemType from primaryincome 
                            inner join item on item.primaryIncomeID = primaryincome.primaryincomeid 
                            inner join itemtype on item.itemTypeID=itemtype.itemTypeID 
                            where YEAR(primaryIncomeDateTime) = {Year} and primaryIncome.bookType = {BookType}" +
                            (BookType == 1 ? $@" union all
                            select primaryincome.primaryIncomeID,sourceName,primaryincome.bookType,ORnum,primaryIncomeDateTime,amount,itemType from primaryincome 
                            inner join payment on payment.primaryIncomeID = primaryincome.primaryIncomeID 
                            inner join sacramentincome on sacramentincome.sacramentIncomeID = payment.sacramentIncomeID 
                            inner join application on application.applicationID = sacramentincome.applicationID 
                            inner join itemtype on itemtype.itemTypeID = application.sacramentType 
                            where YEAR(primaryIncomeDateTime) = {Year} and primaryIncome.bookType = {BookType}" : "") +
                            ") as A  order by ORnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsByAccountingBookFormatBetweenDates(int BookType, DateTime from, DateTime to)
        {
            string q = $@"select * from (select primaryincome.primaryIncomeID, sourceName, primaryincome.bookType ,ORnum,primaryIncomeDateTime,(price*quantity)as price,itemType from primaryincome 
                            inner join item on item.primaryIncomeID = primaryincome.primaryincomeid 
                            inner join itemtype on item.itemTypeID=itemtype.itemTypeID 
                            where(primaryIncomeDateTime between '{ from.ToString("yyyy-MM-dd 00:00:00")}' and '{to.ToString("yyyy-MM-dd 23:59:59")}')
                            and primaryIncome.bookType = { BookType }" +
                            (BookType == 1 ? $@" union all
                            select primaryincome.primaryIncomeID,sourceName,primaryincome.bookType,ORnum,primaryIncomeDateTime,amount,itemType from primaryincome 
                            inner join payment on payment.primaryIncomeID = primaryincome.primaryIncomeID 
                            inner join sacramentincome on sacramentincome.sacramentIncomeID = payment.sacramentIncomeID 
                            inner join application on application.applicationID = sacramentincome.applicationID 
                            inner join itemtype on itemtype.itemTypeID = application.sacramentType 
                            where(primaryIncomeDateTime between '{ from.ToString("yyyy-MM-dd 00:00:00")}' and '{to.ToString("yyyy-MM-dd 23:59:59")}')
                            and primaryIncome.bookType = { BookType }" : "") +
                            ") as A  order by ORnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsByAccountingBookFormatRecent(int BookType)
        {
            string q = $@"select * from (select primaryincome.primaryIncomeID, sourceName, primaryincome.bookType ,ORnum,primaryIncomeDateTime,(price*quantity)as price,itemType from primaryincome 
                            inner join item on item.primaryIncomeID = primaryincome.primaryincomeid 
                            inner join itemtype on item.itemTypeID=itemtype.itemTypeID 
                            where(primaryIncomeDateTime between '{ (DateTime.Now - new TimeSpan(7, 0, 0, 0)).ToString("yyyy-MM-dd")}' and '{DateTime.Now.ToString("yyyy-MM-dd 23:59:59")}')
                            and primaryIncome.bookType = {BookType}" +
                            (BookType == 1 ? $@" union all
                            select primaryincome.primaryIncomeID,sourceName,primaryincome.bookType,ORnum,primaryIncomeDateTime,amount,itemType from primaryincome 
                            inner join payment on payment.primaryIncomeID = primaryincome.primaryIncomeID 
                            inner join sacramentincome on sacramentincome.sacramentIncomeID = payment.sacramentIncomeID 
                            inner join application on application.applicationID = sacramentincome.applicationID 
                            inner join itemtype on itemtype.itemTypeID = application.sacramentType 
                             where(primaryIncomeDateTime between '{ (DateTime.Now - new TimeSpan(7, 0, 0, 0)).ToString("yyyy-MM-dd")}' and '{DateTime.Now.ToString("yyyy-MM-dd 23:59:59")}')
                             and primaryIncome.bookType = {BookType}" : "") +
                            ") as A  order by ORnum desc;";
            return runQuery(q);
        }
        //--------------------------------------------------------------------------------------------------------------//
        //Def: total-summation of transactions per row
        //     breakdown- in 1 row you can see all items in an OR
        //     grouped- groups all OR in 1 day
        //     ungrouped- shows individual OR
        public DataTable getSummaryCashDisbursment(DataTable transactions, int bookType)//summary tab
        {

            DataTable allitems = getItems(bookType, 1);
            Dictionary<string, float> itemtypes = new Dictionary<string, float>();

            foreach (DataRow dr in allitems.Rows)
            {
                itemtypes.Add(dr["itemType"].ToString(), 0);
            }

            foreach (DataRow dr in transactions.Rows)
            {
                if (itemtypes.ContainsKey(dr["itemType"].ToString()))
                {
                    itemtypes[dr["itemtype"].ToString()] = float.Parse(itemtypes[dr["itemtype"].ToString()].ToString()) + float.Parse(dr["price"].ToString());
                }
            }

            DataTable output = new DataTable();
            output.Columns.Add("Type", typeof(string));
            output.Columns.Add("Sum", typeof(string));
            foreach (KeyValuePair<string, float> entry in itemtypes)
            {
                if (entry.Value != 0)
                {
                    output.Rows.Add(entry.Key, entry.Value.ToString("0.00"));
                }
            }
            return output;

        }
        public DataTable getTotalUngroupedCashDisbursment(DataTable transactions)//total ungrouped
        {
            if (transactions.Rows.Count > 0)
            {
                DataTable output = new DataTable();
                int currentOR = int.Parse(transactions.Rows[0]["ORnum"].ToString());
                DataRow row = output.NewRow();

                output.Columns.Add("OR Number", typeof(string));
                output.Columns.Add("Amount", typeof(string));
                output.Columns.Add("Name", typeof(string));
                output.Columns.Add("Date Paid", typeof(string));

                foreach (DataRow dr in transactions.Rows)
                {
                    if (currentOR != int.Parse(dr["ORnum"].ToString()))
                    {
                        output.Rows.Add(row);
                        row = output.NewRow();
                        currentOR = int.Parse(dr["ORnum"].ToString());
                    }
                    row["OR Number"] = dr["ORnum"].ToString();
                    row["Name"] = dr["SourceName"].ToString();
                    row["Date Paid"] = DateTime.Parse(dr["primaryincomedatetime"].ToString()).ToString("MMMM dd yyyy");
                    try { row["Amount"] = (float.Parse(row["Amount"].ToString()) + float.Parse(dr["price"].ToString())).ToString("0.00"); } catch { row["Amount"] = float.Parse(dr["price"].ToString()).ToString("0.00"); };
                }
                output.Rows.Add(row);
                return output;
            }
            else { return new DataTable(); }
        }
        public DataTable getTotalGroupedCashDisbursment(DataTable transactions)//total grouped
        {
            if (transactions.Rows.Count > 0)
            {
                DataTable output = new DataTable();
                output.Columns.Add("OR Number", typeof(string));
                output.Columns.Add("Amount", typeof(string));
                output.Columns.Add("Date Paid", typeof(string));
                DataRow row = output.NewRow();
                DateTime currentDate = DateTime.Parse(transactions.Rows[0]["primaryIncomeDateTime"].ToString()).Date;
                int minOR = int.MaxValue;
                int maxOR = 0;

                foreach (DataRow dr in transactions.Rows)
                {
                    if (!currentDate.Equals(DateTime.Parse(dr["primaryIncomeDateTime"].ToString()).Date))
                    {
                        row["OR Number"] = minOR.ToString() + " -- " + maxOR.ToString();
                        output.Rows.Add(row);
                        row = output.NewRow();
                        currentDate = DateTime.Parse(dr["primaryIncomeDateTime"].ToString()).Date;
                        minOR = int.MaxValue;
                        maxOR = 0;
                    }
                    row["Date Paid"] = DateTime.Parse(dr["primaryincomedatetime"].ToString()).ToString("MMMM dd yyyy");
                    if (minOR > int.Parse(dr["ORnum"].ToString()))
                    {
                        minOR = int.Parse(dr["ORnum"].ToString());
                    }

                    if (maxOR < int.Parse(dr["ORnum"].ToString()))
                    {
                        maxOR = int.Parse(dr["ORnum"].ToString());
                    }
                    row["Date Paid"] = DateTime.Parse(dr["primaryincomedatetime"].ToString()).ToString("MMMM dd yyyy");
                    try { row["Amount"] = (float.Parse(row["Amount"].ToString()) + float.Parse(dr["price"].ToString())).ToString("0.00"); } catch { row["Amount"] = float.Parse(dr["price"].ToString()).ToString("0.00"); };
                }
                row["OR Number"] = minOR.ToString() + " -- " + maxOR.ToString();
                output.Rows.Add(row);
                return output;
            }
            else { return new DataTable(); }
        }
        public DataTable getBreakdownUngroupedCashDisbursment(DataTable transactions, int bookType)//breakdown ungrouped
        {
            if (transactions.Rows.Count > 0)
            {
                DataTable output = new DataTable();
                DataTable itemTypes = getItems(bookType, 1);

                output.Columns.Add("OR Number", typeof(string));
                output.Columns.Add("Name", typeof(string));
                output.Columns.Add("Date Paid", typeof(string));

                foreach (DataRow dr in itemTypes.Rows)
                {
                    output.Columns.Add(dr["itemType"].ToString(), typeof(string)); //add columns 
                    output.Columns[dr["itemType"].ToString()].DefaultValue = 0;
                }

                int currentOR = int.Parse(transactions.Rows[0]["ORnum"].ToString());
                DataRow row = output.NewRow();
                foreach (DataRow dr in transactions.Rows)
                {
                    if (currentOR != int.Parse(dr["ORnum"].ToString()))
                    {
                        output.Rows.Add(row);
                        row = output.NewRow();
                        currentOR = int.Parse(dr["ORnum"].ToString());
                    }
                    row["OR Number"] = dr["ORnum"].ToString();
                    row["Name"] = dr["SourceName"].ToString();

                    row["Date Paid"] = DateTime.Parse(dr["primaryincomedatetime"].ToString()).ToString("MMMM dd yyyy, hh:mm");
                    row[dr["itemType"].ToString()] = ((row[dr["itemType"].ToString()] == null ? 0 : float.Parse(row[dr["itemType"].ToString()].ToString())) + float.Parse(dr["price"].ToString())).ToString("0.00");
                }
                output.Rows.Add(row);
                //remove all empty columns
                bool[] columns = new bool[output.Columns.Count - 3];

                foreach (DataRow dr in output.Rows)
                {
                    for (int x = 0; x < output.Columns.Count - 3; x++)
                    {

                        if (dr[x + 3].ToString() != "0")
                        {
                            columns[x] = true;
                        }
                    }
                }
                int drawback = 0;
                for (int x = 0; x < columns.Length; x++)
                {
                    if (columns[x] == false)
                    {

                        output.Columns.RemoveAt(x + 3 - drawback);
                        drawback++;

                    }

                }
                return output;
            }
            else { return new DataTable(); }
        }
        public DataTable getBreakdownGroupedCashDisbursment(DataTable transactions, int bookType) //breakdown grouped
        {
            if (transactions.Rows.Count > 0)
            {
                DateTime currentDate = DateTime.Parse(transactions.Rows[0]["primaryIncomeDateTime"].ToString()).Date;
                int minOR = int.MaxValue;
                int maxOR = 0;

                DataTable output = new DataTable();
                DataTable itemTypes = getItems(bookType, 1);

                output.Columns.Add("OR Number", typeof(string));
                output.Columns.Add("Date Paid", typeof(string));

                foreach (DataRow dr in itemTypes.Rows)
                {
                    output.Columns.Add(dr["itemType"].ToString(), typeof(string)); //add columns 
                    output.Columns[dr["itemType"].ToString()].DefaultValue = 0;
                }
                int currentOR = int.Parse(transactions.Rows[0]["ORnum"].ToString());
                DataRow row = output.NewRow();
                foreach (DataRow dr in transactions.Rows)
                {
                    if (!currentDate.Equals(DateTime.Parse(dr["primaryIncomeDateTime"].ToString()).Date))
                    {
                        row["OR Number"] = minOR.ToString() + " -- " + maxOR.ToString();
                        output.Rows.Add(row);
                        row = output.NewRow();
                        currentDate = DateTime.Parse(dr["primaryIncomeDateTime"].ToString()).Date;
                        minOR = int.MaxValue;
                        maxOR = 0;
                    }
                    row["Date Paid"] = DateTime.Parse(dr["primaryincomedatetime"].ToString()).ToString("MMMM dd yyyy");
                    if (minOR > int.Parse(dr["ORnum"].ToString()))
                    {
                        minOR = int.Parse(dr["ORnum"].ToString());
                    }

                    if (maxOR < int.Parse(dr["ORnum"].ToString()))
                    {
                        maxOR = int.Parse(dr["ORnum"].ToString());
                    }
                    //per itemtype code starts here
                    row["Date Paid"] = DateTime.Parse(dr["primaryincomedatetime"].ToString()).ToString("MMMM dd yyyy");
                    row[dr["itemType"].ToString()] = ((row[dr["itemType"].ToString()] == null ? 0 : float.Parse(row[dr["itemType"].ToString()].ToString())) + float.Parse(dr["price"].ToString())).ToString("0.00");
                    //per item type code ends here
                }
                row["OR Number"] = minOR.ToString() + " -- " + maxOR.ToString();
                output.Rows.Add(row);

                bool[] columns = new bool[output.Columns.Count - 3];

                foreach (DataRow dr in output.Rows)
                {
                    for (int x = 0; x < output.Columns.Count - 3; x++)
                    {

                        if (dr[x + 3].ToString() != "0")
                        {
                            columns[x] = true;
                        }
                    }
                }
                int drawback = 0;
                for (int x = 0; x < columns.Length; x++)
                {
                    if (columns[x] == false)
                    {

                        output.Columns.RemoveAt(x + 3 - drawback);
                        drawback++;

                    }

                }
                return output;
            }
            else { return new DataTable(); }
        }
        #endregion



        public int getMaxCNNumber(int book)
        {
            string q = $@"select max(checkNum) from cashreleasevoucher where booktype = {book}";
            int holder = 1;
            if (int.TryParse(runQuery(q).Rows[0][0].ToString(), out holder))
            {
                return holder + 1;
            }
            return 1;
        }
        public int getMaxCVNumber(int book)
        {
            string q = $@"select max(CVnum) from cashreleasevoucher where booktype = {book}";
            int holder = 1;
            if (int.TryParse(runQuery(q).Rows[0][0].ToString(), out holder))
            {
                return holder + 1;
            }
            return 1;
        }

        public int addCashRelease(string remark, int checkNum, int CVnum, int bookType, string name)
        {
            string q = $@"INSERT INTO `sad2`.`cashreleasevoucher` (`cashReleaseDateTime`, `remark`, `checkNum`, `CVnum`, `bookType`, `name`) VALUES ('{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{remark}', '{checkNum}', '{CVnum}', '{bookType}','{name}'); SELECT LAST_INSERT_ID()";
            return int.Parse(runQuery(q).Rows[0][0].ToString());
        }
        public void addCashReleaseItem(int CashReleaseVoucherID, int cashReleaseTypeID, decimal releaseAmount)
        {
            string q = $@"INSERT INTO `sad2`.`cashreleaseitem` (`CashReleaseVoucherID`, `cashReleaseTypeID`, `releaseAmount`) VALUES ('{CashReleaseVoucherID}', '{cashReleaseTypeID}', '{releaseAmount}')";
            runNonQuery(q);
        }

        public DataTable getTransactionsCRBByAccountingBookFormatByOrNumber(int BookType, int checknum, int CVnum)
        {
            string q = $@"SELECT * FROM cashreleaseitem 
                        INNER JOIN itemtype on itemtype.itemTypeID = cashreleaseitem.cashReleaseTypeID 
                        INNER JOIN cashreleasevoucher on cashreleasevoucher.cashreleasevoucherid = cashreleaseitem.CashReleaseVoucherID 
                        where 
                        itemtype.booktype = {BookType}  
                        and cashreceipt_cashdisbursment =2,
                        checknum like '%{checknum}%' and
                        CVnum like '%{CVnum}%'
                        order by CVnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsCRBByAccountingBookFormatByDay(int BookType, int Day, int Month, int Year)
        {
            string q = $@"SELECT * FROM cashreleaseitem 
                        INNER JOIN itemtype on itemtype.itemTypeID = cashreleaseitem.cashReleaseTypeID 
                        INNER JOIN cashreleasevoucher on cashreleasevoucher.cashreleasevoucherid = cashreleaseitem.CashReleaseVoucherID 
                        where 
                        itemtype.booktype = {BookType} and 
						DAY(cashReleaseDateTime) = {Day} and MONTH(cashReleaseDateTime) = {Month} and YEAR(cashReleaseDateTime) = {Year}
                        order by CVnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsCRBByAccountingBookFormatByMonth(int BookType, int Month, int Year)
        {
            string q = $@"SELECT * FROM cashreleaseitem 
                        INNER JOIN itemtype on itemtype.itemTypeID = cashreleaseitem.cashReleaseTypeID 
                        INNER JOIN cashreleasevoucher on cashreleasevoucher.cashreleasevoucherid = cashreleaseitem.CashReleaseVoucherID 
                        where 
                        MONTH(cashReleaseDateTime) = {Month} and YEAR(cashReleaseDateTime) = {Year}
                        and cashreleasevoucher.bookType = {BookType}
                        order by CVnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsCRBByAccountingBookFormatByYear(int BookType, int Year)
        {
            string q = $@"SELECT * FROM cashreleaseitem 
                        INNER JOIN itemtype on itemtype.itemTypeID = cashreleaseitem.cashReleaseTypeID 
                        INNER JOIN cashreleasevoucher on cashreleasevoucher.cashreleasevoucherid = cashreleaseitem.CashReleaseVoucherID 
                        where 
                        YEAR(cashReleaseDateTime) = {Year}
                        and cashreleasevoucher.bookType = {BookType}
                        order by CVnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsCRBByAccountingBookFormatBetweenDates(int BookType, DateTime from, DateTime to)
        {
            string q = $@"SELECT * FROM cashreleaseitem 
                        INNER JOIN itemtype on itemtype.itemTypeID = cashreleaseitem.cashReleaseTypeID 
                        INNER JOIN cashreleasevoucher on cashreleasevoucher.cashreleasevoucherid = cashreleaseitem.CashReleaseVoucherID 
                        where 
                        (cashreleasedatetime'{ from.ToString("yyyy-MM-dd 00:00:00")}' and '{to.ToString("yyyy-MM-dd 23:59:59")}')
                        and cashreleasevoucher.bookType = { BookType }
                        order by CVnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsCRBByAccountingBookFormatRecent(int BookType)
        {
            string q = $@"SELECT * FROM cashreleaseitem 
                        INNER JOIN itemtype on itemtype.itemTypeID = cashreleaseitem.cashReleaseTypeID 
                        INNER JOIN cashreleasevoucher on cashreleasevoucher.cashreleasevoucherid = cashreleaseitem.CashReleaseVoucherID 
                        where 
                        (cashreleasedatetime between '{ (DateTime.Now - new TimeSpan(7, 0, 0, 0)).ToString("yyyy-MM-dd")}' and '{DateTime.Now.ToString("yyyy-MM-dd 23:59:59")}')
                        and cashreleasevoucher.bookType = {BookType}
                        order by CVnum desc;";
            return runQuery(q);
        }

        public DataTable getSummaryCashRelease(DataTable transactions, int bookType)//summary tab
        {
            if (transactions.Rows.Count > 0)
            {
                DataTable allitems = getItems(bookType, 2);
                Dictionary<string, float> itemtypes = new Dictionary<string, float>();

                foreach (DataRow dr in allitems.Rows)
                {
                    itemtypes.Add(dr["itemType"].ToString(), 0);
                }

                foreach (DataRow dr in transactions.Rows)
                {
                    if (itemtypes.ContainsKey(dr["itemType"].ToString()))
                    {
                        itemtypes[dr["itemType"].ToString()] = float.Parse(itemtypes[dr["itemType"].ToString()].ToString()) + float.Parse(dr["releaseAmount"].ToString());
                    }
                }
                DataTable output = new DataTable();
                output.Columns.Add("Type", typeof(string));
                output.Columns.Add("Sum", typeof(string));

                foreach (KeyValuePair<string, float> entry in itemtypes)
                {
                    if (entry.Value != 0)
                    {
                        output.Rows.Add(entry.Key, entry.Value.ToString("0.00"));
                    }
                }

                return output;
            }
            else
            {
                return new DataTable();
            }


        }
        public DataTable getTotalUngroupedCashRelease(DataTable transactions)//total ungrouped
        {
            if (transactions.Rows.Count > 0)
            {
                DataTable output = new DataTable();
                int currentOR = int.Parse(transactions.Rows[0]["CVnum"].ToString());
                DataRow row = output.NewRow();

                output.Columns.Add("CVnum", typeof(string));
                output.Columns.Add("CheckNum", typeof(string));
                output.Columns.Add("Amount", typeof(string));
                output.Columns.Add("Name", typeof(string));
                output.Columns.Add("Date Paid", typeof(string));

                foreach (DataRow dr in transactions.Rows)
                {
                    if (currentOR != int.Parse(dr["CVnum"].ToString()))
                    {
                        output.Rows.Add(row);
                        row = output.NewRow();
                        currentOR = int.Parse(dr["CVnum"].ToString());
                    }
                    row["CVnum"] = dr["CVnum"].ToString();
                    row["CheckNum"] = dr["checkNum"].ToString();
                    row["Name"] = dr["name"].ToString();
                    row["Date Paid"] = DateTime.Parse(dr["cashReleaseDateTime"].ToString()).ToString("MMMM dd yyyy, hh:mm");
                    try { row["Amount"] = (float.Parse(row["Amount"].ToString()) + float.Parse(dr["releaseAmount"].ToString())).ToString("0.00"); } catch { row["Amount"] = (dr["releaseAmount"].ToString()); };
                }
                output.Rows.Add(row);
                return output;
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable getTotalGroupedCashRelease(DataTable transactions)//total grouped
        {
            if (transactions.Rows.Count > 0)
            {
                DataTable output = new DataTable();
                output.Columns.Add("CVnum", typeof(string));
                output.Columns.Add("CheckNum", typeof(string));
                output.Columns.Add("Amount", typeof(string));
                output.Columns.Add("Date Paid", typeof(string));
                DataRow row = output.NewRow();
                DateTime currentDate = DateTime.Parse(transactions.Rows[0]["cashReleaseDateTime"].ToString()).Date;
                int minCV = int.MaxValue;
                int maxCV = 0;
                int minCN = int.MaxValue;
                int maxCN = 0;
                foreach (DataRow dr in transactions.Rows)
                {
                    if (!currentDate.Equals(DateTime.Parse(dr["cashReleaseDateTime"].ToString()).Date))
                    {
                        row["CVnum"] = minCV.ToString() + " -- " + maxCV.ToString();
                        row["CheckNum"] = minCN.ToString() + " -- " + maxCN.ToString();
                        output.Rows.Add(row);
                        row = output.NewRow();
                        currentDate = DateTime.Parse(dr["cashReleaseDateTime"].ToString()).Date;
                        minCV = int.MaxValue;
                        maxCV = 0;
                        minCN = int.MaxValue;
                        maxCN = 0;
                    }
                    row["Date Paid"] = DateTime.Parse(dr["cashReleaseDateTime"].ToString()).ToString("MMMM dd yyyy");
                    if (minCV > int.Parse(dr["CVnum"].ToString()))
                    {
                        minCV = int.Parse(dr["CVnum"].ToString());
                        minCN = int.Parse(dr["checkNum"].ToString());
                    }

                    if (maxCV < int.Parse(dr["CVnum"].ToString()))
                    {
                        maxCV = int.Parse(dr["CVnum"].ToString());
                        maxCN = int.Parse(dr["checkNum"].ToString());
                    }
                    row["Date Paid"] = DateTime.Parse(dr["cashReleaseDateTime"].ToString()).ToString("MMMM dd yyyy");
                    try { row["Amount"] = (float.Parse(row["Amount"].ToString()) + float.Parse(dr["releaseAmount"].ToString())).ToString("0.00"); } catch { row["Amount"] = dr["releaseAmount"].ToString(); };
                }
                row["CVnum"] = minCV.ToString() + " -- " + maxCV.ToString();
                row["CheckNum"] = minCN.ToString() + " -- " + maxCN.ToString();
                output.Rows.Add(row);
                return output;
            }
            else
            {
                return new DataTable();
            }
        }

        public DataTable getBreakdownUngroupedCashRelease(DataTable transactions, int bookType)//breakdown ungrouped
        {
            if (transactions.Rows.Count > 0)
            {
                DataTable output = new DataTable();
                DataTable itemTypes = getItems(bookType, 2);

                output.Columns.Add("CVnum", typeof(string));
                output.Columns.Add("CheckNum", typeof(string));
                output.Columns.Add("Name", typeof(string));
                output.Columns.Add("Date Paid", typeof(string));

                foreach (DataRow dr in itemTypes.Rows)
                {
                    output.Columns.Add(dr["itemtype"].ToString(), typeof(string)); //add columns 
                    output.Columns[dr["itemtype"].ToString()].DefaultValue = 0;

                }

                int currentOR = int.Parse(transactions.Rows[0]["CVnum"].ToString());
                DataRow row = output.NewRow();
                foreach (DataRow dr in transactions.Rows)
                {
                    if (currentOR != int.Parse(dr["CVnum"].ToString()))
                    {

                        output.Rows.Add(row);
                        row = output.NewRow();
                        currentOR = int.Parse(dr["CVnum"].ToString());
                    }
                    row["CVnum"] = dr["CVnum"].ToString();
                    row["CheckNum"] = dr["checkNum"].ToString();
                    row["Name"] = dr["name"].ToString();
                    row["Date Paid"] = DateTime.Parse(dr["cashReleaseDateTime"].ToString()).ToString("MMMM dd yyyy, hh:mm");
                    row[dr["itemtype"].ToString()] = ((row[dr["itemtype"].ToString()] == null ? 0 : float.Parse(row[dr["itemtype"].ToString()].ToString())) + float.Parse(dr["releaseAmount"].ToString())).ToString("0.00");
                }
                output.Rows.Add(row);

                bool[] columns = new bool[output.Columns.Count - 3];

                foreach (DataRow dr in output.Rows)
                {
                    for (int x = 0; x < output.Columns.Count - 3; x++)
                    {

                        if (dr[x + 3].ToString() != "0")
                        {
                            columns[x] = true;
                        }
                    }
                }
                int drawback = 0;
                for (int x = 0; x < columns.Length; x++)
                {
                    if (columns[x] == false)
                    {

                        output.Columns.RemoveAt(x + 3 - drawback);
                        drawback++;

                    }

                }
                return output;
            }
            else
            {
                return new DataTable();
            }
        }

        public DataTable getBreakdownGroupedCashRelease(DataTable transactions, int bookType) //breakdown grouped
        {
            if (transactions.Rows.Count > 0)
            {
                DateTime currentDate = DateTime.Parse(transactions.Rows[0]["cashReleaseDateTime"].ToString()).Date;
                DataTable output = new DataTable();
                DataTable itemTypes = getItems(bookType, 2);

                output.Columns.Add("CVnum", typeof(string));
                output.Columns.Add("CheckNum", typeof(string));
                output.Columns.Add("Date Paid", typeof(string));

                foreach (DataRow dr in itemTypes.Rows)
                {
                    output.Columns.Add(dr["itemtype"].ToString(), typeof(string)); //add columns 
                    output.Columns[dr["itemtype"].ToString()].DefaultValue = 0;
                }

                int minCV = int.MaxValue;
                int maxCV = 0;
                int minCN = int.MaxValue;
                int maxCN = 0;

                DataRow row = output.NewRow();
                foreach (DataRow dr in transactions.Rows)
                {
                    if (!currentDate.Equals(DateTime.Parse(dr["cashReleaseDateTime"].ToString()).Date))
                    {
                        row["CVnum"] = minCV.ToString() + " -- " + maxCV.ToString();
                        row["CheckNum"] = minCN.ToString() + " -- " + maxCN.ToString();
                        output.Rows.Add(row);
                        row = output.NewRow();
                        currentDate = DateTime.Parse(dr["cashReleaseDateTime"].ToString()).Date;
                        minCV = int.MaxValue;
                        maxCV = 0;
                        minCN = int.MaxValue;
                        maxCN = 0;
                    }
                    row["Date Paid"] = DateTime.Parse(dr["cashReleaseDateTime"].ToString()).ToString("MMMM dd yyyy");
                    if (minCV > int.Parse(dr["CVnum"].ToString()))
                    {
                        minCV = int.Parse(dr["CVnum"].ToString());
                        minCN = int.Parse(dr["checkNum"].ToString());
                    }

                    if (maxCV < int.Parse(dr["CVnum"].ToString()))
                    {
                        maxCV = int.Parse(dr["CVnum"].ToString());
                        maxCN = int.Parse(dr["checkNum"].ToString());
                    }
                    //per itemtype code starts here
                    row["Date Paid"] = DateTime.Parse(dr["cashReleaseDateTime"].ToString()).ToString("MMMM dd yyyy");
                    row[dr["itemtype"].ToString()] = (row[dr["itemtype"].ToString()] == null ? "0" : (float.Parse(row[dr["itemtype"].ToString()].ToString()) + float.Parse(dr["releaseAmount"].ToString())).ToString("0.00"));
                    //per item type code ends here
                }
                row["CVnum"] = minCV.ToString() + " --" + maxCV.ToString();
                row["CheckNum"] = minCN.ToString() + " -- " + maxCN.ToString();
                output.Rows.Add(row);

                bool[] columns = new bool[output.Columns.Count - 3];

                foreach (DataRow dr in output.Rows)
                {
                    for (int x = 0; x < output.Columns.Count - 3; x++)
                    {

                        if (dr[x + 3].ToString() != "0")
                        {
                            columns[x] = true;
                        }
                    }
                }
                int drawback = 0;
                for (int x = 0; x < columns.Length; x++)
                {
                    if (columns[x] == false)
                    {

                        output.Columns.RemoveAt(x + 3 - drawback);
                        drawback++;

                    }

                }
                return output;
            }
            else
            {
                return new DataTable();
            }
        }

        public DataTable getBloodDonors()
        {
            string q = $@"select blooddonor.blooddonorID , concat(lastname,"","",coalesce("""",suffix),"" "",firstname,"" "",midname)as name,
                        case 
                        when bloodType =1 then 'A+' 
                        when bloodType =2 then 'A-'  
                        when bloodType =3 then 'B+'  
                        when bloodType =4 then 'B-'  
                        when bloodType =5 then 'AB+'  
                        when bloodType =6 then 'AB-'  
                        when bloodType =7 then 'O+'  
                        when bloodType =8 then 'O-' end as bloodT,
                        count(bloodDonationID),
                        concat(""(+63)"",contactnumber) as contactnumber,
                        address
                        from blooddonor
                        left outer join blooddonation on blooddonation.profileid = blooddonor.blooddonorID
                        left outer join blooddonationevent on blooddonationevent.bloodDonationEventID = blooddonation.bloodDonationEventID
                        group by blooddonor.blooddonorID";
            return runQuery(q);
        }

        public DataTable getBloodDonorsOnEvent(int blooddonationeventid)
        {
            string q = $@"select 
                        blooddonor.blooddonorID, concat(lastname,"","",coalesce("""",suffix),"" "",firstname,"" "",midname)as name,
                        case 
                        when bloodType =1 then 'A+' 
                        when bloodType =2 then 'A-'  
                        when bloodType =3 then 'B+'  
                        when bloodType =4 then 'B-'  
                        when bloodType =5 then 'AB+'  
                        when bloodType =6 then 'AB-'  
                        when bloodType =7 then 'O+'  
                        when bloodType =8 then 'O-' end as bloodT,
                        donationid,
                        address,
                        concat(""(+63)"",contactnumber) as contactnumber,
                        eventname
                        from blooddonor
                        inner join blooddonation on blooddonation.profileid = blooddonor.blooddonorID
                        inner join blooddonationevent on blooddonationevent.bloodDonationEventID = blooddonation.bloodDonationEventID
                        where bloodDonationEvent.bloodDonationEventID = ""{blooddonationeventid}""";
            return runQuery(q);
        }
        public DataTable getBloodDonorsOnDate(DateTime Start)
        {
            string q = $@"select 
                        blooddonor.blooddonorID, concat(lastname,"","",coalesce("""",suffix),"" "",firstname,"" "",midname)as name,
                        case 
                        when bloodType =1 then 'A+' 
                        when bloodType =2 then 'A-'  
                        when bloodType =3 then 'B+'  
                        when bloodType =4 then 'B-'  
                        when bloodType =5 then 'AB+'  
                        when bloodType =6 then 'AB-'  
                        when bloodType =7 then 'O+'  
                        when bloodType =8 then 'O-' end as bloodT,
                        donationid,
                        address,
                        concat(""(+63)"",contactnumber) as contactnumber,
                        eventname
                        from blooddonor
                        inner join blooddonation on blooddonation.profileid = blooddonor.blooddonorID
                        inner join blooddonationevent on blooddonationevent.bloodDonationEventID = blooddonation.bloodDonationEventID
                        where startDateTime>=""{Start.ToString("yyyy-MM-dd 00:00:00")}"" and startDateTime<=""{Start.ToString("yyyy-MM-dd 23:59:59")}""";
            return runQuery(q);
        }
        public DataTable getBloodDonorsOnDateRange(DateTime Start, DateTime Stop)
        {
            string q = $@"select 
                        blooddonor.blooddonorID, concat(lastname,"","",coalesce("""",suffix),"" "",firstname,"" "",midname)as name,
                        case 
                        when bloodType =1 then 'A+' 
                        when bloodType =2 then 'A-'  
                        when bloodType =3 then 'B+'  
                        when bloodType =4 then 'B-'  
                        when bloodType =5 then 'AB+'  
                        when bloodType =6 then 'AB-'  
                        when bloodType =7 then 'O+'  
                        when bloodType =8 then 'O-' end as bloodT,
                        donationid,
                        address,
                        concat(""(+63)"",contactnumber) as contactnumber,
                        eventname
                        from blooddonor
                        inner join blooddonation on blooddonation.profileid = blooddonor.blooddonorID
                        inner join blooddonationevent on blooddonationevent.bloodDonationEventID = blooddonation.bloodDonationEventID
                        where startDateTime between ""{Start.ToString("yyyy-MM-dd 00:00:00")}"" and ""{Stop.ToString("yyyy-MM-dd 23:59:59")}""";
            return runQuery(q);
        }
        public DataTable getTotalDonationsOnEvents()
        {
            string q = $@"select blooddonationevent.bloodDonationEventID,eventname,count(donationid) as total from blooddonor 
                            inner join blooddonation on blooddonation.profileid =blooddonor.blooddonorID
                            inner join blooddonationevent on blooddonationevent.bloodDonationEventID=blooddonation.bloodDonationEventID
                            group by bloodDonationEvent.bloodDonationEventID;";
            return runQuery(q);
        }

        public DataTable getsummaryOfBloodleting(DataTable bloodlettingData)
        {
            DataTable Events = getBloodlettingEvents();
            Dictionary<string, float> EventList = new Dictionary<string, float>();

            foreach (DataRow dr in Events.Rows)
            {
                EventList.Add(dr["eventName"].ToString(), 0);
            }

            foreach (DataRow dr in bloodlettingData.Rows)
            {
                if (EventList.ContainsKey(dr["eventName"].ToString()))
                {
                    EventList[dr["eventName"].ToString()] = EventList[dr["eventName"].ToString()] + 1;
                }
            }
            DataTable output = new DataTable();
            output.Columns.Add("Event", typeof(string));
            output.Columns.Add("Sum", typeof(float));
            foreach (KeyValuePair<string, float> entry in EventList)
            {
                if (entry.Value != 0)
                {
                    output.Rows.Add(entry.Key, entry.Value);
                }
            }
            return output;
        }

        public DataTable getBloodDonorsLike(string name)
        {
            string q = $@"select blooddonor.blooddonorID , concat(lastname,"","",coalesce("""",suffix),"" "",firstname,"" "",midname)as name,
                        case 
                        when bloodType =1 then 'A+' 
                        when bloodType =2 then 'A-'  
                        when bloodType =3 then 'B+'  
                        when bloodType =4 then 'B-'  
                        when bloodType =5 then 'AB+'  
                        when bloodType =6 then 'AB-'  
                        when bloodType =7 then 'O+'  
                        when bloodType =8 then 'O-' end as bloodT,
                        count(donationid),
                        concat(""(+63)"",contactnumber) as contactnumber,
                        address
                        from blooddonor
                        inner join blooddonation on blooddonation.profileid = blooddonor.blooddonorID
                        inner join blooddonationevent on blooddonationevent.bloodDonationEventID = blooddonation.bloodDonationEventID
                        where firstname like ""%{name}%"" or lastname like ""%{name}%""
                        group by blooddonor.blooddonorID";
            return runQuery(q);
        }
        public DataTable getBloodlettingEventsLike(string name)
        {
            string q = $@"SELECT * FROM sad2.blooddonationevent where eventName like ""%{name}%""";
            return runQuery(q);
        }
        public DataTable getAllDonations()
        {
            string q = $@"select blooddonor.blooddonorID , concat(lastname,"","",coalesce("""",suffix),"" "",firstname,"" "",midname)as name,
                        case 
                        when bloodType =1 then 'A+' 
                        when bloodType =2 then 'A-'  
                        when bloodType =3 then 'B+'  
                        when bloodType =4 then 'B-'  
                        when bloodType =5 then 'AB+'  
                        when bloodType =6 then 'AB-'  
                        when bloodType =7 then 'O+'  
                        when bloodType =8 then 'O-' end as bloodT,
                        eventname,
                        concat(""(+63)"",contactnumber) as contactnumber,
                        address
                        from blooddonor
                        inner join blooddonation on blooddonation.profileid =blooddonor.blooddonorID
                        inner join blooddonationevent on blooddonationevent.bloodDonationEventID = blooddonation.bloodDonationEventID";
            return runQuery(q);
        }

        public DataTable getApplicationPaymentOf(int applicationID)
        {
            string q = $@"select price,sum(amount)as paid from application 
                        left outer join sacramentincome on sacramentincome.applicationID= application.applicationid 
                        left outer join payment on payment.sacramentIncomeID = sacramentincome.sacramentIncomeID 
                        where application.applicationID={applicationID}";
            return runQuery(q);
        }

        public void editSacramentIncome(decimal price, int sacramentIncomeID)
        {
            string q = $@"UPDATE `sad2`.`sacramentincome` SET `price`='{price}' WHERE `sacramentIncomeID`='{sacramentIncomeID}';";
            runNonQuery(q);
        }
        //select only those who have not fully paid


        public void DisplayInExcel(DataGridView dgv)
        {
            var excelApp = new Excel.Application();
            excelApp.Visible = true;
            excelApp.Workbooks.Add();
            Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

            int a = 65;
            foreach (DataGridViewColumn dc in dgv.Columns)
            {
                workSheet.Cells[1, ((char)a).ToString()] = dc.HeaderText.ToString();
                workSheet.Columns[a - 64].AutoFit();
                a++;
            }
            int b = 2;
            foreach (DataGridViewRow dgvr in dgv.Rows)
            {
                for (int x = 65; x < a; x++)
                {
                    workSheet.Cells[b, ((char)x).ToString()] = dgvr.Cells[x - 65].Value.ToString();
                }
                b++;

            }

        }
        public DataTable getItemsLike(string like, int cashreceipt_cashdisbursment)//no booktype needed because for search only
        {
            string q = $@"SELECT itemType, itemTypeID  ,case when bookType=1 then 'Parish' when bookType=2 then 'Community' when bookType=3 then 'Postulancy' end as Book,
                     case when status=1 then 'Active' when status=2 then 'Inactive' end as Status , concat('₱',' ',suggestedprice)as SuggestedPrice FROM sad2.itemtype where itemType like '%{like}%' and cashreceipt_cashdisbursment ={cashreceipt_cashdisbursment};";
            return runQuery(q);
        }
        public DataTable getItems(int bookType, int cashreceipt_cashdisbursment)
        {
            string q = $@"SELECT itemType, itemTypeID  ,case when bookType=1 then 'Parish' when bookType=2 then 'Community' when bookType=3 then 'Postulancy' end as Book,
                     case when status=1 then 'Active' when status=2 then 'Inactive' end as Status ,suggestedprice FROM sad2.itemtype where booktype={bookType} and cashreceipt_cashdisbursment ={cashreceipt_cashdisbursment}";
            return runQuery(q);
        }
        public DataTable getItemsActive(int bookType, int cashreceipt_cashdisbursment)
        {
            string q = $@"SELECT itemType, itemTypeID  ,case when bookType=1 then 'Parish' when bookType=2 then 'Community' when bookType=3 then 'Postulancy' end as Book,
                     case when status=1 then 'Active' when status=2 then 'Inactive' end as Status ,suggestedprice FROM sad2.itemtype where booktype={bookType} and cashreceipt_cashdisbursment ={cashreceipt_cashdisbursment}  and status = 1";
            return runQuery(q);
        }
        public int getDonationIDPrimaryKey(string donationID)
        {
            string q = $@"select * from blooddonation where donationID='{donationID}' and bloodclaimant is null";
            DataTable a = runQuery(q);
            if (a.Rows.Count > 0)
            {
                return int.Parse(a.Rows[0]["bloodDonationID"].ToString());
            }
            else
            {
                return -1;
            }
        }
        public int AddClaimant(string firstname, string midname, string lastname, string suffix)
        {
            string q = $@"INSERT INTO `sad2`.`bloodclaimant` ( `firstname`, `midname`, `lastname`, `suffix`) VALUES ('{firstname}', '{midname}', '{lastname}', '{suffix}');SELECT MAX(bloodclaimantID) FROM bloodclaimant; ";
            return int.Parse(runQuery(q).Rows[0][0].ToString());
        }
        public void ClaimBloodDonation(int bloodDonationID, int claimantID)
        {
            string q = $@"UPDATE `sad2`.`blooddonation` SET `bloodclaimant`='{claimantID}' WHERE `bloodDonationID`='{bloodDonationID}'";
            runNonQuery(q);
        }
        public DataTable getDonationClaims()
        {
            string q = $@"select *, concat(blooddonor.lastname,"" "",coalesce(blooddonor.suffix,"" ""),"" "",blooddonor.firstName,"" "",blooddonor.midname,""."")as Donor,
                        concat(bloodclaimant.lastname, "" "", coalesce(bloodclaimant.suffix, "" ""), "" "", bloodclaimant.firstName, "" "", bloodclaimant.midname, ""."") as Claimant
                        from blooddonation inner join bloodclaimant on bloodclaimant.bloodclaimantID = blooddonation.bloodclaimant inner
                        join blooddonor on blooddonor.blooddonorID = blooddonation.profileID order by donationID desc";
            return runQuery(q);
        }
        public DataTable getDonationClaimsWhereDonationIDLike(string like)
        {
            string q = $@"select *, concat(blooddonor.lastname,"" "",coalesce(blooddonor.suffix,"" ""),"" "",blooddonor.firstName,"" "",blooddonor.midname,""."")as Donor,
                        concat(bloodclaimant.lastname, "" "", coalesce(bloodclaimant.suffix, "" ""), "" "", bloodclaimant.firstName, "" "", bloodclaimant.midname, ""."") as Claimant
                        from blooddonation inner join bloodclaimant on bloodclaimant.bloodclaimantID = blooddonation.bloodclaimant inner
                        join blooddonor on blooddonor.blooddonorID = blooddonation.profileID where donationID like ""%{like}%"" order by donationID desc";
            return runQuery(q);
        }



        public bool AddUser(string fn, string mn, string ln, string sf, string username, string password, UserPrivileges privilege)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            User user = User.getCurrentUser();
            //string q = $@"INSERT INTO `sad2`.`user` (`firstname`, `midname`, `lastname`, `suffix`, `username`, `pass`, `status`, `addedBy`, `privileges`) VALUES ('{fn}', '{mn}', '{ln}', '{sf}', '{username}', '{savedPasswordHash}',1,{user.userID},{(int)privilege});";
            string q = "INSERT INTO User(firstName, midName, lastName, suffix, username, pass, status, addedBy, privileges) VALUES (@firstName, @midName, @lastName, @suffix, @username, @pass, @status, @addedBy, @privileges)";
            bool success = ExecuteNonQuery(q, fn, mn, ln, sf, username, savedPasswordHash, (int)UserStatus.Active, user.userID, (int)privilege);
            return success;
        }

        public DataTable getUserPassword(string userName)
        {
            string q = "SELECT pass FROM user WHERE userName = @userName AND status = @status";
            DataTable dt = ExecuteQuery(q, userName, (int)UserStatus.Active);

            return dt;
        }
        public DataTable getAdminPassword(string userName)
        {
            string q = $@"SELECT pass FROM user WHERE userName = @userName AND status = @status AND privileges={(int)UserPrivileges.Supervisor}";
            DataTable dt = ExecuteQuery(q, userName, (int)UserStatus.Active);

            return dt;
        }
        public bool editUserResetPassword(string fn, string mn, string ln, string sf, string username, string password, UserStatus status, UserPrivileges privilege, int userID)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            string q = "UPDATE User SET firstName = @firstName, midName = @midName, lastName = @lastName, suffix = @suffix, userName = @userName, pass = @pass, status = @status, privileges = @privileges WHERE userID = @userID";
            //string q = $@"UPDATE `sad2`.`user` SET `firstname`='{fn}', `midname`='{mn}', `lastname`='{ln}', `suffix`='{sf}', `username`='{username}', `pass`='{password}',`status`='{(status ? 1 : 2)}',`privileges`='{privilege}' WHERE `userID`='{userID}';";
            bool success = ExecuteNonQuery(q, fn, mn, ln, sf, username, savedPasswordHash, (int)status, (int)privilege, userID);
            return success;
        }
        public bool editEmployee(string fn, string mn, string ln, string sf, string username, UserStatus status, UserPrivileges privilege, int userID)
        {
            string q = "UPDATE User SET firstName = @firstName, midName = @midName, lastName = @lastName, suffix = @suffix, username = @username, status = @status, privileges = @privileges WHERE userID = @userID";
            bool succes = ExecuteNonQuery(q, fn, mn, ln, sf, username, (int)status, (int)privilege, userID);
            return succes;
        }

        /// <summary>
        /// Returns DataTable that has no superuser
        /// </summary>
        /// <returns></returns>
        public DataTable getEmployeesNoSuperUser()
        {
            string q = "SELECT userID, firstName, midName, lastName, suffix, username, status, privileges, CONCAT_WS(' ', firstName, midName, lastName, suffix) AS name FROM User WHERE privileges != 4";
            DataTable dt = ExecuteQuery(q);
            return dt;
        }

        public DataTable getEmployees()
        {
            string q = "SELECT userID, firstName, midName, lastName, suffix, username, status, privileges, CONCAT_WS(' ', firstName, midName, lastName, suffix) AS name FROM User";
            DataTable dt = ExecuteQuery(q);
            return dt;
        }
        public DataTable getGeneralProfilesProper()
        {
            string q = $@"SELECT  profileid, CONCAT(firstname, ' ', midname, ' ' , lastname, ' ', COALESCE(suffix, '')) as Name,birthdate,case 
                        when gender = 1 then 'Male'
                        when gender = 2 then 'Female'
                        end as gender,birthplace, residence FROM GeneralProfile";

            DataTable dt = runQuery(q);


            return dt;
        }
        public DataTable getGeneralProfilesProperLike(string like)
        {
            string q = $@"SELECT  profileid, CONCAT(firstname, ' ', midname, ' ' , lastname, ' ', COALESCE(suffix, '')) as Name,birthdate,case 
                        when gender = 1 then 'Male'
                        when gender = 2 then 'Female'
                        end as gender,birthplace, residence FROM GeneralProfile where firstname like ""%{like}%"" or midname like ""%{like}%"" or lastname like ""%{like}%""";

            DataTable dt = runQuery(q);


            return dt;
        }

        private void SaveExcelFile(Excel.Workbook book)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveDialog.FilterIndex = 1;

            if(saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                book.SaveAs(saveDialog.FileName);
                Notification.Show(State.ExcelExported);   
            }

        }

        //newWorkbook.Close(false);
        //App.Application.Workbooks.Close();

        //App.Quit();



        // cells[rows , columns]
        //x.usedrange               -gives you y x of all the cells used
        //x.Columns.AutoFit();      -autofits
        //x.Rows.AutoFit();         -autofits
        //Excel.Range a             -x.Cells[1,5];//highlights these columns [rows,columns]
        //a.Columns.Count           -count columns of range
        //a.Rows.Count              -count rows of range
        //x.Cells[5, 5] = "ooooo";  -types in cell 5,5
        //   x.Range[1].EntireRow.Font.Bold = true;
        // x.Range[2].EntireRow.Font.Bold = true;
        //x.Range[x.Cells[6,1], x.Cells[6,2]].Merge(); //- merge
        //x.Range["A1","A2"].Merge(); //- merge
        //Excel.Range b = x.Cells[x.Cells[6, 1]];
        //b.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
        //b.Borders.Weight = 2d;

        //x.Range["B7"].Value ="Hello";
        //x.Range["A1"].Formula="=SUM(A1:A2)";



        public void Excel_CashReciept_Ungrouped_Total(DataGridView dgvr, int cashReceiptCashDisbursment, int parish_community_postulancy, int popup_save)
        {
            Microsoft.Office.Interop.Excel.Application App = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook newWorkbook = App.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet x = App.Worksheets[1];
            x.Name = "Report";

            
            if (cashReceiptCashDisbursment == 1)
            {
                x.Range["A1", "D1"].Merge();
                x.Range["A2", "D2"].Merge();
                x.Range["B3", "D3"].Merge();
                x.Range["B4", "D4"].Merge();
                x.Range["A5", "D5"].Merge();

                x.Range["A1"].Value = "     Assumption Parish     ";
                x.Range["A2"].Value = (cashReceiptCashDisbursment == 1 ? "Cash Receipt: " : "Cash Disbursment: ") + " " + (parish_community_postulancy == 1 ? "Parish" : (parish_community_postulancy == 2 ? "Community" : "Postulancy"));
                x.Range["A3"].Value = "     From";
                x.Range["A4"].Value = "     To";
                DateTime dt1 = DateTime.Parse(dgvr.Rows[dgvr.Rows.Count - 1].Cells[3].Value.ToString(), new System.Globalization.CultureInfo("en-US", true), System.Globalization.DateTimeStyles.AssumeLocal);
                DateTime dt2 = DateTime.Parse(dgvr.Rows[0].Cells[3].Value.ToString(), new System.Globalization.CultureInfo("en-US", true), System.Globalization.DateTimeStyles.AssumeLocal);

                x.Range["B3"].Value = (dt1 < dt2 ? dt1.ToString("MMMM dd yyyy, hh - mm") : dt2.ToString("MMMM dd yyyy, hh - mm"));
                x.Range["B4"].Value = (dt1 > dt2 ? dt1.ToString("MMMM dd yyyy, hh - mm") : dt2.ToString("MMMM dd yyyy, hh - mm"));

                x.Range["A1"].Cells.Font.Size = 18;
                x.Range["A1"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                x.Range["A6"].Value = "     Official Reciept Number     ";
                x.Range["B6"].Value = "     Amount     ";
                x.Range["C6"].Value = "     Name     ";
                x.Range["D6"].Value = "     Date Paid     ";

                x.Range["A6", "D6"].Cells.Font.Size = 15;
                x.Range["A6", "D6"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                x.Range["A1", "D4"].EntireRow.Font.Bold = true;

                DateTime min = DateTime.MaxValue;
                DateTime max = DateTime.MinValue;
                int row = 7;
                foreach (DataGridViewRow rows in dgvr.Rows)
                {
                    for (int num = 1; num <= 4; num++)
                    {
                        x.Cells[row, num].Value = rows.Cells[num - 1].Value.ToString();

                    }
                    row++;
                }


                x.Rows.AutoFit();
                x.Columns.AutoFit();

                x.Range["A1", "D" + (row - 1)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                if (popup_save == 1)
                {
                    App.Visible = true;
                }
                else
                {
                    SaveExcelFile(newWorkbook);
                }
            }
            else
            {
                x.Range["A1", "E1"].Merge();
                x.Range["A2", "E2"].Merge();
                x.Range["B3", "E3"].Merge();
                x.Range["B4", "E4"].Merge();
                x.Range["A5", "E5"].Merge();

                x.Range["A1"].Value = "     Assumption Parish     ";
                x.Range["A2"].Value = (cashReceiptCashDisbursment == 1 ? "Cash Receipt: " : "Cash Disbursment: ") + " " + (parish_community_postulancy == 1 ? "Parish" : (parish_community_postulancy == 2 ? "Community" : "Postulancy"));
                x.Range["A3"].Value = "     From";
                x.Range["A4"].Value = "     To";
                DateTime dt1 = DateTime.Parse(dgvr.Rows[dgvr.Rows.Count - 1].Cells[4].Value.ToString(), new System.Globalization.CultureInfo("en-US", true), System.Globalization.DateTimeStyles.AssumeLocal);
                DateTime dt2 = DateTime.Parse(dgvr.Rows[0].Cells[4].Value.ToString(), new System.Globalization.CultureInfo("en-US", true), System.Globalization.DateTimeStyles.AssumeLocal);

                x.Range["B3"].Value = (dt1 < dt2 ? dt1.ToString("MMMM dd yyyy, hh - mm") : dt2.ToString("MMMM dd yyyy, hh - mm"));
                x.Range["B4"].Value = (dt1 > dt2 ? dt1.ToString("MMMM dd yyyy, hh - mm") : dt2.ToString("MMMM dd yyyy, hh - mm"));

                x.Range["A1"].Cells.Font.Size = 18;
                x.Range["A1"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                x.Range["A6"].Value = "     Check Voucher     ";
                x.Range["B6"].Value = "     Check Number     ";
                x.Range["C6"].Value = "     Amount     ";
                x.Range["D6"].Value = "     Name     ";
                x.Range["E6"].Value = "     Date Paid     ";

                x.Range["A6", "E6"].Cells.Font.Size = 15;
                x.Range["A6", "E6"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                x.Range["A1", "E4"].EntireRow.Font.Bold = true;

                DateTime min = DateTime.MaxValue;
                DateTime max = DateTime.MinValue;
                int row = 7;
                foreach (DataGridViewRow rows in dgvr.Rows)
                {
                    for (int num = 1; num <= 5; num++)
                    {
                        x.Cells[row, num].Value = rows.Cells[num - 1].Value.ToString();

                    }
                    row++;
                }


                x.Rows.AutoFit();
                x.Columns.AutoFit();

                x.Range["A1", "E" + (row - 1)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                if (popup_save == 1)
                {
                    App.Visible = true;
                }
                else
                {
                    SaveExcelFile(newWorkbook);
                }
            }
            

            
           
        }
        public void Excel_CashReciept_Grouped_Total(DataGridView dgvr, int cashReceiptCashDisbursment, int parish_community_postulancy,int popup_save)
        {
            Microsoft.Office.Interop.Excel.Application App = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook newWorkbook = App.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet x = App.Worksheets[1];
            x.Name = "Report";

            if (cashReceiptCashDisbursment == 1)
            {
                x.Range["A1", "C1"].Merge();
                x.Range["A2", "C2"].Merge();
                x.Range["B3", "C3"].Merge();
                x.Range["B4", "C4"].Merge();
                x.Range["A5", "C5"].Merge();

                x.Range["A1"].Value = "     Assumption Parish     ";
                x.Range["A2"].Value = (cashReceiptCashDisbursment == 1 ? "Cash Receipt: " : "Cash Disbursment: ") + " " + (parish_community_postulancy == 1 ? "Parish" : (parish_community_postulancy == 2 ? "Community" : "Postulancy"));
                x.Range["A3"].Value = "     From";
                x.Range["A4"].Value = "     To";

                DateTime dt1 = DateTime.Parse(dgvr.Rows[dgvr.Rows.Count - 1].Cells[2].Value.ToString(), new System.Globalization.CultureInfo("en-US", true), System.Globalization.DateTimeStyles.AssumeLocal);
                DateTime dt2 = DateTime.Parse(dgvr.Rows[0].Cells[2].Value.ToString(), new System.Globalization.CultureInfo("en-US", true), System.Globalization.DateTimeStyles.AssumeLocal);

                x.Range["B3"].Value = (dt1 < dt2 ? dt1.ToString("MMMM dd yyyy") : dt2.ToString("MMMM dd yyyy"));
                x.Range["B4"].Value = (dt1 > dt2 ? dt1.ToString("MMMM dd yyyy") : dt2.ToString("MMMM dd yyyy"));

                x.Range["A1"].Cells.Font.Size = 18;
                x.Range["A1"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                x.Range["A6"].Value = "     Official Reciept Number Range    ";
                x.Range["B6"].Value = "     Amount     ";
                x.Range["C6"].Value = "     Date Paid     ";

                x.Range["A6", "C6"].Cells.Font.Size = 15;
                x.Range["A6", "C6"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


                x.Range["A1", "C4"].EntireRow.Font.Bold = true;
                DateTime min = DateTime.MaxValue;
                DateTime max = DateTime.MinValue;
                int row = 7;
                foreach (DataGridViewRow rows in dgvr.Rows)
                {
                    for (int num = 1; num <= 3; num++)
                    {
                        x.Cells[row, num].Value = rows.Cells[num - 1].Value.ToString();
                    }
                    row++;
                }
                x.Rows.AutoFit();
                x.Columns.AutoFit();
                x.Range["A1", "C" + (row - 1)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                if (popup_save == 1)
                {
                    App.Visible = true;
                }
                else
                {
                    SaveExcelFile(newWorkbook);
                }
            }
            else
            {
                x.Range["A1", "D1"].Merge();
                x.Range["A2", "D2"].Merge();
                x.Range["B3", "D3"].Merge();
                x.Range["B4", "D4"].Merge();
                x.Range["A5", "D5"].Merge();

                x.Range["A1"].Value = "     Assumption Parish     ";
                x.Range["A2"].Value = (cashReceiptCashDisbursment == 1 ? "Cash Receipt: " : "Cash Disbursment: ") + " " + (parish_community_postulancy == 1 ? "Parish" : (parish_community_postulancy == 2 ? "Community" : "Postulancy"));
                x.Range["A3"].Value = "     From";
                x.Range["A4"].Value = "     To";
               
                DateTime dt1 = DateTime.Parse(dgvr.Rows[dgvr.Rows.Count - 1].Cells[3].Value.ToString(), new System.Globalization.CultureInfo("en-US", true), System.Globalization.DateTimeStyles.AssumeLocal);
                DateTime dt2 = DateTime.Parse(dgvr.Rows[0].Cells[3].Value.ToString(), new System.Globalization.CultureInfo("en-US", true), System.Globalization.DateTimeStyles.AssumeLocal);

                x.Range["B3"].Value = (dt1 < dt2 ? dt1.ToString("MMMM dd yyyy, hh - mm") : dt2.ToString("MMMM dd yyyy"));
                x.Range["B4"].Value = (dt1 > dt2 ? dt1.ToString("MMMM dd yyyy, hh - mm") : dt2.ToString("MMMM dd yyyy"));

                x.Range["A1"].Cells.Font.Size = 18;
                x.Range["A1"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                x.Range["A6"].Value = "     Check Voucher     ";
                x.Range["B6"].Value = "     Check Number     ";
                x.Range["C6"].Value = "     Amount     ";
                x.Range["D6"].Value = "     Date Paid     ";

                x.Range["A6", "D6"].Cells.Font.Size = 15;
                x.Range["A6", "D6"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                x.Range["A1", "D4"].EntireRow.Font.Bold = true;

                DateTime min = DateTime.MaxValue;
                DateTime max = DateTime.MinValue;
                int row = 7;
                foreach (DataGridViewRow rows in dgvr.Rows)
                {
                    for (int num = 1; num <= 4; num++)
                    {
                        x.Cells[row, num].Value = rows.Cells[num - 1].Value.ToString();

                    }
                    row++;
                }


                x.Rows.AutoFit();
                x.Columns.AutoFit();

                x.Range["A1", "D" + (row - 1)].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                if (popup_save == 1)
                {
                    App.Visible = true;
                }
                else
                {
                    SaveExcelFile(newWorkbook);
                }
            }
        }
        public void Excel_CashReciept_UnGrouped_Breakdown(DataGridView dgvr, int cashReceiptCashDisbursment, int parish_community_postulancy,int popup_save)
        {
            //here
            Microsoft.Office.Interop.Excel.Application App = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook newWorkbook = App.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet x = App.Worksheets[1];
            x.Name = "Report";

            if (cashReceiptCashDisbursment == 1)
            {
                int lastColumn = dgvr.Rows[0].Cells.Count;

                x.Range["A1", x.Cells[1, lastColumn]].Merge();
                x.Range["A2", x.Cells[2, lastColumn]].Merge();
                x.Range["B3", x.Cells[3, lastColumn]].Merge();
                x.Range["B4", x.Cells[4, lastColumn]].Merge();
                x.Range["A5", x.Cells[5, lastColumn]].Merge();

                x.Range["A1"].Value = "     Assumption Parish     ";
                x.Range["A2"].Value = (cashReceiptCashDisbursment == 1 ? "Cash Receipt: " : "Cash Disbursment: ") + " " + (parish_community_postulancy == 1 ? "Parish" : (parish_community_postulancy == 2 ? "Community" : "Postulancy"));
                x.Range["A3"].Value = "     From";
                x.Range["A4"].Value = "     To";
                
                DateTime dt1 = DateTime.Parse(dgvr.Rows[dgvr.Rows.Count - 1].Cells[2].Value.ToString(), new System.Globalization.CultureInfo("en-US", true), System.Globalization.DateTimeStyles.AssumeLocal);
                DateTime dt2 = DateTime.Parse(dgvr.Rows[0].Cells[2].Value.ToString(), new System.Globalization.CultureInfo("en-US", true), System.Globalization.DateTimeStyles.AssumeLocal);

                x.Range["B3"].Value = (dt1 < dt2 ? dt1.ToString("MMMM dd yyyy, hh - mm") : dt2.ToString("MMMM dd yyyy, hh - mm"));
                x.Range["B4"].Value = (dt1 > dt2 ? dt1.ToString("MMMM dd yyyy, hh - mm") : dt2.ToString("MMMM dd yyyy, hh - mm"));

                x.Range["A1"].Cells.Font.Size = 18;
                x.Range["A1"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                x.Range["A6"].Value = "     Official Reciept Number     ";
                x.Range["B6"].Value = "     Name    ";
                x.Range["C6"].Value = "     Date Paid    ";

                for (int i = 3; i <= dgvr.Columns.Count; i++)
                {
                    x.Cells[6, i].Value = dgvr.Columns[i-1].HeaderText;
                }
                x.Range["A6", x.Cells[6,lastColumn]].Cells.Font.Size = 15;
                x.Range["A6", x.Cells[6,lastColumn]].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


                x.Range["A1", x.Cells[4,lastColumn]].EntireRow.Font.Bold = true;

                DateTime min = DateTime.MaxValue;
                DateTime max = DateTime.MinValue;
                int row = 7;
                foreach (DataGridViewRow rows in dgvr.Rows)
                {
                    for (int num = 1; num <= dgvr.Columns.Count; num++)
                    {
                        x.Cells[row, num].Value = rows.Cells[num - 1].Value.ToString();
                    }
                    row++;
                }
                x.Rows.AutoFit();
                x.Columns.AutoFit();
                x.Range["A1", x.Cells[(row - 1),lastColumn]].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                if (popup_save == 1)
                {
                    App.Visible = true;
                }
                else
                {
                    SaveExcelFile(newWorkbook);
                }
            }
            else
            {
                int lastColumn = dgvr.Rows[0].Cells.Count;

                x.Range["A1", x.Cells[1, lastColumn]].Merge();
                x.Range["A2", x.Cells[2, lastColumn]].Merge();
                x.Range["B3", x.Cells[3, lastColumn]].Merge();
                x.Range["B4", x.Cells[4, lastColumn]].Merge();
                x.Range["A5", x.Cells[5, lastColumn]].Merge();

                x.Range["A1"].Value = "     Assumption Parish     ";
                x.Range["A2"].Value = (cashReceiptCashDisbursment == 1 ? "Cash Receipt: " : "Cash Disbursment: ") + " " + (parish_community_postulancy == 1 ? "Parish" : (parish_community_postulancy == 2 ? "Community" : "Postulancy"));
                x.Range["A3"].Value = "     From";
                x.Range["A4"].Value = "     To";

                DateTime dt1 = DateTime.Parse(dgvr.Rows[dgvr.Rows.Count - 1].Cells[3].Value.ToString(), new System.Globalization.CultureInfo("en-US", true), System.Globalization.DateTimeStyles.AssumeLocal);
                DateTime dt2 = DateTime.Parse(dgvr.Rows[0].Cells[3].Value.ToString(), new System.Globalization.CultureInfo("en-US", true), System.Globalization.DateTimeStyles.AssumeLocal);

                x.Range["B3"].Value = (dt1 < dt2 ? dt1.ToString("MMMM dd yyyy, hh - mm") : dt2.ToString("MMMM dd yyyy, hh - mm"));
                x.Range["B4"].Value = (dt1 > dt2 ? dt1.ToString("MMMM dd yyyy, hh - mm") : dt2.ToString("MMMM dd yyyy, hh - mm"));

                x.Range["A1"].Cells.Font.Size = 18;
                x.Range["A1"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                x.Range["A6"].Value = "     Check Voucher     ";
                x.Range["B6"].Value = "     Check Number     ";
                x.Range["C6"].Value = "     Name    ";
                x.Range["D6"].Value = "     Date Paid    ";

                for (int i = 4; i <= dgvr.Columns.Count; i++)
                {
                    x.Cells[6, i].Value = dgvr.Columns[i - 1].HeaderText;
                }
                x.Range["A6", x.Cells[6, lastColumn]].Cells.Font.Size = 15;
                x.Range["A6", x.Cells[6, lastColumn]].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


                x.Range["A1", x.Cells[4, lastColumn]].EntireRow.Font.Bold = true;

                DateTime min = DateTime.MaxValue;
                DateTime max = DateTime.MinValue;
                int row = 7;
                foreach (DataGridViewRow rows in dgvr.Rows)
                {
                    for (int num = 1; num <= dgvr.Columns.Count; num++)
                    {
                        x.Cells[row, num].Value = rows.Cells[num - 1].Value.ToString();
                    }
                    row++;
                }
                x.Rows.AutoFit();
                x.Columns.AutoFit();
                x.Range["A1", x.Cells[(row - 1), lastColumn]].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                if (popup_save == 1)
                {
                    App.Visible = true;
                }
                else
                {
                    SaveExcelFile(newWorkbook);
                }
            }
        }

        public void Excel_CashReciept_Grouped_Breakdown(DataGridView dgvr, int cashReceiptCashDisbursment, int parish_community_postulancy,int popup_save)
        {
            //here
            Microsoft.Office.Interop.Excel.Application App = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook newWorkbook = App.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet x = App.Worksheets[1];
            x.Name = "Report";

            if (cashReceiptCashDisbursment == 1)
            {
                int lastColumn = dgvr.Rows[0].Cells.Count;

                x.Range["A1", x.Cells[1, lastColumn]].Merge();
                x.Range["A2", x.Cells[2, lastColumn]].Merge();
                x.Range["B3", x.Cells[3, lastColumn]].Merge();
                x.Range["B4", x.Cells[4, lastColumn]].Merge();
                x.Range["A5", x.Cells[5, lastColumn]].Merge();

                x.Range["A1"].Value = "     Assumption Parish     ";
                x.Range["A2"].Value = (cashReceiptCashDisbursment == 1 ? "Cash Receipt: " : "Cash Disbursment: ") + " " + (parish_community_postulancy == 1 ? "Parish" : (parish_community_postulancy == 2 ? "Community" : "Postulancy"));
                x.Range["A3"].Value = "     From";
                x.Range["A4"].Value = "     To";

                DateTime dt1 = DateTime.Parse(dgvr.Rows[dgvr.Rows.Count - 1].Cells[1].Value.ToString(), new System.Globalization.CultureInfo("en-US", true), System.Globalization.DateTimeStyles.AssumeLocal);
                DateTime dt2 = DateTime.Parse(dgvr.Rows[0].Cells[1].Value.ToString(), new System.Globalization.CultureInfo("en-US", true), System.Globalization.DateTimeStyles.AssumeLocal);

                x.Range["B3"].Value = (dt1 < dt2 ? dt1.ToString("MMMM dd yyyy, hh - mm") : dt2.ToString("MMMM dd yyyy"));
                x.Range["B4"].Value = (dt1 > dt2 ? dt1.ToString("MMMM dd yyyy, hh - mm") : dt2.ToString("MMMM dd yyyy"));

                x.Range["A1"].Cells.Font.Size = 18;
                x.Range["A1"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                x.Range["A6"].Value = "     Official Reciept Number     ";
                x.Range["B6"].Value = "     Date Paid    ";

                for (int i = 3; i <= dgvr.Columns.Count; i++)
                {
                    x.Cells[6, i].Value = dgvr.Columns[i - 1].HeaderText;
                }
                x.Range["A6", x.Cells[6, lastColumn]].Cells.Font.Size = 15;
                x.Range["A6", x.Cells[6, lastColumn]].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


                x.Range["A1", x.Cells[4, lastColumn]].EntireRow.Font.Bold = true;

                DateTime min = DateTime.MaxValue;
                DateTime max = DateTime.MinValue;
                int row = 7;
                foreach (DataGridViewRow rows in dgvr.Rows)
                {
                    for (int num = 1; num <= dgvr.Columns.Count; num++)
                    {
                        x.Cells[row, num].Value = rows.Cells[num - 1].Value.ToString();
                    }
                    row++;
                }
                x.Rows.AutoFit();
                x.Columns.AutoFit();
                x.Range["A1", x.Cells[(row - 1), lastColumn]].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                if (popup_save == 1)
                {
                    App.Visible = true;
                }
                else
                {
                    SaveExcelFile(newWorkbook);
                }
            }
            else
            {
                int lastColumn = dgvr.Rows[0].Cells.Count;

                x.Range["A1", x.Cells[1, lastColumn]].Merge();
                x.Range["A2", x.Cells[2, lastColumn]].Merge();
                x.Range["B3", x.Cells[3, lastColumn]].Merge();
                x.Range["B4", x.Cells[4, lastColumn]].Merge();
                x.Range["A5", x.Cells[5, lastColumn]].Merge();

                x.Range["A1"].Value = "     Assumption Parish     ";
                x.Range["A2"].Value = (cashReceiptCashDisbursment == 1 ? "Cash Receipt: " : "Cash Disbursment: ") + " " + (parish_community_postulancy == 1 ? "Parish" : (parish_community_postulancy == 2 ? "Community" : "Postulancy"));
                x.Range["A3"].Value = "     From";
                x.Range["A4"].Value = "     To";

                DateTime dt1 = DateTime.Parse(dgvr.Rows[dgvr.Rows.Count - 1].Cells[2].Value.ToString(), new System.Globalization.CultureInfo("en-US", true), System.Globalization.DateTimeStyles.AssumeLocal);
                DateTime dt2 = DateTime.Parse(dgvr.Rows[0].Cells[2].Value.ToString(), new System.Globalization.CultureInfo("en-US", true), System.Globalization.DateTimeStyles.AssumeLocal);

                x.Range["B3"].Value = (dt1 < dt2 ? dt1.ToString("MMMM dd yyyy, hh - mm") : dt2.ToString("MMMM dd yyyy"));
                x.Range["B4"].Value = (dt1 > dt2 ? dt1.ToString("MMMM dd yyyy, hh - mm") : dt2.ToString("MMMM dd yyyy"));

                x.Range["A1"].Cells.Font.Size = 18;
                x.Range["A1"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                x.Range["A6"].Value = "     Check Voucher     ";
                x.Range["B6"].Value = "     Check Number     ";
                x.Range["C6"].Value = "     Date Paid    ";

                for (int i = 4; i <= dgvr.Columns.Count; i++)
                {
                    x.Cells[6, i].Value = dgvr.Columns[i - 1].HeaderText;
                }
                x.Range["A6", x.Cells[6, lastColumn]].Cells.Font.Size = 15;
                x.Range["A6", x.Cells[6, lastColumn]].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


                x.Range["A1", x.Cells[4, lastColumn]].EntireRow.Font.Bold = true;

                DateTime min = DateTime.MaxValue;
                DateTime max = DateTime.MinValue;
                int row = 7;
                foreach (DataGridViewRow rows in dgvr.Rows)
                {
                    for (int num = 1; num <= dgvr.Columns.Count; num++)
                    {
                        x.Cells[row, num].Value = rows.Cells[num - 1].Value.ToString();
                    }
                    row++;
                }
                x.Rows.AutoFit();
                x.Columns.AutoFit();
                x.Range["A1", x.Cells[(row - 1), lastColumn]].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                if (popup_save == 1)
                {
                    App.Visible = true;
                }
                else
                {
                    SaveExcelFile(newWorkbook);
                }
            }
        }
        public void killAllExcel()
        {
            System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
            foreach (System.Diagnostics.Process p in process)
            {
                if (!string.IsNullOrEmpty(p.ProcessName))
                {
                    try
                    {
                        p.Kill();
                    }
                    catch { }
                }
            }
        }

        public bool isEventNameExist(string name, int ID)
        {
            if (runQuery($@"SELECT * FROM sad2.blooddonationevent where eventName = ""{name}"" and bloodDonationEventID != {ID};").Rows.Count >= 1)
            {
                return true;
            }
            return false;
        }
        public bool isBloodDonationIDExist(string ID)
        {
            if (runQuery($@"SELECT * FROM sad2.blooddonation where donationID = ""{ID}""").Rows.Count >= 1)
            {
                return true;
            }
            return false;
        }
        public bool isItemTypeExist(string name, int ID, int bookType, int CashReceipt_CashDisbursment)
        {
            if (runQuery($@"SELECT * FROM sad2.itemtype where itemtype=""{name}""and itemTypeID != {ID} and bookType={bookType} and cashreceipt_cashdisbursment={CashReceipt_CashDisbursment};").Rows.Count >= 1)
            {
                return true;
            }
            return false;
        }
        public void ExcelBloodlettingReports(DataGridView dgvr, DataGridView summary, int popup_save)
        {
            Microsoft.Office.Interop.Excel.Application App = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook newWorkbook = App.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet x = App.Worksheets[1];
            x.Name = "Report";
            x.Range["A1"].Value = "     Assumption Parish - Bloodletting Report     ";
            x.Range["A1"].Cells.Font.Size = 18;
            x.Range["A1"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            int count = 1;
            foreach (DataGridViewColumn col in dgvr.Columns)
            {
                if (col.Visible)
                {
                    x.Cells[2, count++].Value = "     " + col.HeaderText.ToString() + "     ";
                }

            }
            count = count - 1;
            x.Range["A1", x.Cells[1, count + 3]].Merge();
            x.Range[x.Cells[2, 1], x.Cells[2, count + 3]].Cells.Font.Size = 15;
            x.Range[x.Cells[2, 1], x.Cells[2, count + 3]].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            x.Range[x.Cells[2, 1], x.Cells[2, count + 3]].EntireRow.Font.Bold = true;

            for (int row = 0; row < dgvr.Rows.Count; row++)
            {
                for (int cell = 1; cell < dgvr.Rows[row].Cells.Count; cell++)
                {
                    if (dgvr.Rows[row].Cells[cell].Visible)
                    {
                        x.Cells[row + 3, cell].Value = dgvr.Rows[row].Cells[cell].Value.ToString();
                    }
                }
            }
            x.Range["A1", x.Cells[(dgvr.Rows.Count > summary.Rows.Count ? dgvr.Rows.Count + 2 : summary.Rows.Count + 2), (count + 3)]].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            int colEvent = count + 2;
            int colQuantity = count + 3;
            x.Cells[2, count + 2].Value = "      Event Name     ";
            x.Cells[2, count + 3].Value = "      Total Quantity     ";

            for (int a = 0; a < summary.Rows.Count; a++)
            {
                x.Cells[a + 3, colEvent].Value = summary.Rows[a].Cells[0].Value.ToString();
                x.Cells[a + 3, colQuantity].Value = summary.Rows[a].Cells[1].Value.ToString();
            }

            x.Rows.AutoFit();
            x.Columns.AutoFit();
            if (popup_save == 1)
            {
                App.Visible = true;
            }
            else
            {
                SaveExcelFile(newWorkbook);
            }
        }
        public void Excel_CashReports(DataGridView dgvr, DataGridView summary, int cashReceiptCashDisbursment, int parish_community_postulancy, int popup_save)
        {
            Microsoft.Office.Interop.Excel.Application App = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook newWorkbook = App.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet x = App.Worksheets[1];
            x.Name = "Report";

            if (cashReceiptCashDisbursment == 1)
            {
                int count = 0;
                foreach (DataGridViewColumn dc in dgvr.Columns)
                {
                    if (dc.Visible)
                    {
                        count++;
                    }
                }

                x.Range["A1", x.Cells[1, count + 3]].Merge();
                x.Range["A2", x.Cells[2, count + 3]].Merge();
                x.Range["B3", x.Cells[3, count + 3]].Merge();
                x.Range["B4", x.Cells[4, count + 3]].Merge();
                x.Range["B5", x.Cells[5, count + 3]].Merge();

                x.Range["A1"].Value = "     Assumption Parish     ";
                x.Range["A2"].Value = (cashReceiptCashDisbursment == 1 ? "Cash Receipt: " : "Cash Disbursment: ") + " " + (parish_community_postulancy == 1 ? "Parish" : (parish_community_postulancy == 2 ? "Community" : "Postulancy"));
                x.Range["A3"].Value = "     From";
                x.Range["A4"].Value = "     To";

                DateTime dt1 = DateTime.Parse(dgvr.Rows[dgvr.Rows.Count - 1].Cells[3].Value.ToString(), new System.Globalization.CultureInfo("en-US", true), System.Globalization.DateTimeStyles.AssumeLocal);
                DateTime dt2 = DateTime.Parse(dgvr.Rows[0].Cells[3].Value.ToString(), new System.Globalization.CultureInfo("en-US", true), System.Globalization.DateTimeStyles.AssumeLocal);

                x.Range["B3"].Value = (dt1 < dt2 ? dt1.ToString("MMMM dd yyyy, hh : mm") : dt2.ToString("MMMM dd yyyy, hh : mm"));
                x.Range["B4"].Value = (dt1 > dt2 ? dt1.ToString("MMMM dd yyyy, hh : mm") : dt2.ToString("MMMM dd yyyy, hh : mm"));

                x.Range["A1"].Cells.Font.Size = 18;
                x.Range["A1"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                int a = 1;
                foreach (DataGridViewColumn dc in dgvr.Columns)
                {
                    if (dc.Visible)
                    {
                        x.Cells[6, a].Value = "     " + dc.HeaderText.ToString() + "     ";
                        a++;
                    }
                }
                x.Range["A6", x.Cells[6, a + 3]].Cells.Font.Size = 15;
                x.Range["A6", x.Cells[6, a + 3]].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                x.Range["A1", x.Cells[6, a + 3]].EntireRow.Font.Bold = true;

                int b = 0;
                foreach (DataGridViewRow dr in dgvr.Rows)
                {
                    int c = 1;
                    foreach (DataGridViewCell dc in dr.Cells)
                    {
                        x.Cells[b + 7, c].Value = "     " + dc.Value.ToString() + "     ";
                        c++;
                    }
                    b++;
                }

                x.Cells[6, a + 1].Value = "      Item      ";
                x.Cells[6, a + 2].Value = "      Total      ";

                int d = 1;
                foreach (DataGridViewRow sdgvr in summary.Rows)
                {
                    x.Cells[d + 6, a + 1].Value = sdgvr.Cells[0].Value.ToString();
                    x.Cells[d + 6, a + 2].Value = sdgvr.Cells[1].Value.ToString();
                    d++;
                }

                x.Rows.AutoFit();
                x.Columns.AutoFit();
                x.Range["A1", x.Cells[(dgvr.Rows.Count > summary.Rows.Count ? dgvr.Rows.Count + 1 : summary.Rows.Count + 1) + 5, (dgvr.Columns.Count + 3)]].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                if (popup_save == 1)
                {
                    App.Visible = true;
                }
                else
                {
                    SaveExcelFile(newWorkbook);
                }
            }

        }
        public bool isBloodDonationClaimed(int bloodDonationID)
        {
            return runQuery($@"Select * from blooddonation where bloodDonationID = {bloodDonationID} and bloodclaimant is not null").Rows.Count > 0 ;

        }

        public DataTable getAuditLogs()
        {
            string q = "SELECT auditLogID, userID, tableName, operation, auditDate, CONCAT_WS(' ', firstName, midName, lastName, suffix) AS name, details, oldRecord, newRecord, userName FROM AuditLog NATURAL JOIN User ORDER BY AuditDate DESC";
            DataTable dt = ExecuteQuery(q);
            return dt;
        }

        public DataTable getAuditTypes()
        {
            string q = "SELECT DISTINCT(tableName) FROM AuditLog";
            DataTable dt = ExecuteQuery(q);
            return dt;
        }

        

        public DataTable getORdetails(int bookType,int OR)
        {
            return runQuery($@"select * from (select primaryincome.primaryIncomeID, sourceName, primaryincome.bookType ,ORnum,primaryIncomeDateTime,price,quantity ,(price * quantity) as total,itemType,primaryincome.remarks from primaryincome 
                            inner join item on item.primaryIncomeID = primaryincome.primaryincomeid 
                            inner join itemtype on item.itemTypeID=itemtype.itemTypeID 
                            where primaryincome.booktype = {bookType} and 
                            ORnum ={OR}"+
                            (bookType==1?
                            $@" union all
                            select primaryincome.primaryIncomeID,sourceName,primaryincome.bookType,ORnum,primaryIncomeDateTime,price,1 ,amount, itemType,sacramentincome.remarks from primaryincome
                            inner join payment on payment.primaryIncomeID = primaryincome.primaryIncomeID
                            inner join sacramentincome on sacramentincome.sacramentIncomeID = payment.sacramentIncomeID
                            inner join application on application.applicationID = sacramentincome.applicationID
                            inner join itemtype on itemtype.itemTypeID = application.sacramentType
                            where primaryincome.booktype ={bookType} and
                            ORnum ={OR}" : "")    +   ")  as A  order by ORnum desc");
        }
        public DataTable getCVdetails(int bookType,int CV )
        {
            string q = $@"SELECT * FROM cashreleaseitem 
                        INNER JOIN itemtype on itemtype.itemTypeID = cashreleaseitem.cashReleaseTypeID 
                        INNER JOIN cashreleasevoucher on cashreleasevoucher.cashreleasevoucherid = cashreleaseitem.CashReleaseVoucherID 
                        where 
                        itemtype.booktype = {bookType}  
                        and cashreceipt_cashdisbursment =2
                        and CVnum = {CV}
                        order by CVnum desc;";
            return runQuery(q);
        }
        public DataTable getApplicationsWithoutPay(int sacramentType)
        {
            return runQuery($@"SELECT generalprofile.profileid,application.applicationID,concat(lastname, "" "", coalesce(suffix, "" ""), "" "", firstName, "" "", midName, ""."") as name,  sacramentType,sacramentincome.price,case when sum(amount) is null  then 0 else sum(amount) end as amountInt,case when sacramentincome.price is null  then 0 else sacramentincome.price end as priceInt
                            FROM GeneralProfile left outer JOIN Applicant ON  GeneralProfile.profileID = Applicant.profileID 
                            left outer JOIN Application ON Application.applicationID = Applicant.applicationID 
                            left outer Join sacramentincome on sacramentincome.applicationID= application.applicationID
                            left outer join payment on payment.sacramentIncomeID = sacramentincome.sacramentIncomeID
                            WHERE sacramenttype= {sacramentType}
                            group by application.applicationID
                            having amountInt < sacramentincome.price and priceInt  != 0
                            ");
        }
    }

} 



