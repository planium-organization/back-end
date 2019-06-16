using System;
using KP.BackEnd.Core.DTOs.Shared.Course;

namespace KP.BackEnd.Core.DTOs.Shared.Comment
{
    public class CommentGetDto
    {
        private DateTime _date;
        private string _text;
        private Guid _studentId;
        private DateTime _creationTime;
        private Guid _id;

        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
        public DateTime CreationTime
        {
            get => _creationTime;
            set => _creationTime = value;
        }

        public DateTime Date 
        {
            get => _date;
            set => _date = value;
        }

        public string Text 
        {
            get => _text;
            set => _text = value;
        }

        public Guid StudentId 
        {
            get => _studentId;
            set => _studentId = value;
        }
    }
}