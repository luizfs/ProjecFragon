using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Script.Serialization;

namespace FagronChallenge.Api.Controllers
{
    public class CustomerController : ApiController
    {
     
        public List<Entities.Customer> Get()
        {
            return new Business.CustomerBusiness().GetAll();  
        }

        public Entities.Customer Get(int id)
        {
            return new Business.CustomerBusiness().GetById(id);
        }

        public int Delete(int id)
        {
            return new Business.CustomerBusiness().Delete(id);
        }

        public int Post([FromBody] Entities.Customer customer)
        {
            return new Business.CustomerBusiness().Insert(customer);
        }

        public int Put([FromBody] Entities.Customer  customer)
        {
            return new Business.CustomerBusiness().Update(customer);
        }
    }
}
