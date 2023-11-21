using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain
{
    public class Student
    {
        public string? Firstname { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? Mobile { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        public long OfficialCode { get; set; }

       public string RegistrationState { get; set; } = string.Empty;

    }
}
