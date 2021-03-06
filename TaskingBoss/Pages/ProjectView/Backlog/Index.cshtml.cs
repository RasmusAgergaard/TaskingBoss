using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using TaskingBoss.Core;
using TaskingBoss.Core.ViewModels;
using TaskingBoss.Data;

namespace TaskingBoss.Pages.ProjectView.Backlog
{
    public class IndexModel : PageModel
    {
        private readonly ITaskData _taskData;
        private readonly IProjectData _projectData;
        private readonly IUserData _userData;

        public Project Project { get; set; }
        public List<TaskItemUsersViewModel> BacklogTasksWithUsers { get; set; }

        public IndexModel(ITaskData taskData, IProjectData projectData, IUserData userData)
        {
            _taskData = taskData;
            _projectData = projectData;
            _userData = userData;
        }

        public void OnGet(int projectId)
        {
            Project = _projectData.GetById(projectId);
            BacklogTasksWithUsers = _taskData.GetTasks(TaskStatus.Backlog, projectId).ToList();
        }
    }
}
