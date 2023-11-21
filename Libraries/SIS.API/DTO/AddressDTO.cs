﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.API.DTO
{
    public class AddressDTO
    {
        //kan vrijwel allemaal als key gebruikt worden....choose wisely?
        public string Street { get; set; } = string.Empty;

        public int StreetNumber { get; set; }

        public int? Bus { get; set; }

        public int PostalCode { get; set; }

        public string City { get; set; } = string.Empty;
    }
}