using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using TaskingBoss.Core;
using TaskingBoss.Data;

namespace TaskingBoss.Pages.QA
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ITaskData _taskData;

        public List<TaskItem> QaTasks { get; set; }

        public IndexModel(ITaskData taskData)
        {
            _taskData = taskData;
        }

        public void OnGet()
        {
            QaTasks = _taskData.GetTasks(TaskStatus.QA).ToList();
        }
    }
}
