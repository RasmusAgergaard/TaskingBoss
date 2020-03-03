using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using TaskingBoss.Core;
using TaskingBoss.Core.ViewModels;
using TaskingBoss.Data;
using TaskStatus = TaskingBoss.Core.TaskStatus;

namespace TaskingBoss.Pages.ProjectView.QA
{
    public class IndexModel : PageModel
    {
        private readonly ITaskData _taskData;
        private readonly IProjectData _projectData;

        public Project Project { get; set; }
        public List<TaskItemUsersViewModel> QaTasks { get; set; }

        public IndexModel(ITaskData taskData, IProjectData projectData)
        {
            _taskData = taskData;
            _projectData = projectData;
        }

        public void OnGet(int projectId)
        {
            Project = _projectData.GetById(projectId);
            QaTasks = _taskData.GetTasks(TaskStatus.QA, projectId).ToList();
        }
    }
}
