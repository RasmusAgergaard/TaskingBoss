using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using TaskingBoss.Core;
using TaskingBoss.Core.ViewModels;
using TaskingBoss.Data;

namespace TaskingBoss.Pages.ProjectView.MyTasks
{
    public class IndexModel : PageModel
    {
        private readonly ITaskData _taskData;
        private readonly IProjectData _projectData;

        public Project Project { get; set; }
        public List<TaskItemUsersViewModel> SprintTasks { get; set; }
        public List<TaskItemUsersViewModel> DoingTasks { get; set; }
        public List<TaskItemUsersViewModel> BlockedTasks { get; set; }

        public IndexModel(ITaskData taskData, IProjectData projectData)
        {
            _taskData = taskData;
            _projectData = projectData;
        }

        public void OnGet(int projectId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            Project = _projectData.GetById(projectId);
            SprintTasks = _taskData.GetTasks(TaskStatus.Sprint, projectId, userId).ToList();
            DoingTasks = _taskData.GetTasks(TaskStatus.Doing, projectId, userId).ToList();
            BlockedTasks = _taskData.GetTasks(TaskStatus.Blocked, projectId, userId).ToList();
        }
    }
}
