using AutoMapper;
using Doc_Patient_Project.Models;
using Doc_Patient_Project.Models.DTO;
using Doc_Patient_Project.Repository.iRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Doc_Patient_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly iUnitOfWork _context;
        private readonly IMapper _mapper;
        public PatientController(iUnitOfWork context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        //[Authorize(Roles = SD.Role_Admin +","+ SD.Role_Reception +","+ SD.Role_Doctor)]
        public IActionResult GetPatients()
        {
            var Patients = _context.Patient.GetPatients();
            if (Patients == null) return BadRequest();
            return Ok(Patients);
        }
        [HttpGet("Id")]
        [Authorize]
        public IActionResult GetPatientByUserId(string Id)
        {
            var patients = _context.Patient.GetPatientByUID(Id);
            if (patients == null) return BadRequest();
            return Ok(patients);
        }

        [HttpGet("comment/{id}")]
        [Authorize]
        public IActionResult GetComments(int id)
        {
            var comments = _context.Patient.GetCommentByID(id);
            if (comments == null) return BadRequest();
            return Ok(comments);
        }

        [HttpPost]
        [Authorize(Roles =SD.Role_Reception)]
        public IActionResult AddPatient([FromBody]NewPatient patient)
        {
            var newPatient = _context.Patient.NewPatient(patient);
            if (newPatient == false) return BadRequest();
            return Ok();
        }

        [HttpPost("comment")]
        [Authorize(Roles =SD.Role_Doctor)]
        public IActionResult AddComments([FromBody]CommentDto comment)
        {
            if(comment != null && ModelState.IsValid)
            {
                var newComments = _context.Patient.AddComment(comment);
                if (newComments == false) return BadRequest();
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("refer")]
        public IActionResult UpdatePatient(int id,int docId)
        {
            var patient = _context.Patient.Get(id);
            if (patient == null) return BadRequest();
            var doc = _context.Doctor.Get(docId);
            if (doc == null) return BadRequest();
            patient.Refer = docId;
            _context.Patient.Update(patient);
            _context.Save();
            return Ok();           
        }

    }
}
