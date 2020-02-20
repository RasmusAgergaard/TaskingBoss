using System;
using System.ComponentModel.DataAnnotations;

namespace TaskingBoss.Core
{
    public class Project
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
