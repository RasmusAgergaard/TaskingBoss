using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
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
        public string Abbreviation { get; set; }

        public ICollection<ApplicationUserProjects> ApplicationUserProjects { get; } = new List<ApplicationUserProjects>();

        public void SetAbbreviation()
        {
            string[] nameParts = Name.Split(" ");
            var builder = new StringBuilder();

            foreach (var item in nameParts)
            {
                var letter = item.Substring(0, 1);
                builder.Append(letter);
            }

            var abbreviation = builder.ToString().ToUpper();

            if (abbreviation.Length > 2)
            {
                abbreviation = abbreviation.Remove(2);
            }

            Abbreviation = abbreviation;
        }
    }
}
