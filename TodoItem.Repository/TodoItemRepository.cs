using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoItem.Repository
{
    using TodoItem.Shared.Model;

    public class TodoItemRepository: ITodoItemRepository
    {

        private List<TodoItem> _todoItem = new List<TodoItem>();

        private readonly TodoItemContext _context;

        public TodoItemRepository(TodoItemContext context)
        {

            _context = context;

        }

        public TodoItem Create(TodoItem todoItem)
        {
            bool result = _context.TodoItems.Any(x => x.Id > 0);
            todoItem.Id = _context.TodoItems.Max(t => t.Id) + 1;
            var test = _context.TodoItems.Add(todoItem);
            var res = _context.SaveChangesAsync();
            return todoItem;


        }

        public TodoItem Get(int id)
        {
            return _context.TodoItems.FirstOrDefault(t => t.Id == id);

        }

        public async Task<List<TodoItem>> GetAll()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public TodoItem Update(TodoItem todoItem)
        {
            var existingTodoItem = _context.TodoItems.FirstOrDefault(t => t.Id == todoItem.Id);
            if (existingTodoItem != null)
            {
                existingTodoItem.Name = todoItem.Name;
                existingTodoItem.IsComplete = todoItem.IsComplete;
            }
            return existingTodoItem;

        }

        public bool Delete(int id)
        {
            var todoItemToRemove = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            if (todoItemToRemove != null)
            {
                _context.TodoItems.Remove(todoItemToRemove);
                return true;
            }
            return false;
        }

       
    }
}
