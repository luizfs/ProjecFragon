using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FragonChallenge.Api.Controllers
{
    public class ProfessionController : ApiController
    {
        [HttpGet]
        [Route("api/Profession/Get")]
        public List<Business.Profession> Get()
        {
            List<Business.Profession> professions = new List<Business.Profession>();
            var result = new Data.ProfessionData().GetAllProfession();
            professions.AddRange(result);
            return professions;
        }

        [HttpGet]
        [Route("api/Profession/Get/{id}")]
        public Business.Profession Get(int id)
        {
            var profession = new Data.ProfessionData().GetProfessionById(id);
            return profession;
        }
    }
}
