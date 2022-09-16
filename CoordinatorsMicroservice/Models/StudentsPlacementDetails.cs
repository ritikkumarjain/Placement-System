using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoordinatorsMicroservice.Models
{
    public class StudentsPlacementDetails
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlacementId { get; set; }
        public string PlacementTypeI { get; set; }
        public string PlacementTypeII { get; set; }
        public string PlacementCompanyI { get; set; }
        public string PlacementCompanyII { get; set; }
        public string UniversityId { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
