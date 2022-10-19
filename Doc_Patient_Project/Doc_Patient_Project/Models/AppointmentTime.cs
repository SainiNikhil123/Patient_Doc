using System;
using System.Collections.Generic;

#nullable disable

namespace Doc_Patient_Project.Models
{
    public partial class AppointmentTime
    {
        public AppointmentTime()
        {
            AppointmentRegistrations = new HashSet<AppointmentRegistration>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppointmentRegistration> AppointmentRegistrations { get; set; }
    }
}
