using System;
using System.ComponentModel.DataAnnotations;
using KP.BackEnd.Models;

namespace KP.BackEnd.Areas.Shared.DTOs.Card
{
    public class CardCreateDto
    {
        [Required]
        public TimeSpan Duration { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public string Description{ get; set; }
        [Required]
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