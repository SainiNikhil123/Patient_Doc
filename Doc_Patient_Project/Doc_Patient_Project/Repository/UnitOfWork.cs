using Doc_Patient_Project.Models;
using Doc_Patient_Project.Repository.iRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doc_Patient_Project.Repository
{
    public class UnitOfWork : iUnitOfWork
    {
        private readonly Hospital_ProjectContext _context;
        public UnitOfWork(Hospital_ProjectContext context)
        {
            _context = context;
            Doctor = new DoctorRepository(_context);
            Departments = new DepartmentRepository(_context);
            Designation = new DesignationRepository(_context);
            Appointment = new AppointmentRepository(_context);
            Patient = new PatientRepository(_context);
        }

        public IDoctorRepository Doctor { get; private set; }

        public IDepartmentRepository Departments { get; private set; }

        public IDesignationRepository Designation { get; private set; }

        public IAppointmentRepository Appointment { get; private set; }

        public IPatientRepository Patient { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
