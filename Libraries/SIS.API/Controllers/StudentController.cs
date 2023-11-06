using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIS.API.DTO;
using SIS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly ISISStudentRepository _repository;
        private readonly IMapper _mapper;

        public StudentController(ILogger<StudentController> logger, ISISStudentRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetStudents")]
        public ActionResult<IEnumerable<StudentDTO>> Get()
        {
            return Ok(_mapper.Map<List<StudentDTO>>(_repository.Students.Values.ToList()));
        }
    }
        
}
