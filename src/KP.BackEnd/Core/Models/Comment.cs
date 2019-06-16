using System;
using System.ComponentModel.DataAnnotations;

namespace KP.BackEnd.Core.Models
{
    public class Comment
    {
        private Guid _id;
        private DateTime _creationTime;
        private string _text;
        private Guid _supervisorId;
        private Guid _studentId;
        private Supervisor _supervisor;

        public Guid Id {
            get => _id;
            set => _id = value;
        }

        [Required]
        public DateTime CreationTime {
            get => _creationTime;
            set => _creationTime = value;
        }

        [Required]
        public string Text {
            get => _text;
            set => _text = value;
        }

        [Required]
        public Guid SupervisorId {
            get => _supervisorId;
            set => _supervisorId = value;
        }

        [Required]
        public Guid StudentId {
            get => _studentId;
            set => _studentId = value;
        }

        public Supervisor Supervisor {
            get => _supervisor;
            set => _supervisor = value;
        }
    }
}