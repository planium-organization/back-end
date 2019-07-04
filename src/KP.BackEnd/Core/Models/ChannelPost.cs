using System;
using System.ComponentModel.DataAnnotations;

namespace KP.BackEnd.Core.Models
{
    public class ChannelPost
    {
        private Guid _id;
        private DateTime _creationTime;
        private string _text;
        private byte[] _image;
        private Guid _creatorId;
        private Guid _schoolClassId;
//        private Supervisor _creator;//todo

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

//        public Supervisor Creator
//        {
//            get => _creator;
//            set => _creator = value;
//        }

        [Required]
        public Guid CreatorId 
        {
            get => _creatorId;
            set => _creatorId = value;
        }

        public Guid SchoolClassId
 {
            get => _schoolClassId;
            set => _schoolClassId = value;
        }
    }
}