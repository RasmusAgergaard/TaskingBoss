using System.Collections.Generic;
using System.Linq;
using TaskingBoss.Core;

namespace TaskingBoss.Data
{
    public interface ITaskData
    {
        IEnumerable<TaskItem> GetTaskByName(string name);
        TaskItem GetById(int id);
        TaskItem Update(TaskItem updatedTask);
        TaskItem Add(TaskItem newTask);
        int Commit();
    }

    public class InMemoryTaskData : ITaskData
    {
        private List<TaskItem> _tasks;

        public InMemoryTaskData()
        {
            _tasks = new List<TaskItem>()
            {
                new TaskItem{Id = 1, Title = "Make something great again", Status = TaskStatus.Backlog, Description = "This is the description"},
                new TaskItem{Id = 2, Title = "This is a task", Status = TaskStatus.Backlog, Description = "This is the description"},
                new TaskItem{Id = 3, Title = "Remember to check that thing", Status = TaskStatus.Backlog, Description = "This is the description"},
                new TaskItem{Id = 4, Title = "Don't forget... the.... erhhh...", Status = TaskStatus.Backlog, Description = "This is the description"}
            };
        }

        public TaskItem Add(TaskItem newTask)
        {
            _tasks.Add(newTask);
            newTask.Id = _tasks.Max(t => t.Id) + 1;

            return newTask;
        }

        public int Commit()
        {
            return 0;
        }

        public TaskItem GetById(int id)
        {
            return _tasks.SingleOrDefault(t => t.Id == id);
        }

        public IEnumerable<TaskItem> GetTaskByName(string name = null) //Defaults to null, so the method can be used without a parameter
        {
            return from t in _tasks
                   where string.IsNullOrEmpty(name) || t.Title.StartsWith(name)
                   orderby t.Title
                   select t;
        }

        public TaskItem Update(TaskItem updatedTask)
        {
            var task = _tasks.SingleOrDefault(t => t.Id == updatedTask.Id);

            if (task != null)
            {
                task.Title = updatedTask.Title;
                task.Description = updatedTask.Description;
                task.Status = updatedTask.Status;
            }

            return task;
        }
    }
}
