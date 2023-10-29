namespace SIS.Domain.Interfaces
{
    public interface ISISStudentGroupRepository
    {
        public Dictionary<string, StudentGroup> StudentGroups { get; }

        public Dictionary<string, StudentGroup> RefreshStudentGroups();
        public bool Exists(StudentGroup studentGroup);
        public void Insert(StudentGroup studentGroup);
        public void Update(StudentGroup studentGroup);
        public void Delete(StudentGroup studentGroup);
    }
}