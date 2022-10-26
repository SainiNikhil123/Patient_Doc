using AutoMapper;
using Doc_Patient_Project.Models;
using Doc_Patient_Project.Models.DTO;
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
    [Route("api/Designation")]
    [ApiController]
    [Authorize(Roles = SD.Role_Admin)]
    public class DesignationController : ControllerBase
    {
        private readonly iUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DesignationController(iUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetDesignation()
        {
            var DesList = _unitOfWork.Designation.GetDes();
            if (DesList == null) return BadRequest();
            return Ok(DesList);
        }
    }
}
