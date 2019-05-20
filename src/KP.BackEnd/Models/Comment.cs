using System;
using System.ComponentModel.DataAnnotations;

namespace KP.BackEnd.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public DateTime CreationTime { get; set; }
        public string Text { get; set; }
        
        [Required]
        public Guid SupervisorId { get; set; }
        public Supervisor Supervisor { get; set; }
    }
}