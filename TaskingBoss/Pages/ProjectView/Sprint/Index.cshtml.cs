using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using TaskingBoss.Core;
using TaskingBoss.Core.ViewModels;
using TaskingBoss.Data;
using TaskStatus = TaskingBoss.Core.TaskStatus;

namespace TaskingBoss.Pages.ProjectView.Sprint
{
    public class IndexModel : PageModel
    {
        private readonly ITaskData _taskData;
        private readonly IProjectData _projectData;
        private readonly IUserData _userData;

        public Project Project { get; set; }

        public List<TaskItem> Tasks { get; set; }
        public List<TaskItemUsersViewModel> SprintTasks { get; set; }
        public List<TaskItemUsersViewModel> DoingTasks { get; set; }
        public List<TaskItemUsersViewModel> BlockedTasks { get; set; }
        public List<TaskItemUsersViewModel> QaTasks { get; set; }
        public List<TaskItemUsersViewModel> DoneTasks { get; set; }

        public int AllSP { get; set; }
        public int SprintSP { get; set; }
        public int DoingSP { get; set; }
        public int BlockedSP { get; set; }
        public int QaSP { get; set; }
        public int DoneSP { get; set; }

        public IndexModel(ITaskData taskData, IProjectData projectData, IUserData userData)
        {
            _taskData = taskData;
            _projectData = projectData;
            _userData = userData;
        }

        public void OnGet(int projectId)
        {
            Project = _projectData.GetById(projectId);
            Tasks = _taskData.GetTasks(projectId);

            SprintTasks = _taskData.GetTasks(TaskStatus.Sprint, projectId).ToList();
            DoingTasks = _taskData.GetTasks(TaskStatus.Doing, projectId).ToList();
            BlockedTasks = _taskData.GetTasks(TaskStatus.Blocked, projectId).ToList();
            QaTasks = _taskData.GetTasks(TaskStatus.QA, projectId).ToList();
            DoneTasks = _taskData.GetTasks(TaskStatus.Done, projectId).ToList();

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
