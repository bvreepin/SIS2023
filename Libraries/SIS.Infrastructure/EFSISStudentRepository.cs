using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SIS.Domain;
using SIS.Domain.Interfaces;
using SIS.Infrastructure.EFRepository.Context; 
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIS.Infrastructure
{
    public class EFSISStudentRepository : ISISStudentRepository
    {
        private readonly ILogger<EFSISStudentRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly SisDbContext _context;

        private readonly ISISPersonRepository _personRepository;
        private readonly ISISRegistrationStateRepository _registrationStateRepository;

        private Dictionary<string, Student> _students;

        public EFSISStudentRepository(ILogger<EFSISStudentRepository> logger, IConfiguration configuration, SisDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;

            // Laad alle studenten bij aanmaken van de repository
            RefreshStudents();
        }

        public Dictionary<string, Student> Students
        {
            get
            {
                if (_students != null) return _students;
                return RefreshStudents();
            }
        }

        public Dictionary<string, Student> RefreshStudents()
        {
            _students = new Dictionary<string, Student>();
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

        public void Insert(Student student)
        {
            if (_students.ContainsKey(student.Firstname + " " + student.LastName))
                return;

            // Test if Person already exists...
            var person = _personRepository.Persons.Values.Where(person => person.FirstName == student.Firstname && person.LastName == student.LastName).FirstOrDefault();
            if (person == null)
            {
                person = new Person { FirstName = student.Firstname, LastName = student.LastName };
                _personRepository.Insert(person);
            }
            var efPerson = _context.People.Where(person => person.FirstName == student.Firstname && person.LastName == student.LastName).FirstOrDefault();
            
            var registrationState = _registrationStateRepository.RegistrationStates.Values.Where(s => s.Description == student.RegistrationState).FirstOrDefault();
            if (registrationState == null)
            {
                registrationState = new RegistrationState { Description = student.RegistrationState };
                _registrationStateRepository.Insert(registrationState);
            }
            var efRegistrationState = _context.RegistrationStates.Where(s => s.Description == student.RegistrationState).FirstOrDefault();
            if (efPerson != null && efRegistrationState != null)
            {
                EFRepository.Models.Student newStudent = new()
                {
                    Email = student.Email,
                    Person = efPerson,
                    PersonId = efPerson.PersonId,
                    OfficialCode = student.OfficialCode
                };
                var efTeacher = _context.Students.Add(newStudent).Entity;
                var count = _context.SaveChanges();
            }
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

