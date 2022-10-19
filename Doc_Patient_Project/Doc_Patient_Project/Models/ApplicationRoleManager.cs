﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doc_Patient_Project.Models
{
    public class ApplicationRoleManager :RoleManager<ApplicationRole>
    {
       public ApplicationRoleManager(ApplicationRoleStore appRoleStore,
       IEnumerable<IRoleValidator<ApplicationRole>> roleValidators,
       ILookupNormalizer lookupNormalizer, IdentityErrorDescriber identityErrorDescriber,
       ILogger<ApplicationRoleManager> logger) : base(appRoleStore, roleValidators, lookupNormalizer,
       identityErrorDescriber, logger)
        {

        }
    }
}
