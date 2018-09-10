using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagronChallenge.Data
{
    public class ConfigData
    {
        protected SqlConnection conexao;
        public ConfigData()
        {
            string ConnString = "Data Source =.\\SQLEXPRESS; Initial Catalog = fagronchallenge; Integrated Security = True; MultipleActiveResultSets = True";
            conexao = new SqlConnection(ConnString);
        }

        public void Dispose()
        {
            conexao = null;
        }
    }
}
