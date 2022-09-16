using CoordinatorsMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoordinatorsMicroservice.Repository
{
    public interface ICoordinatorsRepository
    {

        public bool CreateStudentsPlacementsDetails(StudentDetails studentDetails);

        public bool EditStudentsPlacementsDetails(StudentPlacement studentPlacement);

        public StudentsPlacementDetails ViewSingleStudentDetails(string UniversityId, string RegistrationNumber);

    }
}
