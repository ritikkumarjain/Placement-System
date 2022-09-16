using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentMicroservice.Models;
using StudentMicroservice.Services;

namespace StudentMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        [HttpPost]
        [Route("CreateStudentsData")]
        public IActionResult CreateStudentsData(Student student)
        {
            var result = _studentsService.CreateStudentData(student);
            var successMessage = new
            {
                student.UniversityId,
                student.RegistrationNumber,
                student.Name,
                student.Semester,
                student.Department,
                student.FirstSem,
                student.SecondSem,
                student.ThirdSem,
                student.FourthSem,
                student.FifthSem,
                student.SixthSem,
                student.SeventhSem,
                student.EigthSem
            };

            string json_data = JsonConvert.SerializeObject(successMessage);
            if (result == true) { return Ok(result); }
            return NoContent();
        }


        [HttpPut]
        [Route("UpdateStudentsData")]
        public IActionResult UpdateStudentsData(Student student)
        {
            var result = _studentsService.UpdateStudentData(student);
            var successMessage = new
            {
                student.UniversityId,
                student.RegistrationNumber,
                student.Name,
                student.Semester,
                student.Department,
                student.FirstSem,
                student.SecondSem,
                student.ThirdSem,
                student.FourthSem,
                student.FifthSem,
                student.SixthSem,
                student.SeventhSem,
                student.EigthSem
            };

            string json_data = JsonConvert.SerializeObject(successMessage);
            if (result == true) { return Ok(result); }
            return NoContent();
        }



        [HttpGet]
        [Route("ViewStudentsData/{UniversityId}/{RegistrationNumber}")]
        public IActionResult ViewStudentsData(string UniversityId, string RegistrationNumber)
        {
            var result = _studentsService.ViewStudentData(UniversityId, RegistrationNumber);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
