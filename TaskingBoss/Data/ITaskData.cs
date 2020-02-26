using System.Collections.Generic;
using TaskingBoss.Core;

namespace TaskingBoss.Data
{
    public interface ITaskData
    {
        IEnumerable<TaskItem> GetByName(string name);
        TaskItem GetById(int id);
        List<TaskItem> GetTasks(int projectId);
        IEnumerable<TaskItem> GetTasks(TaskStatus status, int projectId);
        ProjectTaskItemViewModel GetProjectWithTasks(TaskStatus status, int projectId);
        TaskItem Update(TaskItem updatedTask);
        TaskItem Add(TaskItem newTask, int projectId);
        TaskItem Delete(int id);
        int GetCountOfTasks(int projectId);
        int Commit();
    }
}
