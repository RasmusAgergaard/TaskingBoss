using System.Collections.Generic;
using TaskingBoss.Areas.Identity.Data;
using TaskingBoss.Core;

namespace TaskingBoss.Data
{
    public class SqlUserData : IUserData
    {
        private readonly TaskingBossDbContext _db;

        public SqlUserData(TaskingBossDbContext db)
        {
            _db = db;
        }

        public void AddUserToTask(string userId, int taskId)
        {
            _db.ApplicationUserTaskItems.Add(new ApplicationUserTaskItems { Id = userId, TaskItemId = taskId });
        }

        public ApplicationUser GetById(string id)
        {
            return _db.Users.Find(id);
        }

        public List<ApplicationUser> GetUsersOnProject(int projectId)
        {
            var users = new List<ApplicationUser>();

            foreach (var item in _db.ApplicationUserProjects)
            {
                if (item.ProjectId == projectId)
                {
                    var user = GetById(item.Id);
                    users.Add(user);
                }
            }

            return users;
        }

        public List<ApplicationUser> GetUsersOnTask(int taskId)
        {
            var users = new List<ApplicationUser>();

            foreach (var item in _db.ApplicationUserTaskItems)
            {
                if (item.TaskItemId == taskId)
                {
                    var user = GetById(item.Id);
                    users.Add(user);
                }
            }

            return users;
        }

        public void RemoveUserFromTask(string userId, int taskId)
        {
            foreach (var item in _db.ApplicationUserTaskItems)
            {
                if (item.Id == userId && item.TaskItemId == taskId)
                {
                    _db.ApplicationUserTaskItems.Remove(item);
                }
            }
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }
    }
}
