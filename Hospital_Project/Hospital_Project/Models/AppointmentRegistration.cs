using System;
using System.Collections.Generic;

#nullable disable

namespace Hospital_Project.Models
{
    public partial class AppointmentRegistration
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public virtual Department Department { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
