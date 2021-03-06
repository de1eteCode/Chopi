using Chopi.Modules.EFCore.Entities.Abstract;
using System;

namespace Chopi.Modules.EFCore.Entities.Identity
{
    public class Passport : BaseEntity
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public string ResidenceRegistration { get; set; }
        public string Citizenship { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
