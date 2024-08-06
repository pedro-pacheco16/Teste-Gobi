using Gobi.Test.Jr.Domain.DTO;

namespace Gobi.Test.Jr.Domain.Interfaces
{
    public interface ITodoItemRepository
    {
        Task<IEnumerable<TodoItem>> GetAll();

		Task<TodoItem?> GetById(int id);

		Task<bool> CreateItem(TodoItemDTO todoItem);

        Task<bool> UpdateItem(TodoItemDTO todoItem,int id);

        Task<bool> DeleteItem(int id);
    }
}
