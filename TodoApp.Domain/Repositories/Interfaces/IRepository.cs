﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Domain.Repositories.Interfaces
{
    public interface IRepository
    {
        public Task SaveChangesAsync();
    }
}
