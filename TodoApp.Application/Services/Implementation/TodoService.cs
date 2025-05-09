using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.DTOs;
using TodoApp.Application.Factories.Interfaces;
using TodoApp.Application.Services.Interfaces;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Repositories.Interfaces;
using TodoApp.Domain.Shared;

namespace TodoApp.Application.Services.Implementation
{
    public class TodoService : ITodoService
    {
        public ITodoRepository TodoRepository;
        public ITodoFactory TodoFactory;
        public TodoService(ITodoRepository todoRepository, ITodoFactory todoFactory)
        {
            TodoRepository = todoRepository;
            TodoFactory = todoFactory;
        }
        public async Task<ServiceResult<Guid>> AddTodo(TodoDTO model)
        {
            var todo = TodoFactory.CreateTodo(model);
            await TodoRepository.Create(todo);
            await TodoRepository.SaveChangesAsync();
            return new ServiceResult<Guid>
            {
                Model = todo.Id,
                IsValid = true
            };
        }

        public async Task<ServiceResult<TodoDTO>> UpdateTodo(TodoDTO model)
        {
            if (!model.Id.HasValue)
                return new ServiceResult<TodoDTO>
                {
                    IsValid = false,
                    ErrorMessage = "Id is requred to be passed for updating todo"
                };

            var todo = await TodoRepository.GetTodoById(model.Id.Value);
            if (todo == null)
                return new ServiceResult<TodoDTO>
                {
                    IsValid = false,
                    ErrorMessage = "todo id is not exists in the db"
                };

            TodoFactory.UpdateTodo(model, todo);
            await TodoRepository.SaveChangesAsync();

            return new ServiceResult<TodoDTO>
            {
                IsValid = true,
                Model = model
            };
        }

        public async Task<ServiceResult<bool>> RemoveTodo(Guid todoId)
        {
            await  TodoRepository.Delete(todoId);
            await TodoRepository.SaveChangesAsync();
            return new ServiceResult<bool>
            {
                IsValid = true,
                Model = true
            };
        }

        public async Task<ServiceResult<TodoDTO>> GetTodo(Guid todoId)
        {
            var todo  = await TodoRepository.GetTodoById(todoId);
            if (todo == null)
                return new ServiceResult<TodoDTO>
                {
                    IsValid = false,
                    ErrorMessage = "id of the todo is not exists in the database"
                };
            var model = TodoFactory.CreateTodoDTO(todo);
            return new ServiceResult<TodoDTO>
            {
                IsValid = true,
                Model = model
            };
        }

        public async Task<ServiceResultList<TodoDTO>> GetTodoList(TodoListRequestDTO model)
        {
            var result = await TodoRepository.GetAllTodos(model.page.Value, model.pageSize.Value, model.Status, model.orderBy);
            
            var modelList = result.List.Select(x => TodoFactory.CreateTodoDTO(x)).ToList();

            return new ServiceResultList<TodoDTO>
            {
                IsValid = true,
                list = modelList,
                TotalPages = (result.TotalCount / (model.pageSize.HasValue ? model.pageSize.Value : 5)) + 1
            };
        }
    }
}
