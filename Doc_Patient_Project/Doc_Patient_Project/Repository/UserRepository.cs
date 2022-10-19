

using Doc_Patient_Project.Models;
using Doc_Patient_Project.Models.DTO;
using Doc_Patient_Project.Repository.iRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Doc_Patient_Project.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Hospital_ProjectContext _context;
        //private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _iconfiguration;
       

        public UserRepository(Hospital_ProjectContext context, IConfiguration iconfiguration /*UserManager<ApplicationUser> userManager*/) 
        {
            _context = context;
            _iconfiguration = iconfiguration;
            //_roleManager = roleManager;
            //_userManager = userManager;
        }
        public Token Authenticate(string UserName, string Password)
        {
            if (UserName == "" || Password == "") return null;
            var UserInDb = (from u in _context.Users
                            join ur in _context.UserRoles
                            on u.Id equals ur.UserId
                            join r in _context.Roles
                            on ur.RoleId equals r.Id
                            where u.UserName == UserName && u.PasswordHash == Password
                            select new
                            {
                                id = u.Id,
                                UserName = u.UserName,
                                Role = r.Name
                            }).FirstOrDefault();

            //var userClaims = _context.UserClaimTable.Where(x => x.UserId == UserInDb.id).Select(x => x.claims.name).Select(x=>new Claim(x,"true")).ToList(); 


            if (UserInDb == null)
                return null;

            //JWT
          

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_iconfiguration["JWT:Key"]);
            var tokenDescritor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, UserInDb.UserName),
                    new Claim("Id",UserInDb.id),
                    new Claim(ClaimTypes.Role, UserInDb.Role),
                }),/*.Union(userClaims)),*/

                Issuer = _iconfiguration["jwt:Issuer"],
                Audience = _iconfiguration["jwt:Audience"],
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescritor);
            Token ValidToken = new Token()
            {
                token = tokenHandler.WriteToken(token),
            };

            return ValidToken;

        }

        public ICollection<UserDto> GetUser()
        {
            var UserList = (from u in _context.Users
                            join ur in _context.UserRoles
                            on u.Id equals ur.UserId
                            join r in _context.Roles
                            on ur.RoleId equals r.Id
                            select new UserDto()
                            {
                                Id = u.Id,
                                UserName = u.UserName,
                                PhoneNumber = u.PhoneNumber,
                                Email = u.Email,
                                RoleId = ur.RoleId,
                                Role = r.Name
                            }).ToList();

            if (UserList == null) return null;

            return (UserList);
        }

        public bool IsUniqueUser(string UserName)
        {
            var User = _context.Users.Count(u => u.UserName == UserName);
            if (User == 0) return true; else return false;
        }

        public  bool Register(UserDto newUser)
        {
            try
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = newUser.UserName,
                    PasswordHash = newUser.Password,
                    PhoneNumber = newUser.PhoneNumber,
                    Email = newUser.Email
                };
                _context.Users.Add(user);
                //_userManager.CreateAsync(user);
                _context.SaveChanges();

                UserRoles userRole = new UserRoles()
                {
                    UserId = user.Id,
                    RoleId = newUser.RoleId
                };
                _context.UserRoles.Add(userRole);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
                
        }
    }
}
