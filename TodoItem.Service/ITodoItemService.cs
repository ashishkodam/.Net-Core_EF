using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoItem.Service
{
    using TodoItem.Shared.Model;
    public interface ITodoItemService
    {
        Task<List<TodoItem>> GetAll();
        TodoItem Create(TodoItem todoItem);
        TodoItem GetById(int id);
        TodoItem Update(TodoItem todoItem);
        bool Delete(int id);
    }
}
