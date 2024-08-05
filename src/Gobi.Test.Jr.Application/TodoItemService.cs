using Gobi.Test.Jr.Domain;
using Gobi.Test.Jr.Domain.DTO;
using Gobi.Test.Jr.Domain.Interfaces;

namespace Gobi.Test.Jr.Application
{
    public class TodoItemService
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public TodoItemService(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _todoItemRepository.GetAll();
        }

        public async Task<bool> CreateItem (TodoItemDTO item)
        {
            if (item.Description == null) 
            {
                return false;
            }
            bool created = await _todoItemRepository.CreateItem(item);
            return created;

        }

        public async Task<bool> UpdateItem (TodoItemDTO item, int id)
        {

            if (item == null || item.Description == null)
            {
                return false;
            }
            bool itemUpdate =  await _todoItemRepository.UpdateItem(item, id);
            return itemUpdate;

        }

        public async Task<bool> DeleteItem (int id)
        {
            if (id <= 0)
            {
                return false;
            }
            bool DeleteItem = await _todoItemRepository.DeleteItem(id);
            return DeleteItem;
        }
    }
}