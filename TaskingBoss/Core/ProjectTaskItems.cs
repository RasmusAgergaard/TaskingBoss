namespace TaskingBoss.Core
{
    public class ProjectTaskItems
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int TaskItemId { get; set; }
        public TaskItem TaskItem { get; set; }
    }
}
