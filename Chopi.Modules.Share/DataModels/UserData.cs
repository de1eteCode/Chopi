using Chopi.Modules.Share.Abstracts;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Chopi.Modules.Share.DataModels
{
    public class UserData : ObjectConteinered
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phonenumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }

        [JsonPropertyName("secondname")]
        public string SecondName { get; set; }

        [JsonPropertyName("middlename")]
        public string MiddleName { get; set; }

        [JsonPropertyName("passportseria")]
        public string Series { get; set; }

        [JsonPropertyName("passportnumber")]
        public string Number { get; set; }

        [JsonPropertyName("passportregistration")]
        public string ResidenceRegistration { get; set; }

        [JsonPropertyName("citizenship")]
        public string Citizenship { get; set; }

        [JsonPropertyName("dateofbirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonPropertyName("roles")]
        public IEnumerable<string> Roles { get; set; }
    }
}
