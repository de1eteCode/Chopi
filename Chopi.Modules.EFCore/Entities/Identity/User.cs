using Chopi.Modules.Share;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Chopi.Modules.EFCore.Entities.Identity
{
    public class User : IdentityUser<Guid>
    {
        public Guid PassportId { get; set; }
        public virtual Passport Passport { get; set; }
        public virtual IEnumerable<UserRole> Roles { get; set; }

        public UserData ToUserData()
        {
            var data = new UserData();
            data.Id = Id;
            data.UserName = UserName;
            data.Email = Email;
            data.PhoneNumber = PhoneNumber;
            data.FirstName = Passport.FirstName;
            data.SecondName = Passport.SecondName;
            data.MiddleName = Passport.MiddleName;
            data.Series = Passport.Series;
            data.Number = Passport.Number;
            data.ResidenceRegistration = Passport.ResidenceRegistration;
            data.Citizenship = Passport.Citizenship;
            data.DateOfBirth = Passport.DateOfBirth;
            
            var roles = new List<string>();

            foreach (var role in Roles)
            {
                roles.Add(role.Role.DisplayName);
            }

            data.Roles = roles;

            return data;
        }
    }
}
