using System;
using System.ComponentModel.DataAnnotations;
using KP.BackEnd.Models;

namespace KP.BackEnd.Areas.Shared.DTOs.Card
{
    public class CardCreateDto
    {
        private TimeSpan _duration;
        private DateTime _dueDate;
        private string _description;
        private CardStatus _status;
        private DateTime? _startTime;

        [Required]
        public TimeSpan Duration {
            get => _duration;
            set => _duration = value;
        }

        [Required]
        public DateTime DueDate {
            get => _dueDate;
            set => _dueDate = value;
        }

        [Required]
        public string Description {
            get => _description;
            set => _description = value;
        }

        [Required]
        public CardStatus Status {
            get => _status;
            set => _status = value;
        }

        public DateTime? StartTime {
            get => _startTime;
            set => _startTime = value;
        }

        public Models.Card ToCard(Guid creatorId)
        {
            return new Models.Card {
                Status = Status,
                Duration = Duration,
                Description = Description,
                DueDate = DueDate,
                StartTime = StartTime,
                StudentId = creatorId
            };
        }
    }
}