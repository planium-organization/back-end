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
        private Guid _schoolClassId;
        private SchoolClass _schoolClass;

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

        [Required]
        public Guid SchoolClassId
 {
            get => _schoolClassId;
            set => _schoolClassId = value;
        }
        
        public virtual SchoolClass SchoolClass
        {
            get => _schoolClass;
            set => _schoolClass = value;
        }
    }
}