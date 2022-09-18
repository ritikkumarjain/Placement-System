


using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NUnit.Framework;
using StudentMicroservice.Models;
using StudentMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace StudentMicroservice.Tests
{
    [TestFixture]
    class StudentsRepositoryTests
    {


        private readonly string _connectionString = "Data Source=LAPTOP-A6G2G4CS\\DATABASES_DOTNET;Initial Catalog=PlacementSystem;Integrated Security=True";

        StudentsRepository _studentsRepository;
        StudentsRepository _studentsRepositoryNoConnection;


        private readonly DatabaseContext _context = new DatabaseContext();

        public StudentsRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer(_connectionString).Options;
            DatabaseContext database = new DatabaseContext(options);

            _studentsRepository = new StudentsRepository(database);
            _studentsRepositoryNoConnection = new StudentsRepository();
        }


        private Student _student = new Student()
        {
            UniversityId = "123456987321",
            RegistrationNumber = "123456789",
            Name = "Kale",
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

        private Student _studentUpdate = new Student()
        {
            StudentId=15,
            UniversityId = "123456987321",
            RegistrationNumber = "123456789",
            Name = "Mongoose",
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
        public void CreateStudentsData_TakesStudentsObjectAsInput_ReturnsTrue()
        {
            var result = _studentsRepository.CreateStudentData(_student);

            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }

        [Test]
        public void CreateStudentsData_TakesStudentsObjectAsInput_ThrowsInvalidOperationExecution()
        {
            Assert.Throws<InvalidOperationException>(() => _studentsRepository.CreateStudentData(_student));
        }

        [Test]
        public void CreateStudentsData_TakesStudentsObjectAsInput_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => _studentsRepositoryNoConnection.CreateStudentData(_student));
        }

        [Test]
        public void UpdateStudentData_TakesStudentObjectAsInput_ReturnsTrue()
        {
            var result = _studentsRepository.UpdateStudentData(_studentUpdate);
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }

        [Test]
        public void UpdateStudentData_TakesStudentObjectAsInput_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => _studentsRepositoryNoConnection.UpdateStudentData(_student));
        }

        [Test]
        public void ViewStudentData_TakesUniversityIdAndRegistrationNumberAsInput_ReturnsStudentsDetails()
        {

            var universityId = "123456987321";
            var registrationNumber = "123456789";
            var result = _studentsRepository.ViewStudentData(universityId, registrationNumber);

            var expected = JsonConvert.SerializeObject(_studentUpdate);
            var resultNew = JsonConvert.SerializeObject(result);

            Assert.IsNotNull(resultNew);
            Assert.AreEqual(expected, resultNew);
        }

        [Test]
        public void ViewStudentData_TakesUniversityIdAndRegistrationNumberAsInput_ThrowsKeyNotFoundException()
        {
            var universityId = "123";
            var registrationNumber = "12";
            Assert.Throws<KeyNotFoundException>(() => _studentsRepository.ViewStudentData(universityId, registrationNumber));

        }
    }
}
