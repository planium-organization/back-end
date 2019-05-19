using System;
using KP.BackEnd.Models;

namespace KP.BackEnd.Areas.Supervisor.DTOs
{
    public class CardDto
    {
        public TimeSpan Duration { get; set; }
        public DateTime DueDate { get; set; }
        public string Description{ get; set; } 
        public CardStatus Type { get; set; }
    }
}