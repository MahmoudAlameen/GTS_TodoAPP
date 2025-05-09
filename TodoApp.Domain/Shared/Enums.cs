using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Domain.Shared
{
    public enum Status
    {
        Pending = 1,
        Progress = 2,
        Completed = 3
    }
    public enum Priority
    {
        Low = 1,
        Medium = 2,
        High = 3
    }
}
