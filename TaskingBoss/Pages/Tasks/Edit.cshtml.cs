using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using TaskingBoss.Core;
using TaskingBoss.Data;

namespace TaskingBoss
{
    public class EditModel : PageModel
    {
        private readonly ITaskData _taskData;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public TaskItem Task { get; set; }
        public IEnumerable<SelectListItem> Status { get; set; }
        public IEnumerable<SelectListItem> Priority { get; set; }

        public EditModel(ITaskData taskData, IHtmlHelper htmlHelper)
        {
            _taskData = taskData;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? taskId)
        {
            Status = _htmlHelper.GetEnumSelectList<TaskStatus>();
            Priority = _htmlHelper.GetEnumSelectList<TaskPriority>();

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
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Status = _htmlHelper.GetEnumSelectList<TaskStatus>();
                Priority = _htmlHelper.GetEnumSelectList<TaskPriority>();
                return Page();
            }

            if (Task.Id > 0)
            {
                _taskData.Update(Task);
                TempData["Message"] = "Task updated!";
            }
            else
            {
                _taskData.Add(Task);
                TempData["Message"] = "Task added!";
            }

            _taskData.Commit();
            return RedirectToPage("./Detail", new { taskId = Task.Id });
        }
    }
}