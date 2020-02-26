using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using TaskingBoss.Core;
using TaskingBoss.Data;

namespace TaskingBoss.Pages.ProjectView.Backlog
{
    public class IndexModel : PageModel
    {
        private readonly ITaskData _taskData;
        private readonly IProjectData _projectData;

        public Project Project { get; set; }
        public List<TaskItem> BacklogTasks { get; set; }

        public IndexModel(ITaskData taskData, IProjectData projectData)
        {
            _taskData = taskData;
            _projectData = projectData;
        }

        public void OnGet(int projectId)
        {
            Project = _projectData.GetById(projectId);
            BacklogTasks = _taskData.GetTasks(TaskStatus.Backlog, projectId).ToList();
        }
    }
}
