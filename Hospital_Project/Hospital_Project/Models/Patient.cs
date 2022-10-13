using System;
using System.Collections.Generic;

#nullable disable

namespace Hospital_Project.Models
{
    public partial class Patient
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }
        public int DoctorId { get; set; }
        public string PatientStatus { get; set; }
        public string Comments { get; set; }
        public int Refer { get; set; }

        public virtual Department Appointment { get; set; }
        public virtual Department Department { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Doctor ReferNavigation { get; set; }
    }
}
