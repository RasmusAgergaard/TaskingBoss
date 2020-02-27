using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using TaskingBoss.Areas.Identity.Data;
using TaskingBoss.Core;
using TaskingBoss.Data;

namespace TaskingBoss.Pages.Projects
{
    public class ListModel : PageModel
    {
        private readonly IProjectData _projectData;
        private readonly UserManager<ApplicationUser> _userManager;

        [TempData]
        public string Message { get; set; }
        public List<Project> Projects { get; set; }
        public string Id { get; set; }

        public ListModel(IProjectData projectData, UserManager<ApplicationUser> userManager)
        {
            _projectData = projectData;
            _userManager = userManager;
        }

        public void OnGet()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            Projects = _projectData.GetAll(userId);
        }
    }
}
