using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace LagerMan
{
    class AuthDbUser
    {
        public ArrayList auth(string uName, string uPass)
        {
            SQLQuery newQuery = new SQLQuery();
            string salt1 = "cRucet5u", salt2 = "5ruK5hek", md5Hash;
            
            ArrayList sql_queryRtn = new ArrayList();
            ArrayList fnc_Return = new ArrayList();

            string saltedPass = salt1 + uPass + salt2;
            md5Hash = md5Crypto.CalculateMD5Hash(saltedPass);

            sql_queryRtn = newQuery.CheckUsr(uName);
           
            if (string.Compare(sql_queryRtn[0].ToString(), md5Hash, false) == 0)
            { 
                fnc_Return.Add(true);
                fnc_Return.Add(sql_queryRtn[1]);
            }

            return fnc_Return;
        }

        public void checkIn(string timestamp)
        {

        }
    }
}
