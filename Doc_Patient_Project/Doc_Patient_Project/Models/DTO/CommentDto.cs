using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doc_Patient_Project.Models.DTO
{
    public class CommentDto
    {
        public int PatientId { get; set; }
        public string Comments { get; set; }
    }
}
