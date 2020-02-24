using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using TaskingBoss.Core;

namespace TaskingBoss.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
        [PersonalData]
        public DateTime DOB { get; set; }

        public ICollection<ApplicationUserProjects> ApplicationUserProjects { get; } = new List<ApplicationUserProjects>();
    }
}
