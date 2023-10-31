using Microsoft.AspNetCore.Mvc;
using TodoItem.Service;

namespace TodoItem.WebAPI.Controllers
{
    using System.Threading.Tasks;
    using TodoItem.Shared.Model;
    public class TodoItemController : Controller
    {
        ITodoItemService _todoItemService = null;
       public TodoItemController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpGet("TodoItemList")]
        public Task<List<TodoItem>> GetAll()
        {
           return _todoItemService.GetAll();
        }

        [HttpPost("CreateTodo")]
        public TodoItem CreateTodoItem(TodoItem item)
        {
            if(_todoItemService == null)
            {
                throw new Exception("DI Failed");
            }
            return _todoItemService.Create(item);
        }

        [HttpPut("UpdateTodoIte")]
        public TodoItem UpdateTodoItem(TodoItem item)
        {
            if(item == null) {
                throw new Exception();
            }

            return _todoItemService.Update(item);
        }

        [HttpGet("GetTodoById")]
        public TodoItem GetTodoItem(int id) { 
            if (id <0 ) { throw new Exception(); }
            return _todoItemService.GetById(id);
        
        }

        [HttpDelete("DeleteTodo")]
        public bool Delete(int id)
        {
            if (id < 0) { throw new Exception(); }
            return _todoItemService.Delete(id);
        }
    }
}
