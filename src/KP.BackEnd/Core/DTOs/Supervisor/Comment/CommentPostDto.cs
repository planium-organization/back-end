using System;

namespace KP.BackEnd.Core.DTOs.Supervisor.Comment
{
    public class CommentPostDto
    {
        private DateTime _date;
        private string _text;
        private Guid _studentId;
        
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