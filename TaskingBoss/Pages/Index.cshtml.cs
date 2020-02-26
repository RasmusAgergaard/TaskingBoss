using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TaskingBoss.Data;

namespace TaskingBoss.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;


        public IndexModel(ILogger<IndexModel> logger, IProjectData projectData, ITaskData taskData)
        {
            _logger = logger;

        }

        public void OnGet(int projectId)
        {

        }
    }
}
