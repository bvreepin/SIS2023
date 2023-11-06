using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SIS.Domain;
using SIS.Domain.Interfaces;

namespace SIS.Infrastructure
{
    public class StudentImporterService : IImporter
    {
        private readonly ILogger<StudentImporterService> _logger;
        private readonly IConfiguration _configuration;
        private readonly ISISStudentRepository _repository;

        public StudentImporterService(ILogger<StudentImporterService> logger, IConfiguration configuration, ISISStudentRepository repository)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
        }

        public void Import()
        {
            string json = File.ReadAllText(Path.Combine(_configuration["JsonDataPath"], "Students.json"));
            var students = JsonConvert.DeserializeObject<List<Student>>(json);
            if (students != null)
            {
                foreach (var s in students)
                {
                    // TO DO: implement update
                    //// TO DO: implement Upsert for this pattern...
                    //if(_repository.Exists(l))
                    //    _repository.Update(l);
                    //else
                    _repository.Insert(s);
                }
            }
        }
    }
}
