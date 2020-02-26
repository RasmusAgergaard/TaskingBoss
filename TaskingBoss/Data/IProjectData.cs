using System.Collections.Generic;
using TaskingBoss.Core;

namespace TaskingBoss.Data
{
    public interface IProjectData
    {
        public Project New(Project newProject, string userId);
        public List<Project> GetAll(string userId); 
        public Project GetById(int id);
        public Project Update(Project updatedProject);
        public int Commit();
    }
}
