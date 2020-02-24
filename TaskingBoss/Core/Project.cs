using System.Collections.Generic;

namespace TaskingBoss.Core
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<ApplicationUserProjects> ApplicationUserProjects { get; } = new List<ApplicationUserProjects>();
    }
}
