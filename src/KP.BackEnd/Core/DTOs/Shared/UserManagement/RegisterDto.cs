using System.ComponentModel.DataAnnotations;

namespace KP.BackEnd.Core.DTOs.Shared.UserManagement
{
    public class RegisterDto
    {
        private string _email;
        private string _password;
        private string _role;
        private string _username;
        private string _lastName;
        private string _firstName;
        private byte[] _image;

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

        [Required]
        public string Username
        {
            get => _username;
            set => _username = value;
        }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        public byte[] Image
        {
            get => _image;
            set => _image = value;
        }
    }
}