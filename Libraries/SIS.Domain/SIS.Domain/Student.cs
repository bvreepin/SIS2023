using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain
{
    public class Student
    {
        public string? Firstname { get; set; }
        public string? LastName { get; set; }
        public string? Mobile { get; set; }

        public string? Email { get; set; }

        public long OfficialCode { get; set; }

       public string RegistrationState { get; set; } = string.Empty;

    }
}
