using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doc_Patient_Project.Models.DTO
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string Docname { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public int DesignationId { get; set; }
        public int oldDesId { get; set; }
        public string Designation { get; set; }
        public int? Rating { get; set; }
    }
}
