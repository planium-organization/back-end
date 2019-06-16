using System;
using System.ComponentModel.DataAnnotations;

namespace KP.BackEnd.Core.DTOs.Supervisor.ChannelPost
{
    public class ChannelPostPostDto
    {
        private string _text;
        private byte[] _image;
        private Guid _classId;

        public Guid ClassId {
            get => _classId;
            set => _classId = value;
        }

        [Required]
        public string Text {
            get => _text;
            set => _text = value;
        }

        [Required]
        public byte[] Image {
            get => _image;
            set => _image = value;
        }
    }
}