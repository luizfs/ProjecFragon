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
        public List<Entities.Customer> Get()
        {
            return new Business.CustomerBusiness().GetAll();  
        }

        [HttpGet]
        public Entities.Customer Get(int id)
        {
            return new Business.CustomerBusiness().GetById(id);
        }

        [HttpDelete]
        public int Delete(int id)
        {
            return new Business.CustomerBusiness().Delete(id);
        }

        [HttpPost]
        public int Post(Entities.Customer customer)
        {
            return new Business.CustomerBusiness().Insert(customer);
        }

        [HttpPut]
        public int Put(Entities.Customer  customer)
        {
            return new Business.CustomerBusiness().Update(customer);
        }
    }
}
