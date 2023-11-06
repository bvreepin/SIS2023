using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain
{
    public class Address
    {
        public string Street { get; set; } = null!;

        public int StreetNumber { get; set; }

        public int? Bus { get; set; }

        public int PostalCode { get; set; }

        public string City { get; set; } = null!;

        public int CountryId { get; set; }
    }
}
