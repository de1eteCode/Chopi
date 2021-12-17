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

        public static UserData ConvertToUserData(User user)
        {
            var data = new UserData();
            data.Id = user.Id;
            data.UserName = user.UserName;
            data.Email = user.Email;
            data.PhoneNumber = user.PhoneNumber;
            data.FirstName = user.Passport.FirstName;
            data.SecondName = user.Passport.SecondName;
            data.MiddleName = user.Passport.MiddleName;
            data.Series = user.Passport.Series;
            data.Number = user.Passport.Number;
            data.ResidenceRegistration = user.Passport.ResidenceRegistration;
            data.Citizenship = user.Passport.Citizenship;
            data.DateOfBirth = user.Passport.DateOfBirth;
            
            var roles = new List<string>();

            foreach (var role in user.Roles)
            {
                roles.Add(role.Role.DisplayName);
            }

            data.Roles = roles;

            return data;
        }
    }
}
