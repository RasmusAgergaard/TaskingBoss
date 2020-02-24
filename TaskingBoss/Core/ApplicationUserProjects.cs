using TaskingBoss.Areas.Identity.Data;

namespace TaskingBoss.Core
{
    public class ApplicationUserProjects
    {
        public string Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
