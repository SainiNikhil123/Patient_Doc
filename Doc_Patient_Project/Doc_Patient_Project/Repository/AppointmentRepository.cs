using Doc_Patient_Project.Models;
using Doc_Patient_Project.Models.DTO;
using Doc_Patient_Project.Repository.iRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doc_Patient_Project.Repository
{
    public class AppointmentRepository:Repository<AppointmentRegistration>, IAppointmentRepository
    {
        private readonly Hospital_ProjectContext _context;
        public AppointmentRepository(Hospital_ProjectContext Context) : base(Context)
        {
            _context = Context;
        }

        public bool AddAppointment(AppointmentRegisterDto appointment)
        {
            if (appointment == null) return false;
            AppointmentRegistration Appointment = new AppointmentRegistration()
            {
                PatientName = appointment.PatientName,
                PhoneNumber = appointment.PhoneNumber,
                Address = appointment.Address,
                DepartmentId = appointment.DepartmentId,
                DoctorId = appointment.DoctorId,
                AppointmentDate = appointment.AppointmentDate,
                AppointmentTimes = appointment.AppointmentTimes,
                UserId = appointment.UserId
            };
            _context.AppointmentRegistrations.Add(Appointment);
            _context.SaveChanges();

            return true;
        }

        public IEnumerable<AppointmentRegisterDto> GetAllAppointment()
        {
            var AppointmentList = from a in _context.AppointmentRegistrations
                                  join d in _context.Doctors
                                  on a.DoctorId equals d.Id
                                  join dep in _context.Departments
                                  on a.DepartmentId equals dep.Id
                                  join t in _context.AppointmentTimes
                                  on a.AppointmentTimes equals t.Id
                                  select new AppointmentRegisterDto()
                                  {
                                      Id = a.Id,
                                      PatientName = a.PatientName,
                                      PhoneNumber = a.PhoneNumber,
                                      Address = a.Address,
                                      AppointmentDate = a.AppointmentDate,
                                      AppointmentTimes = a.AppointmentTimes,
                                      Time = t.Name,
                                      DepartmentId = a.DepartmentId,
                                      Department = dep.Department1,
                                      DoctorId = a.DoctorId,
                                      Doctor = d.Docname,
                                      UserId = a.UserId
                                  };

            if (AppointmentList == null) return null;

            return AppointmentList;
        }

        public IEnumerable<AppointmentRegisterDto> GetById(string id)
        {
           //var Appointment = _context.AppointmentRegistrations.Where(x => x.UserId == id).ToList();
            var AppointmentByUser = from a in _context.AppointmentRegistrations
                                    where a.UserId == id
                                    join d in _context.Doctors
                                    on a.DoctorId equals d.Id
                                    join dep in _context.Departments
                                    on a.DepartmentId equals dep.Id
                                    join t in _context.AppointmentTimes
                                    on a.AppointmentTimes equals t.Id
                                    select new AppointmentRegisterDto()
                                    {
                                        Id = a.Id,
                                        PatientName = a.PatientName,
                                        PhoneNumber = a.PhoneNumber,
                                        Address = a.Address,
                                        AppointmentDate = a.AppointmentDate,
                                        AppointmentTimes = a.AppointmentTimes,
                                        Time = t.Name,
                                        DepartmentId = a.DepartmentId,
                                        Department = dep.Department1,
                                        DoctorId = a.DoctorId,
                                        Doctor = d.Docname,
                                        UserId = a.UserId
                                    };

            if (AppointmentByUser == null) return null;
            
            return AppointmentByUser;
        }

    }
}
