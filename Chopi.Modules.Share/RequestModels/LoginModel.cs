using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Chopi.Modules.Share.RequestModels
{
    public class LoginModel
    {
        [JsonPropertyName("username")]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
