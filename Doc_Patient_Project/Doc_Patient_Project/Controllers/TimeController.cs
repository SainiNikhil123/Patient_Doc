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
    [Route("api/Time")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private readonly iUnitOfWork _unitOfWork;
        public TimeController(iUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize]
        public IActionResult getTime()
        {
            return Ok(_unitOfWork.Time.GetAll().ToList());
        }
    }
}
