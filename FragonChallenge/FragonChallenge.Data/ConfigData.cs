using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragonChallenge.Data
{
    public class ConfigData
    {
        protected IDbConnection conexao;
        public ConfigData()
        {
            string ConnString = "Data Source=\\servername\\SQLEXPRESS; Initial Catalog=fragonchallenge; Integrated Security=SSPI; Persist Security Info=false; Trusted_Connection=Yes";
            conexao = new SqlConnection(ConnString);
        }

        public void Dispose()
        {
            conexao = null;
        }
    }
}
