using System.ComponentModel.DataAnnotations;

namespace KP.BackEnd.Core.DTOs.Student.SchoolClass
{
    public class SchoolClassJoinDto
    {
        private string _token;

        [Required]
        public string Token
        {
            get => _token;
            set => _token = value;
        }
    }
}