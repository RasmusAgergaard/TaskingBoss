using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TaskingBoss.Core;

namespace TaskingBoss.Data
{
    public class SqlProjectData : IProjectData
    {
        private readonly TaskingBossDbContext _db;

        public SqlProjectData(TaskingBossDbContext db)
        {
            _db = db;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public List<Project> GetAll(string userId)
        {
            var result = new List<Project>();

            foreach (var item in _db.ApplicationUserProjects)
            {
                if (item.Id == userId)
                {
                    result.Add(GetById(item.ProjectId));
                }
            }

            return result;
        }

        public Project GetById(int id)
        {
            return _db.Projects.Find(id);
        }

        public Project New(Project newProject, string userId)
        {
            _db.Projects.Add(newProject);
            _db.ApplicationUserProjects.Add(new ApplicationUserProjects { Id = userId, Project = newProject });
            return newProject;
        }

        public Project Update(Project updatedProject)
        {
            //Attach the updated item to the db, so it monitors the changes. Then tell ef that the states is modified. This updates the item in the db
            var entity = _db.Projects.Attach(updatedProject);
            entity.State = EntityState.Modified;

            return updatedProject;
        }
    }
}
