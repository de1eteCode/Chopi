using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Chopi.Modules.Share.RequestModels
{
    public class RegisterModel
    {
        [JsonPropertyName("username")]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [JsonPropertyName("email")]
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [JsonPropertyName("passwordconfirim")]
        [Compare(nameof(Password), ErrorMessage = "Password not equal")]
        public string PasswordConfirim { get; set; }

        [JsonPropertyName("firstname")]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [JsonPropertyName("secondname")]
        [Required(ErrorMessage = "Second name is required")]
        public string SecondName { get; set; }

        [JsonPropertyName("middlename")]
        public string MiddleName { get; set; }

        [JsonPropertyName("passportseria")]
        [Required(ErrorMessage = "Series passport is required")]
        public string Series { get; set; }

        [JsonPropertyName("passportnumber")]
        [Required(ErrorMessage = "Number passport is required")]
        public string Number { get; set; }

        [JsonPropertyName("passportregistration")]
        [Required(ErrorMessage = "Residence registration is required")]
        public string ResidenceRegistration { get; set; }

        [JsonPropertyName("citizenship")]
        [Required(ErrorMessage = "Citizenship is required")]
        public string Citizenship { get; set; }

        [JsonPropertyName("dateofbirth")]
        [Required(ErrorMessage = "DateOfBirth is required")]
        public DateTime DateOfBirth { get; set; }
    }
}
