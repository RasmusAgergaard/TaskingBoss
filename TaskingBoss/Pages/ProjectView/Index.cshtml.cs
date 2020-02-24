using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskingBoss.Core;
using TaskingBoss.Data;

namespace TaskingBoss.Pages.ProjectView
{
    public class IndexModel : PageModel
    {
        private readonly IProjectData _projectData;
        private readonly ITaskData _taskData;

        public Project Project { get; set; }
        public int NumberOfTasks { get; set; }

        public IndexModel(IProjectData projectData, ITaskData taskData)
        {
            _projectData = projectData;
            _taskData = taskData;
        }

        public IActionResult OnGet(int projectId)
        {
            NumberOfTasks = _taskData.GetCountOfTasks(projectId);
            Project = _projectData.GetById(projectId);

            if (Project == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }
    }
}
