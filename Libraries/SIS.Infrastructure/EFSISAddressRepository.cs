using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SIS.Domain;
using SIS.Infrastructure.EFRepository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Infrastructure
{
    public class EFSISAddressRepository : ISISAddressRepository
    {
        private readonly ILogger<EFSISAddressRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly SisDbContext _context;

        private Dictionary<string, Address> _addresses;

        public EFSISAddressRepository(ILogger<EFSISAddressRepository> logger, IConfiguration configuration, SisDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;

            // Laad alle addressen bij aanmaken van de repository
            RefreshAddress();
        }

        public Dictionary<string, Address> Adresses
        {
            get
            {
                if (_addresses != null) return _addresses;
                return RefreshAddress();
            }
        }

        public Dictionary<string, Address> RefreshAddress()
        {
            _addresses = new();
            var dbaddresss = _context.addresses.ToList();
            foreach (var sg in dbaddresss)
            {
                var address = new address
                {
                    Name = sg.Name
                };
                _addresss.Add(sg.Name, address);
            }
            return _addresss;
        }

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
