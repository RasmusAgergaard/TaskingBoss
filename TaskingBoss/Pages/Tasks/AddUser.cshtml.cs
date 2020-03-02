using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskingBoss.Areas.Identity.Data;
using TaskingBoss.Core;
using TaskingBoss.Data;

namespace TaskingBoss.Pages.Tasks
{
    public class AddUserModel : PageModel
    {
        private readonly ITaskData _taskData;
        private readonly IProjectData _projectData;
        private readonly IUserData _userData;

        [TempData]
        public string Message { get; set; }
        public TaskItem Task { get; set; }
        public Project Project { get; set; }
        public List<ApplicationUser> TaskUsers { get; set; }
        public List<ApplicationUser> ProjectUsers { get; set; }
        public List<ApplicationUser> ProjectUsersShow { get; set; }

        public AddUserModel(ITaskData taskData, IProjectData projectData, IUserData userData)
        {
            _taskData = taskData;
            _projectData = projectData;
            _userData = userData;
        }

        public IActionResult OnGet(int taskId, int projectId)
        {
            Project = _projectData.GetById(projectId);
            Task = _taskData.GetById(taskId);
            TaskUsers = _userData.GetUsersOnTask(taskId);
            ProjectUsers = _userData.GetUsersOnProject(projectId);
            ProjectUsersShow = ProjectUsers.Except(TaskUsers).ToList();

            return Page();
        }

        public IActionResult OnPost(int taskId, int projectId, string userId, bool add) 
        {
            if (add)
            {
                _userData.AddUserToTask(userId, taskId);
                _userData.Commit();
                TempData["Message"] = "User added!";
            }
            else
            {
                _userData.RemoveUserFromTask(userId, taskId);
                _userData.Commit();
                TempData["Message"] = "User removed!";
            }

            return RedirectToPage("/Tasks/AddUser", new { taskId, projectId });
        }
    }
}
