using System;
using KP.BackEnd.Core.DTOs.Shared.Course;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Core.DTOs.Shared.Card
{
    public class CardGetDto
    {
        private CourseGetDto _course;
        private TimeSpan _duration;
        private DateTime _dueDate;
        private DateTime? _startTime;
        private string _description;
        private bool _expired;
        private bool _done;
        private bool _editable;
        private bool _supervisorCreated;
        private Guid _id;

        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        public bool SupervisorCreated
        {
            get => _supervisorCreated;
            set => _supervisorCreated = value;
        }

        public CourseGetDto Course
        {
            get => _course;
            set => _course = value;
        }


        public TimeSpan Duration
        {
            get => _duration;
            set => _duration = value;
        }

        public DateTime DueDate 
        {
            get => _dueDate;
            set => _dueDate = value;
        }

        public DateTime? StartTime 
        {
            get => _startTime;
            set => _startTime = value;
        }

        public string Description 
        {
            get => _description;
            set => _description = value;
        }

        public bool Expired 
        {
            get => _expired;
            set => _expired = value;
        }

        public bool Done 
        {
            get => _done;
            set => _done = value;
        }

        public bool Editable 
        {
            get => _editable;
            set => _editable = value;
        }
    }
}