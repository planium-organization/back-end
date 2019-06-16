using System;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Core.DTOs.Shared.Card
{
    public class CardGetDto
    {
        private TimeSpan _duration;
        private DateTime _dueDate;
        private DateTime? _startTime;
        private string _description;
        private bool _expired;
        private bool _done;
        private bool _editable;

        public CardGetDto(Core.Models.Card card, Guid requesterId)
        {
            Duration = card.Duration;
            DueDate = card.DueDate;
            StartTime = card.StartTime;
            Description = card.Description;
            Expired = StartTime == null ? (DateTime.Today - DueDate.Date).Days >= 1 : (StartTime + Duration) < DateTime.Now;
            Editable = !Expired && card.Status != CardStatus.Done && card.StudentId == requesterId;
            Done = card.Status == CardStatus.Done;
        }

        public TimeSpan Duration {
            get => _duration;
            set => _duration = value;
        }

        public DateTime DueDate {
            get => _dueDate;
            set => _dueDate = value;
        }

        public DateTime? StartTime {
            get => _startTime;
            set => _startTime = value;
        }

        public string Description {
            get => _description;
            set => _description = value;
        }

        public bool Expired {
            get => _expired;
            set => _expired = value;
        }

        public bool Done {
            get => _done;
            set => _done = value;
        }

        public bool Editable {
            get => _editable;
            set => _editable = value;
        }
    }
}