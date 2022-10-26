using Doc_Patient_Project.Models;
using Doc_Patient_Project.Models.DTO;
using Doc_Patient_Project.Repository.iRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doc_Patient_Project.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _UserRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
       // private readonly ApplicationUserManager _applicationUserManager;
        public UserController(IUserRepository userRepository, RoleManager<IdentityRole> roleManager/*,ApplicationUserManager applicationUserManager*/ )
        {
            _UserRepository = userRepository;
            _roleManager = roleManager;
            //_applicationUserManager = applicationUserManager;
        }

        [HttpGet]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult GetUser()
      {
            var UserList = _UserRepository.GetUser();
            var AdminUser = UserList.FirstOrDefault(u => u.Role == "Admin");
            UserList.Remove(AdminUser);
            if (UserList == null) return BadRequest();
            return Ok(UserList);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserDto User)
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole{ Name = "Admin" });
            }
            if (!await _roleManager.RoleExistsAsync("Doctor"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Doctor" });
            }
            if (!await _roleManager.RoleExistsAsync("Patient"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Patient" });
            }
            if (!await _roleManager.RoleExistsAsync("Reception"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Reception" });
            }

            if (User == null && !ModelState.IsValid) return BadRequest();

            //var isUnique = await _applicationUserManager.FindByNameAsync(User.UserName);
            var isUnique = _UserRepository.IsUniqueUser(User.UserName);
            if (isUnique != true) return BadRequest();

            var users = _UserRepository.Register(User);
            if (users != true) return BadRequest();
            return Ok();
        }

        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] Login login)
        {
            var user = _UserRepository.Authenticate(login.UserName, login.Password);
            if (user == null) return BadRequest("Wromg User / PWD");
            return Ok(user);
        }
    }
}
