using System;
using System.Collections.Generic;

#nullable disable

namespace Doc_Patient_Project.Models
{
    public partial class Patient
    {
        public Patient()
        {
            DoctorRatings = new HashSet<DoctorRating>();
            PatientComments = new HashSet<PatientComment>();
            UserPatients = new HashSet<UserPatient>();
        }

        public int Id { get; set; }
        public int? AppointmentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }
        public int DoctorId { get; set; }
        public int? Refer { get; set; }
        public string Status { get; set; }

        public virtual AppointmentRegistration Appointment { get; set; }
        public virtual Department Department { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Doctor ReferNavigation { get; set; }
        public virtual ICollection<DoctorRating> DoctorRatings { get; set; }
        public virtual ICollection<PatientComment> PatientComments { get; set; }
        public virtual ICollection<UserPatient> UserPatients { get; set; }
    }
}
