using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Shared;

namespace TodoApp.Application.DTOs
{
    public class TodoListRequestDTO
    {
        public int? page { get; set; }
        public int? pageSize { get; set; }
        public Status? Status { get; set; }
        public string? orderBy { get; set; }
    }
}
