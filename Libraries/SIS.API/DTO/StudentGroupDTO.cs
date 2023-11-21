using System.ComponentModel.DataAnnotations;

namespace SIS.API.DTO
{
    public class StudentGroupDTO
    {
        [MaxLength(500)]
        public string Name { get; set; } = string.Empty;
    }
}