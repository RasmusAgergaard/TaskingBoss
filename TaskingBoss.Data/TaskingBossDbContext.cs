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

        public DbSet<TaskItem> Tasks { get; set; }
    }
}
