using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.DTOs;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Factories.Interfaces
{
    public interface ITodoFactory
    {
        public Todo CreateTodo(TodoDTO model);
        void UpdateTodo(TodoDTO model, Todo todo);
        public TodoDTO CreateTodoDTO(Todo todo);

    }
}
