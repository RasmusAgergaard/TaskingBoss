﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TaskingBoss.Core;
using TaskStatus = TaskingBoss.Core.TaskStatus;

namespace TaskingBoss.Data
{
    public class SqlTaskData : ITaskData
    {
        private readonly TaskingBossDbContext _db;

        public SqlTaskData(TaskingBossDbContext db)
        {
            _db = db;
        }

        public TaskItem Add(TaskItem newTask, int projectId)
        {
            _db.Tasks.Add(newTask);
            _db.ProjectTaskItems.Add(new ProjectTaskItems { ProjectId = projectId, TaskItem = newTask });
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

        public IEnumerable<TaskItem> GetByName(string name)
        {
            var query = from t in _db.Tasks
                        where string.IsNullOrEmpty(name) || t.Title.StartsWith(name)
                        orderby t.Title
                        select t;

            return query;
        }

        public int GetCountOfTasks(int projectId)
        {
            int count = 0;

            foreach (var item in _db.ProjectTaskItems)
            {
                if (item.ProjectId == projectId)
                {
                    count++;
                }
            }

            return count;
        }

        public ProjectTaskItemViewModel GetProjectWithTasks(TaskStatus status, int projectId)
        {
            var tasks = GetTasks(projectId);
            var foundTasks = new ProjectTaskItemViewModel();
            foundTasks.Project = _db.Projects.Find(projectId);

            switch (status)
            {
                case TaskStatus.Backlog:
                    var backlog = (from t in tasks
                                   where t.Status == TaskStatus.Backlog
                                   select t).OrderByDescending(t => t.Priority);
                    foundTasks.Tasks = backlog.ToList();
                    break;
                case TaskStatus.Sprint:
                    var sprint = (from t in tasks
                                  where t.Status == TaskStatus.Sprint
                                  select t).OrderByDescending(t => t.Priority);
                    foundTasks.Tasks = sprint.ToList();
                    break;
                case TaskStatus.Doing:
                    var doing = (from t in tasks
                                 where t.Status == TaskStatus.Doing
                                 select t).OrderByDescending(t => t.Priority);
                    foundTasks.Tasks = doing.ToList();
                    break;
                case TaskStatus.Blocked:
                    var blocked = (from t in tasks
                                   where t.Status == TaskStatus.Blocked
                                   select t).OrderByDescending(t => t.Priority);
                    foundTasks.Tasks = blocked.ToList();
                    break;
                case TaskStatus.QA:
                    var qa = (from t in tasks
                              where t.Status == TaskStatus.QA
                              select t).OrderByDescending(t => t.Priority); ;
                    foundTasks.Tasks = qa.ToList();
                    break;
                case TaskStatus.Done:
                    var done = (from t in tasks
                                where t.Status == TaskStatus.Done
                                select t).OrderByDescending(t => t.Priority);
                    foundTasks.Tasks = done.ToList();
                    break;
                default:
                    break;
            }

            return foundTasks;
        }

        public List<TaskItem> GetTasks(int projectId)
        {
            var tasks = new List<TaskItem>();

            foreach (var item in _db.ProjectTaskItems)
            {
                if (item.ProjectId == projectId)
                {
                    var task = GetById(item.TaskItemId);
                    tasks.Add(task);
                }
            }

            return tasks;
        }

        public IEnumerable<TaskItem> GetTasks(TaskStatus status, int projectId)
        {
            var tasks = GetTasks(projectId);
            var foundTasks = new List<TaskItem>();

            switch (status)
            {
                case TaskStatus.Backlog:
                    var backlog = (from t in tasks
                                   where t.Status == TaskStatus.Backlog
                                   select t).OrderByDescending(t => t.Priority);
                    foundTasks = backlog.ToList();
                    break;
                case TaskStatus.Sprint:
                    var sprint = (from t in tasks
                                  where t.Status == TaskStatus.Sprint
                                  select t).OrderByDescending(t => t.Priority);
                    foundTasks = sprint.ToList();
                    break;
                case TaskStatus.Doing:
                    var doing = (from t in tasks
                                 where t.Status == TaskStatus.Doing
                                 select t).OrderByDescending(t => t.Priority);
                    foundTasks = doing.ToList();
                    break;
                case TaskStatus.Blocked:
                    var blocked = (from t in tasks
                                   where t.Status == TaskStatus.Blocked
                                   select t).OrderByDescending(t => t.Priority);
                    foundTasks = blocked.ToList();
                    break;
                case TaskStatus.QA:
                    var qa = (from t in tasks
                              where t.Status == TaskStatus.QA
                              select t).OrderByDescending(t => t.Priority); ;
                    foundTasks = qa.ToList();
                    break;
                case TaskStatus.Done:
                    var done = (from t in tasks
                                where t.Status == TaskStatus.Done
                                select t).OrderByDescending(t => t.Priority);
                    foundTasks = done.ToList();
                    break;
                default:
                    break;
            }

            //Set projectId route
            foreach (var task in foundTasks)
            {
                task.ProjectIdRoute = projectId;
            }

            return foundTasks;
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
