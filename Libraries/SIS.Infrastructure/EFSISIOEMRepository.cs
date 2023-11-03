using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SIS.Domain.Interfaces;
using SIS.Infrastructure.EFRepository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Infrastructure
{
    public class EFSISIOEMRepository : ISISIOEMRepository
    {
        private readonly ILogger<EFSISIOEMRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly SisDbContext _context;

        public void Update(Student student)
        {
            throw new NotImplementedException();
        }

        public void Delete(Student student)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
