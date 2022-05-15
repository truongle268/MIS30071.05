using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMS.DAO
{
    public class TypeAccount
    {
        private int idTypeAccount;
        private string nameTypeAccount;
        public TypeAccount(int idTypeAccount, string nameTypeAccount)
        {
            this.IdTypeAccount = idTypeAccount;
            this.NameTypeAccount = nameTypeAccount;
        }
        public TypeAccount(DataRow row)
        {
            this.IdTypeAccount = (int)row["idTypeAccount"];
            this.NameTypeAccount = row["nameTypeAccount"].ToString();
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

        public string NameTypeAccount
        {
            get
            {
                return nameTypeAccount;
            }

            set
            {
                nameTypeAccount = value;
            }
        }
    }
}
