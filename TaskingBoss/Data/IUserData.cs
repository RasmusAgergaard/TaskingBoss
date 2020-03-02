using System.Collections.Generic;
using TaskingBoss.Areas.Identity.Data;

namespace TaskingBoss.Data
{
    public interface IUserData
    {
        ApplicationUser GetById(string id);
        List<ApplicationUser> GetUsersOnProject(int projectId);
        List<ApplicationUser> GetUsersOnTask(int taskId);
        void AddUserToTask(string userId, int taskId);
        void RemoveUserFromTask(string userId, int taskId);
        int Commit();
    }
}
