using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

namespace KP.BackEnd.Models
{
    public class ChannelPost
    {
        public Guid Id { get; set; }
        
        public DateTime CreationTime { get; set; }
        
        public string Text { get; set; }
        
        public byte[] Image { get; set; }
        
        public Supervisor Creator { get; set; }
        [Required]
        public Guid CreatorId { get; set; }
    }
}