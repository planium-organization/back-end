using System;

namespace KP.BackEnd.Areas.Supervisor.DTOs.Comment
{
    public class CommentCreateDto
    {
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public Guid SupervisorId { get; set; }
        
        public Models.Comment ToComment(Guid supervisorId)
        {
            return new Models.Comment() {
                Text = Text,
                CreationTime = Date,
                SupervisorId= supervisorId
            };
        }
    }
}