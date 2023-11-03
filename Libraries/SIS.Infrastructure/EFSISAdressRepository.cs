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
    public class EFSISAdressRepository : ISISAdressRepository
    {
        private readonly ILogger<EFSISAdressRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly SisDbContext _context;

        private Dictionary<string, Adress> _adresses;

        public EFSISAdressRepository(ILogger<EFSISAdressRepository> logger, IConfiguration configuration, SisDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;

            // Laad alle studenten bij aanmaken van de repository
            RefreshAdress();
        }

        public Dictionary<string, Adress> Adresses
        {
            get
            {
                if (_adresses != null) return _adresses;
                return RefreshAdress();
            }
        }

        public Dictionary<string, Adress> RefreshAdress()
        {
            _adresses = new Dictionary<string, Adress>();
            // vanaf hier nog niet aangepast
            var dbStudents = _context.Students.Include(s => s.RegistrationState).ToList();

            foreach (var student in dbStudents)
            {
                var p = _personRepository.Persons.Values.Where(person => person.FirstName == student.Person.FirstName && student.Person.LastName == student.Person.LastName).FirstOrDefault();
                if (p == null)
                {
                    p = new Person { FirstName = student.Person.FirstName, LastName = student.Person.LastName };
                    _personRepository.Insert(p);
                };
                var s = new Student
                {
                    Firstname = p.FirstName,
                    LastName = p.LastName,
                    Mobile = string.IsNullOrEmpty(student.Mobile) ? p.Mobile : student.Mobile,
                    Email = string.IsNullOrEmpty(student.Email) ? p.Email : student.Email,
                    OfficialCode = student.OfficialCode,
                    RegistrationState = student.RegistrationState.Description

                };
                _students.Add(p.FirstName + " " + p.LastName, s);
            }

            return _students;
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
