using System;
using KP.BackEnd.Core.DTOs.Shared.Course;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Core.DTOs.Shared.Card
{
    public class CardPutDto
    {
        private TimeSpan? _duration;
        private DateTime? _dueDate;
        private string _description;
        private DateTime? _startTime;
        private CoursePostDto _course;//TODO COURSEPUTDTO
        private bool? _done;

        public bool? Done
        {
            get => _done;
            set => _done = value;
        }

        public CoursePostDto Course
        {
            get => _course;
            set => _course = value;
        }

        public TimeSpan? Duration 
        {
            get => _duration;
            set => _duration = value;
        }

        public DateTime? DueDate 
        {
            get => _dueDate;
            set => _dueDate = value;
        }

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