using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using TaskingBoss.Core;
using TaskingBoss.Data;

namespace TaskingBoss
{
    public class IndexModel : PageModel
    {
        private readonly ITaskData _taskData;

        public List<TaskItem> Tasks { get; set; }
        public List<TaskItem> SprintTasks { get; set; }
        public List<TaskItem> DoingTasks { get; set; }
        public List<TaskItem> BlockedTasks { get; set; }
        public List<TaskItem> QaTasks { get; set; }
        public List<TaskItem> DoneTasks { get; set; }

        public int AllSP { get; set; }
        public int SprintSP { get; set; }
        public int DoingSP { get; set; }
        public int BlockedSP { get; set; }
        public int QaSP { get; set; }
        public int DoneSP { get; set; }

        public IndexModel(ITaskData taskData)
        {
            _taskData = taskData;
            Tasks = new List<TaskItem>();
            SprintTasks = new List<TaskItem>();
            DoingTasks = new List<TaskItem>();
            BlockedTasks = new List<TaskItem>();
            QaTasks = new List<TaskItem>();
            DoneTasks = new List<TaskItem>();

            AllSP = 0;
            SprintSP = 0;
            DoingSP = 0;
            BlockedSP = 0;
            QaSP = 0;
            DoneSP = 0;
        }

        public void OnGet()
        {
            Tasks = _taskData.GetTasks();

            foreach (var task in Tasks)
            {
                switch (task.Status)
                {
                    case Core.TaskStatus.Sprint:
                        SprintTasks.Add(task);
                        SprintSP += task.StoryPoints;
                        break;
                    case Core.TaskStatus.Doing:
                        DoingTasks.Add(task);
                        DoingSP += task.StoryPoints;
                        break;
                    case Core.TaskStatus.Blocked:
                        BlockedTasks.Add(task);
                        BlockedSP += task.StoryPoints;
                        break;
                    case Core.TaskStatus.QA:
                        QaTasks.Add(task);
                        QaSP += task.StoryPoints;
                        break;
                    case Core.TaskStatus.Done:
                        DoneTasks.Add(task);
                        DoneSP += task.StoryPoints;
                        break;
                    default:
                        break;
                }
            }

            AllSP = SprintSP + DoingSP + BlockedSP + QaSP + DoneSP;
        }
    }
}