using System;
using System.ComponentModel.DataAnnotations;

namespace KP.BackEnd.Core.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Title { get; set;}
        public string Color { get; set; }
    }
}