using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doc_Patient_Project.Repository.iRepository
{
   public interface iUnitOfWork
    {
        IDoctorRepository Doctor { get; }
        IDepartmentRepository Departments { get; }
        IDesignationRepository Designation { get; }
        IAppointmentRepository Appointment { get; }
        IPatientRepository Patient { get; }
        ITimeRepository Time { get; }
        void Save();
    }
}
