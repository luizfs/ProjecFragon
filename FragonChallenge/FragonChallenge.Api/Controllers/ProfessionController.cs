using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FagronChallenge.Api.Controllers
{
    public class ProfessionController : ApiController
    {
        [HttpGet]
        public List<Entities.Profession> Get()
        {
            return new Business.ProfessionBusiness().GetAll();
        }

        [HttpGet]
        public Entities.Profession Get(int id)
        {
            return new Business.ProfessionBusiness().GetById(id);
        }
    }
}
