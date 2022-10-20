using AutoMapper;
using Doc_Patient_Project.Models;
using Doc_Patient_Project.Models.DTO;
using Doc_Patient_Project.Repository.iRepository;
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
        public IActionResult GetPatients()
        {
            var Patients = _context.Patient.GetPatients();
            if (Patients == null) return BadRequest();
            return Ok(Patients);
        }

        [HttpGet("comment/{id}")]
        public IActionResult GetComments(int id)
        {
            var comments = _context.Patient.GetCommentByID(id);
            if (comments == null) return BadRequest();
            return Ok(comments);
        }

        [HttpPost]
        public IActionResult AddPatient([FromBody]PatientDto patient)
        {
            var newPatient = _context.Patient.NewPatient(patient);
            if (newPatient == false) return BadRequest();
            return Ok();
        }
    }
}
