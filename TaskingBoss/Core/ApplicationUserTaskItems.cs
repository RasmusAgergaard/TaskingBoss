using TaskingBoss.Areas.Identity.Data;

namespace TaskingBoss.Core
{
    public class ApplicationUserTaskItems
    {
        public string Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int TaskItemId { get; set; }
        public TaskItem TaskItem { get; set; }
    }
}
