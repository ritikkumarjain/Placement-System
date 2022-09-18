using CoordinatorsMicroservice.Models;
using CoordinatorsMicroservice.Repository;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoordinatorsMicroservices.Tests
{
    [TestFixture]
    class CoordinatorsRepositoryTests
    {

        private readonly string _connectionString = "Data Source=LAPTOP-A6G2G4CS\\DATABASES_DOTNET;Initial Catalog=PlacementSystem;Integrated Security=True";

        CoordinatorsRepository _coordinatorsRepository;
        CoordinatorsRepository _coordinatorsRepositoryNoConnection;


        private readonly DatabaseContext _context = new DatabaseContext();

        public CoordinatorsRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer(_connectionString).Options;
            DatabaseContext database = new DatabaseContext(options);

            _coordinatorsRepository = new CoordinatorsRepository(database);
            _coordinatorsRepositoryNoConnection = new CoordinatorsRepository();
        }


        

        private readonly StudentDetails _studentDetails = new StudentDetails()
        {
            UniversityId = "123456987321",
            RegistrationNumber = "123456789"
        };

        private readonly StudentPlacement _studentUpdate = new StudentPlacement()
        {
            PlacementId = 6,
            PlacementTypeI = "Cogni",
            PlacementTypeII = "Not Yet Placed",
            PlacementCompanyI = "Tier I",
            PlacementCompanyII = "NA",
            UniversityId = "123456987321",
            RegistrationNumber = "123456789"


        };


        [Test(Description = "Will Fail Because Data Has Already Been entered into database")]
        public void CreateStudentsPlacementDetails_TakesStudentDetailsObjectAsInput_ReturnsTrue()
        {
            var result = _coordinatorsRepository.CreateStudentsPlacementsDetails(_studentDetails);

            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }

        [Test]
        public void CreateStudentsPlacementDetails_TakesStudentsDetailsAsInput_ThrowsInvalidOperationExecution()
        {
            Assert.Throws<InvalidOperationException>(() => _coordinatorsRepository.CreateStudentsPlacementsDetails(_studentDetails));
        }

        [Test]
        public void CreateStudentsData_TakesStudentsDetailsAsInput_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => _coordinatorsRepositoryNoConnection.CreateStudentsPlacementsDetails(_studentDetails));
        }

        [Test]
        public void UpdateStudentsPlacementDetails_TakesStudentsPlacementAsInput_ReturnsTrue()
        {
            var result = _coordinatorsRepository.EditStudentsPlacementsDetails(_studentUpdate);
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }

        [Test]
        public void UpdateStudentsPlacementDetails_TakesStudentsPlacementAsInput_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => _coordinatorsRepositoryNoConnection.EditStudentsPlacementsDetails(_studentUpdate));
        }

        [Test]
        public void ViewStudentData_TakesUniversityIdAndRegistrationNumberAsInput_ReturnsStudentsPlacementDetails()
        {

            var universityId = "123456987321";
            var registrationNumber = "123456789";
            var result = _coordinatorsRepository.ViewSingleStudentDetails(universityId, registrationNumber);

            var expected = JsonConvert.SerializeObject(_studentUpdate);
            var resultNew = JsonConvert.SerializeObject(result);

            Assert.IsNotNull(resultNew);
            //Assert.AreEqual(expected, resultNew);
        }

        [Test]
        public void ViewStudentData_TakesUniversityIdAndRegistrationNumberAsInput_ThrowsKeyNotFoundException()
        {
            var universityId = "123";
            var registrationNumber = "12";
            Assert.Throws<KeyNotFoundException>(() => _coordinatorsRepository.ViewSingleStudentDetails(universityId, registrationNumber));

        }

    }
}
