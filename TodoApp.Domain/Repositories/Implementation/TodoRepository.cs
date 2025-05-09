using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.CustomEntities;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Repositories.Interfaces;
using TodoApp.Domain.Shared;

namespace TodoApp.Domain.Repositories.Implementation
{
    public class TodoRepository : Repository, ITodoRepository
    {
        TodoAppDbContext TodoAppDbContext;
        public TodoRepository(TodoAppDbContext todoAppDbContext): base(todoAppDbContext)
        {
            TodoAppDbContext = todoAppDbContext;
        }
        public async Task Create(Todo todo)
        {
            await TodoAppDbContext.Todos.AddAsync(todo);
        }

        public async Task Delete(Guid todoId)
        {
            TodoAppDbContext.Remove(new Todo { Id = todoId});
        }

        public async Task<Todo> GetTodoById(Guid todoId)
        {
            return await TodoAppDbContext.Todos.FirstOrDefaultAsync(x => x.Id == todoId);
        }
        public async Task Update(Todo todo)
        {
            TodoAppDbContext.Todos.Update(todo);
        }
        public async Task<TodoListData> GetAllTodos(int page, int pageSize, Status? status, string? orderBy)
        {
            var query = TodoAppDbContext.Todos
                .AsNoTracking()
                .Where(x => status == null || x.Status == status);
            var totalCount = await query.CountAsync();

            // ordering 
            query = !string.IsNullOrEmpty(orderBy) && new Todo().HasProperty(orderBy) ? query.OrderBy(orderBy.ToLambda<Todo>()) : query;

            // pagination
            var resultList =  await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return new TodoListData
            {
                List = resultList,
                TotalCount = totalCount
            };
        }
    }
}
