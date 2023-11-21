using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain
{
    public class IOEM
    {
        public string ShortName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string? Title { get; set; } = string.Empty;

        public string? Detail { get; set; } = string.Empty;

        public string? Remark { get; set; } = string.Empty;
    }
}
