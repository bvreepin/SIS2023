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
    public class AddressController : ControllerBase
    {
        private readonly ILogger<AddressController> _logger;
        private readonly ISISAdressRepository _repository;
        private readonly IMapper _mapper;

        public AddressController(ILogger<AddressController> logger, ISISAdressRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAdressess")] //meervoud adressen of enkelvoud?
        public ActionResult<IEnumerable<AddressDTO>> Get()
        {
            return Ok(_mapper.Map<List<AddressDTO>>(_repository.Adresses.Values.ToList()));
        }
    }
}
