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
    public class AdressController : ControllerBase
    {
        private readonly ILogger<AdressController> _logger;
        private readonly ISISAdressRepository _repository;
        private readonly IMapper _mapper;

        public AdressController(ILogger<AdressController> logger, ISISAdressRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAdressess")] //meervoud adressen of enkelvoud?
        public ActionResult<IEnumerable<AdressDTO>> Get()
        {
            return Ok(_mapper.Map<List<AdressDTO>>(_repository.Adresses.Values.ToList()));
        }
    }
}
