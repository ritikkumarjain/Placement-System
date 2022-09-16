using CoordinatorsMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoordinatorsMicroservice.Data
{
    public class StudentsData
    {
        public static List<StudentDetails> StudentsList = new List<StudentDetails>()
        {
            new StudentDetails()
            {
                UniversityId = "123456987123",
                RegistrationNumber = "123456789",
                Name="Ritik",
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
            }
        };
    }
}
