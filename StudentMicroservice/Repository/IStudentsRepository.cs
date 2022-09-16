using StudentMicroservice.Models;

namespace StudentMicroservice.Repository
{
    public interface IStudentsRepository
    {
        public bool CreateStudentData(Student student);

        public bool UpdateStudentData(Student student);

        public StudentDetails ViewStudentData(string UniversityId, string RegistrationNumber);
    }
}
