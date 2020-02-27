using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using TaskingBoss.Areas.Identity.Data;
using TaskingBoss.Core;
using TaskingBoss.Data;

namespace TaskingBoss.Pages.ProjectView
{
    public class IndexModel : PageModel
    {
        private readonly IProjectData _projectData;
        private readonly ITaskData _taskData;
        private readonly IUserData _userData;

        public Project Project { get; set; }
        public List<TaskItem> Tasks { get; set; }
        public List<ApplicationUser> Users { get; set; }

        public int NumberOfTasks { get; set; }
        public int ProjectProgress { get; set; }
        public int SprintProgress { get; set; }

        public int AllSP { get; set; }
        public int AllSprintSP { get; set; }
        public int BacklogSP { get; set; }
        public int SprintSP { get; set; }
        public int DoingSP { get; set; }
        public int BlockedSP { get; set; }
        public int QaSP { get; set; }
        public int DoneSP { get; set; }

        public IndexModel(IProjectData projectData, ITaskData taskData, IUserData userData)
        {
            _projectData = projectData;
            _taskData = taskData;
            _userData = userData;
        }

        public IActionResult OnGet(int projectId)
        {
            Users = _userData.GetUsersOnProject(projectId);

            Tasks = _taskData.GetTasks(projectId);

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
                    case TaskStatus.Backlog:
                        BacklogSP += task.StoryPoints;
                        break;
                    case TaskStatus.Archived:
                        break;
                    default:
                        break;
                }
            }

            AllSP = BacklogSP + SprintSP + DoingSP + BlockedSP + QaSP + DoneSP;
            AllSprintSP = AllSP - BacklogSP;

            //Project progress
            float projectProgressResult = ((float)DoneSP / (float)AllSP) * 100;
            ProjectProgress = (int)projectProgressResult;

            //Sprint progress
            float sprintProgressResult = ((float)(DoneSP) / (float)AllSprintSP) * 100;
            SprintProgress = (int)sprintProgressResult;

            NumberOfTasks = _taskData.GetCountOfTasks(projectId);
            Project = _projectData.GetById(projectId);

            if (Project == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }
    }
}
