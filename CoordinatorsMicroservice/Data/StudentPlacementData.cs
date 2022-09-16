using CoordinatorsMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoordinatorsMicroservice.Data
{
    public class StudentPlacementData
    {
        public static List<StudentsPlacementDetails> StudentsPlacementDetail = new List<StudentsPlacementDetails>()
        {
            new StudentsPlacementDetails()
            {
                PlacementTypeI = "Tier II",
                PlacementTypeII ="NA",
          
            }
        };
    }
}
