﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain
{
    public class IOEM
    {
        public string ShortName { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? Title { get; set; }

        public string? Detail { get; set; }

        public string? Remark { get; set; }
    }
}
