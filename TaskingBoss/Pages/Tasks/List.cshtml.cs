using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskingBoss.Data;
using TaskingBoss.Core;
using Microsoft.AspNetCore.Mvc;

namespace TaskingBoss.Pages.Tasks
{
    public class ListModel : PageModel
    {
        private readonly ITaskData _taskData;

        public IEnumerable<TaskItem> Tasks { get; set; }

        [BindProperty(SupportsGet = true)] //When the user search, the propperty gets populated (Also on Get requests)
        public string SearchTerm { get; set; }

        public ListModel(ITaskData taskData)
        {
            _taskData = taskData;
        }

        public void OnGet()
        {
            Tasks = _taskData.GetTaskByName(SearchTerm);
        }
    }
}
