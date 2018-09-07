using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Script.Serialization;

namespace FragonChallenge.Api.Controllers
{
    public class CustomerController : ApiController
    {
        [HttpGet]
        [Route("api/Customer/Get")]
        public List<Business.Customer> Get()
        {
            List<Business.Customer> customers = new List<Business.Customer>();
            var result = new Data.CustomerData().GetAllCustomer();
            customers.AddRange(result);
            return customers;
        }

        [HttpGet]
        [Route("api/Customer/Get/{id}")]
        public Business.Customer Get(int id)
        {
            var customer = new Data.CustomerData().GetCustomerById(id);
            return customer;
        }

        [HttpDelete]
        [Route("api/Customer/Delete/{id}")]
        public int Delete(int id)
        {
            var result = new Data.CustomerData();
            if (result.DeleteById(id) == 0)
                return 0;
            return 1;

        }

        [HttpPost]
        [Route("api/Customer/Post/{firstName}/{lastName}/{CPF}/{birthDate}/{age}/{profession}")]
        public int Post(string firstName, string lastName, string CPF, DateTime birthDate, int age, int profession)
        {
            var result = new Data.CustomerData();
            var model = new Business.Customer();
            model.FirstName = firstName;
            model.LastName = lastName;
            model.CPF = CPF;
            model.BirthDate = birthDate;
            model.Age = age;
            model.Profession = profession;

            if (result.InsertCustomer(model) == 0)
                return 0;
            
         return 1;
        }

        [HttpPut]
        [Route("api/Customer/Put/{CustomerId}/{firstName}/{lastName}/{CPF}/{birthDate}/{age}/{profession}")]
        public int Put(int customerId, string firstName, string lastName, string CPF, DateTime birthDate, int age, int profession)
        {
            var result = new Data.CustomerData();
            var model = new Business.Customer();
            model.CustomerId = customerId;
            model.FirstName = firstName;
            model.LastName = lastName;
            model.CPF = CPF;
            model.BirthDate = birthDate;
            model.Age = age;
            model.Profession = profession;

            if (result.UpdateCustomer(model) == 0)
                return 0;

            return 1;
        }

    }
}
