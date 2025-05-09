using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Application.DTOs
{
    public class UpdateTodoDTO : TodoDTO
    {
        public Guid Id { get; set; }
    }
}
