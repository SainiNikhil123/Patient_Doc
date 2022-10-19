using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doc_Patient_Project.Models.DTO
{
    public class AppointmentRegisterDto
    {
        public string UserId { get; set; }
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public int DoctorId { get; set; }
        public string Doctor { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int AppointmentTimes { get; set; }
        public string Time { get; set; }
    }
}
