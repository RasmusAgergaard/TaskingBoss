using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TaskingBoss.Core;
using TaskingBoss.Data;

namespace TaskingBoss
{
    public class EditModel : PageModel
    {
        private readonly ITaskData _taskData;
        private readonly IHtmlHelper _htmlHelper;

        public TaskItem Task { get; set; }
        public IEnumerable<SelectListItem> Status { get; set; }

        public EditModel(ITaskData taskData, IHtmlHelper htmlHelper)
        {
            _taskData = taskData;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int taskId)
        {
            Status = _htmlHelper.GetEnumSelectList<TaskStatus>();

            Task = _taskData.GetById(taskId);

            if (Task == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}