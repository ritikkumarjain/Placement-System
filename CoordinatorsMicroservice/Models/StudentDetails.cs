using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoordinatorsMicroservice.Models
{
    public class StudentDetails
    {

        public int StudentId { get; set; }
        public string UniversityId { get; set; }
        public string RegistrationNumber { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public string Department { get; set; }
        public string FirstSem { get; set; }
        public string SecondSem { get; set; }
        public string ThirdSem { get; set; }
        public string FourthSem { get; set; }
        public string FifthSem { get; set; }
        public string SixthSem { get; set; }
        public string SeventhSem { get; set; }
        public string EigthSem { get; set; }


    }
}
