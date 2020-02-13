using System.Collections.Generic;
using TaskingBoss.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TaskingBoss.Data
{
    public class SqlTaskData : ITaskData
    {
        private readonly TaskingBossDbContext _db;

        public SqlTaskData(TaskingBossDbContext db)
        {
            _db = db;
        }

        public TaskItem Add(TaskItem newTask)
        {
            _db.Tasks.Add(newTask);
            return newTask;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public TaskItem Delete(int id)
        {
            var task = GetById(id);

            if (task != null)
            {
                _db.Tasks.Remove(task);
            }

            return task;
        }

        public TaskItem GetById(int id)
        {
            return _db.Tasks.Find(id);
        }

        public int GetCountOfTasks()
        {
            return _db.Tasks.Count();
        }

        public IEnumerable<TaskItem> GetTaskByName(string name)
        {
            var query = from t in _db.Tasks
                        where string.IsNullOrEmpty(name) || t.Title.StartsWith(name)
                        orderby t.Title
                        select t;

            return query;
        }

        public List<TaskItem> GetTasks()
        {
            return _db.Tasks.ToList();
        }

        public TaskItem Update(TaskItem updatedTask)
        {
            //Attach the updated item to the db, so it monitors the changes. Then tell ef that the states is modified. This updates the item in the db
            var entity = _db.Tasks.Attach(updatedTask);
            entity.State = EntityState.Modified;

            return updatedTask;
        }
    }
}
