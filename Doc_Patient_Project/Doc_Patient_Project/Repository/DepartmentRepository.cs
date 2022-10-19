using Doc_Patient_Project.Models;
using Doc_Patient_Project.Models.DTO;
using Doc_Patient_Project.Repository.iRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doc_Patient_Project.Repository
{
    public class DepartmentRepository:Repository<Department>, IDepartmentRepository
    {
        private readonly Hospital_ProjectContext _context;
        public DepartmentRepository(Hospital_ProjectContext Context) : base(Context)
        {
            _context = Context;
        }

        public IEnumerable<DepartmentDto> GetDep()
        {
            var DepartmentList = from e in _context.Departments
                                 select new DepartmentDto()
                                 {
                                     Id = e.Id,
                                     Department1 = e.Department1
                                 };

            if (DepartmentList == null) return null;

            return DepartmentList;
        }
    }
}
