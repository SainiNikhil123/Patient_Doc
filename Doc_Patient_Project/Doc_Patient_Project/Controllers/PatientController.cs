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
        [Authorize(Roles = SD.Role_Admin +","+ SD.Role_Reception +","+ SD.Role_Doctor)]
        public IActionResult GetPatients()
        {
            var Patients = _context.Patient.GetPatients();     // GetPatients is a method in Repository which is getting Records of all Patients 
            if (Patients == null) return BadRequest();
            return Ok(Patients);
        }
        [HttpGet("Id")]
        [Authorize]
        public IActionResult GetPatientByUserId(string Id)
        {
            var patients = _context.Patient.GetPatientByUID(Id);   // GetPatientByUID is method in Repository 
            if (patients == null) return BadRequest();             // which is finding data of Patient For Perticular UserId.
            return Ok(patients);
        }

        [HttpGet("comment/{id}")]
        [Authorize]
        public IActionResult GetComments(int id)
        {
            var comments = _context.Patient.GetCommentByID(id);   // GetCommentByID is method in Repository 
            if (comments == null) return BadRequest();            // which is finding Comments of Patient For Perticular Patient.
            return Ok(comments);
        }

        [HttpPost]
        [Authorize(Roles =SD.Role_Reception)]
        public IActionResult AddPatient([FromBody]NewPatient patient)
        {
            var newPatient = _context.Patient.NewPatient(patient);        // NewPatient is method in Repository 
            if (newPatient == false) return BadRequest();                 // which is adding new Patient Records in database.
            return Ok();
        }

        [HttpPost("comment")]
        [Authorize(Roles =SD.Role_Doctor)]
        public IActionResult AddComments([FromBody]CommentDto comment)
        {
            if(comment != null && ModelState.IsValid)
            {
                var newComments = _context.Patient.AddComment(comment);          // AddComment is method in Repository  
                if (newComments == false) return BadRequest();                   // which is adding new Comments for perticular Patient By Perticular Doc in database.
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("refer")]
        public IActionResult UpdatePatient(int id,int docId)
        {                                                       // only Refer field is updated
            var patient = _context.Patient.Get(id);             // In this method first we check the patient exist for given id 
            if (patient == null) return BadRequest();           // then same for Doctor
            var doc = _context.Doctor.Get(docId);               // then update the Refer Doctor field 
            if (doc == null) return BadRequest();              
            patient.Refer = docId;
            _context.Patient.Update(patient);
            _context.Save();
            return Ok();           
        }

    }
}
