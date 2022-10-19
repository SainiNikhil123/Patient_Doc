using System;
using System.Collections.Generic;

#nullable disable

namespace Doc_Patient_Project.Models
{
    public partial class Department
    {
        public Department()
        {
            AppointmentRegistrations = new HashSet<AppointmentRegistration>();
            Doctors = new HashSet<Doctor>();
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string Department1 { get; set; }

        public virtual ICollection<AppointmentRegistration> AppointmentRegistrations { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
