using Doc_Patient_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Doc_Patient_Project.Controllers
{
    [Route("api/Roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly Hospital_ProjectContext _context;
        public RolesController(Hospital_ProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = _context.Roles.ToList();
            var adminRole = roles.Find(x => x.Name == "Admin");
            roles.Remove(adminRole);
            return Ok(roles);
        }
    }
}
