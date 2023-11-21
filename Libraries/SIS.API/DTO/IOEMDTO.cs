using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.API.DTO
{
    public class IOEMDTO
    {
        [MaxLength(500)]
        public string? Title { get; set; } = string.Empty;
    }
}
