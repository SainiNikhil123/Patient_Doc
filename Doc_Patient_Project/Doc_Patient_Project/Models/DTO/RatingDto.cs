using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doc_Patient_Project.Models.DTO
{
    public class RatingDto
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int Rating { get; set; }
    }
}
