using System.Collections.Generic;

namespace TaskingBoss.Core
{
    public class ProjectTaskItemViewModel
    {
        public Project Project { get; set; }
        public List<TaskItem> Tasks { get; set; }
    }
}
