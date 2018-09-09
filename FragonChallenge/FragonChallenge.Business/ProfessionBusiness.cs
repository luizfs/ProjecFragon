using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragonChallenge.Business
{
    public class ProfessionBusiness
    {
        public Entities.Profession GetById(int id)
        {
            var data = new Data.ProfessionData();
            return data.GetProfessionById(id);
        }

        public List<Entities.Profession> GetAll()
        {
            var data = new Data.ProfessionData();
            return data.GetAllProfession();
        }
    }
}
