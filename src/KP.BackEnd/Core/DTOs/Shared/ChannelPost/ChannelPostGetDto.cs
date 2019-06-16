using System;

namespace KP.BackEnd.Core.DTOs.Shared.ChannelPost
{
    public class ChannelPostGetDto
    {
        private Guid _id;
        private DateTime _creationTime;
        private string _text;
        private byte[] _image;
        private Guid _creatorId;

        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        public DateTime CreationTime 
        {
            get => _creationTime;
            set => _creationTime = value;
        }

        public string Text
        {
            get => _text;
            set => _text = value;
        }

        public byte[] Image 
        {
            get => _image;
            set => _image = value;
        }

        public Guid CreatorId 
        {
            get => _creatorId;
            set => _creatorId = value;
        }
    }
}