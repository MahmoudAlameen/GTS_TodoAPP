using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Repositories.Interfaces;

namespace TodoApp.Domain.Repositories
{
    public class Repository : IRepository
    {
        public TodoAppDbContext TodoAppDbContext { get; set; }
        public Repository(TodoAppDbContext todoAppDbContext)
        {
            TodoAppDbContext = todoAppDbContext;
        }

        public async Task SaveChangesAsync()
        {
            await TodoAppDbContext.SaveChangesAsync();
        }
    }
}
