using System;
using System.ComponentModel.DataAnnotations;

namespace KP.BackEnd.Models
{
    public class Card
    {
        private Guid _id;
        private TimeSpan _duration;
        private DateTime? _startTime;
        private DateTime _dueDate;
        private string _description;
        private CardStatus _status;
        private Guid _studentId;
        private Guid? _supervisorId;

        public Guid Id {
            get => _id;
            set => _id = value;
        }

        public TimeSpan Duration {
            get => _duration;
            set => _duration = value;
        }

        public DateTime? StartTime {
            get => _startTime;
            set => _startTime = value;
        }

        public DateTime DueDate {
            get => _dueDate;
            set => _dueDate = value;
        }

        public string Description {
            get => _description;
            set => _description = value;
        }

        public CardStatus Status {
            get => _status;
            set => _status = value;
        }

        [Required]
        public Guid StudentId {
            get => _studentId;
            set => _studentId = value;
        }

        public Guid? SupervisorId {
            get => _supervisorId;
            set => _supervisorId = value;
        }

//        public bool IsExpired { get; set; } calculated property TODO
//        public bool IsEditable { get; set; } TODO
//        public bool SupervisorCreated { get; set; } look up db TODO
    }
    
    public enum  CardStatus
    {
        Todo,
        Done
    }
}