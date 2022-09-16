using StudentMicroservice.Models;

namespace StudentMicroservice.Services
{
    public interface IStudentsService
    {

        public bool CreateStudentData(Student student);

        public bool UpdateStudentData(Student student);

        public StudentDetails ViewStudentData(string UniversityId, string RegistrationNumber);
    }
}
