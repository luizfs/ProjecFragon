using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragonChallenge.Data
{
    public class ProfessionData:ConfigData
    {
        public List<Business.Profession> GetAllProfession()
        {
            string sql = "SELECT ProfessionId, NameProfession FROM Profession ORDER BY NameProfession";
            var cmd = new SqlCommand(sql, conexao);
            List<Business.Profession> listProfession = new List<Business.Profession>();
            Business.Profession prof = null;
            try
            {
                conexao.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {

                    while (reader.Read())
                    {
                        prof = new Business.Profession();
                        prof.ProfessionId = (int)reader["ProfessionId"];
                        prof.NameProfession = reader["NameProfession"].ToString();
                        listProfession.Add(prof);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return listProfession;
        }

        public Business.Profession GetProfessionById(int id)
        {
            string sql = "SELECT ProfessionId, NameProfession FROM Profession WHERE ProfessionId=@id";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);
            Business.Profession prof = null;
            try
            {
                conexao.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            prof = new Business.Profession();
                            prof.ProfessionId = (int)reader["ProfessionId"];
                            prof.NameProfession = reader["NameProfession"].ToString();
                           
                        }
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return prof;


        }

    }
}
