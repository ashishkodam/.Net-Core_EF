using TodoItem.Repository;

namespace TodoItem.Service
{
    using TodoItem.Shared.Model;
    public class TodoItemService : ITodoItemService
    {
        ITodoItemRepository _todoItemRepository = null;
        public TodoItemService(ITodoItemRepository todoItemRepository) {

            _todoItemRepository = todoItemRepository;
        }

        public async Task<List<TodoItem>> GetAll()
        {
            var result = await _todoItemRepository.GetAll().ConfigureAwait(false);
            return result;
        }

        public TodoItem Create(TodoItem todoItem)
        {
            if (todoItem == null)
                throw new ArgumentNullException();

//            todoItem.IsComplete = (todoItem.Id > 0) ? true : false;

           var res = _todoItemRepository.Create(todoItem);
            return res;


        }

        public TodoItem GetById(int id)
        {
            return _todoItemRepository.Get(id);
        }

        public TodoItem Update(TodoItem todoItem)
        {
            return _todoItemRepository.Update(todoItem);
        }

        public bool Delete(int id)
        {
            return _todoItemRepository.Delete(id);
        }
    }
}