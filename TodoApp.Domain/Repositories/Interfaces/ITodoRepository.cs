using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.CustomEntities;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Shared;

namespace TodoApp.Domain.Repositories.Interfaces
{
    public interface ITodoRepository : IRepository
    {
        public Task Create(Todo todo);
        public Task Update(Todo todo);
        public Task Delete(Guid todoId);
        public Task<Todo> GetTodoById(Guid todoId);
        public Task<TodoListData> GetAllTodos(int page, int pageSize, Status? status, string? orderBy);
    }
}
