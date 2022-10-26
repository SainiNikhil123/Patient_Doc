using AutoMapper;
using Doc_Patient_Project.Repository.iRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doc_Patient_Project.Controllers
{
    [Route("api/Department")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly iUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DepartmentController(iUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            var DepList = _unitOfWork.Departments.GetDep();
            if (DepList == null) return BadRequest();
            return Ok(DepList);
        }
    }
}
