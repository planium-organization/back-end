using System;

namespace KP.BackEnd.Areas.Student.DTOs.ChannelPost
{
    public class ChannelPostGetDto
    {
        
        public DateTime CreationTime { get; set; }
        
        public string Text { get; set; }
        
        public byte[] Image { get; set; }
        
        public Guid CreatorId { get; set; }
        
        public ChannelPostGetDto(Models.ChannelPost channelPost)
        {
            Text = channelPost.Text;
            Image = channelPost.Image;
            CreatorId = channelPost.CreatorId;
            CreationTime = channelPost.CreationTime;
        }
    }
}