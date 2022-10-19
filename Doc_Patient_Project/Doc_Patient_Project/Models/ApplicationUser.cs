using Doc_Patient_Project.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doc_Patient_Project.Models
{

    public class ApplicationUser: IdentityUser
    {
        public virtual ICollection<UserPatient> UserPatients { get; set; }
        public virtual ICollection<AppointmentRegistration> AppointmentRegistrations { get; set; }
    }
}
