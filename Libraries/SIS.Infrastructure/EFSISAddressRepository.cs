using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SIS.Domain;
using SIS.Domain.Interfaces;
using SIS.Infrastructure.EFRepository.Context;

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

            // Laad alle adressen bij aanmaken van de repository
            RefreshAddresses();
        }

        public Dictionary<string, Address> Addresses
        {
            get
            {
                if (_addresses != null) return _addresses;
                return RefreshAddresses();
            }
        }

        public Dictionary<string, Address> RefreshAddresses()
        {
            _addresses = new();
            var dbAddresses = _context.Addresses.ToList();
            foreach (var adr in dbAddresses)
            {
                var address = new Address
                {
                    Street = adr.Street,
                    City = adr.City,
                    Bus = adr.Bus,
                    CountryId = adr.CountryId,
                    StreetNumber = adr.StreetNumber,
                    PostalCode = adr.PostalCode
                };
                _addresses.Add(adr.Street + " " + adr.StreetNumber + " " + adr.Bus + " " + adr.City, address);
            }
            return _addresses;
        }

        public void Insert(Address address)
        {
            if (_addresses.ContainsKey(address.Street + " " + address.StreetNumber + " " + address.Bus + " " + address.City))
                return;

            EFRepository.Models.Address newAddress = new()
            {
                Street = address.Street,
                City = address.City,
                Bus = address.Bus,
                CountryId = address.CountryId,
                StreetNumber = address.StreetNumber,
                PostalCode = address.PostalCode
            };
            var efAddress = _context.Addresses.Add(newAddress).Entity;
            var count = _context.SaveChanges();
        }
        
        public void Update(Address address)
        {
            throw new NotImplementedException();
        }

        public void Delete(Address address)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
