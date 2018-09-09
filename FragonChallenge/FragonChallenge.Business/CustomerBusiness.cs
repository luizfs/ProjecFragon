using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragonChallenge.Business
{
    public class CustomerBusiness
    {
        public int Insert(Entities.Customer customer)
        {
            if (customer.FirstName == null || customer.FirstName == "")
                return 3;
            if (customer.LastName == null || customer.LastName == "")
                return 3;
            if (customer.CPF == null || customer.CPF == "")
            {
                return 3;
            }
            else
            {
                customer.CPF = customer.CPF.Trim();
                customer.CPF = customer.CPF.Replace(".", "").Replace("-", "");
                if (!this.CheckCpfIsValid(customer.CPF))
                    return 2;
                if (this.CheckExistsCpf(customer.CPF).CPF == customer.CPF)
                    return 1;
            }
            if (customer.BirthDate == null)
            {
                return 3;
            }
            else
            {
                customer.Age = this.CalcAge(customer.BirthDate);
            }

            var data = new Data.CustomerData();
            return data.InsertCustomer(customer);
        }
        public int Update(Entities.Customer customer)
        {
            if (customer.FirstName == null || customer.FirstName == "")
                return 3;
            if (customer.LastName == null || customer.LastName == "")
                return 3;
            if (customer.CPF == null || customer.CPF == "")
            {
                return 3;
            }
            else
            {
                customer.CPF = customer.CPF.Trim();
                customer.CPF = customer.CPF.Replace(".", "").Replace("-", "");
                if (!this.CheckCpfIsValid(customer.CPF))
                    return 2;
                var check = this.CheckExistsCpf(customer.CPF);
                if (check.CPF == customer.CPF && check.CustomerId != customer.CustomerId)
                    return 1;
            }
            if (customer.BirthDate == null)
            {
                return 3;
            }
            else
            {
                customer.Age = this.CalcAge(customer.BirthDate);
            }
            var data = new Data.CustomerData();
            return data.UpdateCustomer(customer);
        }

        public int Delete(int id)
        {
            var data = new Data.CustomerData();
            return data.DeleteById(id);
        }

        public Entities.Customer GetById(int id)
        {
            var data = new Data.CustomerData();
            return data.GetCustomerById(id);
        }

        public List<Entities.Customer> GetAll()
        {
            var data = new Data.CustomerData();
            return data.GetAllCustomer();
        }

        public bool CheckCpfIsValid(string CPF)
        {
            int[] mt1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mt2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string TempCPF;
            string Digit;
            int sum;
            int rest;

            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");

            if (CPF.Length != 11)
                return false;

            TempCPF = CPF.Substring(0, 9);
            sum = 0;
            for (int i = 0; i < 9; i++)
                sum += int.Parse(TempCPF[i].ToString()) * mt1[i];

            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            Digit = rest.ToString();
            TempCPF = TempCPF + Digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(TempCPF[i].ToString()) * mt2[i];

            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            Digit = Digit + rest.ToString();

            return CPF.EndsWith(Digit);
        }

        public Entities.Customer CheckExistsCpf(string cpf)
        {
            var data = new Data.CustomerData();
            return data.CheckExistsCpf(cpf);
        }

        public int CalcAge(DateTime bd)
        {
            int age = DateTime.Now.Year - bd.Year;
            if (DateTime.Now.Month < bd.Month || (DateTime.Now.Month == bd.Month && DateTime.Now.Day < bd.Day))
                age--;

            return age;
        }
    }
}
