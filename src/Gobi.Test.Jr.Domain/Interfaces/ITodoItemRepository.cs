using Gobi.Test.Jr.Domain.DTO;

namespace Gobi.Test.Jr.Domain.Interfaces
{
    public interface ITodoItemRepository
    {
        IEnumerable<TodoItem> GetAll();

        Task<bool> CreateItem(TodoItemDTO todoItem);

        Task<bool> UpdateItem(TodoItemDTO todoItem,int id);

        Task<bool> DeleteItem(int id);
    }
}
