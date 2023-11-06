using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SIS.Domain;
using SIS.Domain.Interfaces;
using SIS.Infrastructure.EFRepository.Context;

namespace SIS.Infrastructure
{
    public class EFSISStudentGroupRepository : ISISStudentGroupRepository
    {
        private readonly ILogger<EFSISStudentGroupRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly SisDbContext _context;

        private Dictionary<string, StudentGroup> _studentGroups;
        public Dictionary<string, StudentGroup> StudentGroups
        {
            get
            {
                if (_studentGroups != null) return _studentGroups;
                return RefreshStudentGroups();
            }
        }

        public EFSISStudentGroupRepository(ILogger<EFSISStudentGroupRepository> logger, IConfiguration configuration, ILoggerFactory loggerFactory, SisDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;

            // Load all student groups up front
            RefreshStudentGroups();
        }

        public Dictionary<string, StudentGroup> RefreshStudentGroups()
        {
            _studentGroups = new();
            var dbStudentGroups = _context.StudentGroups.ToList();
            foreach (var sg in dbStudentGroups)
            {
                var studentGroup = new StudentGroup
                {
                    Name = sg.Name
                };
                _studentGroups.Add(sg.Name, studentGroup);
            }
            return _studentGroups;
        }

        public void Insert(StudentGroup studentGroup)
        {
            if (_studentGroups.ContainsKey(studentGroup.Name))
                return;

            EFRepository.Models.StudentGroup newStudentGroup = new()
            {
                Name = studentGroup.Name
            };
            var efStudentGroup = _context.StudentGroups.Add(newStudentGroup).Entity;
            var count = _context.SaveChanges();
        }

        public void Update(StudentGroup studentGroup)
        {
            // Implement update logic if needed
            throw new NotImplementedException();
        }

        public void Delete(StudentGroup studentGroup)
        {
            // Implement delete logic if needed
            throw new NotImplementedException();
        }

        public bool Exists(StudentGroup studentGroup)
        {
            // Implement existence check logic if needed
            throw new NotImplementedException();
        }
    }
}
