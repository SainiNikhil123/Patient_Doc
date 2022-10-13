using System;
using System.Collections.Generic;

#nullable disable

namespace Hospital_Project.Models
{
    public partial class Department
    {
        public Department()
        {
            AppointmentRegistrations = new HashSet<AppointmentRegistration>();
            Doctors = new HashSet<Doctor>();
            PatientAppointments = new HashSet<Patient>();
            PatientDepartments = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string Department1 { get; set; }

        public virtual ICollection<AppointmentRegistration> AppointmentRegistrations { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Patient> PatientAppointments { get; set; }
        public virtual ICollection<Patient> PatientDepartments { get; set; }
    }
}
