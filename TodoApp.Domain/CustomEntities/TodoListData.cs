using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.CustomEntities
{
    public class TodoListData
    {
        public List<Todo> List { get; set; }
        public int TotalCount { get; set; }
    }


}
