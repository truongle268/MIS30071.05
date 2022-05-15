using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GSMS.DAO
{
    public class TypeAccountDAO
    {
        #region Singleton
        private static TypeAccountDAO instance;

        public static TypeAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TypeAccountDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private TypeAccountDAO() { }
        #endregion
        public DataTable GetListTypeAccount()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM TypeAccount");
        }

        public TypeAccount GetTypeAccountByName(string name)
        {
            TypeAccount account = null;
            string query = "SELECT * FROM TypeAccount WHERE nameTypeAccount = N'" + name + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                account = new TypeAccount(row);
            }
            return account;
        }

        public int DeleteAccountByUserName(string userName)
        {
            return DataProvider.Instance.ExecuteNonQuery("Delete from AccountD Where userName = N'" + userName + "'");
        }
    }
}

