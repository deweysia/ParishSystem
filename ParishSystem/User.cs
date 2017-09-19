using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ParishSystem
{
    public enum UserStatus
    {
        Active = 1,
        Inactive = 2
    }

    public enum UserPrivileges
    {
        None = 0,
        Supervisor = 1,
        Treasurer = 2,
        Secretary = 3
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
        public Privilege Privilege { get; }


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
            this.Privilege = new Privilege(privileges);

        }

        public static bool loginUser(string userName, string password)
        {
            DataTable dt = dh.getUser(userName, password);
            if (dt.Rows.Count == 0)
                return false;
            

            int userID = Convert.ToInt32(dt.Rows[0]["userID"].ToString());
            string firstName = dt.Rows[0]["firstName"].ToString();
            string midName = dt.Rows[0]["midName"].ToString();
            string lastName = dt.Rows[0]["lastName"].ToString();
            string suffix = dt.Rows[0]["suffix"].ToString();
            UserStatus status = (UserStatus)(Convert.ToInt32(dt.Rows[0]["status"]));
            int addedBy = Convert.ToInt32(dt.Rows[0]["addedBy"]);
            UserPrivileges privileges = (UserPrivileges)(Convert.ToInt32(dt.Rows[0]["privileges"]));

            _user = new User(userID, firstName, midName, lastName, suffix, userName, password, status, addedBy, privileges);
            dh.storeUserID(userID);

            return true;
        }

        public static User getUser()
        {
            if(_user == null)
            {
                _user = new User(-1, null, null, null, null, null, null, UserStatus.Active, -1, UserPrivileges.None);
            }
                
            return _user;
        }

    }
}
