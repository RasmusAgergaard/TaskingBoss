using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskingBoss.Models
{
    public class Enums
    {
        public enum TaskStatus
        {
            Backlog,
            Sprint,
            Doing,
            Blocked,
            QA,
            Done
        }

        public enum TaskPriority
        {
            Low,
            Normal,
            Heigh
        }
    }
}