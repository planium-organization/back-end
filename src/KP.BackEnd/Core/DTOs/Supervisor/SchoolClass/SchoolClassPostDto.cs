using System.ComponentModel.DataAnnotations;

namespace KP.BackEnd.Core.DTOs.Supervisor.SchoolClass
{
    public class SchoolClassPostDto
    {
        private string _name;
        private string _schoolName;
        public string SchoolName
        {
            get => _schoolName;
            set => _schoolName = value;
        }

        [Required]
        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }
}