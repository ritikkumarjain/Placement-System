using StudentMicroservice.Models;
using StudentMicroservice.Repository;

namespace StudentMicroservice.Services
{
    public class StudentsService : IStudentsService
    {

        public IStudentsRepository _studentsRepository;

        public StudentsService(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }


        public bool CreateStudentData(Student student)
        {
            //_studentsRepository = new StudentsRepository();
            return _studentsRepository.CreateStudentData(student);
        }

        public bool UpdateStudentData(Student student)
        {
            //_studentsRepository = new StudentsRepository();
            return _studentsRepository.UpdateStudentData(student);
        }

        public StudentDetails ViewStudentData(string UniversityId, string RegistrationNumber)
        {
            return _studentsRepository.ViewStudentData(UniversityId, RegistrationNumber);
        }
    }
}
