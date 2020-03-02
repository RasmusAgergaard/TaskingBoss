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
            SprintTasks = new List<TaskItemUsersViewModel>();
            DoingTasks = new List<TaskItemUsersViewModel>();
            BlockedTasks = new List<TaskItemUsersViewModel>();
            QaTasks = new List<TaskItemUsersViewModel>();
            DoneTasks = new List<TaskItemUsersViewModel>();
        }

        public void OnGet(int projectId)
        {
            Project = _projectData.GetById(projectId);
            Tasks = _taskData.GetTasks(projectId);

            var sprintTasks = _taskData.GetTasks(TaskStatus.Sprint, projectId).ToList();
            foreach (var task in sprintTasks)
            {
                var taskWithUsers = new TaskItemUsersViewModel();
                taskWithUsers.Task = task;
                taskWithUsers.Users = _userData.GetUsersOnTask(task.TaskItemId);
                SprintTasks.Add(taskWithUsers);
            }

            var doingTasks = _taskData.GetTasks(TaskStatus.Doing, projectId).ToList();
            foreach (var task in doingTasks)
            {
                var taskWithUsers = new TaskItemUsersViewModel();
                taskWithUsers.Task = task;
                taskWithUsers.Users = _userData.GetUsersOnTask(task.TaskItemId);
                DoingTasks.Add(taskWithUsers);
            }

            var blockedTasks = _taskData.GetTasks(TaskStatus.Blocked, projectId).ToList();
            foreach (var task in blockedTasks)
            {
                var taskWithUsers = new TaskItemUsersViewModel();
                taskWithUsers.Task = task;
                taskWithUsers.Users = _userData.GetUsersOnTask(task.TaskItemId);
                BlockedTasks.Add(taskWithUsers);
            }

            var qaTasks = _taskData.GetTasks(TaskStatus.QA, projectId).ToList();
            foreach (var task in qaTasks)
            {
                var taskWithUsers = new TaskItemUsersViewModel();
                taskWithUsers.Task = task;
                taskWithUsers.Users = _userData.GetUsersOnTask(task.TaskItemId);
                QaTasks.Add(taskWithUsers);
            }

            var doneTasks = _taskData.GetTasks(TaskStatus.Done, projectId).ToList();
            foreach (var task in doneTasks)
            {
                var taskWithUsers = new TaskItemUsersViewModel();
                taskWithUsers.Task = task;
                taskWithUsers.Users = _userData.GetUsersOnTask(task.TaskItemId);
                DoneTasks.Add(taskWithUsers);
            }

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
