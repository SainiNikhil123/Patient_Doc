using System;
using System.Collections.Generic;

#nullable disable

namespace Doc_Patient_Project.Models
{
    public partial class Comment
    {
        public Comment()
        {
            PatientComments = new HashSet<PatientComment>();
        }

        public int Id { get; set; }
        public string Comments { get; set; }

        public virtual ICollection<PatientComment> PatientComments { get; set; }
    }
}
