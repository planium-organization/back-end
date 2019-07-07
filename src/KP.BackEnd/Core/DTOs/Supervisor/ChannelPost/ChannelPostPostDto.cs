using System;
using System.ComponentModel.DataAnnotations;

namespace KP.BackEnd.Core.DTOs.Supervisor.ChannelPost
{
    public class ChannelPostPostDto
    {
        private string _text;
        private byte[] _image;
        private Guid _schoolClassId;
        
        public Guid SchoolClassId 
        {
            get => _schoolClassId;
            set => _schoolClassId = value;
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