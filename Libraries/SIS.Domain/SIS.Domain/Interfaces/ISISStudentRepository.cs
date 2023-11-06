namespace SIS.Domain.Interfaces
{
    public interface ISISStudentRepository
    {   
        public Dictionary<string, Student> Students { get; }

        public Dictionary<string, Student> RefreshStudents();
        public bool Exists(Student student);
        public void Insert(Student student);
        public void Update(Student student);
        public void Delete(Student student);

    }
}