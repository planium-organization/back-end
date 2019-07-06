using System.ComponentModel.DataAnnotations;

namespace KP.BackEnd.Core.DTOs.Shared.UserManagement
{
    public class RegisterDto
    {
        private string _email;
        private string _password;
        private string _role;

        [Required]
        public string Email
        {
            get => _email;
            set => _email = value;
        }

        [Required]
        public string Password
        {
            get => _password;
            set => _password = value;
        }

        [Required]
        public string Role
        {
            get => _role;
            set => _role = value;
        }
    }
}