using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskingBoss.Core;

namespace TaskingBoss.Data
{
    public class TaskingBossDbContext : IdentityDbContext
    {
        public TaskingBossDbContext(DbContextOptions<TaskingBossDbContext> options) : base(options) //Sends the options to the base class
        {

        }

        //Types that should be created in the database
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
        }
    }
}
