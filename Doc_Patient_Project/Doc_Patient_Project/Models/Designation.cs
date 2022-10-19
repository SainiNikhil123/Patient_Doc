using System;
using System.Collections.Generic;

#nullable disable

namespace Doc_Patient_Project.Models
{
    public partial class Designation
    {
        public Designation()
        {
            DoctorDesignations = new HashSet<DoctorDesignation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DoctorDesignation> DoctorDesignations { get; set; }
    }
}
