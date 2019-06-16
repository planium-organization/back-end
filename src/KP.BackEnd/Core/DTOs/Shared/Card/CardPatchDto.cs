using System;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Core.DTOs.Shared.Card
{
    public class CardPatchDto
    {
        private TimeSpan _duration;
        private DateTime _dueDate;
        private string _description;
        private CardStatus _status;
        private DateTime? _startTime;

        public TimeSpan Duration {
            get => _duration;
            set => _duration = value;
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

        public DateTime? StartTime {
            get => _startTime;
            set => _startTime = value;
        }

        public CardPatchDto(Core.Models.Card card, Guid requesterId)
        {
            Duration = card.Duration;
            DueDate = card.DueDate;
            StartTime = card.StartTime;
            Description = card.Description;
            Status = card.Status;
        }
    }
}