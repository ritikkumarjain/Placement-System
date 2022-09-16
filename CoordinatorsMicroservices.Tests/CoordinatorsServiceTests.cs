using CoordinatorsMicroservice.Models;
using CoordinatorsMicroservice.Repository;
using CoordinatorsMicroservice.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoordinatorsMicroservices.Tests
{
    [TestFixture]
    class CoordinatorsServiceTests
    {

        private CoordinatorsService _coordinatorsService;
        private Mock<ICoordinatorsRepository> mock = new Mock<ICoordinatorsRepository>();
        public CoordinatorsServiceTests()
        {
            _coordinatorsService = new CoordinatorsService(mock.Object);
        }

        private readonly StudentPlacement studentPlacement = new StudentPlacement()
        {
            UniversityId = "12345678900",
            RegistrationNumber = "123456789",
            PlacementCompanyI = "NA",
            PlacementCompanyII = "NA",
            PlacementTypeI = "NA",
            PlacementTypeII = "NA"
        };

        private readonly StudentIds studentIds = new StudentIds()
        {
            UniversityId = "12345678900",
            RegistrationNumber = "123456789"
        };

        private StudentDetails studentDetails = new StudentDetails()
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


        //[Test]
        //public void CreateStudentsPlacementDetails_TakesStudentsIdsObjectAsInput_ReturnsTrue()
        //{
        //    var result = true;

        //    mock.Setup(m => m.CreateStudentsPlacementsDetails(studentDetails)).Returns(result);
            
        //    var response = _coordinatorsService.StudentDetailsFromStudentsAPI(studentIds.UniversityId,studentIds.RegistrationNumber);
        //    var response = _coordinatorsService.CreateStudentsPlacementsDetails(studentIds);
        //    Assert.IsTrue(response);
        //}

        [Test]
        public void EditStudentsPlacementDetails_TakesStudentPlacementsObjectAsInput_ReturnsTrue()
        {
            var result = true;
            mock.Setup(m => m.EditStudentsPlacementsDetails(studentPlacement)).Returns(result);
            var response = _coordinatorsService.EditStudentsPlacementsDetails(studentPlacement);

            Assert.IsTrue(response);
            Assert.IsNotNull(response);
        }

        [Test]
        public void EditStudentsPlacementDetails_TakesStudentPlacementsObjectAsInput_ReturnsFalse()
        {
            var result = false;
            mock.Setup(m => m.EditStudentsPlacementsDetails(studentPlacement)).Returns(result);
            var response = _coordinatorsService.EditStudentsPlacementsDetails(studentPlacement);

            Assert.IsFalse(response);
            Assert.IsNotNull(response);
        }

        [Test]
        public void ViewSingleStudentDetails_TakesUniversityIdAndRegistrationNumberAsInput_ReturnsTrue()
        {
            var result = new StudentsPlacementDetails()
            {
                UniversityId = "12345678900",
                RegistrationNumber = "123456789",
                PlacementCompanyI = "NA",
                PlacementCompanyII = "NA",
                PlacementTypeI = "NA",
                PlacementTypeII = "NA"
            };
            var universityId = "12345678900";
            var registrationNumber = "123456789";
            mock.Setup(m => m.ViewSingleStudentDetails(universityId, registrationNumber)).Returns(result);
            var response = _coordinatorsService.ViewSingleStudentDetails(universityId, registrationNumber);

            Assert.IsNotNull(response);
            Assert.AreEqual(result, response);
        }


        [Test]
        public void ViewSingleStudentDetails_TakesUniversityIdAndRegistrationNumberAsInput_ReturnsFalse()
        {
           
            var universityId = "12345678900";
            var registrationNumber = "123456789";
            mock.Setup(m => m.ViewSingleStudentDetails(universityId, registrationNumber)).Returns(()=>null);
            var response = _coordinatorsService.ViewSingleStudentDetails(universityId, registrationNumber);

            Assert.IsNull(response);
        }
    }
}
