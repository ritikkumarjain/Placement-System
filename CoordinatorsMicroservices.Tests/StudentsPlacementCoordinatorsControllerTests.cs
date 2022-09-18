using CoordinatorsMicroservice.Controllers;
using CoordinatorsMicroservice.Models;
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
    class StudentsPlacementCoordinatorsControllerTests

    {

        public StudentsPlacementCoordinatorsController _coordinatorsController;

        Mock<ICoordinatorsService> mock = new Mock<ICoordinatorsService>();


        public StudentsPlacementCoordinatorsControllerTests()
        {
            _coordinatorsController = new StudentsPlacementCoordinatorsController(mock.Object);
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


        [Test]
        public void CreateStudentsPlacementsDetails_TakesStudentIdsObjectAsInput_ReturnsOkObjectResult()
        {
            var result = true;
            
            mock.Setup(m=> m.CreateStudentsPlacementsDetails(studentIds)).Returns(result);
            var response = _coordinatorsController.CreateStudentsPlacementsDetails(studentIds) as OkObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.StatusCode);

        }

        [Test]
        public void CreateStudentsPlacementsDetails_TakesStudentIdsObjectAsInput_ReturnsNotFoundResult()
        {
            var result = false;

            mock.Setup(m => m.CreateStudentsPlacementsDetails(studentIds)).Returns(result);
            var response = _coordinatorsController.CreateStudentsPlacementsDetails(studentIds) as NotFoundResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(404, response.StatusCode);
        }

        [Test]
        public void EditStudentsPlacementDetails_TakesStudentsPlacementObjectAsInput_ReturnsOkObjectResult()
        {
            var result = true;
            mock.Setup(m => m.EditStudentsPlacementsDetails(studentPlacement)).Returns(result);
            var response = _coordinatorsController.EditStudentsPlacementsDetails(studentPlacement) as OkObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.StatusCode);
        }

        [Test]
        public void EditStudentsPlacementDetails_TakesStudentsPlacementObjectAsInput_ReturnsNotFoundResult()
        {
            var result = false;
            mock.Setup(m => m.EditStudentsPlacementsDetails(studentPlacement)).Returns(result);
            var response = _coordinatorsController.EditStudentsPlacementsDetails(studentPlacement) as NotFoundResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(404, response.StatusCode);
        }

        [Test]
        public void ViewSingleStudentDetails_TakesUniversityIdAndRegistrationNumberAsInput_ReturnsOkObjectResult()
        {
            var universityId = "12345678900";
            var registrationNumber = "123456789";
            var result = new StudentsPlacementDetails()
            {
                UniversityId = "12345678900",
                RegistrationNumber = "123456789",
                PlacementCompanyI = "NA",
                PlacementCompanyII = "NA",
                PlacementTypeI = "NA",
                PlacementTypeII = "NA"
            };

            mock.Setup(m => m.ViewSingleStudentDetails(universityId, registrationNumber)).Returns(result);
            var response = _coordinatorsController.ViewSingleStudentDetails(universityId, registrationNumber) as OkObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.StatusCode);
        }

        [Test]
        public void ViewSingleStudentDetails_TakesUniversityIdAndRegistrationNumberAsInput_ReturnsNotFoundResult()
        {
            var universityId = "12345678900";
            var registrationNumber = "123456789";
            

            mock.Setup(m => m.ViewSingleStudentDetails(universityId, registrationNumber)).Returns(()=>null);
            var response = _coordinatorsController.ViewSingleStudentDetails(universityId, registrationNumber) as NotFoundResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(404, response.StatusCode);
        }


    }
}
