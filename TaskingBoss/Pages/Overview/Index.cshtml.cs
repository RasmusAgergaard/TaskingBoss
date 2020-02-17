using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
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
        }

        public void OnGet()
        {
            Tasks = _taskData.GetTasks();
            SprintTasks = _taskData.GetTasks(TaskStatus.Sprint).ToList();
            DoingTasks = _taskData.GetTasks(TaskStatus.Doing).ToList();
            BlockedTasks = _taskData.GetTasks(TaskStatus.Blocked).ToList();
            QaTasks = _taskData.GetTasks(TaskStatus.QA).ToList();
            DoneTasks = _taskData.GetTasks(TaskStatus.Done).ToList();

            foreach (var task in Tasks)
            {
                switch (task.Status)
                {
                    case TaskStatus.Sprint:
                        SprintSP += task.StoryPoints;
                        break;
                    case TaskStatus.Doing:
                        DoingSP += task.StoryPoints;
                        break;
                    case TaskStatus.Blocked:
                        BlockedSP += task.StoryPoints;
                        break;
                    case TaskStatus.QA:
                        QaSP += task.StoryPoints;
                        break;
                    case TaskStatus.Done:
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