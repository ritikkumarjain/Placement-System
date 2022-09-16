using StudentMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentMicroservice.Repository
{
    public class StudentsRepository : IStudentsRepository
    {

        public readonly DatabaseContext _context;
        public StudentsRepository()
        {

        }

        public StudentsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public bool CreateStudentData(Student student)
        {
            var studentDataToAdd = new StudentDetails()
            {
                UniversityId = student.UniversityId,
                RegistrationNumber = student.RegistrationNumber,
                Name = student.Name,
                Semester = student.Semester,
                Department = student.Department,
                FirstSem = student.FirstSem,
                SecondSem = student.SecondSem,
                ThirdSem = student.ThirdSem,
                FourthSem = student.FourthSem,
                FifthSem = student.FifthSem,
                SixthSem = student.SixthSem,
                SeventhSem = student.SeventhSem,
                EigthSem = student.EigthSem
            };

            var dataIfAlreadyPresent = _context.StudentsDetails.FirstOrDefault(p => p.UniversityId.Equals(student.UniversityId));
            if (dataIfAlreadyPresent != null)
            {
                throw new InvalidOperationException("Data Already Present");
            }


            try
            {
                _context.StudentsDetails.Add(studentDataToAdd);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

            return true;
        }

        public bool UpdateStudentData(Student student)
        {
            var studentDataToUpdate = new StudentDetails()
            {
                StudentId = student.StudentId,
                UniversityId = student.UniversityId,
                RegistrationNumber = student.RegistrationNumber,
                Name = student.Name,
                Semester = student.Semester,
                Department = student.Department,
                FirstSem = student.FirstSem,
                SecondSem = student.SecondSem,
                ThirdSem = student.ThirdSem,
                FourthSem = student.FourthSem,
                FifthSem = student.FifthSem,
                SixthSem = student.SixthSem,
                SeventhSem = student.SeventhSem,
                EigthSem = student.EigthSem
            };


            var deleteData = _context.StudentsDetails.FirstOrDefault(p => p.UniversityId.Equals(student.UniversityId));
            try
            {
                _context.StudentsDetails.Remove(deleteData);
                _context.StudentsDetails.Add(studentDataToUpdate);
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                throw e;
            }

            return true;

        }

        public StudentDetails ViewStudentData(string universityId, string registrationNumber)
        {


            var viewStudentData = _context.StudentsDetails.FirstOrDefault(p => p.UniversityId.Equals(universityId) && p.RegistrationNumber.Equals(registrationNumber));

            if (viewStudentData == null)
            {
                throw new KeyNotFoundException("No data found for given ID");
            }

            return viewStudentData;
        }

    }
}
