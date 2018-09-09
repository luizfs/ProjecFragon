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
        public List<Entities.Profession> GetAllProfession()
        {
            string sql = "SELECT ProfessionId, NameProfession FROM Profession ORDER BY NameProfession";
            var cmd = new SqlCommand(sql, conexao);
            List<Entities.Profession> listProfession = new List<Entities.Profession>();
            Entities.Profession prof = null;
            try
            {
                conexao.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {

                    while (reader.Read())
                    {
                        prof = new Entities.Profession();
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

        public Entities.Profession GetProfessionById(int id)
        {
            string sql = "SELECT ProfessionId, NameProfession FROM Profession WHERE ProfessionId=@id";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);
            Entities.Profession prof = null;
            try
            {
                conexao.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            prof = new Entities.Profession();
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
