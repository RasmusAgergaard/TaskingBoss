using System.Collections.Generic;
using TaskingBoss.Core;

namespace TaskingBoss.Data
{
    public interface ITaskData
    {
        IEnumerable<TaskItem> GetAll();
    }

    public class InMemoryTaskData : ITaskData
    {
        private List<TaskItem> _tasks;

        public InMemoryTaskData()
        {
            _tasks = new List<TaskItem>()
            {
                new TaskItem{TaskId = 1, Title = "Taks 1", Status = TaskStatus.Backlog, Description = "This is the description", Priority = TaskPriority.Normal, StoryPoints = 40},
                new TaskItem{TaskId = 2, Title = "Taks 2", Status = TaskStatus.Backlog, Description = "This is the description", Priority = TaskPriority.Normal, StoryPoints = 40},
                new TaskItem{TaskId = 3, Title = "Taks 3", Status = TaskStatus.Backlog, Description = "This is the description", Priority = TaskPriority.Normal, StoryPoints = 40},
                new TaskItem{TaskId = 4, Title = "Taks 4", Status = TaskStatus.Backlog, Description = "This is the description", Priority = TaskPriority.Normal, StoryPoints = 40}
            };
        }

        public IEnumerable<TaskItem> GetAll()
        {
            return _tasks;
        }
    }
}
