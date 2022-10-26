using Doc_Patient_Project.Models;
using Doc_Patient_Project.Models.DTO;
using Doc_Patient_Project.Repository.iRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doc_Patient_Project.Repository
{
    public class DoctorRepository:Repository<Doctor>, IDoctorRepository
    {
        private readonly Hospital_ProjectContext _context;
        public DoctorRepository(Hospital_ProjectContext Context) : base(Context)
        {
            _context = Context;
        }
        public IEnumerable<DoctorDto> GetAllDoctors()
        {
            var DoctorList = from doc in _context.Doctors
                             join docdes in _context.DoctorDesignations
                             on doc.Id equals docdes.DoctorId
                             select new DoctorDto()
                             {
                                 Id = doc.Id,
                                 Docname = doc.Docname,
                                 DepartmentId = doc.DepartmentId,
                                 Department = doc.Department.Department1,
                                 DesignationId = docdes.DesignationId,
                                 Designation = docdes.Designation.Name,
                                 Rating = doc.Rating
                             };

            if (DoctorList == null) return null;

            return DoctorList;
        }

        public bool AddDoctor(DoctorDto doctor)
        {
            Doctor doc = new Doctor()
            {
                Docname = doctor.Docname,
                DepartmentId = doctor.DepartmentId
            };
            _context.Doctors.Add(doc);
            _context.SaveChanges();

            DoctorDesignation docdes = new DoctorDesignation()
            {
                DoctorId = doc.Id,
                DesignationId = doctor.DesignationId
            };
            _context.DoctorDesignations.Add(docdes);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateDoctor(DoctorDto doctor)
        {
            var validoc = _context.Doctors.Find(doctor.Id);
            if (validoc == null) return false;


            validoc.Docname = doctor.Docname;
            validoc.DepartmentId = doctor.DepartmentId;
            
            _context.Doctors.Update(validoc);
            _context.SaveChanges();

            var olddesignation = _context.DoctorDesignations.FirstOrDefault(x => x.DoctorId == validoc.Id && x.DesignationId == doctor.oldDesId);

            if (olddesignation != null)
            {
                _context.DoctorDesignations.Remove(olddesignation);
                _context.SaveChanges();
            }

            if(doctor.oldDesId != doctor.DesignationId)
            {
                DoctorDesignation newDes = new DoctorDesignation()
                {
                    DoctorId = validoc.Id,
                    DesignationId = doctor.DesignationId
                };
                _context.DoctorDesignations.Add(newDes);
                _context.SaveChanges();
            }
           

            return true;
        }

        public int DocRating(int docId)
        {
           var ratingCount = _context.DoctorRatings.Where(x => x.DoctorId == docId).Count();
            var ratingSum = _context.DoctorRatings.Where(x => x.DoctorId == docId).Sum(x => x.Rating);
            var rating = ratingSum / ratingCount;
            return rating;
        }

        public bool AddRating(RatingDto rating)
        {
            try
            {
                DoctorRating docRAting = new DoctorRating()
                {
                    DoctorId = rating.DoctorId,
                    PatientId = rating.PatientId,
                    Rating = rating.Rating
                };
                _context.DoctorRatings.Add(docRAting);
                _context.SaveChanges();

                var ratingCount = _context.DoctorRatings.Where(x => x.DoctorId == docRAting.DoctorId).Count();
                var ratingSum = _context.DoctorRatings.Where(x => x.DoctorId == docRAting.DoctorId).Sum(x => x.Rating);
                var newRating = ratingSum / ratingCount;

                var doc = _context.Doctors.FirstOrDefault(x => x.Id == docRAting.DoctorId);
                doc.Rating = newRating;
                _context.Doctors.Update(doc);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ;
            }
            
        }
    }
}
