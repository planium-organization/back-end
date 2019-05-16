using System;
using KP.BackEnd.Models;

namespace KP.BackEnd.DTOs
{
    public class CardDto
    {
        public TimeSpan Duration { get; set; }
        public DateTime DueDate { get; set; }
        public string Description{ get; set; } 
        public CardType Type { get; set; }
    }
}