
using Doc_Patient_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doc_Patient_Project.Models
{
    public class ApplicationRoleStore: RoleStore<ApplicationRole, Hospital_ProjectContext>
    {
        public ApplicationRoleStore(Hospital_ProjectContext context, IdentityErrorDescriber errorDescriber) : base(context, errorDescriber)
        {

        }
    }
}
