using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using TaskingBoss.Core;
using TaskingBoss.Data;

namespace TaskingBoss.Pages.Tasks
{
    [Authorize]
    public class ListModel : PageModel
    {
        private readonly ITaskData _taskData;

        public List<TaskItem> SprintTasks { get; set; }
        public List<TaskItem> DoingTasks { get; set; }
        public List<TaskItem> BlockedTasks { get; set; }

        [BindProperty(SupportsGet = true)] //When the user search, the propperty gets populated (Also on Get requests)
        public string SearchTerm { get; set; }

        public ListModel(ITaskData taskData)
        {
            _taskData = taskData;
        }

        public void OnGet()
        {
            //Used for search
            //Tasks = _taskData.GetTaskByName(SearchTerm);

            SprintTasks = _taskData.GetTasks(TaskStatus.Sprint).ToList();
            DoingTasks = _taskData.GetTasks(TaskStatus.Doing).ToList();
            BlockedTasks = _taskData.GetTasks(TaskStatus.Blocked).ToList();

        }
    }
}
