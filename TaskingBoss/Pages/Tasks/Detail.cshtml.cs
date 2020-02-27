using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskingBoss.Core;
using TaskingBoss.Data;

namespace TaskingBoss.Pages.Tasks
{
    public class DetailModel : PageModel
    {
        private readonly ITaskData _taskData;
        private readonly IProjectData _projectData;

        [TempData]
        public string Message { get; set; }
        public TaskItem Task { get; set; }
        public Project Project { get; set; }

        public DetailModel(ITaskData taskData, IProjectData projectData)
        {
            _taskData = taskData;
            _projectData = projectData;
        }

        public IActionResult OnGet(int taskId, int projectId)
        {
            Project = _projectData.GetById(projectId);
            Task = _taskData.GetById(taskId);

            if (Task == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}
