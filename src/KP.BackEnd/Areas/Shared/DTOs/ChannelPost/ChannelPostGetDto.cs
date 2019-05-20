using System;

namespace KP.BackEnd.Areas.Shared.DTOs.ChannelPost
{
    public class ChannelPostGetDto
    {
        public Guid Id { get; set; }
        public DateTime CreationTime { get; set; }
        
        public string Text { get; set; }
        
        public byte[] Image { get; set; }
        
        public Guid CreatorId { get; set; }
        
        public ChannelPostGetDto(Models.ChannelPost channelPost)
        {
            Id = channelPost.Id;
            Text = channelPost.Text;
            Image = channelPost.Image;
            CreatorId = channelPost.CreatorId;
            CreationTime = channelPost.CreationTime;
        }
    }
}