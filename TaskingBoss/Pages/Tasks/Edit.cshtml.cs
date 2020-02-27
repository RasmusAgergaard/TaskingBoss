using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TaskingBoss.Core;
using TaskingBoss.Data;
using TaskStatus = TaskingBoss.Core.TaskStatus;

namespace TaskingBoss.Pages.Tasks
{
    public class EditModel : PageModel
    {
        private readonly ITaskData _taskData;
        private readonly IProjectData _projectData;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public TaskItem Task { get; set; }
        public Project Project { get; set; }
        public IEnumerable<SelectListItem> Status { get; set; }
        public IEnumerable<SelectListItem> Priority { get; set; }

        public EditModel(ITaskData taskData, IProjectData projectData, IHtmlHelper htmlHelper)
        {
            _taskData = taskData;
            _projectData = projectData;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? taskId, int projectId)
        {
            Status = _htmlHelper.GetEnumSelectList<TaskStatus>();
            Priority = _htmlHelper.GetEnumSelectList<TaskPriority>();

            Project = _projectData.GetById(projectId);

            if (taskId.HasValue)
            {
                Task = _taskData.GetById(taskId.Value);
            }
            else
            {
                Task = new TaskItem();
            }

            if (Task == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int projectId)
        {
            if (!ModelState.IsValid)
            {
                Status = _htmlHelper.GetEnumSelectList<TaskStatus>();
                Priority = _htmlHelper.GetEnumSelectList<TaskPriority>();
                return Page();
            }

            if (Task.TaskItemId > 0)
            {
                _taskData.Update(Task);
                TempData["Message"] = "Task updated!";
            }
            else
            {
                _taskData.Add(Task, projectId);
                TempData["Message"] = "Task added!";
            }

            _taskData.Commit();

            return RedirectToPage("/Tasks/Detail", new { taskId = Task.TaskItemId, projectId });
        }
    }
}
