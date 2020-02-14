using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskingBoss.Data;
using TaskingBoss.Core;
using Microsoft.AspNetCore.Mvc;

namespace TaskingBoss.Pages.Tasks
{
    public class ListModel : PageModel
    {
        private readonly ITaskData _taskData;

        public List<TaskItem> Tasks { get; set; }
        public List<TaskItem> SprintTasks { get; set; }
        public List<TaskItem> DoingTasks { get; set; }
        public List<TaskItem> BlockedTasks { get; set; }

        [BindProperty(SupportsGet = true)] //When the user search, the propperty gets populated (Also on Get requests)
        public string SearchTerm { get; set; }

        public ListModel(ITaskData taskData)
        {
            _taskData = taskData;
            Tasks = new List<TaskItem>();
            SprintTasks = new List<TaskItem>();
            DoingTasks = new List<TaskItem>();
            BlockedTasks = new List<TaskItem>();
        }

        public void OnGet()
        {
            //Used for search
            //Tasks = _taskData.GetTaskByName(SearchTerm);

            Tasks = _taskData.GetTasks();

            foreach (var task in Tasks)
            {
                switch (task.Status)
                {
                    case Core.TaskStatus.Sprint:
                        SprintTasks.Add(task);
                        break;
                    case Core.TaskStatus.Doing:
                        DoingTasks.Add(task);
                        break;
                    case Core.TaskStatus.Blocked:
                        BlockedTasks.Add(task);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
