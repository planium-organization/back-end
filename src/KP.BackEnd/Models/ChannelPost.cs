using System;
using System.ComponentModel.DataAnnotations;

namespace KP.BackEnd.Models
{
    public class ChannelPost
    {
        private Guid _id;

        public Guid Id {
            get => _id;
            set => _id = value;
        }

        public DateTime CreationTime { get; set; }
        
        public string Text { get; set; }
        
        public byte[] Image { get; set; }
        
        public Supervisor Creator { get; set; }
        [Required]
        public Guid CreatorId { get; set; }
        public Guid ClassId { get; set; } // TODO
    }
}