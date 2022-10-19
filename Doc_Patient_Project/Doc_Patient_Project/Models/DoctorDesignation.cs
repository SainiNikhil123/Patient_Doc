using System;
using System.Collections.Generic;

#nullable disable

namespace Doc_Patient_Project.Models
{
    public partial class DoctorDesignation
    {
        public int DoctorId { get; set; }
        public int DesignationId { get; set; }

        public virtual Designation Designation { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
