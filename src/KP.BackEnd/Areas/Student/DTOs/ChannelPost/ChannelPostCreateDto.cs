using System;
using System.ComponentModel.DataAnnotations;

namespace KP.BackEnd.Areas.Student.DTOs.ChannelPost
{
    public class ChannelPostCreateDto
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public byte[] Image { get; set; }

        public Models.ChannelPost ToChannelPost(Guid creatorId)
        {
            return new Models.ChannelPost {
                Text = Text,
                Image = Image,
                CreationTime = DateTime.Now,
                CreatorId = creatorId,
            };
        }
    }
}