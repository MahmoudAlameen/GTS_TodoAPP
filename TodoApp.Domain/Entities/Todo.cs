using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Shared;

namespace TodoApp.Domain.Entities
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }   
        public string? Description { get; set; } 
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
