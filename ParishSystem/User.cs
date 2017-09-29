using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Cryptography;

namespace ParishSystem
{
    public enum UserStatus
    {
        Active = 1,
        Inactive = 2
    }

    public enum UserPrivileges
    {
        Supervisor = 1,
        Treasurer = 2,
        Secretary = 3,
        Admin = 4
    }

    public class User
    {

        private static User _user;
        private static DataHandler dh = DataHandler.getDataHandler();

        public int userID { get; }
        public int addedBy { get; }
        public string firstName { get; }
        public string midName { get; }
        public string lastName { get; }
        public string suffix { get; }
        public string userName { get; }
        private string _password { get; }
        public UserStatus _status { get; }
        public int Privilege { get; }
        public UserPrivileges userPrivilegeLevel { get; }


        //USER SESSION VARIABLE is @userID
        private User(int userID, string firstName, string midName, string lastName, string suffix, string userName, string password, UserStatus status, int addedBy, UserPrivileges privileges)
        {
            this.userID = userID;
            this.firstName = firstName;
            this.midName = midName;
            this.lastName = lastName;
            this.suffix = suffix;
            this.userName = userName;
            this._password = password;
            this._status = status;
            this.addedBy = addedBy;
            this.Privilege = (int)privileges;
            this.userPrivilegeLevel = privileges;
   
        }

        public static bool loginUser(string userName, string password)
        {
            bool verified = verify(userName, password, false);
            if (!verified)
                return false;

            DataTable dt = dh.getUser(userName);

            int userID = Convert.ToInt32(dt.Rows[0]["userID"].ToString());
            string firstName = dt.Rows[0]["firstName"].ToString();
            string midName = dt.Rows[0]["midName"].ToString();
            string lastName = dt.Rows[0]["lastName"].ToString();
            string suffix = dt.Rows[0]["suffix"].ToString();
            UserStatus status = (UserStatus)(Convert.ToInt32(dt.Rows[0]["status"]));
            int addedBy = Convert.ToInt32(dt.Rows[0]["addedBy"]);
            UserPrivileges privileges = (UserPrivileges)(Convert.ToInt32(dt.Rows[0]["privileges"]));

            _user = new User(userID, firstName, midName, lastName, suffix, userName, password, status, addedBy, privileges);
            return true;
        }

        public static User getCurrentUser()
        {
            if (_user == null)
            {
                _user = new User(-1, null, null, null, null, null, null, UserStatus.Active, -1, UserPrivileges.Admin);
            }

            return _user;
        }


        public static bool verify(string username, string password,bool isAdmin)
        {
            DataHandler dh = DataHandler.getDataHandler();

            DataTable dt= new DataTable();

            if (isAdmin==false)
            {
                 dt= dh.getUserPassword(username);
            }
            else
            {
                dt = dh.getAdminPassword(username);
            }

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
