using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using TaskingBoss.Core;
using TaskingBoss.Data;

namespace TaskingBoss.Pages.ProjectView.MyTasks
{
    public class IndexModel : PageModel
    {
        private readonly ITaskData _taskData;
        private readonly IProjectData _projectData;

        public Project Project { get; set; }
        public List<TaskItem> SprintTasks { get; set; }
        public List<TaskItem> DoingTasks { get; set; }
        public List<TaskItem> BlockedTasks { get; set; }

        public IndexModel(ITaskData taskData, IProjectData projectData)
        {
            _taskData = taskData;
            _projectData = projectData;
        }

        public void OnGet(int projectId)
        {
            Project = _projectData.GetById(projectId);
            SprintTasks = _taskData.GetTasks(TaskStatus.Sprint, projectId).ToList();
            DoingTasks = _taskData.GetTasks(TaskStatus.Doing, projectId).ToList();
            BlockedTasks = _taskData.GetTasks(TaskStatus.Blocked, projectId).ToList();
        }
    }
}
