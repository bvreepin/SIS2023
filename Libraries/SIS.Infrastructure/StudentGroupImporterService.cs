using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SIS.Domain;
using SIS.Domain.Interfaces;

namespace SIS.Infrastructure
{
    public class StudentGroupImporterService : IImporter
    {
        private readonly ILogger<StudentGroupImporterService> _logger;
        private readonly IConfiguration _configuration;
        private readonly ISISStudentGroupRepository _repository;

        public StudentGroupImporterService(ILogger<StudentGroupImporterService> logger, IConfiguration configuration, ISISStudentGroupRepository repository)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
        }

        public void Import()
        {
            string json = File.ReadAllText(Path.Combine(_configuration["JsonDataPath"], "StudentGroups.json"));
            var studentGroups = JsonConvert.DeserializeObject<List<StudentGroup>>(json);
            if (studentGroups != null)
            {
                foreach (var sg in studentGroups)
                {
                    // TO DO: implement update
                    //// TO DO: implement Upsert for this pattern...
                    //if(_repository.Exists(l))
                    //    _repository.Update(l);
                    //else
                        _repository.Insert(sg);
                }
            }
        }
    }
}