using System.Collections.Generic;
using TaskingBoss.Areas.Identity.Data;

namespace TaskingBoss.Core.ViewModels
{
    public class TaskItemUsersViewModel
    {
        public TaskItem Task { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}
