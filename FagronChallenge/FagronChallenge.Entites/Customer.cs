using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagronChallenge.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public int? Profession { get; set; }
        public string ProfessionDescription { get; set; }
    }
}
