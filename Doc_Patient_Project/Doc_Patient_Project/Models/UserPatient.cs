
using System;
using System.Collections.Generic;

#nullable disable

namespace Doc_Patient_Project.Models
{
    public partial class UserPatient
    {
        public string UserId { get; set; }
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
