using Microsoft.AspNetCore.Identity;
using System;

namespace Chopi.Modules.EFCore.Entities.Identity
{
    public class Role : IdentityRole<Guid>
    {
        public Role() { }

        public Role(string systemAndDispName) : this(systemAndDispName, systemAndDispName) { }

        public Role(string displayName, string systemName) : base(systemName)
        {
            DisplayName = displayName;
        }

        public string DisplayName { get; set; }
    }
}
