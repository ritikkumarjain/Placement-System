using StudentMicroservice.Models;
using System.Collections.Generic;

namespace StudentMicroservice.Data
{
    public class StudentData
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
