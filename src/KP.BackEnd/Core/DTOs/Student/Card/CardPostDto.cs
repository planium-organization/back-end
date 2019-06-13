using System;
using System.ComponentModel.DataAnnotations;
using KP.BackEnd.Core.DTOs.Shared.Course;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Core.DTOs.Student.Card
{
    public class CardPostDto
    {
        private CoursePostDto _course;
        private TimeSpan _duration;
        private DateTime _dueDate;
        private string _description;
        private DateTime? _startTime;

        [Required]
        public CoursePostDto Course
        {
            get => _course;
            set => _course = value;
        }


        [Required]
        public TimeSpan Duration
        {
            get => _duration;
            set => _duration = value;
        }

        [Required]
        public DateTime DueDate 
        {
            get => _dueDate;
            set => _dueDate = value;
        }

        [Required]
        public string Description 
        {
            get => _description;
            set => _description = value;
        }

        public DateTime? StartTime 
        {
            get => _startTime;
            set => _startTime = value;
        }
    }
}