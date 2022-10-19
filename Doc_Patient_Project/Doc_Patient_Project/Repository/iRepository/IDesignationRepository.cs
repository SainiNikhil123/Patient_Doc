using Doc_Patient_Project.Models;
using Doc_Patient_Project.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doc_Patient_Project.Repository.iRepository
{
    public interface IDesignationRepository:IRepository<Designation>
    {
        IEnumerable<DesignationDto> GetDes();
    }
}
