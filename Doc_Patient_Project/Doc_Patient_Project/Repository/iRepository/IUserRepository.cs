using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Doc_Patient_Project.Models.DTO;

namespace Doc_Patient_Project.Repository.iRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string UserName); 
        Token Authenticate(string UserName, string Password);
        bool Register(UserDto newUser);
        ICollection<UserDto> GetUser();
    }
}
