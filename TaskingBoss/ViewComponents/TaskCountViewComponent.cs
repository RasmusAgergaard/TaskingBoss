using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskingBoss.Data;

namespace TaskingBoss.ViewComponents
{
    public class TaskCountViewComponent : ViewComponent
    {
        private readonly ITaskData _taskData;

        public TaskCountViewComponent(ITaskData taskData)
        {
            _taskData = taskData;
        }

        public IViewComponentResult Invoke() 
        {
            var count = _taskData.GetCountOfTasks();
            return View(count);
        }
    }
}
