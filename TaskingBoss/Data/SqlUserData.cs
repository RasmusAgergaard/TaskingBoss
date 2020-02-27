using System.Collections.Generic;
using TaskingBoss.Areas.Identity.Data;

namespace TaskingBoss.Data
{
    public class SqlUserData : IUserData
    {
        private readonly TaskingBossDbContext _db;

        public SqlUserData(TaskingBossDbContext db)
        {
            _db = db;
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
    }
}
