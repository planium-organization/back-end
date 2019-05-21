using System;

namespace KP.BackEnd.Areas.Shared.DTOs.Comment
{
    public class CommentGetDto
    {
        private DateTime _date;
        private string _text;
        private Guid _supervisorId;
        private Guid _studentId;

        public DateTime Date {
            get => _date;
            set => _date = value;
        }

        public string Text {
            get => _text;
            set => _text = value;
        }

        public Guid SupervisorId {
            get => _supervisorId;
            set => _supervisorId = value;
        }

        public Guid StudentId {
            get => _studentId;
            set => _studentId = value;
        }

        public CommentGetDto(Models.Comment comment)
        {
            Text = comment.Text;
            Date = comment.CreationTime;
            SupervisorId = comment.SupervisorId;
            StudentId = comment.StudentId;
        }
    }
}