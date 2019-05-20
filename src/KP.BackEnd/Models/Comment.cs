using System;
using System.ComponentModel.DataAnnotations;

namespace KP.BackEnd.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        [Required]
        public DateTime CreationTime { get; set; }
        [Required]
        public string Text { get; set; }
        
        [Required]
        public Guid SupervisorId { get; set; }
        [Required]
        public Guid StudentId { get; set; }
        public Supervisor Supervisor { get; set; }
    }
}