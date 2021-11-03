using Microsoft.AspNetCore.Identity;
using System;

namespace Chopi.Modules.EFCore.Entities.Identity
{
    public class User : IdentityUser<Guid>
    {
        public Guid PassportId { get; set; }
        public virtual Passport Passport { get; set; }
    }
}
