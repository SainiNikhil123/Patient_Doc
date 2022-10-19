using Doc_Patient_Project.Models;
using Doc_Patient_Project.Models.DTO;
using Doc_Patient_Project.Repository.iRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doc_Patient_Project.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private readonly Hospital_ProjectContext _context;
        public PatientRepository(Hospital_ProjectContext context) : base(context)
        {
            _context = context;
        }

        public List<string> GetCommentByID(int id)
        {
            var Comments = (from c in _context.Comments
                            join pc in _context.PatientComments
                            on c.Id equals pc.CommentId
                            join p in _context.Patients
                            on pc.PatientId equals p.Id
                            where pc.PatientId == id
                            select c.Comments).ToList();

            if (Comments == null) return null;
            
            return Comments;
        }

        public ICollection<PatientDto> GetPatients()
        {
            var PatientList = (from p in _context.Patients
                               join d in _context.Doctors
                               on p.DoctorId equals d.Id
                               join dep in _context.Departments
                               on p.DepartmentId equals dep.Id
                               select new PatientDto()
                               {
                                   Id = p.Id,
                                   AppointmentId = p.AppointmentId,
                                   Name = p.Name,
                                   Address = p.Address,
                                   PhoneNumber = p.PhoneNumber,
                                   DoctorId = p.DoctorId,
                                   Doctor = d.Docname,
                                   DepartmentId = p.DepartmentId,
                                   Department = dep.Department1,
                                   Refer = p.Refer,
                                   ReferName = d.Docname,
                                   Status = p.Status
                               }).ToList();

            if (PatientList == null) return null;

            return PatientList;
        }

        public bool NewPatient(PatientDto patient)
        {
            try
            {
                var user = _context.AppointmentRegistrations.FirstOrDefault(x => x.Id == patient.AppointmentId);
                patient.UserId = user.UserId;

                Patient newPatient = new Patient()
                {
                    AppointmentId = patient.AppointmentId,
                    Name = patient.Name,
                    Address = patient.Address,
                    PhoneNumber = patient.PhoneNumber,
                    DepartmentId = patient.DepartmentId,
                    DoctorId = patient.DoctorId,
                    Refer = patient.Refer,
                    Status = patient.Status
                };
                _context.Patients.Add(newPatient);
                _context.SaveChanges();

                List<Comment> CommentList = new List<Comment>();
                foreach (var item in patient.Comments)
                {
                    Comment comments = new Comment()
                    {
                        Comments = item
                    };
                    CommentList.Add(comments);
                }
                _context.Comments.AddRange(CommentList);
                _context.SaveChanges();

                List<PatientComment> patientCommentList = new List<PatientComment>();
                foreach (var item in CommentList)
                {
                    PatientComment patientComment = new PatientComment()
                    {
                        PatientId = newPatient.Id,
                        CommentId = item.Id
                    };
                    patientCommentList.Add(patientComment);
                }
                _context.PatientComments.AddRange(patientCommentList);
                _context.SaveChanges();

                UserPatient userPatient = new UserPatient()
                {
                    UserId = patient.UserId,
                    PatientId = newPatient.Id
                };
                _context.UserPatients.Add(userPatient);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
    }

    
}
