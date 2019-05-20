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
        public CardStatus Status { get; set; }
        public Guid CreatorId { get; set; }
//        public bool IsExpired { get; set; } calculated property TODO
//        public bool IsEditable { get; set; } TODO
//        public bool SupervisorCreated { get; set; } look up db TODO
    }
    
    public enum  CardStatus
    {
        Todo,
        Done
    }
}