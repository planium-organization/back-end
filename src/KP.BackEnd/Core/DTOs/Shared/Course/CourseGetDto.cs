using System;

namespace KP.BackEnd.Core.DTOs.Shared.Course
{
    public class CourseGetDto
    {
        private string _title;
        private string _color;

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public string Color
        {
            get => _color;
            set => _color = value;
        }
    }
}