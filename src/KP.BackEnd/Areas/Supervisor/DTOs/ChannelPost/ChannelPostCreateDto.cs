using System;

namespace KP.BackEnd.Areas.Supervisor.DTOs.ChannelPost
{
    public class ChannelPostCreateDto
    {
        public string Text { get; set; }
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