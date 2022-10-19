using System;
using System.Collections.Generic;

#nullable disable

namespace Doc_Patient_Project.Models
{
    public partial class PatientComment
    {
        public int PatientId { get; set; }
        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
