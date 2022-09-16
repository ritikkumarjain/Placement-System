using Moq;
using NUnit.Framework;
using StudentMicroservice.Models;
using StudentMicroservice.Repository;
using StudentMicroservice.Services;

namespace StudentMicroservice.Tests
{
    [TestFixture]
    class StudentsServiceTests
    {
        public StudentsService _studentsService;

        Mock<IStudentsRepository> mock = new Mock<IStudentsRepository>();

        public StudentsServiceTests()
        {
            _studentsService = new StudentsService(mock.Object);
        }



        private Student studentDetails = new Student()
        {
            UniversityId = "123456987123",
            RegistrationNumber = "123456789",
            Name = "Ritik",
            Semester = "V",
            Department = "ETE",
            FirstSem = "7",
            SecondSem = "8",
            ThirdSem = "8",
            FourthSem = "8",
            FifthSem = "8",
            SixthSem = "8",
            SeventhSem = "8",
            EigthSem = "8"

        };



        [Test]
        public void CreateStudentsData_TakesStudentObjectAsInput_ReturnsTrue()
        {
            mock.Setup(m => m.CreateStudentData(studentDetails)).Returns(true);
            var response = _studentsService.CreateStudentData(studentDetails);

            Assert.IsNotNull(response);
            Assert.IsTrue(response);
            Assert.AreEqual(true, response);
        }

        [Test]
        public void CreateStudentsData_TakesStudentObjectAsInput_ReturnsFalse()
        {
            mock.Setup(m => m.CreateStudentData(studentDetails)).Returns(false);
            var response = _studentsService.CreateStudentData(studentDetails);

            Assert.IsFalse(response);
            Assert.IsNotNull(response);
            Assert.AreEqual(false, response);
        }

        [Test]
        public void UpdateStudentsData_TakesStudentsObjectAsInput_ReturnsTrue()
        {
            mock.Setup(m => m.UpdateStudentData(studentDetails)).Returns(true);
            var response = _studentsService.UpdateStudentData(studentDetails);

            Assert.True(response);
            Assert.IsNotNull(response);
            Assert.AreEqual(true, response);
        }


        [Test]
        public void UpdateStudentsData_TakesStudentsObjectAsInput_ReturnsFalse()
        {
            mock.Setup(m => m.UpdateStudentData(studentDetails)).Returns(false);
            var response = _studentsService.UpdateStudentData(studentDetails);

            Assert.IsFalse(response);
            Assert.IsNotNull(response);
            Assert.AreEqual(false, response);
        }


        [Test]
        public void ViewStudentsData_TakesUniversityIdAndRegistrationNumberAsInput_ReturnsTrue()
        {
            var universityId = "123456987123";
            var registrationNumber = "123456789";
            StudentDetails studentDetailsOutput = new StudentDetails()
            {
                UniversityId = "123456987123",
                RegistrationNumber = "123456789",
                Name = "Ritik",
                Semester = "V",
                Department = "ETE",
                FirstSem = "7",
                SecondSem = "8",
                ThirdSem = "8",
                FourthSem = "8",
                FifthSem = "8",
                SixthSem = "8",
                SeventhSem = "8",
                EigthSem = "8"

            };


            mock.Setup(m => m.ViewStudentData(universityId, registrationNumber)).Returns(studentDetailsOutput);
            var response = _studentsService.ViewStudentData(universityId, registrationNumber);

            Assert.IsNotNull(response);
            Assert.AreEqual(studentDetailsOutput, response);
        }


        [Test]
        public void ViewStudentsData_TakesUniversityIdAndRegistrationNumberAsInput_ReturnsNull()
        {
            var universityId = "123456987123";
            var registrationNumber = "123456789";


            mock.Setup(m => m.ViewStudentData(universityId, registrationNumber)).Returns(()=>null);
            var response = _studentsService.ViewStudentData(universityId, registrationNumber);

            Assert.Null(response);
            Assert.AreEqual(null, response);
        }



    }
}
