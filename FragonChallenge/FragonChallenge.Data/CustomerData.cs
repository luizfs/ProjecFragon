using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagronChallenge.Data
{
    public class CustomerData:ConfigData
    {
        public int DeleteById(int id)
        {
            string sql = "DELETE Customer WHERE CustomerId =@id";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;

        }

        public List<Entities.Customer> GetAllCustomer()
        {
            string sql = "SELECT CustomerId, FirstName, LastName, CPF, BirthDate, Age, Profession FROM Customer ORDER BY FirstName";
            var cmd = new SqlCommand(sql, conexao);
            List<Entities.Customer> listCustomer = new List<Entities.Customer>();
            Entities.Customer cus = null;
            try
            {
                conexao.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {

                    while(reader.Read())
                    {
                        cus = new Entities.Customer();
                        cus.CustomerId = (int)reader["CustomerId"];
                        cus.FirstName = reader["FirstName"].ToString();
                        cus.LastName = reader["LastName"].ToString();
                        cus.CPF = reader["CPF"].ToString();
                        cus.BirthDate = (DateTime)reader["BirthDate"];
                        cus.Age = (int)reader["Age"];
                        cus.Profession = (int)reader["Profession"];
                        listCustomer.Add(cus);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return listCustomer;

        }

        public Entities.Customer GetCustomerById(int id)
        {
            string sql = "SELECT CustomerId, FirstName, LastName, CPF, BirthDate, Age, Profession FROM Customer WHERE CustomerId=@id";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);
            Entities.Customer cus = null;
            try
            {
                conexao.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            cus = new Entities.Customer();
                            cus.CustomerId = (int)reader["CustomerId"];
                            cus.FirstName = reader["FirstName"].ToString();
                            cus.LastName = reader["LastName"].ToString();
                            cus.CPF = reader["CPF"].ToString();
                            cus.BirthDate = (DateTime)reader["BirthDate"];
                            cus.Age = (int)reader["Age"];
                            cus.Profession = (int)reader["Profession"];
                        }
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return cus;


        }

        public int InsertCustomer(Entities.Customer customer)
        {
            string sql = "INSERT INTO Customer (FirstName, LastName, CPF, BirthDate, Age, Profession) VALUES (@FirstName, @LastName, @CPF, @BirthDate, @Age, @Profession)";
            SqlCommand cmd = new SqlCommand(sql,conexao);
            cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", customer.LastName);
            cmd.Parameters.AddWithValue("@CPF", customer.CPF);
            cmd.Parameters.AddWithValue("@BirthDate", customer.BirthDate);
            cmd.Parameters.AddWithValue("@Age", customer.Age);
            cmd.Parameters.AddWithValue("@Profession", customer.Profession.GetValueOrDefault());
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
               
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;
        }

        public int UpdateCustomer(Entities.Customer customer)
        {          
            string sql = "UPDATE Customer SET FirstName=@FirstName, LastName=@LastName, CPF=@CPF, BirthDate=@BirthDate, Age=@Age, Profession=@Profession WHERE CustomerId=@CustomerId";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
            cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", customer.LastName);
            cmd.Parameters.AddWithValue("@CPF", customer.CPF);
            cmd.Parameters.AddWithValue("@BirthDate", customer.BirthDate);
            cmd.Parameters.AddWithValue("@Age", customer.Age);
            cmd.Parameters.AddWithValue("@Profession", customer.Profession.GetValueOrDefault());
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

            return 0;
        }

        public Entities.Customer CheckExistsCpf(string cpf)
        {
            string sql = "SELECT CustomerId, CPF FROM Customer WHERE CPF = @cpf";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@cpf", cpf);
            Entities.Customer cp = null;
            try
            {
                conexao.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            cp = new Entities.Customer();
                            cp.CustomerId = (int)reader["CustomerId"];
                            cp.CPF = reader["CPF"].ToString();
                        }
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return cp;
        }

    }
}
