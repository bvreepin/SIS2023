using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIS.API.DTO;
using SIS.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IOEMController : ControllerBase
    {
        private readonly ILogger<IOEMController> _logger;
        private readonly ISISIOEMRepository _repository;
        private readonly IMapper _mapper;

        public IOEMController(ILogger<IOEMController> logger, ISISIOEMRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetIOEMs")] 
        public ActionResult<IEnumerable<IOEMDTO>> Get()
        {
            return Ok(_mapper.Map<List<IOEMDTO>>(_repository.IOEMs.Values.ToList()));
        }
    }
}
