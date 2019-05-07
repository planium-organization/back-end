using System;

namespace KP.BackEnd.Models
{
    public class Card
    {
        public Guid Id { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime DueDate { get; set; }
        public string Description{ get; set; }
        public CardType Type { get; set; }
        public bool IsDone { get; set; }
        public bool IsExpired { get; set; }
        public bool IsEditable { get; set; }
        public bool SupervisorCreated { get; set; } 
    }
    
    public enum  CardType
    {
        Todo,
        Burned,
        Expired,
        Backward
    }
}