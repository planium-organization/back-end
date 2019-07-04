using System;

namespace KP.BackEnd.Core.DTOs.Supervisor.SchoolClass
{
    public class SchoolClassGetDto
    {
        private Guid _id;
        private string _name;
        private string _schoolName;

        public string SchoolName
        {
            get => _schoolName;
            set => _schoolName = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
    }
}