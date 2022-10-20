using Doc_Patient_Project.Models;
using Doc_Patient_Project.Repository.iRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doc_Patient_Project.Repository
{
    public class TimeRepository :Repository<AppointmentTime>, ITimeRepository
    {
        private readonly Hospital_ProjectContext _context;
        public TimeRepository(Hospital_ProjectContext context): base(context)
        {
            _context = context;
        }
    }
}
