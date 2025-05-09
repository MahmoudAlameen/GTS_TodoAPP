using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.DTOs;
using TodoApp.Application.Services.Interfaces;
using TodoApp.Domain.Shared;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Packaging;
namespace TodoApp.MVC.Controllers
{
    public class TodoController : Controller
    {

        public ITodoService TodoService;
        public TodoController(ITodoService todoService)
        {
            TodoService = todoService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("GetTodoList", new TodoListRequestDTO());
        }
        public async Task<IActionResult> GetTodoList(TodoListRequestDTO model)
        {
            // Set default pagination values
            model.page ??= 1;
            model.pageSize ??= 5;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await TodoService.GetTodoList(model);

            if (!result.IsValid)
            {
                return BadRequest(result);
            }

            ViewData["TodoStatuses"] = GetStatusSelectList();

            // Pass pagination info to the view
            ViewData["CurrentPage"] = model.page.Value;
            ViewData["TotalPages"] = result.TotalPages;
            ViewData["StatusFilter"] = model.Status;

            return View("TodoList", result.list);
        }

        public async Task<IActionResult> GetTodoDetails(Guid todoId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await TodoService.GetTodo(todoId);
            if (!result.IsValid)
            {
                return BadRequest(result);

            }
            return View("TodoDetails", result.Model);
        }
        public async Task<IActionResult> AddTodo(TodoDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await TodoService.AddTodo(model);
            if (!result.IsValid)
            {
                return BadRequest(result);

            }
            return RedirectToAction("GetTodoList", new TodoListRequestDTO());
        }
        public async Task<IActionResult> UpdateTodo(TodoDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await TodoService.UpdateTodo(model);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }
            return RedirectToAction("GetTodoDetails", new { todoId = result.Model.Id });
        }

        public async Task<IActionResult> DeleteTodo(Guid todoId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await TodoService.RemoveTodo(todoId);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }
            return RedirectToAction("GetTodoList",new TodoListRequestDTO());
        }

        public async Task<IActionResult> CreateTodoView()
        {
            var todoStatuses = Enum.GetValues(typeof(Status)).Cast<Status>().Select(x => new SelectListItem
            {
                Value = ((int)x).ToString(),
                Text = x.ToString()
            }).ToList();
            var todoPriorities = Enum.GetValues(typeof(Priority)).Cast<Priority>().Select(x => new SelectListItem
            {
                Value = ((int)x).ToString(),  
                Text = x.ToString()
            }).ToList();

            ViewData.Add("TodoStatuses", todoStatuses);
            ViewData.Add("TodoPriorities", todoPriorities);

            return View("CreateTodo");

        }

        public async Task<IActionResult> UpdateTodoView(Guid todoId)
        {
            var result = await TodoService.GetTodo(todoId);
            if (!result.IsValid)
            {

                return BadRequest(result.ErrorMessage);
            }

            ViewData.Add("TodoStatuses", GetStatusSelectList());
            ViewData.Add("TodoPriorities", GetPrioritiesSelectList());

            return View("EditTodo", result.Model);

        }
        private List<SelectListItem> GetStatusSelectList()
        {
            return Enum.GetValues(typeof(Status))
                .Cast<Status>()
                .Select(status => new SelectListItem
                {
                    Value = ((int)status).ToString(),
                    Text = status.ToString()
                })
                .ToList();
        }
        private List<SelectListItem> GetPrioritiesSelectList()
        {
            return Enum.GetValues(typeof(Status))
                .Cast<Priority>()
                .Select(status => new SelectListItem
                {
                    Value = ((int)status).ToString(),
                    Text = status.ToString()
                })
                .ToList();
        }

    }
}
