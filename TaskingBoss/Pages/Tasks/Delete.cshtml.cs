using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskingBoss.Core;
using TaskingBoss.Data;

namespace TaskingBoss
{
    public class DeleteModel : PageModel
    {
        private readonly ITaskData _taskData;

        public TaskItem Task { get; set; }

        public DeleteModel(ITaskData taskData)
        {
            _taskData = taskData;
        }

        public IActionResult OnGet(int taskId)
        {
            Task = _taskData.GetById(taskId);

            if (Task == null)
            {
                RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int taskId)
        {
            var task = _taskData.Delete(taskId);
            _taskData.Commit();

            if (task == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"Task '{task.Title}' deleted!";
            return RedirectToPage("./List");
        }
    }
}