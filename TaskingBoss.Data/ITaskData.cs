using System.Collections.Generic;
using System.Linq;
using TaskingBoss.Core;

namespace TaskingBoss.Data
{
    public interface ITaskData
    {
        IEnumerable<TaskItem> GetTaskByName(string name);
        TaskItem GetById(int id);
    }

    public class InMemoryTaskData : ITaskData
    {
        private List<TaskItem> _tasks;

        public InMemoryTaskData()
        {
            _tasks = new List<TaskItem>()
            {
                new TaskItem{TaskId = 1, Title = "Make something great again", Status = TaskStatus.Backlog, Description = "This is the description", Priority = TaskPriority.Normal, StoryPoints = 40},
                new TaskItem{TaskId = 2, Title = "This is a task", Status = TaskStatus.Backlog, Description = "This is the description", Priority = TaskPriority.Normal, StoryPoints = 40},
                new TaskItem{TaskId = 3, Title = "Remember to check that thing", Status = TaskStatus.Backlog, Description = "This is the description", Priority = TaskPriority.Normal, StoryPoints = 40},
                new TaskItem{TaskId = 4, Title = "Don't forget... the.... erhhh...", Status = TaskStatus.Backlog, Description = "This is the description", Priority = TaskPriority.Normal, StoryPoints = 40}
            };
        }

        public TaskItem GetById(int id)
        {
            return _tasks.SingleOrDefault(t => t.TaskId == id);
        }

        public IEnumerable<TaskItem> GetTaskByName(string name = null) //Defaults to null, so the method can be used without a parameter
        {
            return from t in _tasks
                   where string.IsNullOrEmpty(name) || t.Title.StartsWith(name)
                   orderby t.Title
                   select t;
        }
    }
}
