using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.DTOs;
using TodoApp.Application.Factories.Interfaces;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Shared;

namespace TodoApp.Application.Factories.Implementation
{
    public class TodoFactory : ITodoFactory
    {
        public Todo CreateTodo(TodoDTO model)
        {
            return new Todo
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Description,
                Status = model.Status.HasValue ? model.Status.Value : Status.Pending,
                Priority = model.Priority,
                DueDate = model.DueDate,
            };
        }
        public void UpdateTodo(TodoDTO model, Todo todo)
        {
            todo.Title = model.Title;
            todo.Description = model.Description;
            todo.Status = model.Status.HasValue? model.Status.Value : todo.Status;
            todo.Priority = model.Priority;
            todo.DueDate = model.DueDate;
            todo.LastModifiedDate = DateTime.UtcNow;
        }
        public TodoDTO CreateTodoDTO(Todo todo)
        {
            return new TodoDTO
            {
                Id= todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                Status = todo.Status,
                Priority = todo.Priority,
                DueDate = todo.DueDate,
                CreatedDate = todo.CreatedDate,
                LastModifiedDate = todo.LastModifiedDate
            };
        }

    }
}
