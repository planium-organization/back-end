using System;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Core.DTOs.Shared.ChannelPost
{
    public class ChannelPostGetDto
    {
        private Guid _id;
        private Guid _schoolClassId;
        private SchoolClass _schoolClass;
        private DateTime _creationTime;
        private string _text;
        private byte[] _image;

        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
        
        public Guid SchoolClassId
        {
            get => _schoolClassId;
            set => _schoolClassId = value;
        }

        public SchoolClass SchoolClass
        {
            get => _schoolClass;
            set => _schoolClass = value;
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
    }
}