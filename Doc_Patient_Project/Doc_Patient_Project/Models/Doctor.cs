using System;
using System.Collections.Generic;

#nullable disable

namespace Doc_Patient_Project.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            AppointmentRegistrations = new HashSet<AppointmentRegistration>();
            DoctorDesignations = new HashSet<DoctorDesignation>();
            PatientDoctors = new HashSet<Patient>();
            PatientReferNavigations = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string Docname { get; set; }
        public int DepartmentId { get; set; }
        public int? Rating { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<AppointmentRegistration> AppointmentRegistrations { get; set; }
        public virtual ICollection<DoctorDesignation> DoctorDesignations { get; set; }
        public virtual ICollection<Patient> PatientDoctors { get; set; }
        public virtual ICollection<Patient> PatientReferNavigations { get; set; }
    }
}
