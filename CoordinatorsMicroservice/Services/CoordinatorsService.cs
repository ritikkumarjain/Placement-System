using CoordinatorsMicroservice.Models;
using CoordinatorsMicroservice.Repository;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoordinatorsMicroservice.Services
{
    public class CoordinatorsService : ICoordinatorsService
    {

        private readonly ICoordinatorsRepository _coordinatorsRepository;
        private readonly DatabaseContext _context;
        private IConfiguration _configuration;

        public CoordinatorsService(ICoordinatorsRepository coordinatorsRepository)
        {
            _coordinatorsRepository = coordinatorsRepository;
        }

        public CoordinatorsService(DatabaseContext context, ICoordinatorsRepository coordinatorsRepository)
        {
            _coordinatorsRepository = coordinatorsRepository;
            _context = context;
        }

        public CoordinatorsService(ICoordinatorsRepository coordinatorsRepository,DatabaseContext context, IConfiguration configuration)
        {
            _coordinatorsRepository = coordinatorsRepository;
            _configuration = configuration;
            _context = context;
        }



        public bool CreateStudentsPlacementsDetails(StudentIds studentIds)
        {
            var studentDetailsFromStudentsAPI = StudentDetailsFromStudentsAPI(studentIds.UniversityId, studentIds.RegistrationNumber);
            return _coordinatorsRepository.CreateStudentsPlacementsDetails(studentDetailsFromStudentsAPI);
        }

        public bool EditStudentsPlacementsDetails(StudentPlacement studentPlacement)
        {
            return _coordinatorsRepository.EditStudentsPlacementsDetails(studentPlacement);
        }

        public StudentsPlacementDetails ViewSingleStudentDetails(string universityId, string registrationNumber)
        {
            return _coordinatorsRepository.ViewSingleStudentDetails(universityId, registrationNumber);
        }

        public StudentDetails StudentDetailsFromStudentsAPI(string universityId, string registrationNumber)
        {
            string uriConn = _configuration.GetValue<string>("ServiceURIs:Students");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uriConn);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");

                var httpResponse = client.GetAsync($"/api/Students/ViewStudentsData/{universityId}/{registrationNumber}").Result;
                var responseString = httpResponse.Content.ReadAsStringAsync().Result;

                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Unable to reach [Students] microservice.");
                }

                StudentDetails response = JsonConvert.DeserializeObject<StudentDetails>(responseString);
                return response;
            }
        }

    }
}
