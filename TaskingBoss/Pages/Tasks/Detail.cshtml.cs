using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using TaskingBoss.Areas.Identity.Data;
using TaskingBoss.Core;
using TaskingBoss.Data;

namespace TaskingBoss.Pages.Tasks
{
    public class DetailModel : PageModel
    {
        private readonly ITaskData _taskData;
        private readonly IProjectData _projectData;
        private readonly IUserData _userData;

        [TempData]
        public string Message { get; set; }
        public TaskItem Task { get; set; }
        public Project Project { get; set; }
        public List<ApplicationUser> TaskUsers { get; set; }
        public List<ApplicationUser> ProjectUsers { get; set; }
        public List<string> Activity { get; set; }

        public DetailModel(ITaskData taskData, IProjectData projectData, IUserData userData)
        {
            _taskData = taskData;
            _projectData = projectData;
            _userData = userData;
        }

        public IActionResult OnGet(int taskId, int projectId)
        {
            Project = _projectData.GetById(projectId);
            Task = _taskData.GetById(taskId);
            TaskUsers = _userData.GetUsersOnTask(taskId);
            ProjectUsers = _userData.GetUsersOnProject(projectId);

            Activity = Task.ActivityLog.Split(",").ToList();

            if (Task == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}
