using System.Collections.Generic;
using TaskingBoss.Core;
using TaskingBoss.Core.ViewModels;

namespace TaskingBoss.Data
{
    public interface ITaskData
    {
        IEnumerable<TaskItem> GetByName(string name);
        TaskItem GetById(int id);
        List<TaskItem> GetTasks(int projectId);
        IEnumerable<TaskItemUsersViewModel> GetTasks(TaskStatus status, int projectId);
        IEnumerable<TaskItemUsersViewModel> GetTasks(TaskStatus status, int projectId, string userId);
        ProjectTaskItemViewModel GetProjectWithTasks(TaskStatus status, int projectId);
        TaskItem Update(TaskItem updatedTask);
        TaskItem Add(TaskItem newTask, int projectId);
        TaskItem Delete(int id);
        void AddActivity(TaskItem task, string activity);
        int GetCountOfTasks(int projectId);
        int Commit();
    }
}
