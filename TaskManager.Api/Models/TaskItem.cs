using System;

namespace TaskManager.Api.Models
{
    public class TaskItem
    {
        public int Id { get; set; }                   
        public string Title { get; set; }             
        public string Description { get; set; }        
        public string Status { get; set; }             
        public DateTime CreatedAt { get; set; }         
        public int TimerHours { get; set; } = 0;        
        public DateTime TimerStart { get; set; }        
        public int RenewCount { get; set; } = 0;     
        public DateTime? CompletedAt { get; set; }   
    }
}
