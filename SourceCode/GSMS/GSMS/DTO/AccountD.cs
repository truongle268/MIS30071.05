using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMS.DTO
{
    public class AccountD
    {
        private string userName;
        private string displayName;
        private string password;
        private int idTypeAccount;
        public AccountD(string userName, string displayName, string password, int idTypeAccount)
        {
            this.UserName = userName;
            this.DisplayName = displayName;
            this.Password = password;
            this.idTypeAccount = idTypeAccount;
        }
        public AccountD(DataRow row)
        {
            this.UserName = row["userName"].ToString();
            this.DisplayName = row["displayName"].ToString();
            this.Password = row["password"].ToString();
            this.idTypeAccount = (int)row["idTypeAccount"];
        }
        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string DisplayName
        {
            get
            {
                return displayName;
            }

            set
            {
                displayName = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public int IdTypeAccount
        {
            get
            {
                return idTypeAccount;
            }

            set
            {
                idTypeAccount = value;
            }
        }
    }
}
