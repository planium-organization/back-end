using System;

namespace KP.BackEnd.Areas.Shared.DTOs.Comment
{
    public class CommentGetDto
    {
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public Guid SupervisorId { get; set; }
        public Guid StudentId { get; set; }
        
        public CommentGetDto(Models.Comment comment)
        {
            Text = comment.Text;
            Date = comment.CreationTime;
            SupervisorId = comment.SupervisorId;
            StudentId = comment.StudentId;
        }
    }
}