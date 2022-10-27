using Doc_Patient_Project.Models;
using Doc_Patient_Project.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doc_Patient_Project.Repository.iRepository
{
    public interface IPatientRepository:IRepository<Patient>
    {
        ICollection<PatientDto> GetPatients();
        List<String> GetCommentByID(int id);
        bool NewPatient(NewPatient patient);
        bool AddComment(CommentDto comment);
        List<PatientDto> GetPatientByUID(string Id); 
    }
}
