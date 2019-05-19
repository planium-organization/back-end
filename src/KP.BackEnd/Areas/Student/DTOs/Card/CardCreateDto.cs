using System;
using KP.BackEnd.Models;

namespace KP.BackEnd.Areas.Student.DTOs.Card
{
    public class CardCreateDto
    {
        public TimeSpan Duration { get; set; }
        public DateTime DueDate { get; set; }
        public string Description{ get; set; } 
        public CardStatus Status { get; set; }
        public DateTime? StartTime { get; set; }

        public Models.Card ToCard(Guid creatorId)
        {
            return new Models.Card {
                Status = Status,
                Duration = Duration,
                Description = Description,
                DueDate = DueDate,
                StartTime = StartTime,
                CreatorId = creatorId
            };
        }
    }
}