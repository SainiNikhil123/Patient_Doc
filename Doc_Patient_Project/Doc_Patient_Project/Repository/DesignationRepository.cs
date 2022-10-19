using Doc_Patient_Project.Models;
using Doc_Patient_Project.Models.DTO;
using Doc_Patient_Project.Repository.iRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doc_Patient_Project.Repository
{
    public class DesignationRepository:Repository<Designation>, IDesignationRepository
    {
        private readonly Hospital_ProjectContext _context;
        public DesignationRepository(Hospital_ProjectContext Context) : base(Context)
        {
            _context = Context;
        }
        public IEnumerable<DesignationDto> GetDes()
        {
            var DepartmentList = from e in _context.Designations
                                 select new DesignationDto()
                                 {
                                     Id = e.Id,
                                     Name = e.Name
                                 };

            if (DepartmentList == null) return null;

            return DepartmentList;
        }
    }
}
