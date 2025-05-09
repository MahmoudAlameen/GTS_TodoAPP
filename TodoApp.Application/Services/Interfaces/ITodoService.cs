using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.DTOs;

namespace TodoApp.Application.Services.Interfaces
{
    public interface ITodoService
    {
        public Task<ServiceResult<Guid>> AddTodo(TodoDTO model);
        public Task<ServiceResult<TodoDTO>> UpdateTodo(TodoDTO model);
        public Task<ServiceResult<bool>> RemoveTodo(Guid todoId);
        public Task<ServiceResult<TodoDTO>> GetTodo(Guid todoId);
        public Task<ServiceResultList<TodoDTO>> GetTodoList(TodoListRequestDTO model);
    }
}
