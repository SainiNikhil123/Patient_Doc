using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doc_Patient_Project.Models.DTO
{
    public class PatientDto
    {
        public int Id { get; set; }
        public int? AppointmentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public int DoctorId { get; set; }
        public string Doctor { get; set; }
        public string Status { get; set; }
        public List<string> Comments { get; set; }
        public int? Refer { get; set; }
        public string ReferName { get; set; }
        public string UserId { get; set; }
        public Doctor Doctors { get; set; }
    }
}
