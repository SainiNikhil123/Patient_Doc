
using System;
using System.Collections.Generic;

#nullable disable

namespace Doc_Patient_Project.Models
{
    public partial class AppointmentRegistration
    {
        public AppointmentRegistration()
        {
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string PatientName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int AppointmentTimes { get; set; }
        public string UserId { get; set; }

        public virtual AppointmentTime AppointmentTimesNavigation { get; set; }
        public virtual Department Department { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
