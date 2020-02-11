using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskingBoss.Core;
using TaskingBoss.Data;

namespace TaskingBoss
{
    public class DetailModel : PageModel
    {
        public TaskItem Task { get; set; }

        private readonly ITaskData _taskData;

        public DetailModel(ITaskData taskData)
        {
            _taskData = taskData;
        }

        public IActionResult OnGet(int taskId)
        {
            Task = _taskData.GetById(taskId);

            if (Task == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}