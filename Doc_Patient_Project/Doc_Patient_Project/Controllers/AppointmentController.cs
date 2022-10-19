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
    [Route("api/Appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly iUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AppointmentController(iUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllAppointment()
        {
            var List = _unitOfWork.Appointment.GetAllAppointment();
            if (List == null) return BadRequest();
            return Ok(List);
        }

        [HttpGet("{id}")]
        public IActionResult GetAppointmentById(int id)
        {
            var appointment = _unitOfWork.Appointment.Get(id);
            if (appointment == null) return BadRequest();
            return Ok(appointment);
        }
        [HttpGet("user/{userId}")]
        public IActionResult GetByUserId(string userId)
        {
            var appointment = _unitOfWork.Appointment.GetById(userId);
            if (appointment == null) return BadRequest();
            return Ok(appointment);
        }
        [HttpPost]
        public IActionResult AddAppointment(AppointmentRegisterDto appointment)
        {
            try
            {
                if (appointment == null && !ModelState.IsValid) return BadRequest();
                var Appointment = _unitOfWork.Appointment.AddAppointment(appointment);
                if (Appointment == false) return BadRequest();
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
            
        }
    }
}
