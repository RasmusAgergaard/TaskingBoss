using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskingBoss.Core;
using TaskingBoss.Data;

namespace TaskingBoss.Pages.Backlog
{
    public class IndexModel : PageModel
    {
        private readonly ITaskData _taskData;

        public List<TaskItem> Tasks { get; set; }
        public List<TaskItem> BacklogTasks { get; set; }

        public IndexModel(ITaskData taskData)
        {
            _taskData = taskData;
            Tasks = _taskData.GetTasks();
            BacklogTasks = new List<TaskItem>();
        }

        public void OnGet()
        {
            foreach (var task in Tasks)
            {
                if (task.Status == Core.TaskStatus.Backlog)
                {
                    BacklogTasks.Add(task);
                }
            }
        }
    }
}
