using System;
using KP.BackEnd.Models;

namespace KP.BackEnd.Areas.Student.DTOs.Card
{
    public class CardGetDto
    {
        public CardGetDto(Models.Card card, Guid requesterId)
        {
            Duration = card.Duration;
            DueDate = card.DueDate;
            StartTime = card.StartTime;
            Description = card.Description;
            Expired = StartTime == null ? (DateTime.Today - DueDate.Date).Days >= 1 : (StartTime + Duration) < DateTime.Now;
            Editable = !Expired && card.Status != CardStatus.Done && card.CreatorId == requesterId;
            Done = card.Status == CardStatus.Done;
        }

        public TimeSpan Duration { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? StartTime { get; set; }
        public string Description{ get; set; } 
        public bool Expired { get; set; }
        public bool Done { get; set; }
        public bool Editable { get; set; }
    }
}