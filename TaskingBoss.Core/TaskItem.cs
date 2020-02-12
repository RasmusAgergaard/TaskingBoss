using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskingBoss.Core
{

    public class TaskItem
    {
        public int Id { get; set; }
        public TaskStatus Status { get; set; }

        [Required, StringLength(80)]
        public string Title { get; set; }

        [Required, StringLength(255)]
        public string Description { get; set; }

        //public DateTime CreateDate { get; set; }
        //public DateTime LastUpdatedDate { get; set; }
        //public List<string> History { get; set; }
        //public TaskPriority Priority { get; set; }
        //public DateTime Deadline { get; set; }
        //public int StoryPoints { get; set; }
        //public List<Task> Interdependence { get; set; }
    }
}
