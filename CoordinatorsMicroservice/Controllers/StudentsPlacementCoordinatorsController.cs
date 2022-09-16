using CoordinatorsMicroservice.Models;
using CoordinatorsMicroservice.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoordinatorsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsPlacementCoordinatorsController : ControllerBase
    {
        private readonly ICoordinatorsService _coordinatorsService;

        public StudentsPlacementCoordinatorsController(ICoordinatorsService coordinatorsService)
        {
            _coordinatorsService = coordinatorsService;
        }

        [HttpPost]
        [Route("CreateStudentsPlacementsDetails")]
        public IActionResult CreateStudentsPlacementsDetails(StudentIds studentIds)
        {

            var result = _coordinatorsService.CreateStudentsPlacementsDetails(studentIds);

            if (result == true) { return Ok(result); }
            return NotFound();
        }


        [HttpPost]
        [Route("EditStudentsPlacementsDetails")]
        public IActionResult EditStudentsPlacementsDetails(StudentPlacement studentPlacement)
        {
            var result = _coordinatorsService.EditStudentsPlacementsDetails(studentPlacement);
            if (result == true) { return Ok(result); }
            return NotFound();
        }

        [HttpGet]
        [Route("ViewSingleStudentDetails/{UniversityId}/{RegistrationNumber}")]
        public IActionResult ViewSingleStudentDetails(string UniversityId, string RegistrationNumber)
        {
            var result = _coordinatorsService.ViewSingleStudentDetails(UniversityId, RegistrationNumber);
            if (result.Equals(null))
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
