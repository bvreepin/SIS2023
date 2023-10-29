using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIS.API.DTO;
using SIS.Domain.Interfaces;
using AutoMapper;

namespace SIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentGroupController : ControllerBase
    {
        private readonly ILogger<StudentGroupController> _logger;
        private readonly ISISStudentGroupRepository _repository;
        private readonly IMapper _mapper;

        public StudentGroupController(ILogger<StudentGroupController> logger, ISISStudentGroupRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetStudentGroups")]
        public ActionResult<IEnumerable<StudentGroupDTO>> Get()
        {
            return Ok(_mapper.Map<List<StudentGroupDTO>>(_repository.StudentGroups.Values.ToList()));
        }
    }
}
