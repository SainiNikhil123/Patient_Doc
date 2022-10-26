using System;
using System.Collections.Generic;

#nullable disable

namespace Doc_Patient_Project.Models
{
    public partial class DoctorRating
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int Rating { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
