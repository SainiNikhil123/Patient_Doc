using AutoMapper;
using Doc_Patient_Project.Models;
using Doc_Patient_Project.Models.DTO;
using Doc_Patient_Project.Repository.iRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doc_Patient_Project.Controllers
{
    [Route("api/Doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly iUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DoctorController(iUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            var DoctorList = _unitOfWork.Doctor.GetAllDoctors();
            if (DoctorList == null) return BadRequest();
            return Ok(DoctorList);
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctorById(int id)
        {
            var Doctor = _unitOfWork.Doctor.Get(id);
            if (Doctor == null) return BadRequest("Wrong Id");
            return Ok(Doctor);
        }

        [HttpPost]
        public IActionResult AddDoctor(DoctorDto doctor)
        {
            if(doctor != null && ModelState.IsValid)
            {
                var Doc = _unitOfWork.Doctor.AddDoctor(doctor);
                if (Doc != true) return BadRequest();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            // if (id == 0) return BadRequest();
            var doc = _unitOfWork.Doctor.Get(id);
            _unitOfWork.Doctor.Remove(doc);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateDoctor(DoctorDto doctor)
        {
            if(doctor != null && ModelState.IsValid)
            {
                var doc =_unitOfWork.Doctor.UpdateDoctor(doctor);
                if (doc == false) return BadRequest();
                _unitOfWork.Save();
                return Ok();
            }
            return BadRequest();
        }

    }
}
