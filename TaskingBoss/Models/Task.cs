using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaskingBoss.Models.Enums;

namespace TaskingBoss.Models
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }
        public TaskStatus Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public List<string> History { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime Deadline { get; set; }
        public int StoryPoints { get; set; }
        //public List<Task> Interdependence { get; set; }
    }
}