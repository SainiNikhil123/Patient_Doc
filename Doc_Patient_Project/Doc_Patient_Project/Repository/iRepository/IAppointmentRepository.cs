using Doc_Patient_Project.Models;
using Doc_Patient_Project.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doc_Patient_Project.Repository.iRepository
{
    public interface IAppointmentRepository:IRepository<AppointmentRegistration>
    {
        IEnumerable<AppointmentRegisterDto> GetAllAppointment();
        bool AddAppointment(AppointmentRegisterDto appointment);
        IEnumerable<AppointmentRegisterDto> GetById(string id);
    }
}
