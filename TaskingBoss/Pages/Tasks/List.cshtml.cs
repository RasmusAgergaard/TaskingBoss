using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskingBoss.Data;
using TaskingBoss.Core;

namespace TaskingBoss.Pages.Tasks
{
    public class ListModel : PageModel
    {
        private readonly ITaskData _taskData;

        public IEnumerable<TaskItem> Tasks { get; set; }

        public ListModel(ITaskData taskData)
        {
            _taskData = taskData;
        }

        public void OnGet()
        {
            Tasks = _taskData.GetAll();
        }
    }
}
