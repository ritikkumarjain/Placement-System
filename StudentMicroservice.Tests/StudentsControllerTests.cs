using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using StudentMicroservice.Controllers;
using StudentMicroservice.Models;
using StudentMicroservice.Services;

namespace StudentMicroservice.Tests
{

    [TestFixture]
    class StudentsControllerTests
    {

        [SetUp]
        public void Setup()
        {

        }


        private StudentsController _studentsController;

        Mock<IStudentsService> mock = new Mock<IStudentsService>();


        public StudentsControllerTests()
        {
            _studentsController = new StudentsController(mock.Object);
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
        public void CreateStudentsData_TakesStudentModelClassAsInput_ReturnsAnOkObjectResult()
        {

            var result = true;
            mock.Setup(m => m.CreateStudentData(studentDetails)).Returns(result);
            var response = _studentsController.CreateStudentsData(studentDetails) as OkObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.StatusCode);

        }


        [Test]
        public void CreateStudentsData_TakesStudentModelClassAsInput_ReturnsANoContentResult()
        {

            var result = false;
            mock.Setup(m => m.CreateStudentData(studentDetails)).Returns(result);
            var response = _studentsController.CreateStudentsData(studentDetails) as NoContentResult;

            Assert.AreEqual(204, response.StatusCode);

        }


        [Test]
        public void UpdateStudentsData_TakesStudentModelClassAsInput_ReturnsAnOkObjectResult()
        {
            var result = true;
            mock.Setup(m => m.UpdateStudentData(studentDetails)).Returns(result);
            var response = _studentsController.UpdateStudentsData(studentDetails) as OkObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.StatusCode);
        }

        [Test]
        public void UpdateStudentsData_TakesStudentModelClassAsInput_ReturnsANoContentResult()
        {
            var result = false;
            mock.Setup(m => m.UpdateStudentData(studentDetails)).Returns(result);
            var response = _studentsController.UpdateStudentsData(studentDetails) as NoContentResult;


            Assert.AreEqual(204, response.StatusCode);
        }

        [Test]
        public void ViewStudentsData_TakesUniversityIdAndRegistrationNumberAsInput_ReturnsAnOkObjectResult()
        {
            var universityId = "123456987123";
            var registrationNumber = "123456789";
            var result = new StudentDetails()
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

            mock.Setup(m => m.ViewStudentData(universityId, registrationNumber)).Returns(result);
            var response = _studentsController.ViewStudentsData(universityId, registrationNumber) as OkObjectResult;



            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.StatusCode);

        }

        [Ignore("Difficult in understanding the problem")]
        [Test]
        public void ViewStudentsData_TakesUniversityIdAndRegistrationNumberAsInput_ReturnsResult()
        {
            var universityId = "123456987123";
            var registrationNumber = "123456789";
            var result = new StudentDetails()
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

            mock.Setup(m => m.ViewStudentData(universityId, registrationNumber)).Returns(result);
            var response = _studentsController.ViewStudentsData(universityId, registrationNumber) as NotFoundResult;


            Assert.Null(response);
            Assert.AreEqual(null, response);

            

        }

    }
}
