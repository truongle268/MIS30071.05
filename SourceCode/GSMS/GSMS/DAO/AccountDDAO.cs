using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSMS.DAO
{
    public class AccountDDAO
    {
        private static AccountDDAO instance;
        public static AccountDDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private AccountDDAO() { }

        public bool CheckLogin(string userName, string password)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hashString = "";
            foreach (byte item in hashData)
            {
                hashString += item;
            }


            string query = String.Format("SELECT * FROM AccountD WHERE userName = N'{0}' AND password = N'{1}'", userName, password);
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_CheckLogin @userName , @password", new object[] { userName, hashString });
            if (data.Rows.Count != 0)
                return true;
            return false;
        }

        public DataTable GetListAccountD()
        {
            string query = "SELECT userName , displayName , nameTypeAccount FROM AccountD INNER JOIN TypeAccount ON AccountD.idTypeAccount = TypeAccount.idTypeAccount";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public int CheckOldPassword(string userName, string password)
        {
            int i = 0;
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hashString = "";
            foreach (byte item in hashData)
            {
                hashString += item;
            }
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM AccountD WHERE userName = N'" + userName + "' AND password = N'" + hashString + "'");
            foreach (DataRow row in data.Rows)
            {
                i = 1;
                break;
            }
            return i;
        }

        public int EditAccountByUserName(string userName, string displayName, int selectedIndex, string password = null)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hashString = "";
            foreach (byte item in hashData)
            {
                hashString += item;
            }

            return DataProvider.Instance.ExecuteNonQuery("USP_UpdateAccountByUserName @userName , @displayName , @idTypeAccount , @password", new object[] { userName, displayName, selectedIndex + 1, hashString });
        }

        public int EditAccountByUserNameNoPass(string userName, string displayName, int selectedIndex)
        {
            return DataProvider.Instance.ExecuteNonQuery("USP_UpdateAccountByUserNameNoPass @userName , @displayName , @idTypeAccount ", new object[] { userName, displayName, selectedIndex + 1 });
        }
        public bool CheckUserName(string name)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM AccountD WHERE userName = N'" + name + "'");
            if (data.Rows.Count > 0)
                return false;
            return true;
        }

        public int AddAccountByUserName(string userName, string displayName, int selectedIndex, string password)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hashString = "";
            foreach (byte item in hashData)
            {
                hashString += item;
            }

            return DataProvider.Instance.ExecuteNonQuery("USP_AddAccountByUserName @userName , @displayName , @idTypeAccount , @password", new object[] { userName, displayName, selectedIndex + 1, hashString });
        }

        public int EditAccountByUserNameNoType(string userName, string displayName, string password)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hashString = "";
            foreach (byte item in hashData)
            {
                hashString += item;
            }

            return DataProvider.Instance.ExecuteNonQuery("USP_UpdateAccountByUserNameNoType @userName , @displayName , @password", new object[] { userName, displayName, hashString });
        }

        public string GetDisplayNameByUserName(string userName)
        {
            string name = "";
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT displayName FROM AccountD WHERE userName = N'" + userName + "'");
            foreach (DataRow row in data.Rows)
            {
                name = row["displayName"].ToString();
            }
            return name;
        }
        public bool IsAdmin(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM AccountD WHERE userName = N'" + userName + "'");
            foreach (DataRow row in data.Rows)
            {
                if ((int)row["idTypeAccount"] == 1)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
