using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskingBoss.Areas.Identity.Data;
using TaskingBoss.Core;

namespace TaskingBoss.Data
{
    public class TaskingBossDbContext : IdentityDbContext<ApplicationUser>
    {
        public TaskingBossDbContext(DbContextOptions<TaskingBossDbContext> options) : base(options)
        {

        }

        //Types that should be created in the database
        public DbSet<Project> Projects { get; set; }
        public DbSet<ApplicationUserProjects> ApplicationUserProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUserProjects>().HasKey(t => new { t.Id, t.ProjectId });

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
