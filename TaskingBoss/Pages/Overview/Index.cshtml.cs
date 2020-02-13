using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskingBoss.Core;
using TaskingBoss.Data;

namespace TaskingBoss
{
    public class IndexModel : PageModel
    {
        private readonly ITaskData _taskData;

        public List<TaskItem> Tasks { get; set; }
        public List<TaskItem> BacklogTasks { get; set; }
        public List<TaskItem> SprintTasks { get; set; }
        public List<TaskItem> DoingTasks { get; set; }
        public List<TaskItem> BlockedTasks { get; set; }
        public List<TaskItem> QaTasks { get; set; }
        public List<TaskItem> DoneTasks { get; set; }

        public IndexModel(ITaskData taskData)
        {
            _taskData = taskData;
        }

        public void OnGet()
        {
            Tasks = new List<TaskItem>();
            BacklogTasks = new List<TaskItem>();
            SprintTasks = new List<TaskItem>();
            DoingTasks = new List<TaskItem>();
            BlockedTasks = new List<TaskItem>();
            QaTasks = new List<TaskItem>();
            DoneTasks = new List<TaskItem>();

            Tasks = _taskData.GetTasks();

            foreach (var task in Tasks)
            {
                switch (task.Status)
                {
                    case Core.TaskStatus.Backlog:
                        BacklogTasks.Add(task);
                        break;
                    case Core.TaskStatus.Sprint:
                        SprintTasks.Add(task);
                        break;
                    case Core.TaskStatus.Doing:
                        DoingTasks.Add(task);
                        break;
                    case Core.TaskStatus.Blocked:
                        BlockedTasks.Add(task);
                        break;
                    case Core.TaskStatus.QA:
                        QaTasks.Add(task);
                        break;
                    case Core.TaskStatus.Done:
                        DoneTasks.Add(task);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}