using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Chopi.Modules.Share
{
    public class AddUserToRoleModel
    {

        [JsonPropertyName("username")]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [JsonPropertyName("rolename")]
        [Required(ErrorMessage = "Rolename is required")]
        public string Rolename { get; set; }
    }
}
