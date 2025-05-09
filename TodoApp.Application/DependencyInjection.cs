using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain;
using TodoApp.Domain.Repositories.Interfaces;
using TodoApp.Domain.Repositories.Implementation;
using TodoApp.Application.Services.Interfaces;
using TodoApp.Application.Services.Implementation;
using TodoApp.Application.Factories.Interfaces;
using TodoApp.Application.Factories.Implementation;


namespace TodoApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTodoAppDbContext(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<TodoAppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("cs")));
            return service;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<ITodoRepository, TodoRepository>();
            return service;
        }
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            service.AddScoped<ITodoService, TodoService>();
            service.AddScoped<ITodoFactory, TodoFactory>();
            return service;
        }

    }
}
