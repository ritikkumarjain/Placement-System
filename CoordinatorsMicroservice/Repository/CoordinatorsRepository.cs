using CoordinatorsMicroservice.Data;
using CoordinatorsMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace CoordinatorsMicroservice.Repository
{
    public class CoordinatorsRepository : ICoordinatorsRepository
    {

        private readonly DatabaseContext _context;

        public CoordinatorsRepository()
        {

        }

        public CoordinatorsRepository(DatabaseContext context)
        {
            _context = context;
        }

        

        public bool CreateStudentsPlacementsDetails(StudentDetails studentDetails) 
        {
            var detailsIfExist = _context.StudentsPlacementDetails.FirstOrDefault(p => p.UniversityId.Equals(studentDetails.UniversityId) && p.RegistrationNumber.Equals(studentDetails.RegistrationNumber));
            if(detailsIfExist != null)
            {
                throw new InvalidOperationException("Data Already Present");
            }

            var placementsDetails = new StudentsPlacementDetails()
            {
                PlacementCompanyI = "NA",
                PlacementCompanyII = "NA",
                PlacementTypeI = "Not Yet Placed",
                PlacementTypeII = "Not Yet Placed",
                RegistrationNumber = studentDetails.RegistrationNumber,
                UniversityId = studentDetails.UniversityId
            };

            try
            {
                _context.StudentsPlacementDetails.Add(placementsDetails);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }

            return true;
        }


        public bool EditStudentsPlacementsDetails(StudentPlacement studentPlacement)
        {

            var viewStudentPlacementData = _context.StudentsPlacementDetails.FirstOrDefault(p => p.UniversityId.Equals(studentPlacement.UniversityId) && p.RegistrationNumber.Equals(studentPlacement.RegistrationNumber));

            if (viewStudentPlacementData == null)
            {
                throw new KeyNotFoundException();
            }

            var studentPlacementDetailsToAdd = new StudentsPlacementDetails()
            {
                PlacementId = viewStudentPlacementData.PlacementId,
                PlacementCompanyI = studentPlacement.PlacementCompanyI,
                PlacementCompanyII = studentPlacement.PlacementCompanyII,
                PlacementTypeI = studentPlacement.PlacementTypeI,
                PlacementTypeII = studentPlacement.PlacementTypeII,
                RegistrationNumber = viewStudentPlacementData.RegistrationNumber,
                UniversityId = viewStudentPlacementData.UniversityId
            };

            try
            {
                _context.StudentsPlacementDetails.Remove(viewStudentPlacementData);
                _context.StudentsPlacementDetails.Add(studentPlacementDetailsToAdd);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }

            return true;
        }


        public StudentsPlacementDetails ViewSingleStudentDetails(string UniversityId, string RegistrationNumber)
        {

            var viewStudentData = _context.StudentsPlacementDetails.FirstOrDefault(p => p.UniversityId.Equals(UniversityId) && p.RegistrationNumber.Equals(RegistrationNumber));

            if (viewStudentData == null)
            {
                throw new KeyNotFoundException("No data found for given ID");
            }

            return viewStudentData;
        }



        


    }
}
