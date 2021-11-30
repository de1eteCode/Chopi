using System;
using System.ComponentModel.DataAnnotations;

namespace Chopi.Modules.Share
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Password not equal")]
        public string PasswordConfirim { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Second name is required")]
        public string SecondName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Series passport is required")]
        public string Series { get; set; }

        [Required(ErrorMessage = "Number passport is required")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Residence registration is required")]
        public string ResidenceRegistration { get; set; }

        [Required(ErrorMessage = "Citizenship is required")]
        public string Citizenship { get; set; }

        [Required(ErrorMessage = "DateOfBirth is required")]
        public DateTime DateOfBirth { get; set; }
    }
}
