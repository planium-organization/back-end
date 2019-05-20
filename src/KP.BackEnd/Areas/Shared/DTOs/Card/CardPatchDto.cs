using System;
using KP.BackEnd.Models;

namespace KP.BackEnd.Areas.Student.DTOs.Card
{
    public class CardPatchDto
    {
        public TimeSpan Duration { get; set; }
        public DateTime DueDate { get; set; }
        public string Description{ get; set; } 
        public CardStatus Status { get; set; }
        public DateTime? StartTime { get; set; }
        
        public CardPatchDto(Models.Card card, Guid requesterId)
        {
            Duration = card.Duration;
            DueDate = card.DueDate;
            StartTime = card.StartTime;
            Description = card.Description;
            Status = card.Status;
        }
    }
}