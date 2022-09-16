using CoordinatorsMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoordinatorsMicroservice.Services
{
    public interface ICoordinatorsService
    {
        public bool CreateStudentsPlacementsDetails(StudentIds studentIds);

        public bool EditStudentsPlacementsDetails(StudentPlacement studentPlacement);

        public StudentsPlacementDetails ViewSingleStudentDetails(string UniversityId, string RegistrationNumber);
    }
}
