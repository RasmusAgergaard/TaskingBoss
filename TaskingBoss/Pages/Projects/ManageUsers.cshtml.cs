using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using TaskingBoss.Areas.Identity.Data;
using TaskingBoss.Core;
using TaskingBoss.Data;

namespace TaskingBoss.Pages.Projects
{
    public class ManageUsersModel : PageModel
    {
        private readonly IProjectData _projectData;
        private readonly IUserData _userData;

        [TempData]
        public string PositiveMessage { get; set; }
        [TempData]
        public string NegativeMessage { get; set; }

        public Project Project { get; set; }
        public List<ApplicationUser> Users { get; set; }

        public ManageUsersModel(IProjectData projectData, IUserData userData)
        {
            _projectData = projectData;
            _userData = userData;
        }

        public void OnGet(int projectId)
        {
            Project = _projectData.GetById(projectId);
            Users = _userData.GetUsersOnProject(projectId);
        }

        public IActionResult OnPost(int projectId, string searchString)
        {
            
            if (_userData.AddUserToProject(projectId, searchString))
            {
                _userData.Commit();
                TempData["PositiveMessage"] = "User added to project!";
            }
            else
            {
                TempData["NegativeMessage"] = "Could not find user";
            }
            

            return RedirectToPage("/Projects/ManageUsers", new { projectId });
        }
    }
}
