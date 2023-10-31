using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TodoItem.Repository
{
    using TodoItem.Shared.Model;

    public interface ITodoItemRepository
    {
        Task<List<TodoItem>> GetAll();
        TodoItem Get(int id);
        TodoItem Create(TodoItem todoItem);
        TodoItem Update(TodoItem todoItem);
        bool Delete(int id);
    }
}
