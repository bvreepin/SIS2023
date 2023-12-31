using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.API.DTO
{
    public class AddressDTO
    {
        [MaxLength(500)]
        public string Street { get; set; } = string.Empty;

        public int StreetNumber { get; set; }

        public int? Bus { get; set; }

        public int PostalCode { get; set; }
        [MaxLength(100)]
        public string City { get; set; } = string.Empty;
    }
}
